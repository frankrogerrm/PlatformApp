import React from "react";
import { Modal, Button } from "react-bootstrap";

const RemoveConfirmationModalComponent = ({
  showModal,
  hideModal,
  removeProduct,
  productId,
}) => {
  return (
    <Modal show={showModal} onHide={hideModal}>
      <Modal.Header closeButton>
        <Modal.Title>Delete Product</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <div className="alert alert-danger">
          Are you sure to remove this Product
        </div>
      </Modal.Body>
      <Modal.Footer>
        <Button variant="success" onClick={hideModal}>
          Cancel
        </Button>
        <Button variant="danger" onClick={() => removeProduct(productId)}>
          Delete
        </Button>
      </Modal.Footer>
    </Modal>
  );
};

export default RemoveConfirmationModalComponent;
