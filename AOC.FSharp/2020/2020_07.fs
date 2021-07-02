namespace AOC.FSharp

module AOC2020_07 =
    open System
    open System.Text.RegularExpressions

    let regexNonLeaf = new Regex("(.*) bags contain (.*)\\.")
    let regexLeaf = new Regex("(.*) bags contain no other bags.")
    let regexUnpackContents = new Regex("(\\d+) (.*) bag")

    type Bag =
        { Color: string;
          Quantity: int }

    let parseBagStatement (str : string) =
        let splits = str.Split([|' '|], StringSplitOptions.RemoveEmptyEntries)
        let number = int(splits.[0])
        let color = splits.[1] + " " + splits.[2]
        { Color = color; Quantity = number }

    let parseLine line =
        let match1 = regexNonLeaf.Match(line)
        let match2 = regexLeaf.Match(line)

        if match2.Success
        then (match2.Groups.[1].Value, Array.zeroCreate 0)
        else (match1.Groups.[1].Value, match1.Groups.[2].Value.Split(',') |> Array.map parseBagStatement)

    let buildMap (lines : string[]) =
        lines
        |> Array.map parseLine
        |> Map

    let rec find map root target =
        if root = target then true
        elif not (Map.containsKey root map) then false
        else map.[root] |> Array.exists (fun bag -> find map bag.Color target)

    let rec countInside map root =
        match Map.containsKey root.Color map with
        | false -> root.Quantity
        | true ->
            let countInsideEach = map.[root.Color] |> Seq.sumBy (fun bag -> countInside map bag)
            root.Quantity + (root.Quantity * countInsideEach)

    let solve1 (lines : string[]) =
        let map = buildMap lines

        Map.remove "shiny gold" map
        |> Map.filter (fun key _ -> find map key "shiny gold")
        |> Map.count
        |> int64

    let solve2 (lines : string[]) =
        let map = buildMap lines

        map.["shiny gold"]
        |> Array.sumBy (fun bag -> countInside map bag)
        |> int64