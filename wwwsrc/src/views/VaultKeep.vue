<template>
    <div class="VaultKeep">
        <div class="row">
      <!-- <div class="col-3"> -->
       <vaultKeep v-for="vaultKeep in VaultKeeps" :vaultKeepData="vaultKeep" :key="vaultKeep.id"></vaultKeep>

      </div>

    </div>
</template>


<script>
    import vaultKeep from "../components/vaultKeeps";
export default {
    name: 'VaultKeep',
    data(){
        return {}
    },
    computed:{
        VaultKeeps(){
            return this.$store.state.vaultKeeps }
    },
    methods:{},
    components:{
        vaultKeep
    }
}
</script>


<style scoped>

</style>