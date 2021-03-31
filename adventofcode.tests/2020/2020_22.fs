namespace Year2020

module Day22 =
    open System
    open Utils
    open Xunit

    type Unfinished = { Deck1: int list; Deck2: int list }
    type Finished = { Deck: int list }
    type Game = 
        Unfinished of Unfinished
        | Finished of Finished

    let parse_initial (lines : string[]) =
        let decks = (String.Join("|", lines).Split([|"||"|], StringSplitOptions.None)
        |> Array.map (fun (x : string) -> x.Split('|'))
        |> Array.map (fun x -> x.[1..]))

        let deck1 = decks.[0] |> Array.map int |> List.ofArray
        let deck2 = decks.[1] |> Array.map int |> List.ofArray

        Game.Unfinished { Deck1 = deck1; Deck2 = deck2 }

    let play_round game =
        match game with
        | Finished _ -> game
        | Unfinished u ->
            if u.Deck1.[0] > u.Deck2.[0] then
                match u.Deck2 with
                | [] -> Game.Finished { Deck = u.Deck1 }
                | [_] -> Game.Finished { Deck = u.Deck1.[1..] @ [u.Deck1.[0]; u.Deck2.[0]] }
                | _ :: xs -> Game.Unfinished { Deck1 = u.Deck1.[1..] @ [u.Deck1.[0]; u.Deck2.[0]]; Deck2 = xs}
            else
                match u.Deck1 with
                | [] -> Game.Finished { Deck = u.Deck2 }
                | [_] -> Game.Finished { Deck = u.Deck2.[1..] @ [u.Deck2.[0]; u.Deck1.[0]] }
                | _ :: xs -> Game.Unfinished { Deck1 = xs; Deck2 = u.Deck2.[1..] @ [u.Deck2.[0]; u.Deck1.[0]] }

    let rec play_until_done game =
        match game with
        | Finished _ -> game
        | Unfinished _ -> play_until_done (play_round game)

    let calc_value game =
        match game with
        | Finished f ->
            f.Deck
            |> List.rev
            |> List.mapi (fun i el -> (i + 1) * el)
            |> List.sum
            |> int64
        | Unfinished _ -> -1L

    let solve (lines : string[]) =
        let initial_game = parse_initial lines
        let done_game = play_until_done initial_game
        let ans1 = calc_value done_game

        (ans1, 0L)

    [<Fact>]
    let Sample () =
        readInput "2020" "22" "sample" |> solveAndValidate (306L, -1L) solve

    [<Fact>]
    let Actual () =
        readInput "2020" "22" "actual" |> solveAndValidate (34664L, -1L) solve