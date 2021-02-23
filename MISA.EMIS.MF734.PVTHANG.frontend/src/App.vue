<template>
  <div id="app">
    <Menu />
    <Header />
    <Content />
  </div>
</template>

<script>
import Menu from './components/layout/TheMenu'
import Header from './components/layout/TheHeader'
import Content from './components/layout/TheContent'

export default {
  name: 'App',
  components: {
    Menu,
    Header,
    Content,
  }
}
</script>

<style>
@import url('./styles/index.css');

</style>
