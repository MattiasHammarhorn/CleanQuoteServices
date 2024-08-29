import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

interface IQuote {
  location?: ILocation;
  locationId?: number;
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
    totalSquareMeters: 0,
    balconyCleaningEnabled: false,
    windowCleaningEnabled: false,
    wasteCollectionEnabled: false,
  };

  locations: ILocation[] = [];
  selectedLocationId?: number;

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

  calculateQuote() {
    this.refreshQuote();
    this.http.post<IQuote>('api/quotes/', this.quote).subscribe();
  }

  logQuote() {
    console.log(this.quote);
  }

  title = 'cleanquoteservices.client';
}
