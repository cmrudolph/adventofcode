namespace AOC.FSharp

module AOC2020_02 =
    open System.Text.RegularExpressions

    type Input =
        { Val1: int
          Val2: int
          Target: char
          Password: string }

    let makeRec inputLine =
        let pattern = Regex("(.*)-(.*) (.): (.*)")
        let m = pattern.Match(inputLine)

        { Val1 = System.Int32.Parse(m.Groups.[1].Value)
          Val2 = System.Int32.Parse(m.Groups.[2].Value)
          Target = System.Char.Parse(m.Groups.[3].Value)
          Password = m.Groups.[4].Value }

    let validFun1 r =
        Seq.toList r.Password
        |> Seq.filter ((=) r.Target)
        |> Seq.length
        |> (fun o -> o <= r.Val2 && o >= r.Val1)

    let validFun2 r =
        let chars = Seq.toList r.Password
        ((chars.[r.Val1 - 1] = r.Target) <> (chars.[r.Val2 - 1] = r.Target))

    let calculate validFun recs =
        recs
        |> Seq.filter validFun
        |> Seq.length
        |> int64

    let solve1 lines =
        let recs = lines |> Seq.map makeRec
        recs |> calculate validFun1

    let solve2 lines =
        let recs = lines |> Seq.map makeRec
        recs |> calculate validFun2