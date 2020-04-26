import { Component, OnInit } from '@angular/core';

import { CoinService } from '../../../../core/vending-api/services/coin/coin.service';
import { ProductService } from '../../../../core/vending-api/services/product/product.service';
import { Coin } from '../../../../core/vending-api/models/coin';
import { Product } from '../../../../core/vending-api/models/product';
import { BuyProductResponse } from '../../../../core/vending-api/models/buy-product-response';

@Component({
  selector: 'app-main-vending',
  templateUrl: './main-vending.component.html',
  styleUrls: ['./main-vending.component.scss']
})
export class MainVendingComponent implements OnInit {

  public depositedAmount: number=0;

  public coins: Array<Coin>;
  public products: Array<Product>;
  public depositedCoins: Array<Coin> = new Array<Coin>();
  public result: BuyProductResponse= new BuyProductResponse();
  

  constructor(public coinSrv: CoinService,
    public productSrv: ProductService) { }

  ngOnInit(): void {

    this.initializeVendingMachine();

  }

  private initializeVendingMachine(){
    this.coinSrv.GetCoins().subscribe(
      coins => {
        this.coins = coins;
    });
    this.productSrv.GetProducts().subscribe(
      products => {
        this.products = products;
    });
  }

  public depositsCoin($coin: Coin){
    let foundCoin = this.depositedCoins.find(c => c.id == $coin.id);
    if(!!foundCoin){
      foundCoin.quantity++;
    }
    else{
      $coin.quantity = 1;
      this.depositedCoins.push($coin);
    }
    this.depositedAmount = this.depositedAmount + $coin.value;
  }

  public refundDepositedCoins(){

    this.result = new BuyProductResponse();
    this.result.success = false;
    this.result.data = this.depositedCoins;
    this.result.message = 'Get your money';
    this.initializeDepositedCoins();
  }

  public initializeDepositedCoins(){
    this.depositedCoins = new Array<Coin>();
    this.depositedAmount = 0;

  }

  public buyProduct(product: Product){
    this.productSrv.BuyProduct(product.id, this.depositedCoins).subscribe(
      result => {
        this.result = result;
    });
    this.initializeDepositedCoins();
  }

}
