// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
/* eslint-disable */ 
import { 
  BootstrapVue, 
  BootstrapVueIcons 
} from 'bootstrap-vue';
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap-vue/dist/bootstrap-vue.css';
import 'chart.js';
import 'hchs-vue-charts';

import Vue from 'vue'
import App from './App'
import router from './router'



Vue.use(BootstrapVue);
Vue.use(BootstrapVueIcons);
Vue.use(window.VueCharts);





Vue.config.productionTip = false

/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  components: { App },
  template: '<App/>'
})
