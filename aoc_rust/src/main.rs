use aoc_rust::aoc2024::aoc202405;

fn main() {
    let input = std::fs::read_to_string("input/05-sample.txt").expect("Missing input file");
    println!("Part 5: {}", aoc202405::part1(&input));
}
