open System.Text.RegularExpressions

type Input =
    { Val1: int
      Val2: int
      Target: char
      Password: string }

let makeRec inputLine =
    let pattern = Regex("(.*)-(.*) (.): (.*)")
    let m = pattern.Match(inputLine)
    { Val1 = System.Int32.Parse(m.Groups.[1].Value)
      Val2 = System.Int32.Parse(m.Groups.[2].Value)
      Target = System.Char.Parse(m.Groups.[3].Value)
      Password = m.Groups.[4].Value }

let readInput =
    System.IO.File.ReadLines("02.txt")

let validFun1 r =
    Seq.toList r.Password
    |> Seq.filter ((=) r.Target)
    |> Seq.length
    |> (fun o -> if o <= r.Val2 && o >= r.Val1 then true else false)

let validFun2 r =
    let chars = Seq.toList r.Password
    ((chars.[r.Val1 - 1] = r.Target) <> (chars.[r.Val2 - 1] = r.Target))

let solve validFun recs =
    recs
    |> Seq.filter validFun
    |> Seq.length
    |> (fun len -> printfn "%i" len)

readInput |> Seq.map makeRec |> solve validFun1
readInput |> Seq.map makeRec |> solve validFun2
