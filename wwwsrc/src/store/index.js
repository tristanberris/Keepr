import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "../router";
import { authProvider } from "@bcwdev/auth0-vue/AuthProvider";

Vue.use(Vuex);

let baseUrl = location.host.includes("localhost")
  ? "https://localhost:5001/"
  : "/";

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
});

export default new Vuex.Store({
  state: {
    publicKeeps: [],
    posts: [],
    vaults: [],
    vaultKeeps: []
  },
  mutations: {
    setPosts(state, posts){
      state.posts = posts
    },
    setVaults(state, vaults){
      state.vaults = vaults
    },
    setVaultKeeps(state, vaultKeeps){
      state.vaultKeeps = vaultKeeps
    }
  },
  actions: {
    setBearer({}, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },
    async addPost({commit, dispatch}, keepData){
      try {
        let res = await api.post("Keeps", keepData)
        dispatch("getPosts")
        console.log(res)
      } catch (error) {
        console.error(error)
      }
    },
    async getPosts({commit, dispatch}){
      try {
        let res = await api.get('Keeps')
        commit("setPosts", res.data)
        console.log(res.data)
      } catch (error) {
        console.error(error)
      }
    },
    async deleteKeep({commit, dispatch}, keepId){
      try {
        await api.delete("Keeps/" + keepId)    
      } catch (error) {
        console.error(error)
      }
    },
    async getVaults({commit, dispatch}){
      try {
        let res = await api.get('Vaults')
        // console.log(res.data)
        commit("setVaults", res.data)
      } catch (error) {
        console.error(error)
      }
    },
    async addVault({commit, dispatch}, vaultData){
      try { 
        // console.log(vaultData)
        let res = await api.post("Vaults", vaultData)
        // dispatch("getVaults")
      } catch (error) {
        console.error(error)
      }
    },
    async deleteVault({commit, dispatch}, vaultId){
      try {
        await api.delete("Vaults/" + vaultId)
      } catch (error) {
        console.error(error)
      }
    },
    async getVaultKeepsById({commit, dispatch}, vaultKeepId){
      try {
        let res = await api.get("VaultKeep/" + vaultKeepId)
        console.log(res.data)
        commit("setVaultKeeps", res.data)
      } catch (error) {
        console.error(error)
      }
    }
  }
});
