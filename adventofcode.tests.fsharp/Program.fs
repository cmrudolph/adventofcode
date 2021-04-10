open Utils
open Year2020

[<EntryPoint>]
let main argv =
    let input = readInput "2020" "22" "sample"
    let ans1, ans2 = Day22.solve input
    printfn "%i" ans1
    printfn "%i" ans2
    0
