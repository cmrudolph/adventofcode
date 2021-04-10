namespace Year2020

module Day05 =
    open Utils
    open Xunit

    let takeHalf (lst : int list) ch =
        let len = Seq.length lst
        match ch with
        | 'F' | 'L' -> lst.[0..(len/2)-1]
        | 'B' | 'R' -> lst.[(len/2)..len]
        | _ -> []

    let calcSeatId (line : string) =
        let chars = Seq.toList line
        let rows = [0..127]
        let seats = [0..7]
    
        let row = ([0..6]
        |> Seq.map (fun i -> chars.[i])
        |> Seq.fold takeHalf rows
        |> Seq.head)

        let seat = ([0..2]
        |> Seq.map (fun i -> chars.[i + 7])
        |> Seq.fold takeHalf seats
        |> Seq.head)

        (row * 8) + seat |> int64

    let solve lines =
        let seatIds = (lines
        |> Seq.map calcSeatId
        |> Seq.sort)

        let min = seatIds |> Seq.head
        let max = seatIds |> Seq.last
        let openSeat = (set([min..max]) - set(seatIds)) |> Seq.head

        (max, openSeat)

    [<Fact>]
    let Sample () =
        readInput "2020" "05" "sample" |> solveAndValidate (3L, 2L) solve

    [<Fact>]
    let Actual () =
        readInput "2020" "05" "actual" |> solveAndValidate (933L, 711L) solve