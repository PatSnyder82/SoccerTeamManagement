import { Address } from "./address";
import { Image } from "./image";
import { Phone } from "./phone";
import { CountryLookup } from "./countryLookup";

export interface Person {
  id: number;
  firstName: string;
  lastName: string;
  nickName: string;

  dateOfBirth: Date;
  phone: Phone;
  address: Address;
  photo: Image;
  nationId: number;
  nation: CountryLookup;
}
