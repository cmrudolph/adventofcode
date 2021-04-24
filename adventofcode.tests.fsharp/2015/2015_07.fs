namespace Year2015

open System.Collections.Generic

module Day07 =
    open System
    open Utils
    open Xunit
    open System.Text.RegularExpressions

    type StringOrInt =
        | Str of string
        | Int of int

    type Action =
        | Assign of StringOrInt
        | BitwiseAnd of (StringOrInt * StringOrInt)
        | BitwiseOr of (StringOrInt * StringOrInt)
        | LeftShift of (string * int)
        | RightShift of (string * int)
        | Negate of string

    type Instruction =
        { Target: string;
          Action: Action }

    let strVal (idx : int) (regexMatch : Match) =
        regexMatch.Groups.[idx].Value

    let intVal (idx : int) (regexMatch : Match) =
        let s = strVal idx regexMatch
        int s

    let matchVal (idx : int) (regexMatch : Match) =
        let str = regexMatch.Groups.[idx].Value
        let success, parsed = Int32.TryParse(str)
        if success then Int parsed else Str str

    let parseAnd line =
        let m = Regex("(.+) AND (.+) -> (.+)").Match(line)
        if m.Success then Some { Target = strVal 3 m; Action = BitwiseAnd (matchVal 1 m, matchVal 2 m) } else None

    let parseOr line =
        let m = Regex("(.+) OR (.+) -> (.+)").Match(line)
        if m.Success then Some { Target = strVal 3 m; Action = BitwiseOr (matchVal 1 m, matchVal 2 m) } else None

    let parseLeftShift line =
        let m = Regex("(.+) LSHIFT (\d+) -> (.+)").Match(line)
        if m.Success then Some { Target = strVal 3 m; Action = LeftShift (strVal 1 m, intVal 2 m) } else None

    let parseRightShift line =
        let m = Regex("(.+) RSHIFT (\d+) -> (.+)").Match(line)
        if m.Success then Some { Target = strVal 3 m; Action = RightShift (strVal 1 m, intVal 2 m) } else None

    let parseNot line =
        let m = Regex("NOT (.+) -> (.+)").Match(line)
        if m.Success then Some { Target = strVal 2 m; Action = Negate (strVal 1 m) } else None

    let parseAssign line =
        let m = Regex("(.+) -> (.+)").Match(line)
        if m.Success then Some { Target = strVal 2 m; Action = Assign (matchVal 1 m) } else None

    let parse line =
        [parseAnd; parseOr; parseLeftShift; parseRightShift; parseNot; parseAssign]
        |> List.map (fun f -> f line)
        |> List.choose id
        |> List.head

    let parseAll lines =
        lines
        |> Array.map parse
        |> Array.map (fun x -> (x.Target, x))
        |> Map.ofArray

    let rec calc (cache : Dictionary<string, int>) (inst : Map<string, Instruction>) target =
        let curr = inst.[target]
        let recurse = calc cache inst

        let (isCached, cacheVal) = cache.TryGetValue(target)
        match isCached with
        | true -> cacheVal
        | false ->
            let result =
                match curr.Action with
                | Assign x ->
                    match x with
                    | Str s -> (recurse s)
                    | Int i -> i
                | BitwiseAnd (x, y) ->
                    let left, right =
                        match (x, y) with
                        | Str s1, Str s2 -> (recurse s1), (recurse s2)
                        | Str s1, Int i2 -> (recurse s1), i2
                        | Int i1, Str s2 -> i1, (recurse s2)
                        | Int i1, Int i2 -> i1, i2
                    left &&& right
                | BitwiseOr (x, y) ->
                    let left, right =
                        match (x, y) with
                        | Str s1, Str s2 -> (recurse s1), (recurse s2)
                        | Str s1, Int i2 -> (recurse s1), i2
                        | Int i1, Str s2 -> i1, (recurse s2)
                        | Int i1, Int i2 -> i1, i2
                    left ||| right
                | LeftShift (x, amt) -> (recurse x) <<< amt
                | RightShift (x, amt) -> (recurse x) >>> amt
                | Negate x -> 65535 - (recurse x)
            cache.Add(target, result)
            result

    let solve (lines : string[]) =
        let cache1 = Dictionary<string, int>()
        let inst1 = lines |> parseAll
        let a1 = calc cache1 inst1 "a"
        let ans1 = int64 a1

        let cache2 = Dictionary<string, int>()
        let inst2 = Map.change "b" (fun _ -> Some { Target = "b"; Action = Assign (Int a1) }) inst1
        let a2 = calc cache2 inst2 "a"
        let ans2 = int64 a2

        (ans1, ans2)

    [<Fact>]
    let Sample () =
        readInput "2015" "07" "sample" |> solveAndValidate (114L, 114L) solve

    [<Fact>]
    let Actual () =
        readInput "2015" "07" "actual" |> solveAndValidate (956L, 40149L) solve