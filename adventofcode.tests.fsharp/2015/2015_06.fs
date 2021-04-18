namespace Year2015

module Day06 =
    open Utils
    open Xunit
    open System.Text.RegularExpressions

    let adjust func coords (grid : int[,]) =
        let x1, y1, x2, y2 = coords
        for x in x1..x2 do
            for y in y1..y2 do
                grid.[x, y] <- func grid.[x, y]

    let grpStr (m : Match) (idx : int) =
        m.Groups.[idx].Value

    let grpInt (m : Match) (idx : int) =
        grpStr m idx |> int

    let turnOn1 _ = 1

    let turnOff1 _ = 0

    let toggle1 x = (x + 1) % 2

    let turnOn2 x = x + 1

    let turnOff2 x = max (x - 1) 0

    let toggle2 x = x + 2

    let applyInstruction on off toggle action coords (grid: int[,]) =
        match action with
        | "turn on" -> adjust on coords grid
        | "turn off" -> adjust off coords grid
        | "toggle" -> adjust toggle coords grid
        | _ -> failwith $"Unknown action {action}"

    let sumOn (grid : int[,]) =
        grid |> Seq.cast<int> |> Seq.sum |> int64

    let solveCase apply lines =
        let grid = Array2D.zeroCreate 1000 1000
        let pattern = Regex("(.*) (\d+),(\d+) through (\d+),(\d+)")

        lines
        |> Array.map (fun line -> pattern.Match(line))
        |> Array.map (fun m -> (grpStr m 1, (grpInt m 2, grpInt m 3, grpInt m 4, grpInt m 5)))
        |> Array.iter (fun t -> apply (fst t) (snd t) grid)

        sumOn grid

    let solve (lines : string[]) =
        let apply1 = applyInstruction turnOn1 turnOff1 toggle1
        let apply2 = applyInstruction turnOn2 turnOff2 toggle2

        let ans1 = lines |> solveCase apply1
        let ans2 = lines |> solveCase apply2
        (ans1, ans2)

    [<Fact>]
    let Sample () =
        readInput "2015" "06" "sample" |> solveAndValidate (998996L, 0L) solve

    [<Fact>]
    let Actual () =
        readInput "2015" "06" "actual" |> solveAndValidate (543903L, 53L) solve