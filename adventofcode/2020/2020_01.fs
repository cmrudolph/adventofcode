module AOC2020_01

let pairs vals =
    vals |> Seq.collect (fun i -> Seq.map (fun j -> [i; j]) vals)

let triples vals =
    vals |> pairs |> Seq.collect (fun pair -> Seq.map (fun k -> pair @ [k]) vals)

let getSumAndProduct vals =
    vals |> Seq.sum, (1, vals) ||> Seq.fold (*)

let findAnswer generator sumPredicate inputValues =
    inputValues
    |> generator
    |> Seq.map getSumAndProduct
    |> Seq.find (fun (sum, _) -> sumPredicate sum)
    |> (fun (_, product) -> product)
    |> int64

let solve lines =
    let parsedLines = (lines
    |> Seq.map System.Int32.Parse
    |> Seq.toList)

    let ans1 = parsedLines |> findAnswer pairs ((=) 2020)
    let ans2 = parsedLines |> findAnswer triples ((=) 2020)

    (ans1, ans2)