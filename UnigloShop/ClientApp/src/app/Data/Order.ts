import { OrderItem } from "./OrderItem";

export interface Order {
  orderId: number;
  orderDate: Date;
  OrderNumber: string;
  items: OrderItem[];
}
