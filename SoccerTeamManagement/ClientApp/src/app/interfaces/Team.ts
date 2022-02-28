import { Image } from "./image";
import { Club } from "./club";
import { League } from "./league";
import { Player } from "./player";

export interface Team {
  id: number;
  name: string;
  image: Image;
  club: Club;
  leagues: League[];
  players: Player[];
}
