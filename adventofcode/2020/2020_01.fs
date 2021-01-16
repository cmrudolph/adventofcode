module AOC2020_01

let rec comb n lst =
    match n, lst with
    | 0, _ -> [[]]
    | _, [] -> []
    | k, (x::xs) -> List.map ((@) [x]) (comb (k-1) xs) @ comb k xs

let calculate n input =
    comb n input
    |> List.map (fun lst -> (List.reduce (+) lst), (List.reduce (*) lst))
    |> List.filter (fun (sum, _) -> sum = 2020)
    |> List.head
    |> (fun (_, product) -> int64 product)

let solve lines =
    let parsedLines = (lines
    |> Seq.map System.Int32.Parse
    |> Seq.toList)

    let ans1 = calculate 2 parsedLines
    let ans2 = calculate 3 parsedLines

    (ans1, ans2)