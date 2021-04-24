open Utils
open Year2015

[<EntryPoint>]
let main argv =
    let input = readInput "2015" "07" "sample"
    let ans1, ans2 = Day07.solve input
    printfn "%i" ans1
    printfn "%i" ans2

    let input2 = readInput "2015" "07" "actual"
    let ans3, ans4 = Day07.solve input2
    printfn "%i" ans3
    printfn "%i" ans4
    0
