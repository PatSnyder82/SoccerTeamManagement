import { Address } from "./address";
import { Image } from "./image";
import { Phone } from "./phone";
import { Country } from "./lookups/country";

export interface Person {
  id: number;
  firstName: string;
  lastName: string;
  nickName: string;

  dateOfBirth: Date;
  phoneId: number;
  phone: Phone;
  addressId: number;
  address: Address;
  imageId: number;
  image: Image;
  countryId: number;
  country: Country;
}
