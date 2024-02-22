var options = {
	chart: {
		type: 'donut',
		height: 250,
	},
	legend: {
		position: "bottom",
		offsetY: 10,
	},
	dataLabels: {
		enabled: false
  },
	labels: ['Buy', 'Sell', 'Keep'],
	series: [20, 70, 30],
	stroke: {
		width: 0,
	},
	colors: ['#074b9c', '#00a9e2', '#ec4842', '#fc9709'],
}
var chart = new ApexCharts(
	document.querySelector("#donut-volume-currency"),
	options
);
chart.render();