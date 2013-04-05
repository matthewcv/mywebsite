(function() {
    candyCount.app = new app();
    var cc = candyCount;
    
    function app() {
        this.viewModel = {
            countedCandy: ko.observable(),//an instance of cc.countedCandy
            candyType: ko.observable(),//an instance of cc.candy used for adding a new candy to the system.  m&m's, skittles, etc.
            candyTypes:ko.observableArray()//an array of cc.candy used for selecting which candy you want to add a count for.
        };
        this.sammy = _sammy();

        this.start = function(appRoot) {
            this.sammy.element_selector = appRoot;
            this.sammy.run();
            ko.applyBindings(this.viewModel, $(appRoot)[0]);
        };
        



    }
    
    function _sammy() {
        return Sammy()
        .route("GET", "/CandyCount", _index)
        .route("GET", "/CandyCount/Index", _index)

        .route("GET", "/CandyCount/Add", _add);
       
    }

    function _add(ctx) {
        var vm = cc.app.viewModel;

        vm.countedCandy(new cc.countedCandy());
    }

    function _index(ctx) {
        var vm = cc.app.viewModel;
        vm.countedCandy(null);
    }
})();