namespace AOC.FSharp

module AOC2020_20 =
    open System.Text.RegularExpressions

    type Side = { Value: string; IsEdge: bool }

    type Tile =
        { Number: int
          Contents: char [,]
          Top: Side
          Right: Side
          Bottom: Side
          Left: Side }

    type TrackedChar = { Id: int; CharValue: char }

    let getSides (contents: char [,]) =
        let len = Array2D.length1 contents

        let flat = contents |> Seq.cast<char> |> Array.ofSeq
        let top = new string (flat.[0..len - 1])

        let right =
            new string (
                [| 1 .. len |] |> Array.map (fun i -> flat.[(i * len) - 1])
            )

        let bottom = new string (flat.[(len * (len - 1))..])

        let left =
            new string (
                [| 0 .. len - 1 |] |> Array.map (fun i -> flat.[i * len])
            )

        [ { Value = top; IsEdge = false }
          { Value = right; IsEdge = false }
          { Value = bottom; IsEdge = false }
          { Value = left; IsEdge = false } ]

    let parseTile (cleanLine: string) =
        let splits = cleanLine.Split('@')
        let contentSplits = splits.[1..]

        let len = Array.length contentSplits
        let arr2d = Array2D.init len len (fun i j -> contentSplits.[i].[j])

        let regex = Regex("Tile (.*):")
        let number = regex.Match(splits.[0]).Groups.[1].Value |> int

        let sides = getSides arr2d

        { Number = number
          Contents = arr2d
          Top = sides.[0]
          Right = sides.[1]
          Bottom = sides.[2]
          Left = sides.[3] }

    let rotate2dArray arr =
        let len = Array2D.length1 arr
        Array2D.init len len (fun i j -> arr.[len - 1 - j, i])

    let flip2dArray arr =
        let len = Array2D.length1 arr
        Array2D.init len len (fun i j -> arr.[i, len - 1 - j])

    let print2dArray arr =
        let len = Array2D.length1 arr

        for i in [ 0 .. len - 1 ] do
            for j in [ 0 .. len - 1 ] do
                printf "%c" arr.[i, j].CharValue

            printfn ""

    let rotateTile tile =
        let newContents = rotate2dArray tile.Contents
        let newSides = getSides newContents

        { Number = tile.Number
          Contents = newContents
          Top = { Value = newSides.[0].Value; IsEdge = tile.Left.IsEdge }
          Right = { Value = newSides.[1].Value; IsEdge = tile.Top.IsEdge }
          Bottom = { Value = newSides.[2].Value; IsEdge = tile.Right.IsEdge }
          Left = { Value = newSides.[3].Value; IsEdge = tile.Bottom.IsEdge } }

    let flipTile tile =
        let newContents = flip2dArray tile.Contents
        let newSides = getSides newContents

        { Number = tile.Number
          Contents = newContents
          Top = { Value = newSides.[0].Value; IsEdge = tile.Bottom.IsEdge }
          Right = { Value = newSides.[1].Value; IsEdge = tile.Left.IsEdge }
          Bottom = { Value = newSides.[2].Value; IsEdge = tile.Top.IsEdge }
          Left = { Value = newSides.[3].Value; IsEdge = tile.Right.IsEdge } }

    let getAllTilePermutations tile =
        let t1 = tile
        let t2 = rotateTile t1
        let t3 = rotateTile t2
        let t4 = rotateTile t3
        let t5 = flipTile t4
        let t6 = rotateTile t5
        let t7 = rotateTile t6
        let t8 = rotateTile t7
        [ t1; t2; t3; t4; t5; t6; t7; t8 ]

    let getAllPossibleSides tile =
        (List.collect
            (fun t -> [ t.Top; t.Right; t.Bottom; t.Left ])
            (getAllTilePermutations tile))
        |> Set.ofList

    let edgeifySide side allSidesOtherTiles =
        let unique =
            allSidesOtherTiles
            |> Set.map (fun side -> side.Value)
            |> Set.contains side.Value
            |> not

        { side with IsEdge = unique }

    let edgeifyTile allTiles tile =
        let allSidesAllOtherTiles =
            allTiles
            |> List.except [ tile ]
            |> List.map getAllPossibleSides
            |> Set.unionMany

        let newTop = edgeifySide tile.Top allSidesAllOtherTiles
        let newRight = edgeifySide tile.Right allSidesAllOtherTiles
        let newBottom = edgeifySide tile.Bottom allSidesAllOtherTiles
        let newLeft = edgeifySide tile.Left allSidesAllOtherTiles

        { tile with
              Top = newTop
              Right = newRight
              Bottom = newBottom
              Left = newLeft }

    let edgeifyTiles tiles = tiles |> List.map (edgeifyTile tiles)

    let countEdge side =
        match side.IsEdge with
        | true -> 1
        | false -> 0

    let countEdges sides = List.sumBy countEdge sides

    let getEdges tile = [ tile.Top; tile.Right; tile.Bottom; tile.Left ]

    let isCorner tile =
        let count = getEdges tile |> countEdges
        count = 2

    let leftCornerize corner =
        getAllTilePermutations corner
        |> List.filter (fun tile -> tile.Top.IsEdge && tile.Left.IsEdge)
        |> List.head

    let findWithLeft targetLeft tilesToSearch =
        (List.collect getAllTilePermutations tilesToSearch)
        |> List.filter (fun tile -> tile.Left.Value = targetLeft)
        |> List.head

    let findWithTopAndLeft targetTop targetLeft tilesToSearch =
        (List.collect getAllTilePermutations tilesToSearch)
        |> List.filter
            (fun tile ->
                tile.Top.Value = targetTop && tile.Left.Value = targetLeft)
        |> List.head

    let findWithTop targetTop tilesToSearch =
        (List.collect getAllTilePermutations tilesToSearch)
        |> List.filter (fun tile -> tile.Top.Value = targetTop)
        |> List.head

    let stitchItTogether tiles =
        let len = tiles |> List.length |> float |> sqrt |> int

        let corners = tiles |> List.filter isCorner

        let topLeft = corners |> List.head |> leftCornerize

        // Go all mutable and do some ugly looping to build the puzzle
        let mutable remaining =
            tiles |> List.filter (fun tile -> tile.Number <> topLeft.Number)

        let mutable curr = topLeft
        let mutable ordered = [ topLeft ]

        // Top row
        for _ in [ 1 .. len - 1 ] do
            let next = findWithLeft curr.Right.Value remaining
            ordered <- List.append ordered [ next ]

            remaining <-
                remaining
                |> List.filter (fun tile -> tile.Number <> next.Number)

            curr <- next

        // Next N rows
        for i in [ 1 .. len - 1 ] do
            // Leftmost in new row
            let next =
                findWithTop ordered.[(i - 1) * len].Bottom.Value remaining

            ordered <- List.append ordered [ next ]

            remaining <-
                remaining
                |> List.filter (fun tile -> tile.Number <> next.Number)

            curr <- next

            // Remainder of new row
            for j in [ 1 .. len - 1 ] do
                let targetTop = ordered.[((i - 1) * len) + j].Bottom.Value

                let next =
                    findWithTopAndLeft targetTop curr.Right.Value remaining

                ordered <- List.append ordered [ next ]

                remaining <-
                    remaining
                    |> List.filter (fun tile -> tile.Number <> next.Number)

                curr <- next

        ordered

    let buildCombinedImage (tiles: Tile list) =
        let tileLen = tiles |> List.length |> float |> sqrt |> int
        let contentLen = Array2D.length1 tiles.[0].Contents
        let mutable charLists = []
        let mutable counter = 1

        let totalLen = tileLen * contentLen

        for i in [ 0 .. totalLen - 1 ] do
            let shouldProcessRow =
                ((i % contentLen) <> 0) && ((i % contentLen) <> contentLen - 1)

            if shouldProcessRow then
                let mutable chars = ([]: TrackedChar list)

                for j in [ 0 .. totalLen - 1 ] do
                    let shouldProcessCol =
                        ((j % contentLen) <> 0)
                        && ((j % contentLen) <> contentLen - 1)

                    if shouldProcessCol then
                        let tileIdx =
                            ((i / contentLen) * tileLen) + (j / contentLen)

                        let x = i % contentLen
                        let y = j % contentLen

                        let tracked =
                            { Id = counter
                              CharValue = tiles.[tileIdx].Contents.[x, y] }

                        counter <- counter + 1
                        chars <- chars |> List.append [ tracked ]

                charLists <- charLists |> List.append [ chars ]

        let newLen = List.length charLists
        Array2D.init newLen newLen (fun i j -> charLists.[i].[j])

    let getIdIfMonsterChar (arr: TrackedChar [,]) i j offset =
        let rowOffset, colOffset = offset
        let row = i + rowOffset
        let col = j + colOffset
        let ch = arr.[row, col]

        match ch.CharValue with
        | '#' -> ch.Id
        | _ -> -1

    let getSeaMonsterIds arr =
        let offsets =
            [ (0, 18)
              (1, 0)
              (1, 5)
              (1, 6)
              (1, 11)
              (1, 12)
              (1, 17)
              (1, 18)
              (1, 19)
              (2, 1)
              (2, 4)
              (2, 7)
              (2, 10)
              (2, 13)
              (2, 16) ]

        let mutable allMonsterIds = Set.empty

        let len = Array2D.length1 arr

        for i in [ 0 .. len - 3 ] do
            for j in [ 0 .. len - 20 ] do
                let ids = offsets |> List.map (getIdIfMonsterChar arr i j)
                let areMonsterIds = ids |> List.forall (fun id -> id <> -1)

                if areMonsterIds then
                    allMonsterIds <- Set.union allMonsterIds (ids |> Set.ofList)
                else
                    allMonsterIds <- allMonsterIds

        allMonsterIds

    let countHashes arr =
        arr
        |> Seq.cast<TrackedChar>
        |> Seq.filter (fun ch -> ch.CharValue = '#')
        |> Seq.length

    let countRough arr =
        let a1 = arr
        let a2 = rotate2dArray a1
        let a3 = rotate2dArray a2
        let a4 = rotate2dArray a3
        let a5 = flip2dArray a4
        let a6 = rotate2dArray a5
        let a7 = rotate2dArray a6
        let a8 = rotate2dArray a7
        let permutations = [ a1; a2; a3; a4; a5; a6; a7; a8 ]

        let seaMonsterHashCount =
            permutations
            |> List.map getSeaMonsterIds
            |> Set.unionMany
            |> Set.count

        let hashCount = countHashes arr
        (hashCount - seaMonsterHashCount) |> int64

    let solve1 (lines: string []) =
        let singleLine = System.String.Join("\r\n", lines)

        let cleanLines =
            singleLine
                .Replace("\r\n\r\n", "|")
                .Replace("\r\n", "@")
                .Split('|')

        let tiles = cleanLines |> Array.map parseTile |> List.ofArray
        let edgeified = edgeifyTiles tiles

        let corners = edgeified |> List.filter isCorner

        corners
        |> List.map (fun tile -> tile.Number)
        |> List.map int64
        |> List.reduce (*)

    let solve2 (lines: string []) =
        let singleLine = System.String.Join("\r\n", lines)

        let cleanLines =
            singleLine
                .Replace("\r\n\r\n", "|")
                .Replace("\r\n", "@")
                .Split('|')

        let tiles = cleanLines |> Array.map parseTile |> List.ofArray
        let edgeified = edgeifyTiles tiles

        let ordered = stitchItTogether edgeified
        let combined = buildCombinedImage ordered
        countRough combined
