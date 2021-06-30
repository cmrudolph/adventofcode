namespace AOC.FSharp

module AOC2015_04 =
    open System

    let buildPrefixTarget length =
        let zeroes = "".PadRight(length, '0')
        let delimited = zeroes.Replace("00", "00-")
        delimited.TrimEnd('-')

    let (|Prefix|_|) (p:string) (s:string) =
        if s.StartsWith(p) then
            Some(s.Substring(p.Length))
        else
            None

    let calcMd5 computeHash (str : string) =
        str
        |> System.Text.Encoding.ASCII.GetBytes
        |> computeHash
        |> (function hash -> BitConverter.ToString(hash))

    let rec calculate computeHash prefix value prefixTarget =
        let md5Result = calcMd5 computeHash (prefix + string(value))
        match md5Result with
        | Prefix prefixTarget _ -> int64(value)
        | _ -> calculate computeHash prefix (value + 1) prefixTarget

    let solve (lines : string[]) =
        let str = lines.[0]

        let md5 = System.Security.Cryptography.MD5.Create()
        let ans1 = buildPrefixTarget 5 |> calculate md5.ComputeHash str 0
        let ans2 = buildPrefixTarget 6 |> calculate md5.ComputeHash str 0

        (ans1, ans2)