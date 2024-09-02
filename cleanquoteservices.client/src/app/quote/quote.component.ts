import { Component } from '@angular/core';
import { IQuote } from '../quote.model';
import { ILocation } from '../location.model';
import { ApiService } from './api.service';

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

  constructor(private apiSvc: ApiService) { }

  ngOnInit() {
    this.getLocations();
  }

  getLocations() {
    this.apiSvc.getLocations().subscribe(locations => {
      console.log(locations);
      this.locations = locations;
    });
  }

  submitQuote() {
    this.refreshQuote();

    this.apiSvc.postQuote(this.quote).subscribe(result => {
      console.log(result);
      this.postSuccessful = true;
      this.quote.totalPrice = result.totalPrice;
    });
  }

  refreshQuote() {
    if (!this.quote.location?.hasBalconyCleaning)
      this.quote.balconyCleaningEnabled = false;

    if (!this.quote.location?.hasWindowCleaning == true)
      this.quote.windowCleaningEnabled = true;

    if (!this.quote.location?.hasWasteCollection)
      this.quote.wasteCollectionEnabled = false;
  }
  
  logQuote() {
    console.log(this.quote);
  }
}
