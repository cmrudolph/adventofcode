namespace Year2020

module Day24 =
    open System
    open Utils
    open Xunit

    let parseInput (lines : string[]) =
        String.Join("", lines)

    let rec calculateFinalPosition pos remaining =
        let (|Prefix|_|) (p:string) (s:string) =
            if s.StartsWith(p) then
                Some(s.Substring(p.Length))
            else
                None

        match remaining with
        | "" -> pos
        | rem ->
            let adjustment, newRemaining =
                match rem with
                | Prefix "nw" rest -> ((-1, -2), rest)
                | Prefix "ne" rest -> ((1, -2), rest)
                | Prefix "sw" rest -> ((-1, 2), rest)
                | Prefix "se" rest -> ((1, 2), rest)
                | Prefix "w" rest -> ((-2, 0), rest)
                | Prefix "e" rest -> ((2, 0), rest)
                | _ -> failwith "invalid prefix"

            let oldX, oldY = pos
            let adjX, adjY = adjustment
            let newPos = (oldX + adjX, oldY + adjY)
            calculateFinalPosition newPos newRemaining

    let solve (lines : string[]) =
        //lines
        //|> Array.map (calculateFinalPosition (0, 0))
        //|> Array.groupBy (fun x -> x)
        //|> Array.map (fun (_, grp) -> grp)
        //|> Array.iter (fun grp -> printfn "%A" grp)

        let ans1 =
            lines
            |> Array.map (calculateFinalPosition (0, 0))
            |> Array.groupBy (fun x -> x)
            |> Array.map (fun (_, grp) -> Array.length grp)
            |> Array.filter (fun x -> x % 2 = 1)
            |> Array.length
            |> int64

        (ans1, 0L)

    [<Fact>]
    let Sample () =
        readInput "2020" "24" "sample" |> solveAndValidate (-1L, -1L) solve

    [<Fact>]
    let Actual () =
        readInput "2020" "24" "actual" |> solveAndValidate (-1L, -1L) solve