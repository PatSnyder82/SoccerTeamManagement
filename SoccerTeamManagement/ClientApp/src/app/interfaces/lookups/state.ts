import { ILookup } from "./lookup";
import { ICountry } from "./country";

export interface IState extends ILookup {
  alpha2Code: string;

  countryId: number;
  country: ICountry;
}
