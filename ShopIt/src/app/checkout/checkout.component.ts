import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from '../api.service';
import { CalculatorService } from '../calculator.service';
import { ShoppingCartService } from '../cart.service';
import { CountryRates } from '../countryrates.model';
import { Item } from '../item.model';
import { Order, OrderItem } from '../order.model';
import { ShippingCharges } from '../shippingcharges.model';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {

  public items: Item[] = [];
  public totalCost: number = 0;
  public shippingCost: number = 0;
  public countryRates: CountryRates[] = [];
  public shippingCharges: ShippingCharges[] = [];

  public orderForm: FormGroup = new FormGroup({
    'name': new FormControl(null, Validators.required),
    'address': new FormControl(null, Validators.required),
    'country': new FormControl(null, Validators.required)
  });

  public currentCurrency:string = 'AUD';

  constructor(private http: HttpClient, private shoppingCartService: ShoppingCartService, private calculatorService: CalculatorService, private apiService: ApiService, private router: Router) {    
    this.apiService.getCountryRates().subscribe(result => {
      this.countryRates = result;
      //this.countryRates.forEach((rates) => { console.log(rates.countryName); });
    }, error => console.error(error));

    
  }

  ngOnInit(): void {
    this.items = this.shoppingCartService.getItems();
    this.apiService.getShippingCharges().subscribe(result => {
      this.shippingCharges = result;
      this.shippingCharges.forEach((charges) => {
        //console.log(charges.amount);
        this.calculate();
      });
    }, error => console.error(error));
    
    this.currentCurrency = this.calculatorService.getCurentCurrency();
  }

  updateCount(countInput: HTMLInputElement, id: number) {    
    this.shoppingCartService.updateCount(+countInput.value, id);
    this.items = this.shoppingCartService.getItems();
    this.calculate();
  }

  submit() {    
    let orderItems: OrderItem[] = [];
    this.items.forEach((item) => {
      let itm = new OrderItem(item.id, item.count);
      orderItems.push(itm);
    });
    let order = new Order(orderItems, this.orderForm.get('name')?.value, this.orderForm.get('address')?.value, this.orderForm.get('country')?.value);
    this.apiService.createOrder(order).subscribe((result) => {
      console.log('result=' + result);
      this.resetAll();
      this.router.navigate(['/confirmation']);
    }, error => console.error(error));
  }

  changeCountry(e: any) {    
    let newCurrency = e.target.value;
    if (newCurrency !== this.currentCurrency) {
      let exchangeRate: number = 0;
      this.countryRates.forEach((item) => {
        if (item.currency === newCurrency) {
          exchangeRate = item.exchangeRate;
          return;
        }
      });      
      this.calculatorService.updateCurrency(newCurrency, exchangeRate);
      this.calculate();
      this.currentCurrency = newCurrency;
    }
  }

  goHome() {
    this.router.navigate(['/home']);
  }

  calculate() {
    let costs: number[] = this.calculatorService.calculate(this.items, this.shippingCharges);
    this.totalCost = costs[0];
    this.shippingCost = costs[1];
  }

  resetAll() {
    this.items.splice(0, this.items.length);
    this.shoppingCartService.clearCart();
    this.currentCurrency = 'AUD';
    this.calculatorService.updateCurrency('AUD', 1);
  }
}
