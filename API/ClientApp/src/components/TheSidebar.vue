<template>
  <div class="controls-layout">
    <span v-if="currentWinStatus === 1">Game in progress</span>
    <span v-if="currentWinStatus === 2">Player {{(timeCounter % 2 + 1)}} won</span>
    <span v-if="currentWinStatus === 3">Game ended with draw</span>
    <span>Time: {{timeCounter}}</span>
    <button class="btn" @click="newGame()">Start New Game</button>
    <button class="btn" @click="nextMove()">Next Move</button>
  </div>
</template>

<script lang="ts">
import {defineComponent, PropType} from "vue";
import {WinStatus} from "@/models/WinStatus";

export default defineComponent({
  name: "TheControls",
  props: {
    timeCounter: Number,
    currentWinStatus: {} as PropType<WinStatus>,
  },
  methods: {
    newGame() {
      this.$emit("newGame");
    },
    
    nextMove() {
      this.$emit("nextMove");
    },
  }
});
</script>

<style scoped>
.controls-layout {
  display: flex;
  flex-direction: column;
}

</style>