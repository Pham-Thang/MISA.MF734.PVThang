import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home'
import FeeList from '../views/planning/'

Vue.use(VueRouter)

const routes = [
  { path: '/', name: 'Home', component: Home },
  {
    path: '/planning-fee',
    name: 'FeeList',
    component: FeeList
  },
  {
    path: '/dashboard',
    name: 'Dashboard',
    component: Home
  },
  {
    path: '/manage-fee',
    name: 'ManageFee',
    component: Home
  },
  {
    path: '/manage-invoice',
    name: 'ManageInvoice',
    component: Home
  },
  {
    path: '/recivable-payable',
    name: 'RecivablePayable',
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