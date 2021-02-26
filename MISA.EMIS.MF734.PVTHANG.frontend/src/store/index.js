import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    menuTab: [
      {
        id: "Dashboard",
        name: "Tổng quan",
        icon: "icon-dashboard"
      },
      {
        id: "PlanningFee",
        name: "Lập kế hoach thu",
        icon: "icon-planning-fee"
      },
      {
        id: "ManageFee",
        name: "Quản lý thu",
        icon: "icon-manage-fee"
      },
      {
        id: "ManageBill",
        name: "Quản lý hóa đơn",
        icon: "icon-manage-bill"
      },
      {
        id: "ReceivablePayable",
        name: "Số phải thu, phải trả",
        icon: "icon-receivable-payable"
      },
      {
        id: "Report",
        name: "Báo cáo",
        icon: "icon-report"
      },
      {
        id: "Message",
        name: "Tin nhắn",
        icon: "icon-message"
      },
      {
        id: "System",
        name: "Hệ thống",
        icon: "icon-system"
      },
    ],
  },
  mutations: {
    setCurrentTab(state, newTab) {
      state.currentTab = newTab;
    }
  },
  actions: {
  },
  modules: {
  }
})