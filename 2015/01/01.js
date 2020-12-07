const fs = require('fs')

fs.readFile('01.txt', 'utf8', (_, data) => {
    let floor = 0;
    let basementPos = -1;
    [...data].forEach((ch, idx) => {
        floor += ch === '(' ? 1 : -1
        if (floor < 0 && basementPos == -1) {
            basementPos = idx + 1;
        }
    })
    console.log(floor)
    console.log(basementPos)
})