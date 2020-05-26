<template>
  <div class="home container-fluid">
    <h1>This is the homepage :)</h1>
    <!-- Button trigger modal -->
    <button
      type="button"
      class="btn btn-primary"
      data-toggle="modal"
      data-target="#exampleModalCenter"
    >Add Post</button>

    <!-- Modal -->
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
            <h5 class="modal-title" id="exampleModalLongTitle">Add Post</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <form @submit.prevent="addPost()">
              <div class="form-group">
                <label for="exampleInputEmail1">Title</label>
                <input
                  type="text"
                  class="form-control"
                  id="exampleInputEmail1"
                  aria-describedby="emailHelp"
                  placeholder="Enter title..."
                  v-model="newPost.name"
                />
              </div>
              <div class="form-group">
                <label for="exampleInputPassword1">Image URL</label>
                <input
                  type="text"
                  class="form-control"
                  id="exampleInputPassword1"
                  placeholder="Image URL"
                  v-model="newPost.img"
                />
              </div>
              <div class="form-group">
                <label for="exampleInputPassword1">Description</label>
                <input
                  type="text"
                  class="form-control"
                  id="exampleInputPassword1"
                  placeholder="Description..."
                  v-model="newPost.description"
                />
              </div>
              <div class="form-check">
                <input
                  type="checkbox"
                  class="form-check-input"
                  id="exampleCheck1"
                  v-model="newPost.isPrivate"
                />
                <label class="form-check-label" for="exampleCheck1">Make public?</label>
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
      <!-- <div class="col-3"> -->
       <keep v-for="keep in Keeps" :keepData="keep" :key="keep.id"></keep>

      </div>
    </div>

</template>

<script>
import keep from "../components/keep";
export default {
  name: "home",
  data() {
    return {
      newPost: {}
    };
  },
  mounted(){
      this.$store.dispatch("getPosts")
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    Keeps(){
      return this.$store.state.posts;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
    addPost() {
      console.log(this.newPost);
      this.$store.dispatch("addPost", this.newPost);
    }
  },
  components: {
    keep
  }
};
</script>
