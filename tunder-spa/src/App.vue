<template>
  <div id="app">
    <Header/>
    <div class="container is-widescreen">
      <router-view/>
    </div>
    <Footer/>
  </div>
</template>

<script>
import Header from '@/components/layout/Header.vue'
import Footer from '@/components/layout/Footer.vue'

export default {
  name: 'App',
  components: {
    Header,
    Footer
  }
}
  
</script>

<style lang="scss">

.container, #app, .view__container, html, body {
  height: 100%;
}

.button { 
  min-width: 90px;
}
</style>
