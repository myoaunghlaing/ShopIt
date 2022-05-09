import { EventEmitter, Injectable } from "@angular/core";
import { Item } from "./item.model";

@Injectable({
  providedIn: 'root'
})
export class ShoppingCartService {

  items: Item[] = [];
  countTotal: number = 0;
  cartUpdated = new EventEmitter<number>();
  
  constructor() { }

  addItem(item: Item) {
    let index = this.items.findIndex(elem => elem.id === item.id);
    if (index >= 0) {
      let elem = this.items[index];
      elem.count++;
    }
    else {
      this.items.push(item)
    }
    this.countTotal++;
    this.cartUpdated.emit(this.countTotal);       
  }

  removeItem(id: number) {
    let index = this.items.findIndex(item => item.id === id);
    if (index >= 0) {
      let item = this.items[index];
      if (item.count === 1) {
        this.items.splice(index, 1);
      }
      else {
        item.count--;
        this.countTotal--;
      }
    }
    this.cartUpdated.emit(this.countTotal);
  }

  getItems(): Item[] {
    let itemsCopy = this.items.map(x => Object.assign({}, x));
    return itemsCopy;    
  }

  updateCount(count: number, id: number) {
    let index = this.items.findIndex(elem => elem.id === id);
    if (index >= 0) {
      let item = this.items[index];
      let origCount = item.count;
      if (count === 0) {
        this.items.splice(index, 1);
        this.countTotal -= origCount;
      }
      else {
        if (count > origCount) {
          this.countTotal += count - origCount;
        }
        else {          
          this.countTotal -= origCount-count;
        }
        item.count = count;
      }
      this.cartUpdated.emit(this.countTotal);   
    }
  }
  
  clearCart() {
    this.items.splice(0, this.items.length);
    this.countTotal = 0;
    this.cartUpdated.emit(this.countTotal);  
  }
}
