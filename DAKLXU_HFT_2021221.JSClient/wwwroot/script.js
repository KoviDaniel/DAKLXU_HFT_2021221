let brands = [];

getdata();

async function getdata() {
    await fetch('http://localhost:17167/brand')
        .then(x => x.json())
        .then(y => {
            brands = y;
            console.log(brands);
            display();
        });
}


function display()
{
    document.getElementById('resultareas').innerHTML = "";
    brands.forEach(t =>
    {
        document.getElementById('resultareas').innerHTML +=
            "<tr><td>" + t.brandID + "</td><td>"
        + t.brandName + "</td><td>" +
        `<button type="button" onclick="remove(${t.brandID})">Remove</button>` + "</td><td>" +
        `<button type="button" onclick="updateBrand(${t.brandID})">Update</button>`
        +"</td ></tr > ";
    });
}

function updateBrand(id) {
    let newName = document.getElementById('brandname').value;
    fetch('http://localhost:17167/brand/'+id, {
        method: 'UPDATE',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                brandName: name
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}

function remove(id) {
    fetch('http://localhost:17167/brand/'+id, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
        },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}

function createBrand() {
    let name = document.getElementById('brandname').value;
    fetch('http://localhost:17167/brand', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                brandName: name
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}