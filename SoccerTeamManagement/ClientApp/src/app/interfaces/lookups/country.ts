import { Lookup } from "./lookup";

export interface Country extends Lookup {
  alpha2Code: string;
  alpha3Code: string;
}
