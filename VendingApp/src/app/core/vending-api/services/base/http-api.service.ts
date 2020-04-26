import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpApiService {

  protected endPointHost: string;

  constructor(private httpClient: HttpClient) {
	}

	public get(url: string, withCredentials?: any): Observable<any> {
		return this.httpClient.get(url, {  });
	}

	public post(url: string, data: any, withCredentials?: any): Observable<any> {
		return this.httpClient.post(url, data, {  });
	}

	public put(url: string, data: any, withCredentials?: any): Observable<any> {
		return this.httpClient.put(url, data, {  });
	}

	public delete(url: string, withCredentials?: any): Observable<any> {
		return this.httpClient.delete(url, {  });
  }
  
}
