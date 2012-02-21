$(function () {
    Blog.Page.init();
});

Blog.Page = {
    init: function () {
        console.log('initializing');

        Blog.Page.postRouter = new Blog.Routing.PostRouter();

        Backbone.history.start();
    }
}