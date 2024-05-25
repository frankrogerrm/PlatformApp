import { Component } from "react";

class CustomerInfoComponent extends Component {
  constructor(props) {
    super(props);
    this.state = {
      customer: {},
    };
  }

  renderCustomerInfo(customer) {
    if (typeof customer !== "undefined") {
      this.setState({ customer });
    }
  }

  componentDidMount() {
    this.renderCustomerInfo();
  }

  render() {
    return (
      <div style={{ padding: "40px" }}>
        <div className="header" style={{ textAlign: "left" }}>
          <h1>Customer Details</h1>
        </div>
        <br></br>
        <div className="row" style={{ padding: "20px" }}>
          <div className="col-sm-1" style={{ textAlign: "left" }}>
            First Name:{" "}
          </div>
          <div className="col-sm-1" style={{ textAlign: "left" }}>
            {this.state.customer.firstName}
          </div>
        </div>
        <div className="row" style={{ padding: "20px" }}>
          <div className="col-sm-1" style={{ textAlign: "left" }}>
            Last Name:{" "}
          </div>
          <div className="col-sm-1" style={{ textAlign: "left" }}>
            {this.state.customer.lastName}
          </div>
        </div>
        <div className="row" style={{ padding: "20px" }}>
          <div className="col-sm-1" style={{ textAlign: "left" }}>
            Address:{" "}
          </div>
          <div className="col-sm-11" style={{ textAlign: "left" }}>
            {this.state.customer.address}
          </div>
        </div>
      </div>
    );
  }
}

export default CustomerInfoComponent;
