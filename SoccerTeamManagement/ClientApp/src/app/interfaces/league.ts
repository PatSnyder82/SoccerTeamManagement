import { Image } from "./image";
import { Team } from "./Team";

export interface League {
  id: number;
  name: string;
  logo: Image;
  teams: Team[];
}
