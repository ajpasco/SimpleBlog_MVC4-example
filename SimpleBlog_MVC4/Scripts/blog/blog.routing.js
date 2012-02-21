Blog.Routing.PostRouter = Backbone.Router.extend({
    routes: {
        "view/:id": "select"
    },
    initialize: function () {
        var posts = new Blog.Collections.Posts();

        posts.fetch();
        new Blog.Views.PostList({ collection: posts });
    },
    select: function () {

    }
});