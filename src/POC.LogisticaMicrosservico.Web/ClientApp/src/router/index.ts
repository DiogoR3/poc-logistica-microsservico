import Vue from 'vue'
import VueRouter, { RouteConfig } from 'vue-router'
import Menu from '../views/Menu.vue'
import Login from '../views/Login.vue'

Vue.use(VueRouter)

const routes: Array<RouteConfig> = [
  {
    path: '/',
    name: 'Menu',
    component: Menu,
    meta: {
      requerLogin: true
    }
  },
  {
    path: '/Login',
    name: 'Login',
    component: Login
  }
]

const router = new VueRouter({
  routes
})

router.beforeEach((to, from, next) => {
  console.log('teste')
  next()
})

export default router
