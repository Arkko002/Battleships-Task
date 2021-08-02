<template>
  <div class="board-layout">
    <ul class="board-list" v-bind:key="line" v-for="line in playersBoard.fields">
      <li class="board-list-item" v-bind:key="index" v-for="(field, index) in line">
        <div class="ship-img" v-if="field !== null">
          <img :src="`${publicPath}ship.png`" v-if="!field.isDestroyed">
          <img :src="`${publicPath}skull.png`" v-else/>
        </div>
      </li>
    </ul>
  </div>

</template>

<script lang="ts">
import {defineComponent, PropType} from "vue"
import {PlayerBoard} from "@/models/PlayerBoard";

export default defineComponent({
  name: "PlayersBoard",
  data() {
    return {
      publicPath: process.env.BASE_URL
    }
  },
  
	props: {
    playersBoard: {
      type: Object as PropType<PlayerBoard>,
      required: true,
    },
	},
});
</script>

<style scoped>
.board-layout {
  display: flex;
}

.board-list {
  list-style: none;
  padding: 0;
}

.board-list-item {
  height: 40px;
  width: 40px;
  display: flex;
  border: solid 1px black;
}

.ship-img {
  width: 100%;
  height: 100%;
}
</style>
