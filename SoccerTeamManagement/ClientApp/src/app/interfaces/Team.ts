import { IImage } from "./image";
import { IClub } from "./club";
import { ILeague } from "./league";
import { IPlayer } from "./player";
import { IEntity } from "./entity";

export interface ITeam extends IEntity {
  name: string;
  image: IImage;
  club: IClub;
  leagues: ILeague[];
  players: IPlayer[];
}
