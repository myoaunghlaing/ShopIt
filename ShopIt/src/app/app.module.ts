import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { ShoppingcartComponent } from './shoppingcart/shoppingcart.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { ConfirmationComponent } from './confirmation/confirmation.component';
import { CalculatorService } from './calculator.service';
import { ReactiveFormsModule } from '@angular/forms';
import { HeaderComponent } from './header/header.component';
import { ShoppingCartService } from './cart.service';
import { AppRoutingModule } from './app-routing.module';
import { HomeComponent } from './home/home.component';
import { ApiService } from './api.service';

@NgModule({
  declarations: [
    AppComponent,
    ShoppingcartComponent,
    CheckoutComponent,
    ConfirmationComponent,
    HeaderComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,    
    ReactiveFormsModule,
    AppRoutingModule
  ],
  providers: [CalculatorService, ShoppingCartService, ApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
