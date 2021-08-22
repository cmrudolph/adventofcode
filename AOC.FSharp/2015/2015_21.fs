namespace AOC.FSharp

module AOC2015_21 =
    open System.Collections.Generic
    open System.Linq

    type Item = { Name: string; Cost: int; Damage: int; Armor: int }

    type BossStats = { HitPoints: int; Damage: int; Armor: int }

    type SimulateResult = { Gold: int; PlayerWon: bool }

    let parseLine (line: string) = line.Split(':').[1] |> int

    let parse (lines: string []) =
        let hp = parseLine (lines.[0])
        let damage = parseLine (lines.[1])
        let armor = parseLine (lines.[2])

        { HitPoints = hp; Damage = damage; Armor = armor }

    let weapons =
        [ { Name = "Dagger"; Cost = 8; Damage = 4; Armor = 0 }
          { Name = "Shortsword"; Cost = 10; Damage = 5; Armor = 0 }
          { Name = "Warhammer"; Cost = 25; Damage = 6; Armor = 0 }
          { Name = "Longsword"; Cost = 40; Damage = 7; Armor = 0 }
          { Name = "Greataxe"; Cost = 74; Damage = 8; Armor = 0 } ]

    let armor =
        [ { Name = "None"; Cost = 0; Damage = 0; Armor = 0 }
          { Name = "Leather"; Cost = 13; Damage = 0; Armor = 1 }
          { Name = "Chainmail"; Cost = 31; Damage = 0; Armor = 2 }
          { Name = "Splintmail"; Cost = 53; Damage = 0; Armor = 3 }
          { Name = "Bandedmail"; Cost = 75; Damage = 0; Armor = 4 }
          { Name = "Platemail"; Cost = 102; Damage = 0; Armor = 5 } ]

    let rings =
        [ { Name = "None"; Cost = 0; Damage = 0; Armor = 0 }
          { Name = "None"; Cost = 0; Damage = 0; Armor = 0 }
          { Name = "Damage +1"; Cost = 25; Damage = 1; Armor = 0 }
          { Name = "Damage +2"; Cost = 50; Damage = 2; Armor = 0 }
          { Name = "Damage +3"; Cost = 100; Damage = 3; Armor = 0 }
          { Name = "Defense +1"; Cost = 20; Damage = 0; Armor = 1 }
          { Name = "Defense +2"; Cost = 40; Damage = 0; Armor = 2 }
          { Name = "Defense +3"; Cost = 80; Damage = 0; Armor = 3 } ]

    let combineItems weapon armor ring1 ring2 =
        { Name = "Combined"
          Cost = weapon.Cost + armor.Cost + ring1.Cost + ring2.Cost
          Damage = weapon.Damage + armor.Damage + ring1.Damage + ring2.Damage
          Armor = weapon.Armor + armor.Armor + ring1.Armor + ring2.Armor }

    let calcNewHp hp damage armor =
        let damageDone = max (damage - armor) 1
        hp - damageDone

    let simulate boss (loadout: Item) =
        let mutable playerHp = 100
        let mutable bossHp = boss.HitPoints

        while playerHp > 0 && bossHp > 0 do
            bossHp <- calcNewHp bossHp loadout.Damage boss.Armor

            if bossHp > 0 then
                playerHp <- calcNewHp playerHp boss.Damage loadout.Armor

        playerHp

    let simulateAll boss =
        let results = new List<SimulateResult>()

        for w in weapons do
            for a in armor do
                for i in [ 0 .. rings.Length - 1 ] do
                    for j in [ i + 1 .. rings.Length - 1 ] do
                        let loadout = combineItems w a rings.[i] rings.[j]
                        let finalPlayerHealth = simulate boss loadout

                        results.Add(
                            { PlayerWon = finalPlayerHealth > 0
                              Gold = loadout.Cost }
                        )

        results

    let solve1 (lines: string []) =
        let boss = parse lines
        let results = simulateAll boss

        results
            .Where((fun r -> r.PlayerWon))
            .Select((fun r -> r.Gold))
            .Min()
        |> int64

    let solve2 (lines: string []) =
        let boss = parse lines
        let results = simulateAll boss

        results
            .Where((fun r -> (not r.PlayerWon)))
            .Select((fun r -> r.Gold))
            .Max()
        |> int64
