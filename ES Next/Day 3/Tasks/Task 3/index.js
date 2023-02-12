let table = document.getElementById("tb");

function Stringify(obj) {
    let str = '';

    for (const prop in obj) {
        str += prop + ": " + obj[prop] + " "
    }

    return str
}

function createHeader(data) {
    let thead = document.createElement("thead");
    let tr = document.createElement("tr");

    Object.keys(data).forEach(function (key) {
        let th = document.createElement("th");
        th.innerHTML = key.toUpperCase();
        tr.appendChild(th);
    });

    thead.appendChild(tr);
    table.appendChild(thead);
}

function createBody(data) {
    let tbody = document.createElement("tbody");

    data.forEach(function (user) {
        let tr = document.createElement("tr");
        Object.values(user).forEach(function (value) {
            let td = document.createElement("td");
            if (typeof value === 'object')
                td.innerHTML = Stringify(value);
            else
                td.innerHTML = value;
            tr.appendChild(td);
        });
        tbody.appendChild(tr);
    });
    table.appendChild(tbody);
    document.body.appendChild(table);
}

function getData() {
    return fetch('https://jsonplaceholder.typicode.com/users')
        .then(response => response.json())

        .catch(error => {
            console.error(error);
        });
}

getData()
    .then(data => {
        createHeader(data[0])
        createBody(data)
    })
    .catch(error => {
        console.error(error);
    });
