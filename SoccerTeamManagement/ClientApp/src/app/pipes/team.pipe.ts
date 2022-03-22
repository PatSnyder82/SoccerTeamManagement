import { Pipe, PipeTransform } from '@angular/core';
import { ITeamPlayer } from '../interfaces/joins/team-player';

@Pipe({
  name: 'teams',
  pure: false
})
export class TeamPipe implements PipeTransform {
  transform(teamPlayers: ITeamPlayer[], numberTeams: number = 3): string {
    let value: string = 'None';
    let index = 0;

    if (teamPlayers && teamPlayers?.length > 0) {
      value = '';
      teamPlayers.forEach(teamPlayer => {
        if (index === 0) {
          value += teamPlayer?.team.name;
        }
        else if (index < numberTeams) {
          value += ", " + teamPlayer?.team.name;
        }

        index++;
      });
    }

    return value;
  }
}
