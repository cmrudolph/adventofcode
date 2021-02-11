namespace Year2020

module Day19 =
    open System
    open System.Text.RegularExpressions
    open Utils
    open Xunit

    type RuleDef =
        Literal of char
        | Single of int list
        | Piped of int list list

    type Rule = { Id: int; Def: RuleDef }

    let intStringToInts (str : string) =
        str.Trim().Split(' ')
        |> Array.map int
        |> Array.toList

    let parseLiteral line =
        let regex = new Regex("^(\d+): \"(.)\"$")
        let regexMatch = regex.Match(line)
        if regexMatch.Success then
            let id = regexMatch.Groups.[1].Value |> int
            let char = regexMatch.Groups.[2].Value.[0]
            Some { Id = id; Def = RuleDef.Literal char }
        else
            None

    let parseList1 line =
        let regex = new Regex("^(\d+): (\d+[^|]*)$")
        let regexMatch = regex.Match(line)
        if regexMatch.Success then
            let id = regexMatch.Groups.[1].Value |> int
            let values = regexMatch.Groups.[2].Value |> intStringToInts
            Some { Id = id; Def = RuleDef.Single values }
        else
            None

    let parseList2 line =
        let regex = new Regex("^(\d+): (\d+[^|]*)$")
        let regexMatch = regex.Match(line)
        if regexMatch.Success then
            let id = regexMatch.Groups.[1].Value |> int

            match id with
            | 8 -> Some { Id = id; Def = RuleDef.Piped [
                [42];
                [42;42];
                [42;42;42];
                [42;42;42;42];
                [42;42;42;42;42]] }
            | 11 -> Some { Id = id; Def = RuleDef.Piped [
                [42;31];
                [42;42;31;31];
                [42;42;42;31;31;31];
                [42;42;42;42;31;31;31;31]] }
            | _ ->
                let values = regexMatch.Groups.[2].Value |> intStringToInts
                Some { Id = id; Def = RuleDef.Single values }
        else
            None

    let parsePiped line =
        let regex = new Regex("^(\d+): (\d.*\|.*)$")
        let regexMatch = regex.Match(line)
        if regexMatch.Success then
            let id = regexMatch.Groups.[1].Value |> int
            let values = regexMatch.Groups.[2].Value
            let groups = values.Split('|') |> Array.toList |> List.map intStringToInts
            Some { Id = id; Def = RuleDef.Piped groups }
        else
            None

    let parse parseList line =
        [parseLiteral; parseList; parsePiped]
        |> List.map (fun f -> f line)
        |> List.choose id
        |> List.head

    let rec buildRegex (ruleMap : Map<int, RuleDef>) target =
        let rule = ruleMap.[target]
        match rule with
        | Literal ch -> ch |> string
        | Single lst -> "(" + String.Join("", lst |> List.map (fun x -> buildRegex ruleMap x)) + ")"
        | Piped lsts ->
            let segments = lsts |> List.map (fun lst -> "(" + String.Join("", lst |> List.map (fun x -> buildRegex ruleMap x)) + ")")
            let joined = String.Join("|", segments)
            "(" + joined + ")"

    let checkRegex (regex : Regex) input =
           if regex.IsMatch(input) then 1 else 0

    let buildRuleMap parse lines =
        lines
        |> Array.takeWhile (fun line -> line <> "")
        |> Array.map parse
        |> Array.map (fun rule -> (rule.Id, rule.Def))
        |> Map.ofArray

    let solve (lines : string[]) =
        let ruleMap1 = lines |> buildRuleMap (parse parseList1)
        let ruleMap2 = lines |> buildRuleMap (parse parseList2)

        let inputs = (lines
        |> Array.skipWhile (fun line -> line <> "")
        |> Array.skip 1)

        let regex1 = new Regex("^" + (buildRegex ruleMap1 0) + "$", RegexOptions.Compiled)
        let regex2 = new Regex("^" + (buildRegex ruleMap2 0) + "$", RegexOptions.Compiled)

        let ans1 = inputs |> Array.sumBy (checkRegex regex1) |> int64
        let ans2 = inputs |> Array.sumBy (checkRegex regex2) |> int64

        (ans1, ans2)

    [<Fact>]
    let Sample () =
        readInput "2020" "19" "sample" |> solveAndValidate (2L, 2L) solve

    [<Fact>]
    let Actual () =
        readInput "2020" "19" "actual" |> solveAndValidate (147L, 263L) solve