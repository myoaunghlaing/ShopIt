import { Component, OnInit } from '@angular/core';
import { Item } from '../item.model';
import { ShoppingCartService } from '../cart.service';
import { ApiService } from '../api.service';
import { CalculatorService } from '../calculator.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  public items: Item[] = [];

  constructor(private shoppingCartService: ShoppingCartService, private apiService: ApiService, private calculatorService: CalculatorService) { }

  ngOnInit(): void {    
    this.apiService.getProducts().subscribe(result => {
      this.items = result;
      this.items.forEach((product) => {
        product.imageUrl = '../assets/images/' + product.imageUrl;
        console.log(product.title);
      });      
      this.calculatorService.calculatePrice(this.items);
    }, error => console.error(error));
    
  }

  addToCart(id: number) {
    let item = this.items.find(i => i.id === id);    
    if (item !== undefined) {
      let itemCopy = {...item };
      itemCopy.count = 1;
      this.shoppingCartService.addItem(itemCopy);      
    }
  }

}
