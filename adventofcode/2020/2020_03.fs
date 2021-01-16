module AOC2020_03

let solveCase input (right, down) =
    let width = List.head input |> List.length

    input
    |> List.mapi (fun i s -> if (i % down) = 0 then s.[((i * right) / down) % width] else '.')
    |> List.filter (fun ch -> ch = '#')
    |> List.length

let calculate input cases =
    cases
    |> List.map (solveCase input)
    |> List.map int64
    |> List.reduce (*)

let solve lines =
    let parsedLines = (lines
    |> Seq.map Seq.toList
    |> Seq.toList)

    let ans1 = calculate parsedLines [(3,1)]
    let ans2 = calculate parsedLines [(1,1);(3,1);(5,1);(7,1);(1,2)]

    (ans1, ans2)