namespace AOC.FSharp

module AOC2015_02 =
    let dimensions (line: string) =
        line.Split('x') |> Seq.map int |> Seq.toList |> List.sort

    let paper (dims: int list) =
        (3 * dims.[0] * dims.[1])
        + (2 * dims.[1] * dims.[2])
        + (2 * dims.[0] * dims.[2])

    let ribbon (dims: int list) =
        (2 * dims.[0]) + (2 * dims.[1]) + (dims.[0] * dims.[1] * dims.[2])

    let calculate allDimensions valueFunc =
        allDimensions |> Seq.map valueFunc |> Seq.sumBy int64

    let solve1 (lines: string []) =
        let allDimensions = Seq.map dimensions lines
        calculate allDimensions paper

    let solve2 (lines: string []) =
        let allDimensions = Seq.map dimensions lines
        calculate allDimensions ribbon
