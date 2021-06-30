namespace AOC.FSharp

module AOC2015_07 =
    open System
    open System.Collections.Generic
    open System.Text.RegularExpressions

    type Wire = Wire of string

    type WireOrValue =
        | W of Wire
        | V of int

    type Action =
        | Assign of WireOrValue
        | BitwiseAnd of (WireOrValue * WireOrValue)
        | BitwiseOr of (WireOrValue * WireOrValue)
        | LeftShift of (Wire * int)
        | RightShift of (Wire * int)
        | Negate of Wire

    type Instruction =
        { Target: Wire;
          Action: Action }

    let parse line =
        let wire (idx : int) (regexMatch : Match) =
            regexMatch.Groups.[idx].Value |> Wire.Wire

        let value (idx : int) (regexMatch : Match) =
            regexMatch.Groups.[idx].Value|> int

        let either (idx : int) (regexMatch : Match) =
            let str = regexMatch.Groups.[idx].Value
            let success, parsed = Int32.TryParse(str)
            if success then V parsed else W (Wire str)

        let parseAnd =
            let m = Regex("(.+) AND (.+) -> (.+)").Match(line)
            if m.Success then Some { Target = wire 3 m; Action = BitwiseAnd (either 1 m, either 2 m) } else None

        let parseOr =
            let m = Regex("(.+) OR (.+) -> (.+)").Match(line)
            if m.Success then Some { Target = wire 3 m; Action = BitwiseOr (either 1 m, either 2 m) } else None

        let parseLeftShift =
            let m = Regex("(.+) LSHIFT (\d+) -> (.+)").Match(line)
            if m.Success then Some { Target = wire 3 m; Action = LeftShift (wire 1 m, value 2 m) } else None

        let parseRightShift =
            let m = Regex("(.+) RSHIFT (\d+) -> (.+)").Match(line)
            if m.Success then Some { Target = wire 3 m; Action = RightShift (wire 1 m, value 2 m) } else None

        let parseNot =
            let m = Regex("NOT (.+) -> (.+)").Match(line)
            if m.Success then Some { Target = wire 2 m; Action = Negate (wire 1 m) } else None

        let parseAssign =
            let m = Regex("(.+) -> (.+)").Match(line)
            if m.Success then Some { Target = wire 2 m; Action = Assign (either 1 m) } else None

        [parseAnd; parseOr; parseLeftShift; parseRightShift; parseNot; parseAssign]
        |> List.choose id
        |> List.head

    let parseAll lines =
        lines
        |> Array.map parse
        |> Array.map (fun x -> (x.Target, x))
        |> Map.ofArray

    let rec calc (cache : Dictionary<Wire, int>) (inst : Map<Wire, Instruction>) targetWire =
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
                    | W w -> (recurse w)
                    | V v -> v
                | BitwiseAnd (left, right) ->
                    let l, r =
                        match (left, right) with
                        | W w1, W w2 -> (recurse w1), (recurse w2)
                        | W w1, V v2 -> (recurse w1), v2
                        | V v1, W w2 -> v1, (recurse w2)
                        | V v1, V v2 -> v1, v2
                    l &&& r
                | BitwiseOr (left, right) ->
                    let l, r =
                        match (left, right) with
                        | W w1, W w2 -> (recurse w1), (recurse w2)
                        | W w1, V v2 -> (recurse w1), v2
                        | V v1, W w2 -> v1, (recurse w2)
                        | V v1, V v2 -> v1, v2
                    l ||| r
                | LeftShift (w, v) -> (recurse w) <<< v
                | RightShift (w, v) -> (recurse w) >>> v
                | Negate w -> 65535 - (recurse w)
            cache.Add(targetWire, wireValue)
            wireValue

    let solve (lines : string[]) =
        let a = Wire "a"
        let b = Wire "b"

        let cache1 = Dictionary<Wire, int>()
        let inst1 = lines |> parseAll
        let a1 = calc cache1 inst1 a
        let ans1 = int64 a1

        let cache2 = Dictionary<Wire, int>()
        let inst2 = Map.change b (fun _ -> Some { Target = b; Action = Assign (V a1) }) inst1
        let a2 = calc cache2 inst2 a
        let ans2 = int64 a2

        (ans1, ans2)