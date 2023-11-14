import Vue from 'vue'
import App from './App.vue'
import VueRouter from 'vue-router'
import about from './components/About.vue'
import contact from './components/Contact.vue'
import Home from './components/Home.vue'
import kpvitem from './components/kpvitem'
import routes from './routes';
import { store } from './Shared/store.js'

Vue.use(VueRouter);

Vue.component("kpvitem", kpvitem)
Vue.use(VueRouter);
  const router = new VueRouter({
        routes: routes,
    mode: 'history'
    }
)

Vue.config.productionTip = false



new Vue({
  router, store,
  render: h => h(App),

}).$mount('#app')
