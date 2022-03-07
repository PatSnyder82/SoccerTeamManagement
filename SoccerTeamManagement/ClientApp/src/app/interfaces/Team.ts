import { IImage } from "./image";
import { IClub } from "./club";
import { ILeague } from "./league";
import { IPlayer } from "./player";

export interface ITeam {
  id: number;
  name: string;
  image: IImage;
  club: IClub;
  leagues: ILeague[];
  players: IPlayer[];
}
