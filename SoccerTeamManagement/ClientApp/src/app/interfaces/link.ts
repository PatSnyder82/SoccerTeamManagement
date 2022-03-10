import { IEntity } from "./entity";

export interface ILink extends IEntity  {
  openNewWindow: boolean;
  text: string;
  url: string;
}
