<template>
    <div class="board-layout">
      <ul class="board-list" v-bind:key="line" v-for="(line, x) in trackingBoard.fields">
        <li class="board-list-item" v-bind:key="`${x.toString()}.${y.toString()}`" v-for="(field, y) in line">
          <div v-if="field === 1"/>
          <img :src="`${publicPath}miss.png`" v-else-if="field === 2"/>
          <img :src="`${publicPath}hit.png`" v-else-if="field === 3"/>
          <img :src="`${publicPath}skull.png`" v-else-if="field === 4"/>
        </li>
      </ul>
    </div>
</template>

<script lang="ts">
import {defineComponent, PropType} from "vue";
import {TrackingBoard} from "@/models/TrackingBoard";
import {TrackingFieldState} from "@/models/TrackingFieldState";

export default defineComponent({
  name: "TrackingBoard",
  data() {
    return {
      publicPath: process.env.BASE_URL
    }
  },
  props: {
    trackingBoard: {
      type: Object as PropType<TrackingBoard>,
      required: true,
    },
  }
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
</style>