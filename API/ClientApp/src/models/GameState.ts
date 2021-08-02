import { WinStatus } from "@/models/WinStatus";
import { PlayerBoard } from "@/models/PlayerBoard";
import { TrackingBoard } from "@/models/TrackingBoard";

export interface GameState {
  timeCounter: number;
  currentWinStatus: WinStatus;

  firstPlayersBoard: PlayerBoard;
  firstTrackingBoard: TrackingBoard;

  secondPlayersBoard: PlayerBoard;
  secondTrackingBoard: TrackingBoard;
}

