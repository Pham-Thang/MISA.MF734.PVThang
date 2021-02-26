import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home'
import FeeList from '../views/planning/FeeList'

Vue.use(VueRouter)

const routes = [
  { path: '/', name: 'Home', component: Home },
  {
    path: '/dashboard',
    name: 'Dashboard',
    component: Home
  },
  {
    path: '/planning-fee',
    name: 'PlanningFee',
    component: FeeList
  },
  {
    path: '/manage-fee',
    name: 'ManageFee',
    component: Home
  },
  {
    path: '/mange-bill',
    name: 'ManageBill',
    component: Home
  },
  {
    path: '/receivable-payable',
    name: 'ReceivablePayable',
    component: Home
  },
  {
    path: '/report',
    name: 'Report',
    component: Home
  },
  {
    path: '/message',
    name: 'Message',
    component: Home
  },
  {
    path: '/system',
    name: 'System',
    component: Home
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router