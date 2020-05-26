<template>
  <div class="vaultKeeps col-4">

      <div class="card bg-dark text-white shadow">
        <img :src="vaultKeepData.img" class="card-img image-size" alt="..." />
        <div class="card-img-overlay text-center">
          <h5 class="card-title align-middle">{{vaultKeepData.name}}</h5>
          <p class="card-text">{{vaultKeepData.description}}</p>
        </div>
        <!-- <button type="button" class="close text-middle text-danger" @click="deleteKeep()">
          <span>&times;</span>
        </button> -->
    </div>
  </div>
</template>


<script>
export default {
  name: "vaultKeeps",
  props: ["vaultKeepData"],
  data() {
    return {};
  },
  computed: {},
  methods: {},
  components: {}
};
</script>


<style scoped>
</style>