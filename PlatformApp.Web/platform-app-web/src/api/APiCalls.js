import axios from "axios";

const api = axios.create({
  baseURL: "https://platform-app-service-2024.azurewebsites.net",
});

export function GetAllCustomers() {
  return api.get("/api/Customer");
}

export function GetAllProducts() {
  return api.get("/api/Product");
}

export function GetAllProductsByCustomer(customerId) {
  return api.get(`/api/Product/Customer/${customerId}`);
}

export function RemoveProduct(productId) {
  return api.post(`/api/Product/Remove`, { ProductId: productId });
}

export function AddProduct(product) {
  return api.post(`/api/Product`, product);
}

export function updateProduct(product) {
  return api.post(`/api/Product/Update`, product);
}
