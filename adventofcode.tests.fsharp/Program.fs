open Utils
open Year2015

[<EntryPoint>]
let main argv =
    let input = readInput "2015" "05" "sample"
    let ans1, ans2 = Day05.solve input
    printfn "%i" ans1
    printfn "%i" ans2

    let input2 = readInput "2015" "05" "actual"
    let ans3, ans4 = Day05.solve input2
    printfn "%i" ans3
    printfn "%i" ans4
    0
