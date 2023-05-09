function showMessage(message) {
	alert(message);

	alert("Now I will call you back.")

	DotNet.invokeMethodAsync('Task03', 'SayHiFromJs')
		.then(result => {
			alert(result)
		});
}