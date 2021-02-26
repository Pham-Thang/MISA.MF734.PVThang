<template>
  <div id="app">
    <Menu />
    <Header />
    <Content />
    <div class="toast-message-container">
      <ToastMessage v-for="(toast) in $store.state.listToastMessage" :key="toast.id"
        :message="toast.message" :type="toast.type" 
        @close="() => {
          $store.commit('setListToastMessage', $store.state.listToastMessage.filter((t) => {
            return t.id !== toast.id;
          }))
        }"></ToastMessage>
    </div>
  </div>
</template>

<script>
import Menu from './components/layout/TheMenu'
import Header from './components/layout/TheHeader'
import Content from './components/layout/TheContent'
import ToastMessage from './views/basics/ToastMessage'

export default {
  name: 'App',
  components: {
    Menu,
    Header,
    Content,
    ToastMessage
  }
}
</script>

<style>
@import url('./styles/index.css');
.toast-message-container {
  position: fixed;
  top: 0;
  width: 300px;
  left: calc((100% - 300px) / 2);
  z-index: 10;
}
</style>
