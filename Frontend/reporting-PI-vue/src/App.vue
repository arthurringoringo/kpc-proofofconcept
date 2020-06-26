<template>
  <div>
    <h1>Store A Dashboard</h1>

    <div class="grid-container">
      <div class = "item1"> <ChartDoughnut /> </div>
      <div class = "item2"> <ChartBar1 /> </div>
    </div>
    <div class="grid-container">
      <div class = "item3"> <ChartBar2 /> </div>
      <div class = "item4">   <ChartBar2 /></div>
    </div>
  </div>
</template>

<script>

import ChartDoughnut from '@/components/PriceReport'
import ChartBar1 from '@/components/ItemReport'
import ChartBar2 from '@/components/PricediffReport'

export default {
  components: {
    ChartDoughnut,
    ChartBar1,
    ChartBar2
  }
}
</script>

<style>
h1 {
  text-align: center;
}
.grid-container {
  display: grid;
  grid-template-columns: 600px 600px 600px;
  grid-gap: 10px;
  background-color: #2196F3;
  padding: 10px;
}
.item1 {
  grid-column-start: 1;
  grid-column-end: 1;
  grid-row-start:1 ;
  grid-row-end:1 ;
}
.item2 {
  grid-column-start: 2;
  grid-column-end: 2;
  grid-row-start:1 ;
  grid-row-end: 1;
}
.item3 {
  grid-column-start: 1;
  grid-column-end: 1;
  grid-row-start:2 ;
  grid-row-end: 2;
}
.item4 {
  grid-column-start: 2;
  grid-column-end: 2;
  grid-row-start:2;
  grid-row-end: 2;
}
</style>
