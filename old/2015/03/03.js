const fs = require('fs')

function makeKey(x, y) {
    return x.toString() + "|" + y.toString()
}

function solve (numSantas) {
    fs.readFile('03.txt', 'utf8', (_, data) => {
        let visits = new Map()
        let idx = 0;
        let x = Array(numSantas).fill(0);
        let y = Array(numSantas).fill(0);

        visits.set(makeKey(0, 0), 1);
        [...data].forEach((ch, _) => {
            if (ch === '^') { y[idx]-- }
            if (ch === '>') { x[idx]++ }
            if (ch === 'v') { y[idx]++ }
            if (ch === '<') { x[idx]-- }
            visits.set(makeKey(x[idx], y[idx]), 1);

            idx++
            if (idx === numSantas) {
                idx = 0
            }
        })

        console.log(visits.size)
    })
}

solve(1)
solve(2)