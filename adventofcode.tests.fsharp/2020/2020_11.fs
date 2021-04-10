namespace Year2020

module Day11 =
    open Utils
    open Xunit

    type Counts = { Edge: int; Floor: int; Empty: int; Occupied: int }

    [<Literal>]
    let EdgeChar = '-'

    [<Literal>]
    let FloorChar = '.'

    [<Literal>]
    let EmptyChar = 'L'

    [<Literal>]
    let OccupiedChar = '#'

    let createGrid (lines : string[]) =
        let edgeStr = string EdgeChar
        let width = String.length lines.[0]
        let topBottom = String.init (width + 2) (fun _ -> edgeStr)
        let paddedLines = Array.map (fun line -> edgeStr + line + edgeStr) lines
        Array.concat (seq { [|topBottom|]; paddedLines; [|topBottom|] }) |> array2D

    let move pos direction =
        let row, col = pos;
        let rowDiff, colDiff = direction;
        row + rowDiff, col + colDiff

    let shouldStop curr stopChars =
        stopChars |> Set.contains curr

    let checkNeighbor (grid : char[,]) stopChars pos acc direction =
        // A non-idiomatic pragmatic concession. Mutable state is kept local, so it's not too terrible
        let mutable currPos = move pos direction
        let mutable currRow, currCol = currPos
        let mutable currChar = grid.[currRow, currCol]
        let mutable stop = stopChars |> shouldStop currChar
        while not stop do
            currPos <- move currPos direction
            let r, c = currPos
            currChar <- grid.[r, c]
            stop <- stopChars |> shouldStop currChar

        match currChar with
        | EdgeChar -> { acc with Edge = acc.Edge + 1 }
        | FloorChar -> { acc with Floor = acc.Floor + 1 }
        | EmptyChar -> { acc with Empty = acc.Empty + 1 }
        | OccupiedChar -> { acc with Occupied = acc.Occupied + 1 }
        | _ -> acc

    let checkNeighbors grid pos stopChars =
        let neighbors = [
            (-1, -1); (-1, 0); (-1, 1);
            (0, -1); (0, 1);
            (1, -1); (1, 0); (1, 1)]

        let acc = {Edge = 0; Floor = 0; Empty = 0; Occupied = 0 }
        (acc, neighbors) ||> List.fold (checkNeighbor grid stopChars pos)

    let identifyNewValue grid pos stopChars threshold =
        let counts = checkNeighbors grid pos stopChars
        let row, col = pos
        let currVal = grid.[row, col]

        if currVal = EmptyChar && counts.Occupied = 0 then OccupiedChar
        elif currVal = OccupiedChar && counts.Occupied >= threshold then EmptyChar
        else currVal

    let transformGrid stopChars threshold grid =
        let rows = Array2D.length1 grid
        let c = Array2D.length2 grid

        let coords = [1..(rows - 2)] |> List.collect (fun r -> [1..(c - 2)] |> List.map (fun col -> (r, col)));
        let writable = Array2D.copy grid

        coords |> List.iter (fun (r, c) -> Array2D.set writable r c (identifyNewValue grid (r, c) stopChars threshold))
        writable

    let countOccupied grid =
        Seq.cast<char> grid
        |> Seq.filter (fun ch -> ch = OccupiedChar)
        |> Seq.length
        |> int64

    let rec findFinalOccupiedCount stopChars threshold grid =
        let transformed = grid |> transformGrid stopChars threshold
        if transformed = grid then countOccupied grid
        else findFinalOccupiedCount stopChars threshold transformed

    let solve (lines : string[]) =
        let grid = lines |> createGrid
        
        let allChars = Set.ofList [EdgeChar; FloorChar; EmptyChar; OccupiedChar]
        let ans1 = grid |> findFinalOccupiedCount allChars 4

        let seatChars = Set.ofList [EdgeChar; EmptyChar; OccupiedChar]
        let ans2 = grid |> findFinalOccupiedCount seatChars 5

        (ans1, ans2)

    [<Fact>]
    let Sample () =
        readInput "2020" "11" "sample" |> solveAndValidate (37L, 26L) solve

    [<Fact>]
    let Actual () =
        readInput "2020" "11" "actual" |> solveAndValidate (2299L, 2047L) solve