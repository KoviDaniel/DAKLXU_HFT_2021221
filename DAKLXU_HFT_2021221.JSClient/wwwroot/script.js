fetch('http://localhost:17167/rentacar')
    .then(x => x.json())
    .then(y => console.log(y));