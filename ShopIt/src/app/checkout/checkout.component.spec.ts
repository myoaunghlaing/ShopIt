import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { CheckoutComponent } from './checkout.component';
import { ShoppingCartService } from '../cart.service';

describe('CheckoutComponent', () => {
  let component: CheckoutComponent;
  let fixture: ComponentFixture<CheckoutComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HttpClientTestingModule, RouterTestingModule],      
      declarations: [ CheckoutComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CheckoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should have the same items as shopping cart', () => {
    fixture = TestBed.createComponent(CheckoutComponent);
    component = fixture.debugElement.componentInstance;
    let shoppingCartService = fixture.debugElement.injector.get(ShoppingCartService);
    expect(shoppingCartService.items).toEqual(component.items);
  });


});
