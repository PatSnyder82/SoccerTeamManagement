import { Person } from "./person";
import { PlayerAttributes } from "./playerAttributes";
import { PositionLookup } from "./positionLookup";
import { Team } from "./Team";
import { Parent } from "./Parent";

export interface Player extends Person {
  height: number;
  weight: number;
  foot: string;
  weakFootRating: number;
  flareRating: number;

  attributes: PlayerAttributes;
  teams: Team[];
  position: PositionLookup[];
  parents: Parent[];
}
