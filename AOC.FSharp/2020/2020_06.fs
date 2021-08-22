namespace AOC.FSharp

module AOC2020_06 =
    open System

    let parse (lines: string []) =
        (String
            .Join(Environment.NewLine, lines)
            .Replace(Environment.NewLine + Environment.NewLine, "|")
            .Replace(Environment.NewLine, " "))

    let distinctChars str = str |> Seq.toList |> Seq.distinct |> Seq.length

    let commonChars (str: string) =
        str.Split(' ')
        |> Seq.map Set.ofSeq
        |> Set.intersectMany
        |> Set.count
        |> int64

    let calculate1 (delimited: string) =
        delimited.Replace(" ", "").Split('|')
        |> Seq.sumBy distinctChars
        |> int64

    let calculate2 (delimited: string) =
        delimited.Split('|') |> Seq.sumBy commonChars |> int64

    let solve1 (lines: string []) =
        let delimited = parse lines
        calculate1 delimited

    let solve2 (lines: string []) =
        let delimited = parse lines
        calculate2 delimited
