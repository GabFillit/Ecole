import Vue from 'vue'
import Router from 'vue-router'
import Home from './views/Home.vue'
import Login from './views/Login.vue';
import SignUp from './views/SignUp.vue';
import VeeValidate from 'vee-validate'

Vue.use(Router);
Vue.use(VeeValidate);

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/login',
      name: 'login',
      component: Login
    } ,
    {
      path: '/signup',
      name: 'signup',
      component: SignUp
    }
  ]
})
