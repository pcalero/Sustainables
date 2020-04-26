import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable ,throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

import { HttpApiService } from '../base/http-api.service';
import { Coin } from '../../models/coin';
import { environment } from '../../../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CoinService extends HttpApiService {

  protected productController = '/coin';

  protected actionEndpoints = {
		GetAll: environment.vendingApi + this.productController
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
  
  public GetCoins(): Observable<Coin[]> {
    return this.get(this.actionEndpoints.GetAll, { })
      .pipe(map((response: Coin[]) => response))
      .pipe(catchError((error: any) => this.handleError(error, 'GetCoins')));
  }

}
