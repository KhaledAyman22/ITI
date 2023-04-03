$("#getUsers").on("click", () => {
    fetch('/getUsers')
        .then(response => response.json())
        .then(data => {
            GetUsersTable(data);
        })
        .catch(error => {
            console.log(error)
        });
})

function GetUsersTable(users) {
    const div1 = document.createElement('div');
    div1.id = 'usersTable'
    div1.className = "row d-flex align-items-center justify-content-center";

    const div2 = document.createElement('div');
    div2.className = "col-md-10";

    const table = document.createElement('table');
    table.className = 'table table-striped mt-5';

    const thead = document.createElement('thead');
    const headerRow = document.createElement('tr');
    headerRow.innerHTML = '<th>Name</th><th>Mobile</th><th>Email</th><th>Address</th>';
    thead.appendChild(headerRow);
    table.appendChild(thead);

    const tbody = document.createElement('tbody');
    users.forEach((user) => {
        const row = document.createElement('tr');
        row.innerHTML = `<td>${user.name}</td><td>${user.mobile}</td><td>${user.email}</td><td>${user.address}</td>`;
        tbody.appendChild(row);
    });
    table.appendChild(tbody);

    div2.appendChild(table);
    div1.appendChild(div2);

    let t = document.getElementById('usersTable');
    if(t) t.remove();
    document.getElementById('cont').appendChild(div1);
}
