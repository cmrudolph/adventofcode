open Utils
open Year2020

[<EntryPoint>]
let main argv =
    let input = readInput "2020" "23" "actual"
    let ans1, ans2 = Day23.solve input
    printfn "%s" ans1
    printfn "%s" ans2
    0
