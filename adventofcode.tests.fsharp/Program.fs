open Utils
open Year2020

[<EntryPoint>]
let main argv =
    let input = readInput "2020" "12" "sample"
    let ans1, ans2 = Day12.solve input
    printfn "%i" ans1
    printfn "%i" ans2

    let input2 = readInput "2020" "12" "actual"
    let ans3, ans4 = Day12.solve input2
    printfn "%i" ans3
    printfn "%i" ans4
    0
