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

    let getNeighbors pos =
        // Get the positions of the neighboring tiles on all six sides
        let x, y = pos
        Set.ofList [(x-1, y-2); (x+1, y-2); (x-1, y+2); (x+1, y+2); (x-2, y); (x+2, y)]

    let findWhiteNeighbors blacks =
        // Given black tiles, find all directly connected tiles that are currently white
        let allNeighbors =
            blacks
            |> Set.map getNeighbors
            |> Set.unionMany

        Set.difference allNeighbors blacks

    let findToFlip filterPrediicate blacks tiles =
        // Find all neighbors of the specified set of tiles to consider flipping
        let neighbors =
            tiles
            |> List.ofSeq
            |> List.map (fun x -> (x, getNeighbors x))

        // For each searched tile, determine how many black neighbors there are
        let blackNeighborCounts =
            neighbors
            |> List.map (fun (pos, neighbors) -> (pos, Set.count (Set.intersect neighbors blacks)))

        // Reduce the initial set of tiles to only those that satisfy the filter criteria
        blackNeighborCounts
            |> List.filter (fun (_, blackNeighborCount) -> filterPrediicate blackNeighborCount)
            |> List.map (fun (pos, _) -> pos)
            |> Set.ofList

    let findToFlipBlack blacks whites =
        // Given white tiles, return all the tiles that should be flipped to black (2 neighboring black tiles)
        findToFlip (fun blackCount -> blackCount = 2) blacks whites

    let findToFlipWhite blacks =
        // Given black tiles, return all the tiles that should be flipped to white (zero or >2 neighboring black tiles)
        findToFlip (fun blackCount -> blackCount = 0 || blackCount > 2) blacks blacks

    let doDayFlip blacks =
        // Perform the daily tile flipping routine
        let toFlipWhite = findToFlipWhite blacks
        let whiteCandidates = findWhiteNeighbors blacks
        let toFlipBlack = findToFlipBlack blacks whiteCandidates
        let unfilteredBlacks = Set.union blacks toFlipBlack
        Set.difference unfilteredBlacks toFlipWhite

    let solve (lines : string[]) =
        let blacks =
            lines
            |> Array.map (calculateFinalPosition (0, 0))
            |> Array.groupBy (fun x -> x)
            |> Array.filter (fun (_, grp) -> (Array.length grp) % 2 = 1)
            |> Array.map (fun (key, _) -> key)
            |> Set.ofArray

        let ans1 =
            blacks
            |> Set.count
            |> int64

        let ans2 =
            [1..100]
            |> List.fold (fun acc _ -> doDayFlip acc) blacks
            |> Set.count
            |> int64

        (ans1, ans2)

    [<Fact>]
    let Sample () =
        readInput "2020" "24" "sample" |> solveAndValidate (10L, 2208L) solve

    [<Fact>]
    let Actual () =
        readInput "2020" "24" "actual" |> solveAndValidate (400L, 3768L) solve