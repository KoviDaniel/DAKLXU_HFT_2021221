﻿let brands = [];
let connection = null;
getdata();
setupSignalR();

async function getdata() {
    await fetch('http://localhost:17167/brand')
        .then(x => x.json())
        .then(y => {
            brands = y;
            //console.log(brands);
            display();
        });
}

function setupSignalR()
{
     connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:17167/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on
    (
        "BrandCreated", (user, message) => {
            getdata();
        }
    );
    connection.on
        (
            "BrandDeleted", (user, message) => {
                getdata();
            }
    );
    connection.on
        (
            "BrandUpdated", (user, message) => {
                getdata();
            }
        );
    connection.onclose
        (async () => {
            await start();
        });
    start();

}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
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
    let upd = null;
    brands.forEach(t => {
        if (t.brandID == id) {
            upd = t;
            upd.brandName = newName;
        }
    });
    upd.brandName = newName;
    fetch('http://localhost:17167/brand', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(upd)
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