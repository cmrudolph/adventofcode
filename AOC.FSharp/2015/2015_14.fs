namespace AOC.FSharp

module AOC2015_14 =
    open System.Collections.Generic
    open System.Text.RegularExpressions

    type Reindeer = { Name: string; MoveSeconds: Map<int, int> }

    let regex =
        Regex(
            "(\w+) can fly (\d+) km/s for (\d+) seconds, but then must rest for (\d+) seconds."
        )

    let parse seconds line =
        let m = regex.Match(line)
        let name = m.Groups.[1].Value
        let speed = m.Groups.[2].Value |> int
        let travelSeconds = m.Groups.[3].Value |> int
        let restSeconds = m.Groups.[4].Value |> int

        let mutable travelSecondsRemaining = travelSeconds
        let mutable restSecondsRemaining = 0
        let mutable travelMap = Map.empty
        let mutable i = 1

        // Build a complete "travel map", which serves up the amount of movement that will happen at each possible
        // second in the simulation. Rest seconds include a zero to make sure the lookup works for all cases
        while i <= seconds do
            if travelSecondsRemaining > 0 then
                travelMap <- Map.add i speed travelMap
                travelSecondsRemaining <- travelSecondsRemaining - 1

                if travelSecondsRemaining = 0 then
                    restSecondsRemaining <- restSeconds

                i <- i + 1
            else if restSecondsRemaining > 0 then
                travelMap <- Map.add i 0 travelMap
                restSecondsRemaining <- restSecondsRemaining - 1

                if restSecondsRemaining = 0 then
                    travelSecondsRemaining <- travelSeconds

                i <- i + 1

        { Name = name; MoveSeconds = travelMap }

    let getAmountForSecond reindeer second =
        match reindeer.MoveSeconds.TryGetValue(second) with
        | true, amount -> amount
        | false, _ -> 0

    let calcDistance seconds reindeer =
        [| 1 .. seconds |] |> Array.sumBy (getAmountForSecond reindeer)

    let solve1 (lines: string []) (extra: string) =
        let seconds = extra |> int
        let allReindeer = lines |> Array.map (parse seconds)

        allReindeer |> Array.map (calcDistance seconds) |> Array.max |> int64

    let solve2 (lines: string []) (extra: string) =
        let seconds = extra |> int
        let allReindeer = lines |> Array.map (parse seconds)

        let positions = new Dictionary<string, int>()
        let points = new Dictionary<string, int>()

        for r in allReindeer do
            positions.Add(r.Name, 0)
            points.Add(r.Name, 0)

        for i in [ 1 .. seconds ] do
            for r in allReindeer do
                // Move each reindeer the proper amount for this second
                positions.[r.Name] <- positions.[r.Name] + r.MoveSeconds.[i]

            // Find the position of the leader(s). The position is found rather than selecting the front reindeer
            // directly because ties require granting points to all leaders
            let leaderPosition =
                positions.Keys
                |> Seq.map (fun x -> (x, positions.[x]))
                |> Seq.sortByDescending (fun (_, value) -> value)
                |> Seq.map (fun (_, value) -> value)
                |> Seq.head

            // Find the leader(s) by finding all reindeer matching the highest position
            let leaderNames =
                positions.Keys
                |> Seq.map (fun x -> (x, positions.[x]))
                |> Seq.filter (fun (name, value) -> value = leaderPosition)
                |> Seq.map (fun (name, _) -> name)

            // Grant a point to all leaders
            for leaderName in leaderNames do
                points.[leaderName] <- points.[leaderName] + 1

        points.Values |> Seq.sortByDescending id |> Seq.head |> int64
