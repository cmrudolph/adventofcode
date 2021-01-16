namespace Tests

open Xunit
open Utils

module ``2020`` =
    [<Fact>]
    let ``01`` () =
        solveAndValidate "2020" "01" (468051L, 272611658L) AOC2020_01.solve

    [<Fact>]
    let ``02`` () =
        solveAndValidate "2020" "02" (434L, 509L) AOC2020_02.solve

    [<Fact>]
    let ``03`` () =
        solveAndValidate "2020" "03" (211L, 3584591857L) AOC2020_03.solve

    [<Fact>]
    let ``04`` () =
        solveAndValidate "2020" "04" (226L, 160L) AOC2020_04.solve

    [<Fact>]
    let ``05`` () =
        solveAndValidate "2020" "05" (933L, 711L) AOC2020_05.solve