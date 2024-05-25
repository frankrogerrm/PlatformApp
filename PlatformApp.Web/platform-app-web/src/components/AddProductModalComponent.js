import { useState } from "react";
import { Button, Form, Modal } from "react-bootstrap";
import { AddProduct } from "../api/APiCalls";

const AddProductModalComponent = ({
  showModal,
  hideModal,
  customer,
  renderProductList,
}) => {
  const [productName, setProductName] = useState("");
  const [productDescription, setProductDescription] = useState("");
  const [productPrice, setProductPrice] = useState("");

  const addProduct = () => {
    var product = {
      customerId: customer.customerId,
      productName: productName,
      productDescription: productDescription,
      productPrice: productPrice,
    };
    AddProduct(product).then((response) => {
      renderProductList(response.data.customer);
      cleanForm();
    });
  };

  const cleanForm = () => {
    setProductDescription("");
    setProductName("");
    setProductPrice("");
  };
  const handleProductName = (event) => {
    setProductName(event.target.value);
  };

  const handleProductDescription = (event) => {
    setProductDescription(event.target.value);
  };

  const handleProductPrice = (event) => {
    setProductPrice(event.target.value);
  };

  const cancelModal = () => {
    cleanForm();
    hideModal();
  };

  return (
    typeof customer !== "undefined" && (
      <Modal show={showModal} onHide={cancelModal}>
        <Modal.Header closeButton>
          <Modal.Title>Add Product</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <div>
            <Form.Group className="mb-3" controlId="exampleForm.ControlInput1">
              <Form.Label>Customer</Form.Label>
              <Form.Control
                type="text"
                disabled
                placeholder="Customer Name"
                value={`${customer.firstName} ${customer.lastName}`}
              />
            </Form.Group>
            <Form.Group className="mb-3" controlId="exampleForm.ControlInput1">
              <Form.Label>Product Name</Form.Label>
              <Form.Control
                type="text"
                onChange={handleProductName}
                value={productName}
                placeholder="Product Name"
              />
            </Form.Group>
            <Form.Group className="mb-3" controlId="exampleForm.ControlInput1">
              <Form.Label>Product Description</Form.Label>
              <Form.Control
                as="textarea"
                rows={3}
                onChange={handleProductDescription}
                value={productDescription}
                placeholder="ProProduct Description"
              />
            </Form.Group>
            <Form.Group className="mb-3" controlId="exampleForm.ControlInput1">
              <Form.Label>Product Price(USD) </Form.Label>
              <Form.Control
                type="number"
                value={productPrice}
                onChange={handleProductPrice}
                placeholder="Product Price"
              />
            </Form.Group>
          </div>
        </Modal.Body>
        <Modal.Footer>
          <Button variant="info" onClick={hideModal}>
            Cancel
          </Button>
          <Button variant="success" onClick={addProduct}>
            Save
          </Button>
        </Modal.Footer>
      </Modal>
    )
  );
};
export default AddProductModalComponent;
