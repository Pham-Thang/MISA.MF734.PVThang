import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home'
import FeeList from '../views/planning/FeeList'

Vue.use(VueRouter)

const routes = [
  { path: '/', name: 'Home', component: Home },
  {
    path: '/planning-fee',
    name: 'FeeList',
    component: FeeList
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router