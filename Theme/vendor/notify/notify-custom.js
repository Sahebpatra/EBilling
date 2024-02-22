// Notify examples

//var notes = $('#notes').notify({
//	removeIcon: '<i class="icon-close"></i>'
//});

$('.add-noti').on('click', function() {
	notes.show("I'm a notification I will quickly alert you as well!", {
		title: 'Hello',
	});
});

$('.add-success-noti').on('click', function() {
	notes.show("I'm a notification I will quickly alert you as well!", {
		type: 'success',
		title: 'E-Bidding',
		icon: '<i class="icon-sentiment_satisfied"></i>'
	});
});

$('.add-info-noti').on('click', function() {
	notes.show("I'm a notification I will quickly alert you as well!", {
		type: 'info',
		title: 'E-Bidding',
		icon: '<i class="icon-alert-circle"></i>'
	});
});

$('.add-warning-noti').on('click', function() {
	notes.show("I'm a notification I will quickly alert you as well!", {
		type: 'warning',
		title: 'E-Bidding',
		icon: '<i class="icon-alert-octagon"></i>'
	});
});

$('.add-danger-noti').on('click', function() {
	notes.show("I'm a notification I will quickly alert you as well!", {
		type: 'danger',
		title: 'E-Bidding',
		icon: '<i class="icon-alert-triangle"></i>'
	});
});

$('.add-sticky-noti').on('click', function() {
	notes.show("I'm a notification I will quickly alert you as well!", {
		title: 'E-Bidding',
		icon: '<i class="icon-alert-circle"></i>',
		sticky: true
	});
});




/*************************
	*************************
	*************************
	*************************
	Fixed on Top
	*************************
	*************************
	*************************
	*************************/

//var messages = $('#messages').notify({
//	type: 'messages',
//	removeIcon: '<i class="icon-close"></i>'
//});

$('.add-message').on('click', function() {
	messages.show("I'm a message and I will quickly alert you", {
		title: 'Hello,',
	});
});

$('.add-success-message').on('click', function() {
	messages.show("I'm a message and I will quickly alert you", {
		type: 'success',
		title: 'Hello,',
		icon: '<i class="icon-sentiment_satisfied"></i>'
	});
});

$('.add-info-message').on('click', function() {
	messages.show("I'm a message and I will quickly alert you", {
		type: 'info',
		title: 'Hello,',
		icon: '<i class="icon-alert-circle"></i>'
	});
});

$('.add-warning-message').on('click', function() {
	messages.show("I'm a message and I will quickly alert you", {
		type: 'warning',
		title: 'Hello,',
		icon: '<i class="icon-alert-octagon"></i>'
	});
});

$('.add-danger-message').on('click', function() {
	messages.show("I'm a message and I will quickly alert you", {
		type: 'danger',
		title: 'Hello,',
		icon: '<i class="icon-alert-triangle"></i>'
	});
});

$('.add-sticky-message').on('click', function() {
	messages.show("I'm a message and I will quickly alert you", {
		title: 'Hello,',
		sticky: true
	});
});

function LoginShowErrorMessage(message) {
	var messages1 = $('#messages').notify({
		type: 'messages',
		removeIcon: '<i class="icon-close"></i>'
	});

	messages1.show(message, {
		type: 'danger',
		title: 'E-Bidding,',
		icon: '<i class="icon-alert-triangle"></i>'
	});
}


function ShowInfoMessage(message) {

	var notesInfo = $('#notes').notify({
		removeIcon: '<i class="icon-close"></i>'
	});

	notesInfo.show(message, {
		type: 'info',
		title: 'E-Bidding',
		icon: '<i class="icon-alert-circle"></i>'
	});
}

function ShowWarningMessage(message) {

	var notesWarning = $('#notes').notify({
		removeIcon: '<i class="icon-close"></i>'
	});

	notesWarning.show(message, {
		type: 'warning',
		title: 'E-Bidding',
		icon: '<i class="icon-alert-octagon"></i>'
	});
}

function ShowSuccessMessage(message) {

	var notesSuccess = $('#notes').notify({
		removeIcon: '<i class="icon-close"></i>'
	});

	notesSuccess.show(message, {
		type: 'success',
		title: 'E-Bidding',
		icon: '<i class="icon-sentiment_satisfied"></i>'
	});
}

function ShowDangerMessage(message) {
	
	var notesDanger = $('#notes').notify({
		removeIcon: '<i class="icon-close"></i>'
	});

	notesDanger.show(message, {
		type: 'danger',
		title: 'E-Bidding',
		icon: '<i class="icon-alert-triangle"></i>'
	});
}


