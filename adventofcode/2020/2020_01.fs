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

let solve2 lst =
    [for x in lst do
     for y in lst do
     if (x + y = 2020) then
        yield x * y]

let solve3 lst =
    [for x in lst do
     for y in lst do
     for z in lst do
     if (x + y + z = 2020) then
        yield x * y * z]

let solve lines =
    let parsedLines = (lines
    |> Seq.map System.Int32.Parse
    |> Seq.toList)

    // Generalized solution, but not very efficient
    //let ans1 = calculate 2 parsedLines
    //let ans2 = calculate 3 parsedLines

    // Very specific iterative solution that runs a lot faster
    let ans1 = solve2 parsedLines |> List.head |> int64
    let ans2 = solve3 parsedLines |> List.head |> int64

    (ans1, ans2)