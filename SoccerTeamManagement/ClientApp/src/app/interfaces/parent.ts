import { Person } from "./person";
import { Player } from "./player";

export interface Parent extends Person {
  players: Player[];
}
