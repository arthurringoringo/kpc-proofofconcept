<template>
  <div class="card">
    <div class="card-body">
      <h2 class="card-title">Store A Price Category Analysis</h2>
    </div>
    <div class="card-img-bottom">
      <chartjs-pie
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
      .get(`https://localhost:5001/api/pricelist/compare/category`)
      .then(data => (this.datasets = data.data))
      .catch(e => {
        this.errors.push(e)
      })
  },
  data () {
    return {
      datasets: [
        {
          label: 'Store A',
          data: [],
          hoverBackgroundColor: ['#fbd2cd', '#fef5c9', '#d1e3f7']
        }
      ],
      labels: ['Food', 'Technology', 'Beauty', 'Drinks'],
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
