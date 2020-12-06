let readInput =
    System.IO.File.ReadLines("01.txt")
    |> Seq.map System.Int32.Parse
    |> Seq.toList

let rec comb n lst =
    match n, lst with
    | 0, _ -> [[]]
    | _, [] -> []
    | k, (x::xs) -> List.map ((@) [x]) (comb (k-1) xs) @ comb k xs

let solve n input =
    comb n input
    |> List.map (fun lst -> (List.reduce (+) lst), (List.reduce (*) lst))
    |> List.filter (fun (sum, _) -> sum = 2020)
    |> List.head
    |> (fun (_, product) -> printfn "%i" product)

readInput |> solve 2
readInput |> solve 3
