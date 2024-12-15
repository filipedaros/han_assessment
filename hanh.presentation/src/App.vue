<template>
  <Header></Header>

  

  <main class="flex-shrink-0">
    <div class="container">
    <CountriesList></CountriesList>
    </div>
  </main>

</template>

<script>
import CountriesList from './components/CountriesList.vue';
import Header from './components/Header.vue';

export default {
  name: 'App',
  components: {
    Header,
    CountriesList
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
