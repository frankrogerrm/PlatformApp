import logo from "./logo.svg";
import "./App.css";
import LeftMenuComponent from "./components/LeftMenuComponent";
import ProductListComponent from "./components/ProductListComponent";
import { useEffect, useRef, useState } from "react";
import CustomerInfoComponent from "./components/CustomerInfoComponent";
import AddProductModalComponent from "./components/AddProductModalComponent";
import { AddProduct } from "./api/APiCalls";

function App() {
  const [customer, setCustomer] = useState();
  const productListComponentRef = useRef();
  const customerInfoComponentRef = useRef();
  const [productListComponentVisible, setProductListComponentVisible] =
    useState(false);
  const [customerInfoComponentVisible, setCustomerInfoComponentVisible] =
    useState(true);

  useEffect(() => {
    customerInfoComponentRef.current.renderCustomerInfo(customer);
    productListComponentRef.current.renderProductList(customer);
  }, [customer]);

  const filterCustomerProducts = (customerPar) => {
    setCustomer(customerPar);
  };

  const showProductListComponent = () => {
    setProductListComponentVisible(true);
    setCustomerInfoComponentVisible(false);
  };

  const showCustomerInfoComponent = () => {
    setProductListComponentVisible(false);
    setCustomerInfoComponentVisible(true);
  };

  return (
    <div className="App">
      <div className="row">
        <div className="col-sm-2" style={{ marginTop: "60px" }}>
          <LeftMenuComponent
            showCustomerInfoComponent={showCustomerInfoComponent}
            showProductListComponent={showProductListComponent}
            filterCustomerProducts={filterCustomerProducts}></LeftMenuComponent>
        </div>
        <div className="col-sm-9">
          <div
            style={{
              display: productListComponentVisible ? "block" : "none",
            }}>
            <ProductListComponent
              ref={productListComponentRef}></ProductListComponent>
          </div>
          <div
            style={{
              display: customerInfoComponentVisible ? "block" : "none",
            }}>
            <CustomerInfoComponent
              ref={customerInfoComponentRef}></CustomerInfoComponent>
          </div>
        </div>
      </div>
      <link
        rel="stylesheet"
        href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"></link>
      {/* <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer">
          Learn React
        </a>
      </header> */}
    </div>
  );
}

export default App;
