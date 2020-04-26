import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable ,throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

import { HttpApiService } from '../base/http-api.service';
import { Product } from '../../models/product';
import { Coin } from '../../models/coin';
import { environment } from '../../../../../environments/environment';
import { BuyProductResponse} from '../../models/buy-product-response'; 

@Injectable({
  providedIn: 'root'
})
export class ProductService extends HttpApiService{

  protected productController = '/product';

  protected actionEndpoints = {
		GetAll: environment.vendingApi + this.productController,
		BuyProduct: environment.vendingApi + this.productController + '/buy/{0}',
  };

  constructor(httpClient: HttpClient) {
		super(httpClient);
  }

  private handleError(error: any, method: string): Observable<any> {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
        // client-side error
        errorMessage = `Error: ${error.error.message}`;
    } else {
        // server-side error
        errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
		console.log('Error in method ' + method + ' of Vending API. Error: ' + JSON.stringify(errorMessage));  
    return throwError(errorMessage);
  }
  
  public GetProducts(): Observable<Product[]> {
    return this.get(this.actionEndpoints.GetAll, { })
      .pipe(map((response: Product[]) => response))
      .pipe(catchError((error: any) => this.handleError(error, 'GetProducts')));
  }

  public BuyProduct(productId: Number, depositedCoins: Coin[]): Observable<BuyProductResponse> {
    return this.post(this.actionEndpoints.BuyProduct.replace('{0}', productId.toString()), depositedCoins)
      .pipe(map((response: BuyProductResponse) => response))
      .pipe(catchError((error: any) => this.handleError(error, 'BuyProduct')));
  }
}
