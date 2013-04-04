(function() {
    var cc = window.candyCount = {};

    cc.candy = function() {
        this.Id = 0;
        this.Name = ko.observable();
        this.Colors = ko.observableArray();
        this.Total = ko.observable();
    };

    cc.candyColor = function() {
        this.Name = ko.observable();
        this.Total = ko.observable();
    };

    cc.countedCandy = function() {
        this.Id = 0;
        this.Colors = ko.observableArray();

    };

})();