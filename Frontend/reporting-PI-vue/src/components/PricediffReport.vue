<template>
  <div class="card">
    <div class="card-body">
      <h2 class="card-title">Store A Price Percentage Analysis</h2>
    </div>
    <div class="card-img-bottom">
      <chartjs-bar
        :bind="true"
        :data="datasets"
        :labels="labels"
        :backgroundColor="backgroundColor"
        :option="option"

      />
    </div>
  </div>
</template>

<script>
import axios from 'Axios'

export default {
  created () {
    axios
      .get(`https://localhost:5001/api/pricelist/compare/percentage`)
      .then(data => (this.datasets = data.data))
      .catch(e => {
        this.errors.push(e)
      })
  },
  data () {
    return {
      datasets: [
        {
          data: [],
          hoverBackgroundColor: ['#fbd2cd', '#fef5c9', '#d1e3f7']
        }
      ],
      labels: ['Not Found', 'Less than -50% Difference', 'Less than -1% Difference', 'More than 1% Difference', 'More than 50% Difference'],
      backgroundColor: ['#f36e60', '#ffdb3b', '#185190'],
      option: {}
    }
  }
}
</script>
<style>

h2 {
    text-align: center;
}

</style>
