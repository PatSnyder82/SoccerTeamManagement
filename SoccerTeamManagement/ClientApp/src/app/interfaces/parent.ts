import { IPerson } from "./person";
import { IPlayer } from "./player";

export interface IParent extends IPerson {
  players: IPlayer[];
}
