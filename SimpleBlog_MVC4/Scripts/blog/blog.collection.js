Blog.Collections.Posts = Backbone.Collection.extend({
    model: Blog.Models.Post,
    url: "api/posts"
})