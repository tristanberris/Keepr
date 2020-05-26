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
  </div>
</template>


<script>
export default {
  name: "keep",
  props: ["keepData"],
  data() {
    return {};
  },

  computed: {},
  methods: {
    deleteKeep() {
      this.$store.dispatch("deleteKeep", this.keepData.id);
    }
  },
  components: {}
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