let readInput year problem =
    System.IO.File.ReadAllLines($"../../../../input/{year}/{problem}.txt")

let solveAndPrint year problem solver =
    let lines = readInput year problem
    let (result1, result2) = solver lines
    printfn "%i" result1
    printfn "%i" result2

[<EntryPoint>]
let main argv =
    solveAndPrint "2020" "05" AOC2020_05.solve 
    0
