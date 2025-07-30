use aoc_rust::aoc2024::aoc202401;

fn main() {
    let input = std::fs::read_to_string("input/01-sample.txt").expect("Missing input file");
    println!("Part 1: {}", aoc202401::part1(&input));
}