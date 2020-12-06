open System.Text.RegularExpressions

let readInput =
    System.IO.File.ReadAllText("04.txt")

let phase1Func key _ =
    match key with
    | "ecl" -> true
    | "iyr" -> true
    | "hgt" -> true
    | "eyr" -> true
    | "pid" -> true
    | "byr" -> true
    | "hcl" -> true
    | _ -> false

let validateYearRange value min max =
    let typed = int(value)
    typed >= min && typed <= max

let validateHeightResult (regexMatch : Match) =
    let typed = int(regexMatch.Groups.[1].Value)
    let heightUnit = regexMatch.Groups.[2].Value
    match heightUnit with
        | "cm" -> typed >= 150 && typed <= 193
        | "in" -> typed >= 59 && typed <= 76
        | _ -> false

let validateHgt value =
    let m = Regex.Match(value, "(\d+)(cm|in)")
    if m.Success then validateHeightResult m else false

let phase2Func key value =
    match key with
    | "ecl" -> Regex.Match(value, "(amb|blu|brn|gry|grn|hzl|oth)").Success
    | "iyr" -> validateYearRange value 2010 2020
    | "hgt" -> validateHgt value
    | "eyr" -> validateYearRange value 2020 2030
    | "pid" -> Regex.Match(value, "^\d{9}$").Success
    | "byr" -> validateYearRange value 1920 2002
    | "hcl" -> Regex.Match(value, "#[0-9a-f]{6}$").Success
    | _ -> false

let validatePair pairEvalFunc (pair : string) =
    let splits = pair.Split(':')
    let key = splits.[0]
    let value = splits.[1]
    let valid = pairEvalFunc key value
    if valid then 1 else 0

let countValidPairs validatorFunc (passportLine : string) =
    passportLine.Split(' ')
    |> Array.map (fun pair -> validatorFunc pair)
    |> Array.sum

let solve pairEvalFunc passportLines =
    passportLines
    |> Array.map (countValidPairs (validatePair pairEvalFunc))
    |> Array.filter ((=) 7)
    |> Array.length
    |> printfn "%i"

let passportLines = readInput.Replace("\r\n\r\n", "|").Replace("\r\n", " ").Split('|')

passportLines |> solve phase1Func
passportLines |> solve phase2Func
