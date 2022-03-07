import { ILookup } from "./lookup";
import { IState } from "./state";

export interface ICountry extends ILookup {
  alpha2Code: string;
  alpha3Code: string;

  states: IState[];
}
