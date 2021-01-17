namespace Tests

open Xunit
open Utils

module ``2015`` =
    [<Fact>]
    let ``01`` () =
        solveAndValidate "2015" "01" (74L, 1795L) AOC2015_01.solve

    [<Fact>]
    let ``02`` () =
        solveAndValidate "2015" "02" (1598415L, 3812909L) AOC2015_02.solve

    [<Fact>]
    let ``03`` () =
        solveAndValidate "2015" "03" (2572L, 2631L) AOC2015_03.solve