<template>
  <div class="game-layout" v-if="isDataLoaded">
     <TheSidebar :current-win-status="gameState.currentWinStatus" :time-counter="gameState.timeCounter" @newGame="startNewGame()" @nextMove="nextMove()"/> 
    
    <div class="game-boards-grid-layout">
      <div class="game-boards-layout">
        <PlayersBoardComponent :players-board="gameState.firstPlayersBoard"/>
        <TrackingBoardComponent :tracking-board="gameState.firstTrackingBoard"/>
      </div>

      <div class="game-boards-layout">
        <PlayersBoardComponent :players-board="gameState.secondPlayersBoard"/>
        <TrackingBoardComponent :tracking-board="gameState.secondTrackingBoard"/>
      </div>
    </div>
  </div>
  
  <div v-else>
    Loading Data
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import {
  getGameState,
    nextMove,
    startNewGame,
} from "@/services/battleships.service";
import { GameState } from "@/models/GameState";
import PlayersBoardComponent from "@/components/PlayersBoard.vue";
import TrackingBoardComponent from "@/components/TrackingBoard.vue";
import TheSidebar  from "@/components/TheSidebar.vue";

export default defineComponent({
  name: "TheGame",
  components: {
    PlayersBoardComponent,
    TrackingBoardComponent,
    TheSidebar
  },
  data() {
    return {
      gameState: {} as GameState,
      isDataLoaded: false
    };
  },

  created() {
    getGameState().then((state) => {this.gameState = state; this.isDataLoaded = true;});
  },
  
  methods: {
    startNewGame() {
      startNewGame().then((state) => this.gameState = state)
    },
    
    nextMove() {
      nextMove().then((state) => this.gameState = state) 
      this.$forceUpdate()
    }
  }
});
</script>

<style scoped>
.game-layout {
  display: flex;
}

.game-boards-grid-layout {
  padding-left: 10px;
  padding-right: 10px;
  display: grid;
  grid-template-columns: 1fr 1fr;
  grid-gap: 30px;
}

.game-boards-layout {
  display: flex;
  flex-direction: column;
}
</style>
