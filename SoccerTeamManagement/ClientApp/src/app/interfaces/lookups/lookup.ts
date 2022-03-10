import { IEntity } from "../entity";

export interface ILookup extends IEntity  {
  isDisabled: boolean;
  sortOrder: number;
  text: string;
  value: string;
}
