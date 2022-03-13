import { IEntity } from "./entity";

export interface IPhone extends IEntity {
  countryCode: string;
  areaCode: string;
  extension: string;
  number: string;
  phoneType: number;
}
