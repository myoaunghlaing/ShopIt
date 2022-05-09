import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { catchError, map, Observable, retry, throwError } from "rxjs";
import { CountryRates } from "./countryrates.model";
import { Item } from "./item.model";
import { Order } from "./order.model";
import { ShippingCharges } from "./shippingcharges.model";

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  constructor(private http: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };

  getProducts(): Observable<Item[]> {
    return this.http
      .get<Item[]>('/Product/products')
      .pipe(retry(1), catchError(this.handleError));
  }

  getCountryRates(): Observable<CountryRates[]>{
    return this.http
      .get<CountryRates[]>('/CountryRate/countryrates')
      .pipe(retry(1), catchError(this.handleError));
  }

  getShippingCharges(): Observable<ShippingCharges[]> {
    return this.http
      .get<ShippingCharges[]>('/CountryRate/shippingcharges')
      .pipe(retry(1), catchError(this.handleError));
  }

  createOrder(order: any): Observable<number> {
    return this.http
      .post<number>('/Order/create',
        JSON.stringify(order),
        this.httpOptions
      )
      .pipe(retry(1), catchError(this.handleError));
  }

  handleError(error: any) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }    
    return throwError(() => {
      return errorMessage;
    });
  }
}
