namespace Year2020

module Day17 =
    open Utils
    open Xunit
    open System.Collections.Generic

    type Neighbors3 = Dictionary<(int*int*int), seq<int*int*int>>
    type Neighbors4 = Dictionary<(int*int*int*int), seq<int*int*int*int>>

    [<Literal>]
    let InactiveChar = '.'

    [<Literal>]
    let ActiveChar = '#'
    
    let copyGrid3 grid =
        let s = Array3D.length1 grid
        Array3D.init s s s (fun a b c -> grid.[a, b, c])

    let copyGrid4 grid =
        let s = Array4D.length1 grid
        Array4D.init s s s s (fun a b c d -> grid.[a, b, c, d])

    let isActiveChar3 grid a b c =
        let size = Array3D.length1 grid
        let outOfRange = a < 0 || b < 0 || c < 0 || a = size || b = size || c = size
        if outOfRange then false
        else grid.[a, b, c] = ActiveChar

    let isActiveChar4 grid a b c d =
        let size = Array4D.length1 grid
        let outOfRange = a < 0 || b < 0 || c < 0 || d < 0 || a = size || b = size || c = size || d = size
        if outOfRange then false
        else grid.[a, b, c, d] = ActiveChar

    let countActiveNeighbors3 (grid : char[,,]) (neighbors : Neighbors3) a b c =
        let myNeighbors = neighbors.[(a, b, c)]

        (myNeighbors
        |> Seq.filter (fun (i, j, k) -> isActiveChar3 grid i j k)
        |> Seq.length)

    let countActiveNeighbors4 (grid : char[,,,]) (neighbors : Neighbors4) a b c d =
        let myNeighbors = neighbors.[(a, b, c, d)]

        (myNeighbors
        |> Seq.filter (fun (i, j, k, m) -> isActiveChar4 grid i j k m)
        |> Seq.length)

    let countActive3 (grid : char[,,]) =
        Seq.cast<char> grid |> Seq.filter (fun c -> c = ActiveChar) |> Seq.length

    let countActive4 (grid : char[,,,]) =
        Seq.cast<char> grid |> Seq.filter (fun c -> c = ActiveChar) |> Seq.length

    let cycleGrid3 grid neighbors =
        let size = Array3D.length1 grid
        let transformed = grid |> copyGrid3

        for a in [0..size - 1] do
            for b in [0..size - 1] do
                for c in [0..size - 1] do
                    let curr = grid.[a, b, c]
                    let count = countActiveNeighbors3 grid neighbors a b c
                    let newChar =
                        match curr, count with
                        | (ActiveChar, 2) | (ActiveChar, 3) -> ActiveChar
                        | (InactiveChar, 3) -> ActiveChar
                        | _ -> InactiveChar
                    Array3D.set transformed a b c newChar
        transformed

    let cycleGrid4 grid neighbors =
        let size = Array4D.length1 grid
        let transformed = grid |> copyGrid4

        for a in [0..size - 1] do
            for b in [0..size - 1] do
                for c in [0..size - 1] do
                    for d in [0..size - 1] do
                        let curr = grid.[a, b, c, d]
                        let count = countActiveNeighbors4 grid neighbors a b c d
                        let newChar =
                            match curr, count with
                            | (ActiveChar, 2) | (ActiveChar, 3) -> ActiveChar
                            | (InactiveChar, 3) -> ActiveChar
                            | _ -> InactiveChar
                        Array4D.set transformed a b c d newChar
        transformed
                    
    let makeGrid3 (lines : string[]) =
        let padding = 14
        let origSize = Array.length lines
        let gridSize = origSize + padding
        let grid = Array3D.create gridSize gridSize gridSize '.'
        let startIdx = padding / 2
        let endIdx = startIdx + origSize - 1 
        let fixedIdx = endIdx / 2

        for a in [startIdx..endIdx] do
            for b in [startIdx..endIdx] do
                let lineIdx1 = a - startIdx
                let lineIdx2 = b - startIdx
                Array3D.set grid a b fixedIdx (lines.[lineIdx1].[lineIdx2])   
        grid

    let makeGrid4 (lines : string[]) =
           let padding = 20
           let origSize = Array.length lines
           let gridSize = origSize + padding
           let grid = Array4D.create gridSize gridSize gridSize gridSize '.'
           let startIdx = padding / 2
           let endIdx = startIdx + origSize - 1 
           let fixedIdx = endIdx / 2

           for a in [startIdx..endIdx] do
               for b in [startIdx..endIdx] do
                   let lineIdx1 = a - startIdx
                   let lineIdx2 = b - startIdx
                   Array4D.set grid a b fixedIdx fixedIdx (lines.[lineIdx1].[lineIdx2])   
           grid

    let solve (lines : string[]) =
        let adjustments3 =
            let mutable temp = []
            for i in [-1..1] do
                for j in [-1..1] do
                    for k in [-1..1] do
                        temp <- List.append [(i, j, k)] temp
            temp |> List.filter (fun (i, j, k) -> (i, j, k) <> (0, 0, 0))

        let calcNeighbors3 size adjustments =
            let neighbors = new Neighbors3()
            for a in [0..size - 1] do
                for b in [0..size - 1] do
                    for c in [0..size - 1] do
                        let key = (a, b, c)
                        let n = adjustments |> Seq.map (fun (i, j, k) -> (a + i, b + j, c + k))
                        neighbors.Add(key, n)
            neighbors

        let adjustments4 =
            let mutable temp = []
            for i in [-1..1] do
                for j in [-1..1] do
                    for k in [-1..1] do
                        for m in [-1..1] do
                            temp <- List.append [(i, j, k, m)] temp
            temp |> List.filter (fun (i, j, k, m) -> (i, j, k, m) <> (0, 0, 0, 0))

        let calcNeighbors4 size adjustments =
            let neighbors = new Neighbors4()
            for a in [0..size - 1] do
                for b in [0..size - 1] do
                    for c in [0..size - 1] do
                        for d in [0..size - 1] do
                            let key = (a, b, c, d)
                            let n = adjustments |> Seq.map (fun (i, j, k, m) -> (a + i, b + j, c + k, d + m))
                            neighbors.Add(key, n)
            neighbors

        let grid3 = makeGrid3 lines
        let size3 = Array3D.length1 grid3
        let neighbors3 = calcNeighbors3 size3 adjustments3
        let ans1 = ((grid3, [1..6]) ||> List.fold (fun acc _ -> cycleGrid3 acc neighbors3)
        |> countActive3
        |> int64)

        // TODO: Optimize. Kind of slow
        let grid4 = makeGrid4 lines
        let size4 = Array4D.length1 grid4
        let neighbors4 = calcNeighbors4 size4 adjustments4
        let ans2 = ((grid4, [1..6]) ||> List.fold (fun acc _ -> cycleGrid4 acc neighbors4)
        |> countActive4
        |> int64)

        (ans1, ans2)

    [<Fact>]
    let Sample () =
        readInput "2020" "17" "sample" |> solveAndValidate (112L, 848L) solve

    [<Fact>]
    let Actual () =
        readInput "2020" "17" "actual" |> solveAndValidate (298L, 1792L) solve