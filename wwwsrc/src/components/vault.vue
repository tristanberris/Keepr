<template>
  <div class="vault col-3 p-3">
   <div class="card text-center">
 
  <div class="card-body">
    <h5 class="card-title">{{vaultData.name}}</h5>
    <p class="card-text">{{vaultData.description}}</p>
    <router-link to="/vault">
    <a href="#" class="btn btn-primary" @click="enterVault()">Enter Vault</a>
    </router-link>
  </div>
    <button type="button" class="close text-middle text-danger" @click="deleteVault()">
          <span>&times;</span>
        </button>
</div>
  </div>
</template>


<script>
export default {
  name: "vault",
  props: ["vaultData"],
  data() {
    return {};
  },
  computed: {},
  methods: {
    deleteVault(){
      this.$store.dispatch("deleteVault", this.vaultData.id)
    },
    enterVault(){
      this.$store.dispatch("getVaultKeepsById", this.vaultData.id)
    }
  },
  components: {}
};
</script>


<style scoped>
</style>