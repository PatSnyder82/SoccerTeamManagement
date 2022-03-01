import { Address } from "./address";
import { Image } from "./image";
import { Phone } from "./phone";
import { CountryLookup } from "./countryLookup";

export interface Person {
  id: number;
  firstName: string;
  lastName: string;
  nickName: string;
  isAdult: boolean;

  phone: Phone;
  address: Address;
  photo: Image;
  nation: CountryLookup;
}
