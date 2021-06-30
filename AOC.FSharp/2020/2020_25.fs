namespace AOC.FSharp

module AOC2020_25 =
    let transform value subject =
        (value * subject) % 20201227L

    let getLoopSize target subject =
        let mutable value = 1L
        let mutable loopSize = 0L

        while value <> target do
            value <- transform value subject
            loopSize <- loopSize + 1L

        loopSize

    let getEncryptionKey loopSize subject =
        (1L, [1L..loopSize]) ||> List.fold (fun acc i -> transform acc subject)

    let solve (lines : string[]) =
        let publicKeys = Array.map int64 lines

        let loopSize = getLoopSize publicKeys.[0] 7L
        let ans1 = getEncryptionKey loopSize publicKeys.[1]

        (ans1, 0L)