import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ILocation } from '../location.model';
import { IQuote } from '../quote.model';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

  getLocations(): Observable<ILocation[]> {
    return this.http.get<ILocation[]>('api/locations');
  }

  postQuote(quote: IQuote): Observable<IQuote> {
    return this.http.post<IQuote>('api/quotes/', quote);
  }
}
