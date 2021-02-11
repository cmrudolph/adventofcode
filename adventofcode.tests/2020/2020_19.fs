namespace Year2020

module Day19 =
    open System
    open System.Text.RegularExpressions
    open Utils
    open Xunit

    type RuleDef =
        Literal of char
        | Single of int list
        | Piped of (int list * int list)

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

    let parseList line =
        let regex = new Regex("^(\d+): (\d+[^|]*)$")
        let regexMatch = regex.Match(line)
        if regexMatch.Success then
            let id = regexMatch.Groups.[1].Value |> int
            let values = regexMatch.Groups.[2].Value |> intStringToInts
            Some { Id = id; Def = RuleDef.Single values }
        else
            None

    let parsePiped line =
        let regex = new Regex("^(\d+): (\d.*)\|( \d.*)$")
        let regexMatch = regex.Match(line)
        if regexMatch.Success then
            let id = regexMatch.Groups.[1].Value |> int
            let values1 = regexMatch.Groups.[2].Value |> intStringToInts
            let values2 = regexMatch.Groups.[3].Value |> intStringToInts
            Some { Id = id; Def = RuleDef.Piped (values1, values2) }
        else
            None

    let parse line =
        [parseLiteral; parseList; parsePiped]
        |> List.map (fun f -> f line)
        |> List.choose id
        |> List.head

    let rec buildRegex (ruleMap : Map<int, RuleDef>) target =
        let rule = ruleMap.[target]
        match rule with
        | Literal ch -> ch |> string
        | Single lst -> "(" + String.Join("", lst |> List.map (fun x -> buildRegex ruleMap x)) + ")"
        | Piped (lst1, lst2) ->
            let segment1 = String.Join("", lst1 |> List.map (fun x -> buildRegex ruleMap x))
            let segment2 = String.Join("", lst2 |> List.map (fun x -> buildRegex ruleMap x))
            "((" + segment1 + ")|(" + segment2 + "))"

    let checkRegex regex input =
           let r = new Regex(regex)
           if r.IsMatch(input) then 1 else 0

    let solve (lines : string[]) =
        let ruleMap = (lines
        |> Array.takeWhile (fun line -> line <> "")
        |> Array.map parse
        |> Array.map (fun rule -> (rule.Id, rule.Def))
        |> Map.ofArray)

        let inputs = (lines
        |> Array.skipWhile (fun line -> line <> "")
        |> Array.skip 1)

        let regex = "^" + (buildRegex ruleMap 0) + "$"

        let ans1 = inputs |> Array.sumBy (checkRegex regex) |> int64

        (ans1, 0L)

    [<Fact>]
    let Sample () =
        readInput "2020" "19" "sample" |> solveAndValidate (2L, -1L) solve

    [<Fact>]
    let Actual () =
        readInput "2020" "19" "actual" |> solveAndValidate (147L, 888L) solve