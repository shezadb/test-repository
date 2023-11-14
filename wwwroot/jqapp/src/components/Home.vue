// Contact.vue

<template>
<div>
        <Menu />
  <kpvitem />
</div>

</template>

<script>
  import Menu from "../Menu.vue";
  import kpvitem from "./kpvitem";
  export default {
  components: { kpvitem, Menu },

  }
</script>