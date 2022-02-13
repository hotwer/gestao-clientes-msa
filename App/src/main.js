import Vue from 'vue'
import App from './App.vue'
import ConfirmationDialog from './components/global/ConfirmationDialog.vue'
import { BootstrapVue, BootstrapVueIcons } from 'bootstrap-vue';
import http from './axios.bootstrap';
import moment from 'moment';

import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

Vue.config.productionTip = false

Vue.prototype.$http = http;
Vue.prototype.momentjs = moment;

Vue.use(BootstrapVue);
Vue.use(BootstrapVueIcons);

// global components
Vue.component("ConfirmationDialog", ConfirmationDialog)

new Vue({
    render: h => h(App),
})
.$mount('#app')