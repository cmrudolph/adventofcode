namespace ``2020``

module ``Day 10`` =
    open Utils
    open Xunit

    let updateAt targetIdx func lst =
        lst |> List.mapi (fun idx value -> if idx = targetIdx then (func value) else value)

    let diffAndCount counts (small, big) =
        printfn "%A %A" small big
        let diff = big - small
        let idx = diff - 1L |> int
        let increment x = x + 1L
        counts |> updateAt idx increment

    let parseAndAugment (lines : string[]) =
        let nums = (lines
        |> List.ofArray
        |> List.map System.Int64.Parse
        |> List.sort)

        // Implicit elements - always start with 0 and end with (max + 3)
        [0L] @ nums @ [(List.last nums) + 3L]

    let numPathsFrom pathMap fromValue =
        match Map.tryFind fromValue pathMap with
        | Some x -> x
        | None -> 0L

    let numPathsTo pathMap targetValue =
        [1L..3L]
        |> List.map (fun i -> targetValue + i)
        |> List.sumBy (numPathsFrom pathMap)
        |> int64

    let solve1 nums =
        let pairs = nums |> List.pairwise
        let counts = ([0L; 0L; 0L], pairs) ||> List.fold diffAndCount
        counts.[0] * counts.[2] |> int64

    let solve2 nums =
        let numsDescending = nums |> List.sortDescending
        let pathMap = Map.empty |> Map.add numsDescending.[0] 1L
        let tail = numsDescending |> List.tail
        let finalPaths = (pathMap, tail) ||> List.fold (fun acc x -> acc |> Map.add x (numPathsTo acc x))
        finalPaths |> Map.find 0L |> int64

    let solve (lines : string[]) =
        let nums = lines |> parseAndAugment

        let ans1 = nums |> solve1
        let ans2 = nums |> solve2

        (ans1, ans2)

    [<Fact>]
    let ``2020-10 Sample`` () =
        readInput "2020" "10" "sample" |> solveAndValidate (35L, 8L) solve

    [<Fact>]
    let ``2020-10 Actual`` () =
        readInput "2020" "10" "actual" |> solveAndValidate (1876L, 14173478093824L) solve