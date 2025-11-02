use aoc_rust::aoc2024::aoc202404;

fn main() {
    let input = std::fs::read_to_string("input/04-sample.txt").expect("Missing input file");
    println!("Part 4: {}", aoc202404::part1(&input));
}
