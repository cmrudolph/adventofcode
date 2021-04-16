namespace Year2020

module Day02 =
    open System.Text.RegularExpressions
    open Utils
    open Xunit

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

    let solve lines =
        let recs = lines |> Seq.map makeRec
        let ans1 = recs |> calculate validFun1
        let ans2 = recs |> calculate validFun2

        (ans1, ans2)

    [<Fact>]
    let Sample () =
        readInput "2020" "02" "sample" |> solveAndValidate (2L, 1L) solve

    [<Fact>]
    let Actual () =
        readInput "2020" "02" "actual" |> solveAndValidate (434L, 509L) solve