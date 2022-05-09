export class Item {
  constructor(public id: number,
    public title: string,
    public description: string,
    public imageUrl: string,
    public priceOriginal: number,
    public currencyOriginal: string,
    public sellPrice: number,
    public currencyCurrent: string,
    public count: number,
    ) { }
}
