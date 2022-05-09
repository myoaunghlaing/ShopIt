import { Injectable } from "@angular/core";
import { Item } from "./item.model";
import { ShippingCharges } from "./shippingcharges.model";

@Injectable({
  providedIn: 'root'
})
export class CalculatorService {

  curRate: [string, number] = ['AUD', 1]

  calculate(items: Item[], shippingCharges: ShippingCharges[]) {
    let totalCost = 0;
    items.forEach((item) => {
      if (item.currencyCurrent !== this.curRate[0]) {
        item.sellPrice = item.priceOriginal * this.curRate[1];
        item.currencyCurrent = this.curRate[0];
      }
      totalCost += item.count * item.sellPrice;
    });
    let shippingCost = 0;
    shippingCharges.forEach((item) => {
      if (totalCost >= item.threshold) {
        shippingCost = item.amount;
      }
    });
    totalCost += shippingCost;
    return [ totalCost, shippingCost ];
  }

  calculatePrice(items: Item[]) {
    items.forEach((item) => {
      if (item.currencyCurrent !== this.curRate[0]) {
        item.sellPrice = item.priceOriginal * this.curRate[1];
        item.currencyCurrent = this.curRate[0];
      }
    });
  }

  updateCurrency(currency: string, exchangeRate: number) {    
    this.curRate = [currency, exchangeRate];
  }

  getCurentCurrency() {
    return this.curRate[0];
  }
}
