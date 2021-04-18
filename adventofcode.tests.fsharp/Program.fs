open Utils
open Year2015

[<EntryPoint>]
let main argv =
    let input = readInput "2015" "06" "sample"
    let ans1, ans2 = Day06.solve input
    printfn "%i" ans1
    printfn "%i" ans2

    let input2 = readInput "2015" "06" "actual"
    let ans3, ans4 = Day06.solve input2
    printfn "%i" ans3
    printfn "%i" ans4
    0
