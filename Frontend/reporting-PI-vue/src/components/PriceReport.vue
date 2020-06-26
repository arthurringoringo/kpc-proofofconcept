<template>
  <div class="card">
    <div class="card-body">
      <h2 class="card-title">Store A Price Analysis</h2>
    </div>
    <div id= "sect1" class="card-img-bottom">
      <chartjs-doughnut
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

  async mounted () {
    await axios
      .get('https://localhost:5001/api/pricelist/compare/450')
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
          hoverBackgroundColor: ['#fbd2cd', '#fef5c9', '#d1e3f7', '#ff0000']
        }
      ],
      labels: ['UnderPrice', 'Overprice', 'Equalprice', 'Not Found'],
      backgroundColor: ['#f36e60', '#ffdb3b', '#185190', '#ff0000'],
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
