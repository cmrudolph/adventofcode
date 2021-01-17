let readInput year problem =
    System.IO.File.ReadAllLines($"../../../../input/{year}/{problem}.txt")

let solveAndPrintFile year problem solver =
    let lines = readInput year problem
    let (result1, result2) = solver lines
    printfn "%i" result1
    printfn "%i" result2

let solveAndPrint lines solver =
    let (result1, result2) = solver lines
    printfn "%i" result1
    printfn "%i" result2

[<EntryPoint>]
let main argv =
    //solveAndPrintFile "2015" "03" AOC2015_03.solve 
    solveAndPrint [|"^v^v^v^v^v"|] AOC2015_03.solve 
    0
