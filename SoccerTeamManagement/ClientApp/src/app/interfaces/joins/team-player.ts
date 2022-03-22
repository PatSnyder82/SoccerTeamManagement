import { IPlayer } from '../player';
import { ITeam } from '../team';

export interface ITeamPlayer {
  playerId: number;
  player: IPlayer;
  teamId: number;
  team: ITeam;
  joinedTeam: Date;
  departedTeam: Date;
}
