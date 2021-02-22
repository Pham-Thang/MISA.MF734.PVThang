<template>
  <div id="app">
    <Menu />
    <Header />
    <Content />
  </div>
</template>

<script>
import Menu from './components/Menu'
import Header from './components/Header'
import Content from './components/Content'

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
