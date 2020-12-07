const fs = require('fs');
const lines = fs.readFileSync('02.txt', 'utf8').split('\n')

var paperAmounts = []
var ribbonAmounts = []

lines.forEach(line => {
    const dims = line.split('x').map(s => parseInt(s)).sort((a, b) => a - b)

    const areas = [dims[0] * dims[1], dims[1] * dims[2], dims[0] * dims[2]].sort((a, b) => a - b)
    const paper = (2 * areas[0]) + (2 * areas[1]) + (2 * areas[2]) + areas[0]
    paperAmounts.push(paper)

    const ribbon = dims[0] + dims[0] + dims[1] + dims[1] + (dims[0] * dims[1] * dims[2])
    ribbonAmounts.push(ribbon);
});

const paperTotal = paperAmounts.reduce((acc, val) => acc + val);
const ribbonTotal = ribbonAmounts.reduce((acc, val) => acc + val);

console.log(paperTotal)
console.log(ribbonTotal)