import Vue from 'vue'
import Router from 'vue-router'
import PriceReport from '@/components/PriceReport'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'PriceReport',
      component: PriceReport
    }
  ]
})
