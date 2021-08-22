namespace AOC.FSharp

module AOC2020_22 =
    open System

    type Deck = int list

    type Decks = { Deck1: Deck; Deck2: Deck }

    type GameState = { Decks: Decks; Previous: Set<Decks> }

    let parseInitial (lines: string []) =
        let decks =
            (String
                .Join("|", lines)
                 .Split([| "||" |], StringSplitOptions.None)
             |> Array.map (fun (x: string) -> x.Split('|'))
             |> Array.map (fun x -> x.[1..]))

        let deck1 = decks.[0] |> Array.map int |> List.ofArray
        let deck2 = decks.[1] |> Array.map int |> List.ofArray

        { Decks = { Deck1 = deck1; Deck2 = deck2 }; Previous = Set.empty }

    let isInstantWin gameState =
        // Have we seen this game arrangement before?
        gameState.Previous |> Set.contains gameState.Decks

    let findWinnerForNormalRound gameState =
        let decks = gameState.Decks

        // Normal round is just a comparison of the top cards
        if decks.Deck1.[0] > decks.Deck2.[0] then 1 else 2

    let isGameOver gameState winner =
        // If the last round's winner is going to take the last card from the other deck, it is over
        if winner = 1 && gameState.Decks.Deck2.Length = 1 then true
        elif winner = 2 && gameState.Decks.Deck1.Length = 1 then true
        else false

    let transformForWinner gameState winner =
        let decks = gameState.Decks
        let d1 = decks.Deck1
        let d2 = decks.Deck2
        let newPrevious = gameState.Previous |> Set.add decks

        // Rearrange the decks appropriately based on which player won the round. The round cards are appended
        // to the winner's deck with the winner's card coming first
        if winner = 1 then
            { Decks =
                  { Deck1 = d1.[1..] @ [ d1.[0]; d2.[0] ]; Deck2 = d2.[1..] }
              Previous = newPrevious }
        else
            { Decks =
                  { Deck1 = d1.[1..]; Deck2 = d2.[1..] @ [ d2.[0]; d1.[0] ] }
              Previous = newPrevious }

    let transformDeckForSubGame deck =
        match deck with
        | x :: xs ->
            // Use first card to determine A, then take the next A cards to form a new deck
            if x <= (List.length xs) then Some(xs |> List.take x) else None
        | _ -> None

    let transformForSubGame gameState =
        let new1 = transformDeckForSubGame gameState.Decks.Deck1
        let new2 = transformDeckForSubGame gameState.Decks.Deck2
        let newDecks = (new1, new2)

        // Make the new decks and create a brand new game state. None of the previously seen configurations
        // need to carry over. A sub game is a brand new thing
        match newDecks with
        | (Some d1, Some d2) ->
            { Decks = { Deck1 = d1; Deck2 = d2 }; Previous = Set.empty }
        | _ -> failwith "Cannot play subgame with these inputs"

    let shouldPlaySubGame gameState =
        let new1 = transformDeckForSubGame gameState.Decks.Deck1
        let new2 = transformDeckForSubGame gameState.Decks.Deck2
        let newDecks = (new1, new2)

        // Only play a sub game if both decks meet the criteria for it
        match newDecks with
        | (Some _, Some _) -> true
        | _ -> false

    let rec playGame shouldPlaySub gameState =
        let mutable isDone = false
        let mutable localState = gameState
        let mutable winner = 1

        while not isDone do
            winner <-
                if isInstantWin localState then
                    // Player 1 always instant wins the game in this situation
                    isDone <- true
                    1
                elif shouldPlaySub localState then
                    let subState = transformForSubGame localState
                    let win, _ = playGame shouldPlaySub subState
                    isDone <- isGameOver localState win
                    win
                else
                    let win = findWinnerForNormalRound localState
                    isDone <- isGameOver localState win
                    win

            localState <- transformForWinner localState winner

        (winner, localState)

    let calcValue deck =
        deck
        |> List.rev
        |> List.mapi (fun i el -> (i + 1) * el)
        |> List.sum
        |> int64

    let playAndCalculate play gameState =
        let win, state = play gameState

        let deck =
            match win with
            | 1 -> state.Decks.Deck1
            | 2 -> state.Decks.Deck2
            | _ -> failwith $"Bad winner value {win}"

        calcValue deck

    let solve1 (lines: string []) =
        let play1 = playGame (fun _ -> false)
        parseInitial lines |> playAndCalculate play1

    let solve2 (lines: string []) =
        let play2 = playGame shouldPlaySubGame
        parseInitial lines |> playAndCalculate play2
