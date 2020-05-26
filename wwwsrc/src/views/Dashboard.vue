<template>
  <div class="dashboard container-fluid">
    <h1>WELCOME TO THE DASHBOARD</h1>
    <!-- public {{ publicKeeps }} user {{ userKeeps }} -->
     <!-- Modal -->
     <button
      type="button"
      class="btn btn-primary"
      data-toggle="modal"
      data-target="#exampleModalCenter"
    >Create Vault</button>
    <div
      class="modal fade"
      id="exampleModalCenter"
      tabindex="-1"
      role="dialog"
      aria-labelledby="exampleModalCenterTitle"
      aria-hidden="true"
    >
      <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLongTitle">Create Vault</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <form @submit.prevent="addVault()">
              <div class="form-group">
                <label for="exampleInputEmail1">Vault Name</label>
                <input
                  type="text"
                  class="form-control"
                  id="exampleInputEmail1"
                  aria-describedby="emailHelp"
                  placeholder="Enter vault name..."
                  v-model="newVault.name"
                
                />
              </div>
              <div class="form-group">
                <label for="exampleInputEmail1">Description</label>
                <input
                  type="text"
                  class="form-control"
                  id="exampleInputEmail1"
                  aria-describedby="emailHelp"
                  placeholder="Enter vault name..."
                  v-model="newVault.description"
                
                />
              </div>
             
              <button type="submit" class="btn btn-primary">Submit</button>
            </form>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
          </div>
        </div>
      </div>
    </div>
    <!-- end modal -->
    <div class="row">
    <vault v-for="vault in Vaults" :vaultData="vault" :key="vault.id"></vault>
    </div>
  </div>
</template>

<script>
import vault from "../components/vault"
export default {
  name: "dashboard",
  data(){
    return{
      newVault:{}
    };
  },
  mounted() {
    this.$store.dispatch("getVaults")
  },
  computed: {
    Vaults(){
      return this.$store.state.vaults
    }
  },
  methods: {
    addVault(){
      this.$store.dispatch('addVault', this.newVault)
    }
  },
  components: {
    vault
  }
};
</script>

<style></style>
