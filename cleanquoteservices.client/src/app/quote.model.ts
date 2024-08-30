import { ILocation } from "./location.model";

export interface IQuote {
  location?: ILocation;
  locationId?: number;
  totalPrice: number;
  totalSquareMeters: number;
  balconyCleaningEnabled: boolean;
  windowCleaningEnabled: boolean;
  wasteCollectionEnabled: boolean;
}
