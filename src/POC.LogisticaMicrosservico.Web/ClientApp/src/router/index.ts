import Vue from 'vue'
import VueRouter, { RouteConfig } from 'vue-router'
import Login from '../views/Login.vue'

//Menu
import Usuarios from '../components/Menu/Usuarios.vue'
import Atendimento from '../components/Menu/Atendimento.vue'
import Mercadoria from '../components/Menu/Mercadoria.vue'

Vue.use(VueRouter)

const routes: Array<RouteConfig> = [
  {
    path: '/',
    name: 'Login',
    component: Login
  },
  {
    path: '/Menu',
    name: 'Menu',
    component: () => import('../views/Menu.vue'),
    meta: {
      requerLogin: true
    },
    children: [
      {
        path: 'Atendimento',
        component: Atendimento
      },{
        path: 'Mercadoria',
        component: Mercadoria
      },
      {
        path: 'Usuarios',
        component: Usuarios
      },
    ]
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
