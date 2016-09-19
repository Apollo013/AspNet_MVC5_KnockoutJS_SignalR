/*------------------------------------------------------
View model for 'graphcomponent.html' template
------------------------------------------------------*/
var graph = function (name) {
	this.name = name;
	this.elemId = "#" + name;
	this.data = [];
	this.dataSet = [ { label: this.name, data: this.data } ];
};


graph.prototype = {

	options: {
		yaxis: {
			min: 0,
			max: 100
		},
		xaxis: {
			min: 0,
			max: 100
		},
		colors: ["#6595b4"],
		series: {
			lines: {
				lineWidth: 1,
				fill: true,
				fillColor: {
					colors: [{
						opacity: 0.4
					}, {
						opacity: 0
					}]
				},
				steps: false

			}
		}
	},
	// Updates price list data and redraws the graph
	updateGraph: function (item) {
		var count = this.data.length;
		this.data.push([count, item.Price]);

		// Only show the last 100 updates
		if (count > 100) {
			this.data.shift();
			$.each(this.data, function (idx, item) {
				item[0] = idx;
			});
		}

		// Redraw graph		
		$.plot($(this.elemId), this.dataSet, this.options);
	}
};
