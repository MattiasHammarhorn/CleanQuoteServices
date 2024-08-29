import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Observable, map } from 'rxjs';

interface IQuote {
  location?: ILocation;
  locationId?: number;
  totalPrice: number;
  totalSquareMeters: number;
  balconyCleaningEnabled: boolean;
  windowCleaningEnabled: boolean;
  wasteCollectionEnabled: boolean;
}

interface ILocation {
  locationId: number;
  locationName: string,
  hasBalconyCleaning: boolean;
  hasWindowCleaning: boolean;
  hasWasteCollection: boolean;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  quote: IQuote = {
    location: undefined,
    locationId: undefined,
    totalPrice: 0,
    totalSquareMeters: 0,
    balconyCleaningEnabled: false,
    windowCleaningEnabled: false,
    wasteCollectionEnabled: false,
  };

  locations: ILocation[] = [];
  selectedLocationId?: number;
  
  postSuccessful: boolean = false;

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getLocations();
  }

  getLocations() {
    this.http.get<ILocation[]>('api/locations').subscribe(
      locations => {
        console.log(locations);
        this.locations = locations;
    });
  }

  refreshQuote() {
    if (!this.quote.location?.hasBalconyCleaning) {
      this.quote.balconyCleaningEnabled = false;
    }

    if (!this.quote.location?.hasWindowCleaning == true) {
      this.quote.windowCleaningEnabled = true;
    }

    if (!this.quote.location?.hasWasteCollection) {
      this.quote.wasteCollectionEnabled = false;
    }
  }

  postQuote() {
    this.refreshQuote();
    //this.postQuote2(this.quote).subscribe();

    this.http.post<IQuote>('api/quotes/', this.quote).subscribe(response => {
      console.log(response);
      this.postSuccessful = true;
      this.quote.totalPrice = response.totalPrice;
    });
    //this.http.post(Url, JSON.stringify(data), requestOptions)
    //  .map((response: Response) => response.json())
  }

  //postQuote2(quote: IQuote): Observable<IQuote> {
  //  let quote2;

  //  return this.http
  //    .post<IQuote>('api/quotes/', this.quote)
  //    .pipe(map((quote: IQuote) => {
  //      this.quote.next(quote);
  //      return quote;
  //    }));
  //}

  logQuote() {
    console.log(this.quote);
  }

  title = 'cleanquoteservices.client';
}
