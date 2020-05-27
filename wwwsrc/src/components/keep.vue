<template>
  <div class="keep col-4">
    <div class="card bg-dark text-white shadow">
      <img :src="keepData.img" class="card-img image-size" alt="..." />
      <div class="card-img-overlay text-center">
        <h5 class="card-title align-middle">{{keepData.name}}</h5>
        <p class="card-text">{{keepData.description}}</p>
      </div>
      <button type="button" class="close text-middle text-danger" @click="deleteKeep()">
        <span>&times;</span>
      </button>
    </div>
    <!-- Button trigger modal -->
    <button
      type="button"
      class="btn btn-primary"
      data-toggle="modal"
      :data-target="'#keepModal-'+keepData.id"
    >Add to Vault</button>

    <!-- Modal -->
    <div
      class="modal fade"
      :id="'keepModal-'+keepData.id"
      tabindex="-1"
      role="dialog"
      aria-labelledby="exampleModalCenterTitle"
      aria-hidden="true"
    >
      <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalCenterTitle">Add to Vault</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <div class="dropdown">
              <button
                class="btn btn-secondary dropdown-toggle"
                type="button"
                id="dropdownMenuButton"
                data-toggle="dropdown"
                aria-haspopup="true"
                aria-expanded="false"
              >Vaults</button>
              <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                <vaultName v-for="vault in Vaults" :vaultData="vault" :keep="keepData" :key="vault.id"></vaultName>
              </div>
            </div>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
          
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import vaultName from "../components/vaultName";
export default {
  name: "keep",
  props: ["keepData"],
  data() {
    return {
      vaultKeepData: {  }
    };
  },
  mounted() {
    this.$store.dispatch("getVaults");
    console.log(this.$store.state.vaults);
  },

  computed: {
    Vaults() {
      return this.$store.state.vaults;
    },

  },
  methods: {
    deleteKeep() {
      this.$store.dispatch("deleteKeep", this.keepData.id);
    }
  },
  components: {
    vaultName
  }
};
</script>


<style scoped>
.image-size {
  /* display: block;
  max-width:230px;
  max-height:400px;
  width: auto;
  height: auto; */
}
</style>