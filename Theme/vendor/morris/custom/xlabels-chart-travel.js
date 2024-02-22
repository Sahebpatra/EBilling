// Displaying X Labels Diagonally (Bar Chart)
var day_data = [
	{"period": "Jan", "Booked": 400, "Cancelled": 82},
	{"period": "Feb", "Booked": 540, "Cancelled": 132},
	{"period": "Mar", "Booked": 300, "Cancelled": 22},
	{"period": "Apr", "Booked": 460, "Cancelled": 12},
	{"period": "May", "Booked": 600, "Cancelled": 52},
	{"period": "June", "Booked": 230, "Cancelled": 12},
	{"period": "July", "Booked": 120, "Cancelled": 43},
	{"period": "Aug", "Booked": 710, "Cancelled": 256},
	{"period": "Sept", "Booked": 535, "Cancelled": 109},
	{"period": "Oct", "Booked": 876, "Cancelled": 234},
	{"period": "Nov", "Booked": 290, "Cancelled": 21},
	{"period": "Dec", "Booked": 670, "Cancelled": 62},
];
Morris.Bar({
	element: 'xlabels-chart-travel',
	data: day_data,
	xkey: 'period',
	ykeys: ['Booked', 'Cancelled'],
	labels: ['Booked', 'Cancelled'],
	gridLineColor: "#e4e6f2",
	resize: true,
	hideHover: "auto",
	barColors:['#074b9c', '#00a9e2', '#ec4842', '#fc9709'],
});




