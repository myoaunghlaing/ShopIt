import { CalculatorService } from "./calculator.service";
import { Item } from "./item.model";
import { ShippingCharges } from "./shippingcharges.model";

// Isolation tests on Calculator Service
describe('Calculator Service', () => {
  let calculatorService: CalculatorService;
  let items: Item[];
  let shippingCharges: ShippingCharges[];

  beforeEach(async () => {
    calculatorService = new CalculatorService();
    items = [new Item(1, 'Test 1', '', '', 10, 'AUD', 0, '', 2), new Item(1, 'Test 2', '', '', 10, 'AUD', 0, '', 3)];
    shippingCharges = [new ShippingCharges(1, 1, 10), new ShippingCharges(2, 50, 20)]
  });

  
  it('should calculate sell price', () => {   
    calculatorService.calculatePrice(items);
    expect(items[0].sellPrice).toEqual(10);
    expect(items[1].sellPrice).toEqual(10);
  });

  it('should calculate total price and shipping', () => {
    let result: number[] = calculatorService.calculate(items, shippingCharges);
    expect(result[0]).toEqual(70);
    expect(result[1]).toEqual(20);
  });

});
