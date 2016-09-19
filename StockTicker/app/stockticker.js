(function () {

    /*------------------------------------------------------------------------------
    Stock Ticker Object
    ------------------------------------------------------------------------------*/
    var stockticker = function () {
        this.graphs = ko.observableArray();
        this.init();
    };

    stockticker.prototype = {

        init: function () {
            this.graphs.push(new graph("MKS"));
            this.graphs.push(new graph("AAPL"));
            this.graphs.push(new graph("INTC"));
        },

        updateGraph: function (data) {
            //console.log(data);
            this.graphs()[data.Id].updateGraph(data);
        }
    };


    /*------------------------------------------------------------------------------
    View Binding
    ------------------------------------------------------------------------------*/
    var vm = new stockticker();
    $(function () {
        ko.components.register('graph', { template: { require: 'text!../app/graphcomponent.html' } });
        ko.applyBindings(vm);
    });


    /*------------------------------------------------------------------------------
    Hub Connection
    ------------------------------------------------------------------------------*/    
    var tickerhub = $.connection.stockTickerHub;
    $.connection.hub.logging = true;

    $.connection.hub.start().done(function () {
        // Inform server what tickers we want price updates for
        $.each(vm.graphs(), function (idx, ticker) {
            tickerhub.server.addTicker(idx, ticker.name);
        });
    });

    tickerhub.client.notifyStockChange = function (data) {
        vm.updateGraph(data);
    };

}());