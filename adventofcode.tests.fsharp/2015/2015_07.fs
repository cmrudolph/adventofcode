namespace Year2015

open System.Collections.Generic

module Day07 =
    open System
    open Utils
    open Xunit
    open System.Text.RegularExpressions

    type Wire = string
    type Value = int

    type WireOrValue =
        | Wire of Wire
        | Value of Value

    type Action =
        | Assign of WireOrValue
        | BitwiseAnd of (WireOrValue * WireOrValue)
        | BitwiseOr of (WireOrValue * WireOrValue)
        | LeftShift of (Wire * Value)
        | RightShift of (Wire * Value)
        | Negate of Wire

    type Instruction =
        { Target: string;
          Action: Action }

    let getWire (idx : int) (regexMatch : Match) =
        regexMatch.Groups.[idx].Value

    let getValue (idx : int) (regexMatch : Match) =
        let s = getWire idx regexMatch
        int s

    let getEither (idx : int) (regexMatch : Match) =
        let str = regexMatch.Groups.[idx].Value
        let success, parsed = Int32.TryParse(str)
        if success then Value parsed else Wire str

    let parseAnd line =
        let m = Regex("(.+) AND (.+) -> (.+)").Match(line)
        if m.Success then Some { Target = getWire 3 m; Action = BitwiseAnd (getEither 1 m, getEither 2 m) } else None

    let parseOr line =
        let m = Regex("(.+) OR (.+) -> (.+)").Match(line)
        if m.Success then Some { Target = getWire 3 m; Action = BitwiseOr (getEither 1 m, getEither 2 m) } else None

    let parseLeftShift line =
        let m = Regex("(.+) LSHIFT (\d+) -> (.+)").Match(line)
        if m.Success then Some { Target = getWire 3 m; Action = LeftShift (getWire 1 m, getValue 2 m) } else None

    let parseRightShift line =
        let m = Regex("(.+) RSHIFT (\d+) -> (.+)").Match(line)
        if m.Success then Some { Target = getWire 3 m; Action = RightShift (getWire 1 m, getValue 2 m) } else None

    let parseNot line =
        let m = Regex("NOT (.+) -> (.+)").Match(line)
        if m.Success then Some { Target = getWire 2 m; Action = Negate (getWire 1 m) } else None

    let parseAssign line =
        let m = Regex("(.+) -> (.+)").Match(line)
        if m.Success then Some { Target = getWire 2 m; Action = Assign (getEither 1 m) } else None

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

    let rec calc (cache : Dictionary<string, int>) (inst : Map<string, Instruction>) targetWire =
        let curr = inst.[targetWire]
        let recurse = calc cache inst

        let (isCached, cachedValue) = cache.TryGetValue(targetWire)
        match isCached with
        | true -> cachedValue
        | false ->
            let wireValue =
                match curr.Action with
                | Assign wOrV ->
                    match wOrV with
                    | Wire w -> (recurse w)
                    | Value v -> v
                | BitwiseAnd (left, right) ->
                    let l, r =
                        match (left, right) with
                        | Wire w1, Wire w2 -> (recurse w1), (recurse w2)
                        | Wire w1, Value v2 -> (recurse w1), v2
                        | Value v1, Wire w2 -> v1, (recurse w2)
                        | Value v1, Value v2 -> v1, v2
                    l &&& r
                | BitwiseOr (left, right) ->
                    let l, r =
                        match (left, right) with
                        | Wire w1, Wire w2 -> (recurse w1), (recurse w2)
                        | Wire w1, Value v2 -> (recurse w1), v2
                        | Value v1, Wire w2 -> v1, (recurse w2)
                        | Value v1, Value v2 -> v1, v2
                    l ||| r
                | LeftShift (w, v) -> (recurse w) <<< v
                | RightShift (w, v) -> (recurse w) >>> v
                | Negate w -> 65535 - (recurse w)
            cache.Add(targetWire, wireValue)
            wireValue

    let solve (lines : string[]) =
        let cache1 = Dictionary<string, int>()
        let inst1 = lines |> parseAll
        let a1 = calc cache1 inst1 "a"
        let ans1 = int64 a1

        let cache2 = Dictionary<string, int>()
        let inst2 = Map.change "b" (fun _ -> Some { Target = "b"; Action = Assign (Value a1) }) inst1
        let a2 = calc cache2 inst2 "a"
        let ans2 = int64 a2

        (ans1, ans2)

    [<Fact>]
    let Sample () =
        readInput "2015" "07" "sample" |> solveAndValidate (114L, 114L) solve

    [<Fact>]
    let Actual () =
        readInput "2015" "07" "actual" |> solveAndValidate (956L, 40149L) solve