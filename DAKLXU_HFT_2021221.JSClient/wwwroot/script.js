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
    brands.forEach(t =>
    {
        document.getElementById('resultareas').innerHTML +=
            "<tr><td>" + t.brandID + "</td><td>"
            + t.brandName + "</td></tr>";
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