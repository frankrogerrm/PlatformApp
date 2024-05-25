import React, { Component } from "react";
import { Button, Form, Nav } from "react-bootstrap";
import { GetAllCustomers } from "../api/APiCalls";

class LeftMenuComponent extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      customers: [],
      filterCustomerProducts: props.filterCustomerProducts,
      showCustomerInfoComponent: props.showCustomerInfoComponent,
      showProductListComponent: props.showProductListComponent,
    };
  }

  customerDropdownHandle = (e) => {
    var customer = this.state.customers.filter(
      (x) => x.customerId == e.target.value
    )[0];
    this.state.filterCustomerProducts(customer);
  };

  componentDidMount() {
    GetAllCustomers().then((response) => {
      var customers = response.data;
      this.setState({ customers });
      this.state.filterCustomerProducts(customers[0]);
    });
  }

  render() {
    return (
      <div style={{ padding: "40px" }}>
        <div>
          <Form.Select
            aria-label="Select Customer"
            onChange={this.customerDropdownHandle}>
            {this.state.customers.map((customer) => (
              <option key={customer.customerId} value={customer.customerId}>
                {customer.firstName} {customer.lastName}
              </option>
            ))}
          </Form.Select>
        </div>
        <br></br>
        <div style={{ textAlign: "left" }}>
          <Nav defaultActiveKey="/home" className="flex-column">
            <Nav.Link
              onClick={this.state.showCustomerInfoComponent}
              eventKey="customer-info-option">
              Customer Info
            </Nav.Link>
            <Nav.Link
              onClick={this.state.showProductListComponent}
              eventKey="product-list-option">
              Product Details
            </Nav.Link>
          </Nav>
        </div>
      </div>
    );
  }
}

export default LeftMenuComponent;
