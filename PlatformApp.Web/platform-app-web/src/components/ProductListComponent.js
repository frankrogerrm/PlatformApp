import { Component } from "react";
import {
  GetAllProducts,
  GetAllProductsByCustomer,
  RemoveProduct,
  updateProduct,
} from "../api/APiCalls";
import { DataGrid, GridRowEditStopReasons } from "@mui/x-data-grid";
import { Button } from "react-bootstrap";
import RemoveConfirmationModalComponent from "./RemoveConfirmationModalComponent";
import AddProductModalComponent from "./AddProductModalComponent";

class ProductListComponent extends Component {
  constructor(props) {
    super(props);
    this.state = {
      products: [],
      customer: {},
      displayConfirmationModal: false,
      productId: null,
      addProductModalComponentVisible: false,
      rowModesModel: {},
    };
  }

  addProductModalComponentHide = () => {
    const addProductModalComponentVisible = false;
    this.setState({ addProductModalComponentVisible });
  };

  addProductModalComponentShow = () => {
    const addProductModalComponentVisible = true;
    this.setState({ addProductModalComponentVisible });
  };

  removeProduct = (productId) => {
    this.setState({ displayConfirmationModal: false });
    RemoveProduct(productId).then((response) => {
      this.renderProductList();
    });
  };

  removeProductConfirmation = (productId) => {
    this.setState({ displayConfirmationModal: true });
    this.setState({ productId: productId });
  };

  removeProductConfirmationHide = () => {
    this.setState({ displayConfirmationModal: false });
  };

  columns = [
    {
      field: "productId",
      headerName: "Product Id",
      width: 150,
    },
    {
      field: "customerId",
      headerName: "Customer",
      width: 250,
      valueGetter: (params) =>
        `${params.row.customer.firstName || ""} ${
          params.row.customer.lastName || ""
        }`,
    },
    {
      field: "productName",
      headerName: "Product Name",
      width: 300,
      editable: true,
    },
    {
      field: "productDescription",
      headerName: "Product Description",
      width: 300,
      editable: true,
    },
    {
      field: "productPrice",
      headerName: "Product Price(USD)",
      width: 250,
      type: "number",
      editable: true,
      align: "left",
      headerAlign: "left",
    },
    {
      field: "Action",
      headerName: "",
      width: 100,
      renderCell: (params) => (
        <Button
          onClick={() => {
            this.removeProductConfirmation(params.row.productId);
          }}
          variant="danger">
          <i className="fa fa-trash-o"></i>
        </Button>
      ),
    },
  ];

  renderProductList = (customer) => {
    var customerId = null;
    if (typeof customer !== "undefined") {
      customerId = customer.customerId;
      this.setState({ customer });
    } else if (Object.keys(this.state.customer).length !== 0) {
      customerId = this.state.customer.customerId;
    }
    if (customerId !== null) {
      GetAllProductsByCustomer(customerId).then((response) => {
        var products = response.data;
        this.setState({ products });
        this.removeProductConfirmationHide();
        this.addProductModalComponentHide();
      });
    }
  };

  componentDidMount() {
    this.renderProductList();
  }

  handleRowEditStop = (params, event) => {
    if (params.reason === GridRowEditStopReasons.enterKeyDown) {
      event.defaultMuiPrevented = true;
    }
  };
  handleRowModesModelChange = (newRowModesModel) => {
    this.setState({ rowModesModel: newRowModesModel });
  };
  processRowUpdate = (newRow) => {
    const updatedRow = { ...newRow, isNew: false };
    var model = {
      productId: newRow.productId,
      productName: newRow.productName,
      productDescription: newRow.productDescription,
      productPrice: newRow.productPrice,
    };
    updateProduct(model).then((response) => {
      this.renderProductList();
    });
    return updatedRow;
  };

  onProcessRowUpdateError = (error) => {};

  render() {
    return (
      <div style={{ padding: "40px" }}>
        <div className="header" style={{ textAlign: "left" }}>
          <div className="row">
            <div className="col-sm-10">
              <h1>
                Product Details:{" "}
                {this.state.customer === null
                  ? " All"
                  : ` ${this.state.customer.firstName} ${this.state.customer.lastName}`}
              </h1>
            </div>

            <div className="col-sm-2" style={{ textAlign: "right" }}>
              <Button onClick={this.addProductModalComponentShow}>
                Add Product
              </Button>
            </div>
          </div>
        </div>
        <br></br>
        <div>
          <DataGrid
            editMode="row"
            getRowId={(row) => row.productId}
            rows={this.state.products}
            onRowEditStop={this.handleRowEditStop}
            onRowModesModelChange={this.handleRowModesModelChange}
            processRowUpdate={this.processRowUpdate}
            onProcessRowUpdateError={this.onProcessRowUpdateError}
            columns={this.columns}
            initialState={{
              pagination: {
                paginationModel: {
                  pageSize: 10,
                },
              },
            }}
            pageSizeOptions={[10]}
            disableRowSelectionOnClick></DataGrid>
        </div>
        <RemoveConfirmationModalComponent
          showModal={this.state.displayConfirmationModal}
          removeProduct={this.removeProduct}
          productId={this.state.productId}
          hideModal={
            this.removeProductConfirmationHide
          }></RemoveConfirmationModalComponent>
        <AddProductModalComponent
          customer={this.state.customer}
          renderProductList={this.renderProductList}
          showModal={this.state.addProductModalComponentVisible}
          hideModal={
            this.addProductModalComponentHide
          }></AddProductModalComponent>
      </div>
    );
  }
}

export default ProductListComponent;
