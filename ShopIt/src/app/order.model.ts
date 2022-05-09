import { Item } from "./item.model";

export class Order {
  constructor(public orderItems: OrderItem[],   
    public name: string,
    public address: string,
    public country: string  ) {
  }
}

export class OrderItem {
  constructor(public productId: number, public count: number) { }
}
