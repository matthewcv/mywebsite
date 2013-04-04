(function() {
    candyCount.app = new app();

    function app() {
        this.viewModel = {
            
        };
        var s;
        this.sammy = s = Sammy();
        s.route("GET", "/CandyCount", _index);
        s.route("GET", "/CandyCount/Index", _index);

        s.route("GET", "/CandyCount/Add", _add);

        this.start = function(appRoot) {
            s.element_selector = appRoot;
            s.run();
        };
        



    }

    function _add(ctx) {
        console.log(ctx.path);
    }

    function _index(ctx) {
        console.log(ctx.path);
    }
})();