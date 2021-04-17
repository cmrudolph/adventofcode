﻿namespace Year2015

module Day05 =
    open Utils
    open Xunit

    let isNice1 (s : string) =
        let hasDoubleLetter =
            [0..s.Length-2] |> List.exists (fun i -> s.[i] = s.[i+1])

        let hasAtLeastThreeVowels =
            let isVowel ch =
                ch = 'a' || ch = 'e' || ch = 'i' || ch = 'o' || ch = 'u'
            s |> Seq.filter isVowel |> Seq.length >= 3

        let doesNotHaveBannedStrings =
            let isBanned s2 =
                s2 = "ab" || s2 = "cd" || s2 = "pq" || s2 = "xy"
            [0..s.Length-2] |> List.map (fun i -> s.[i..i+1]) |> List.exists isBanned |> not

        hasDoubleLetter && hasAtLeastThreeVowels && doesNotHaveBannedStrings

    let isNice2 (s : string) =
        let hasPairTwiceNoOverlap =
            [0..s.Length-2]
            |> List.map (fun i -> (i, s.[i..i+1]))
            |> List.groupBy (fun (_, s2) -> s2)
            |> List.map (fun (_, lst) -> (lst, List.length lst))
            |> List.exists (fun (lst, len) -> len > 2 || len = 2 && abs((fst lst.[0]) - fst lst.[1]) > 1)

        let hasLetterRepeatWithGap =
            [0..s.Length-3] |> List.exists (fun i -> s.[i] = s.[i+2])

        hasPairTwiceNoOverlap && hasLetterRepeatWithGap

    let solver filter lines =
        lines |> Array.filter filter |> Array.length |> int64

    let solve (lines : string[]) =
        let ans1 = lines |> solver isNice1
        let ans2 = lines |> solver isNice2
        (ans1, ans2)

    [<Fact>]
    let Sample () =
        readInput "2015" "05" "sample" |> solveAndValidate (2L, 0L) solve

    [<Fact>]
    let Actual () =
        readInput "2015" "05" "actual" |> solveAndValidate (258L, 53L) solve