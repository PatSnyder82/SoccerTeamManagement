export interface PlayerAttributes {
  id: number;
  playerId: number;

  //#region Pace

  acceleration: number;
  sprintSpeed: number;

  //#endregion

  //#region Dribbling

  agility: number;
  balance: number;
  reactions: number;
  ballControl: number;
  dribbling: number;
  composure: number;

  //#endregion

  //#region Shooting

  offensivePositioning: number;
  finishing: number;
  shotPower: number;
  longShots: number;
  volleys: number;
  penalties: number;

  //#endregion

  //#region Defending

  interceptions: number;
  headingAccuracy: number;
  defensiveAwareness: number;
  standingTackle: number;
  slidingTackle: number;

  //#endregion

  //#region Passing

  vision: number;
  crossing: number;
  freeKickAccuracy: number;
  shortPassing: number;
  longPassing: number;
  curve: number;

  //#endregion

  //#region Physicality

  jumping: number;
  stamina: number;
  strength: number;
  aggression: number;

  //#endregion

  //#region Goalie

  diving: number;
  reflexes: number;
  handling: number;
  kicking: number;
  goaliePositioning: number;

  //#endregion
}
