import { Component } from '@angular/core';
import { IQuote } from '../quote.model';
import { ILocation } from '../location.model';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-quote',
  templateUrl: './quote.component.html',
  styleUrls: ['./quote.component.css']
})
export class QuoteComponent {

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

  constructor(private http: HttpClient) { }

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

    this.http.post<IQuote>('api/quotes/', this.quote).subscribe(response => {
      console.log(response);
      this.postSuccessful = true;
      this.quote.totalPrice = response.totalPrice;
    });
  }

  logQuote() {
    console.log(this.quote);
  }
}
