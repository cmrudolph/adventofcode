module AOC2020_09

let getPossibleSums (nums : int64 array) =
    let sumIfDifferentValue x y =
        if x <> y then Some (x + y)
        else None

    let sumWithAllOtherValues x =
        nums |> Seq.map (sumIfDifferentValue x)

    nums
    |> Seq.collect sumWithAllOtherValues
    |> Seq.choose id
    |> Set.ofSeq

let rec sumRange startIdx size target nums =
    let sum = Array.sub nums startIdx size |> Array.sum

    match sum with
    | sum when sum = target -> (startIdx, size)
    | sum when sum < target -> sumRange startIdx (size + 1) target nums
    | sum when sum > target -> sumRange (startIdx + 1) 2 target nums
    | _ -> failwith "match failure"

let solve1 nums =
    let windows = nums |> Array.windowed 25
    let sets = windows |> Array.map getPossibleSums

    nums
    |> Array.skip 25
    |> Array.mapi (fun i value -> if Set.contains value sets.[i] then None else Some value)
    |> Array.choose id
    |> Array.head
    |> int64

let solve2 target nums =
    let startIdx, size = nums |> sumRange 0 2 target
    
    let slice = Array.sub nums startIdx size
    let min = slice |> Array.min
    let max = slice |> Array.max

    min + max |> int64

let solve (lines : string[]) =
    let nums = lines |> Seq.map System.Int64.Parse|> Array.ofSeq

    let ans1 = nums |> solve1
    let ans2 = nums |> solve2 ans1

    (ans1, ans2)