function displayData() {
    const urlParams = new URLSearchParams(location.search);
    urlParams.get(name);
    document.body.innerHTML += `<h2> Welcome ${urlParams.get('name')}<\h2>`
    document.body.innerHTML += `<h3> Gender: ${urlParams.get('gender')}<\h3>`
    document.body.innerHTML += `<h3> Address: ${urlParams.get('address')}<\h3>`
    document.body.innerHTML += `<h3> Email: ${urlParams.get('email')}<\h3>`
    document.body.innerHTML += `<h3> Mobile: ${urlParams.get('mobile')}<\h3>`

}
