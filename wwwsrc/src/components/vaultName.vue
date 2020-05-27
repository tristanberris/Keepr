<template>
  <div class="vault col-3 p-3">
   <a  class="dropdown-item" @click="addToVault()">
     {{vaultData.name}}
     
     </a>
  </div>
</template>


<script>
// import keep from "../components/keep"
export default {
  name: "vaultName",
  props: ["vaultData", "keep"], 

  data() {
    return {
      vaultKeepData: {vaultId: this.vaultData.id.toString(), keepId: this.keep.id.toString()}
    };
  },
  computed: {},
  mounted(){
    // console.log(vaultData)
  },
  methods: {
    addToVault(){
      this.$store.dispatch("addToVault", this.vaultKeepData)
      // console.log(keepData)
    }
  },
  components: {}
};
</script>


<style scoped>
</style>