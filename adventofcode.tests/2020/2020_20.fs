namespace Year2020

module Day20 =
    open Utils
    open Xunit
    open System.Text.RegularExpressions

    type Tile = { Number: int; Edges: Set<string> }

    let reverse (input:string) =
        input |> Seq.rev |> System.String.Concat

    let makeTile (cleanLine : string) =
        let splits = cleanLine.Split('@')

        let regex = Regex("Tile (.*):");
        let number = regex.Match(splits.[0]).Groups.[1].Value |> int

        let startRow = 1
        let endRow = splits.Length - 1
        let endCol = splits.[startRow].Length - 1
        let edge1 = splits.[startRow]
        let edge2 = splits.[endRow]
        let edge3 = splits.[startRow..endRow] |> Array.map (fun row -> row.[0]) |> Array.map string |> Array.reduce (+)
        let edge4 = splits.[startRow..endRow] |> Array.map (fun row -> row.[endCol]) |> Array.map string |> Array.reduce (+)
        let forwardEdges = [edge1; edge2; edge3; edge4]
        let reversedEdges = forwardEdges |> List.map reverse

        { Number = number; Edges = Set.ofList (forwardEdges @ reversedEdges) }

    let isCorner tile allTiles =
        let otherTiles = allTiles |> List.except [tile]
        let otherSets = otherTiles |> List.map (fun t -> t.Edges)
        let otherEdges = Set.unionMany otherSets
        let uniqueEdges = tile.Edges - otherEdges
        let count = Set.count uniqueEdges
        printfn "%A %A" tile.Number count
        count = 4 // Edge count doubled (forward + reversed)

    let solve (lines : string[]) =
        let singleLine = System.String.Join("\r\n", lines)
        let cleanLines = singleLine.Replace("\r\n\r\n", "|").Replace("\r\n", "@").Split('|')
        let tiles = cleanLines |> Array.map makeTile |> List.ofArray
        
        let ans1 = (tiles
        |> List.filter (fun tile -> isCorner tile tiles)
        |> List.map (fun tile -> tile.Number)
        |> List.map int64
        |> List.reduce (*))

        (ans1, 0L)

    [<Fact>]
    let Sample () =
        readInput "2020" "20" "sample" |> solveAndValidate (20899048083289L, -1L) solve

    [<Fact>]
    let Actual () =
        readInput "2020" "20" "actual" |> solveAndValidate (83775126454273L, -1L) solve