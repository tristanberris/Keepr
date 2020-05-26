<template>
  <div class="vault col-3 p-3">
   <a href="" class="dropdown-item">
     {{vaultData.name}}

     </a>
  </div>
</template>


<script>
export default {
  name: "vaultName",
  props: ["vaultData"],
  data() {
    return {};
  },
  computed: {},
  methods: {
    
  },
  components: {}
};
</script>


<style scoped>
</style>