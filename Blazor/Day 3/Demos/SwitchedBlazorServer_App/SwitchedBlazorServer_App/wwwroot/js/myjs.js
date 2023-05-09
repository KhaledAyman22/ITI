function GetName() {
	alert("My Name is Basma :))");
}

function giveMeRandomInt() {
	DotNet.invokeMethodAsync('SwitchedBlazorServer_App', 'GenerateRandomInt')
		.then(result => {
			document.getElementById('randomNumSpan').innerText = result
		});
}

//we have to reference this file in _Host