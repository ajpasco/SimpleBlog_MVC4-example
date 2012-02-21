Blog.Views.PostList = Backbone.View.extend({
   events: {
       "click btnEdit": "editPost"
   },
   initialize: function () {
       var source = $("#postlist-template").html();
       this.template = Handlebars.compile(source);
   },
   editPost: function () {
       
   }
});