import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ShoppingCartService } from '../cart.service';

@Component({
  selector: 'app-shoppingcart',
  templateUrl: './shoppingcart.component.html',
  styleUrls: ['./shoppingcart.component.css']
})
export class ShoppingcartComponent implements OnInit {

  public count: number = 0;

  constructor(private shoppingCartService: ShoppingCartService, private router: Router) { }

  ngOnInit(): void {
    this.shoppingCartService.cartUpdated.subscribe((data: number) => this.count = data);
  }

  onClick() {
    this.router.navigate(['/checkout']);
  }

}
