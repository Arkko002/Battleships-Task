import {WinStatus} from "@/models/WinStatus";
import {PlayerBoard} from "@/models/PlayerBoard";
import {TrackingBoard} from "@/models/TrackingBoard";

export interface GameState {
    TimeCounter: number;
    WinStatus: WinStatus
    
    FirstPlayersBoard: PlayerBoard
    FirstTrackingBoard: TrackingBoard
    
    SecondPlayersBoard: PlayerBoard
    SecondTrackingBoard: TrackingBoard
}