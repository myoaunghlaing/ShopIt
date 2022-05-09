import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { AppComponent } from "./app.component";
import { CheckoutComponent } from "./checkout/checkout.component";
import { ConfirmationComponent } from "./confirmation/confirmation.component";
import { HomeComponent } from "./home/home.component";

const appRoutes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'checkout', component: CheckoutComponent },
  { path: 'confirmation', component: ConfirmationComponent },
  { path: '**', component: HomeComponent }
]

@NgModule({
  imports: [
    RouterModule.forRoot(appRoutes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {
  
}
