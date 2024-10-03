import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/Home.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/CrudUsuarios',
      name: 'CrudUsuarios',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/CrudUsuarios.vue')
    },
    {
      path: '/CrudProdutos',
      name: 'CrudProdutos',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/CrudProdutos.vue')
    },
    {
      path: '/Initialpage',
      name: 'Initialpage',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/Initialpage.vue')
    },
    {
      path: '/FormDeleteUsuario',
      name: 'FormDeleteUsuario',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('@/components/Usuario/FormDeleteUsuario.vue')
    },
    {
      path: '/FormGetUsuario',
      name: 'FormGetUsuario',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('@/components/Usuario/FormGetUsuario.vue')
    },
    {
      path: '/FormPostUsuario',
      name: 'FormPostUsuario',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('@/components/Usuario/FormPostUsuario.vue')
    },
    {
      path: '/FormUpdateUsuario',
      name: 'FormUpdateUsuario',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('@/components/Usuario/FormUpdateUsuario.vue')
    }
  ]
})

export default router
