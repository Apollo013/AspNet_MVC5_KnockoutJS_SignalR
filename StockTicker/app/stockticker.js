(function () {

    /*------------------------------------------------------------------------------
    Stock Ticker Object
    ------------------------------------------------------------------------------*/
    var stockticker = function () {
        this.graphs = ko.observableArray();
        this.init();
    };

    stockticker.prototype = {

        // Crete stock items to get price updates for
        init: function () {
            this.graphs.push(new graph("MKS"));
            this.graphs.push(new graph("AAPL"));
            this.graphs.push(new graph("INTC"));
        },

        // Updates the price for a stock item
        updateGraph: function (data) {
            this.graphs()[data.Id].updateGraph(data);
        }
    };


    /*------------------------------------------------------------------------------
    View Binding
    ------------------------------------------------------------------------------*/
    var vm = new stockticker();
    console.log("vm: " + vm);

    ko.components.register('graph', { template: { require: 'text!../app/graphcomponent.html' } });
    ko.applyBindings(vm);


    /*------------------------------------------------------------------------------
    Hub Connection
    ------------------------------------------------------------------------------*/    
    var tickerhub = $.connection.stockTickerHub;
    $.connection.hub.logging = true;

    $.connection.hub.start().done(function () {
        console.log("start");
        // Inform server what tickers we want price updates for
        $.each(vm.graphs(), function (idx, ticker) {
            tickerhub.server.addTicker(idx, ticker.name);
        });
    });

    // Update stock price received from server
    tickerhub.client.notifyStockChange = function (data) {
        console.log("notifyStockChange");
        vm.updateGraph(data);
    };

}());