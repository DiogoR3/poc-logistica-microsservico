import Vue from 'vue'
import VueRouter, { RouteConfig } from 'vue-router'
import Login from '../views/Login.vue'

import { jaFezLogin } from '../api/autenticacao'

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
        name: 'Atendimento',
        component: Atendimento
      }, {
        path: 'Mercadoria',
        name: 'Mercadoria',
        component: Mercadoria
      },
      {
        path: 'Usuarios',
        name: 'Usuarios',
        component: Usuarios
      },
    ]
  },
]

const router = new VueRouter({
  routes
})

router.beforeEach((to, from, next) => {

  if (to.name == 'Login' && jaFezLogin()) {
    next('/Menu/Usuarios')
  }

  if (to.name == 'Menu') {
    next('/Menu/Usuarios')
  }

  if ((to.name == 'Atendimento' || to.name == 'Mercadoria' || to.name == 'Usuarios') && !jaFezLogin()) {
    next('/')
  }

  next()
})

export default router
