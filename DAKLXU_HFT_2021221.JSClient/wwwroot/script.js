fetch('http://localhost:8551/rentacar')
    .then(x => x.json())
    .then(y => console.log(y));