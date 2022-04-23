let companies = [];
fetch('http://localhost:17167/rentacar')
    .then(x => x.json())
    .then(y => {
        companies = y;
        console.log(companies);
        display();
    });

function display()
{
    companies.forEach(t =>
    {
        document.getElementById('resultareas').innerHTML +=
            "<tr><td>" + t.rentCarID + "</td><td>"
            +t.rentName+"</td><td>"+t.rating+"</td></tr>"
        console.log(t.rentName);
    });
}

function create() {
    fetch('http://localhost:17167/rentacar', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                rentName: name,
                rating: com_rating
            }),
    })
        .then(response => response.json())
        .then(data => {
            console.log('Success:', data);
        })
        .catch((error) => {
            console.error('Error:', error);
        });
    display();
}