let readInput =
    System.IO.File.ReadLines("03.txt")
    |> Seq.map Seq.toList
    |> Seq.toList

let solveCase input (right, down) =
    let width = List.head input |> List.length

    input
    |> List.mapi (fun i s -> if (i % down) = 0 then s.[((i * right) / down) % width] else '.')
    |> List.filter (fun ch -> ch = '#')
    |> List.length

let solve input cases =
    cases
    |> List.map (solveCase input)
    |> List.map int64
    |> List.reduce (*)
    |> printfn "%i"

let input = readInput

[(3,1)] |> solve input
[(1,1);(3,1);(5,1);(7,1);(1,2)] |> solve input
