<template>
  <div>
      <!-- <router-link to="/">Home</router-link>
      <router-link to="/About">About</router-link>
      <router-link to="/Home">Home</router-link> -->
      <router-view></router-view>
  </div>
 
</template>

<script>
  import JqxGrid from "jqwidgets-scripts/jqwidgets-vue/vue_jqxgrid.vue";
  import JqxButton from 'jqwidgets-scripts/jqwidgets-vue/vue_jqxbuttons.vue';
  import Menu from "./Menu.vue";
  import kpvitem from "./components/kpvitem.vue";
  //import store from './Shared/store.js'

  
 export default {
    components: {
      JqxGrid, Menu, JqxButton,kpvitem, 

    },

    
  }
</script>

<style src='./assets/styles/jqwidgets/jqx.base.css'></style>
<style src='./assets/styles/jqwidgets/jqx.bootstrap.css'></style>