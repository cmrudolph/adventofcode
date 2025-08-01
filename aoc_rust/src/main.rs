use aoc_rust::aoc2024::aoc202403;

fn main() {
    let input = std::fs::read_to_string("input/03-sample.txt").expect("Missing input file");
    println!("Part 3: {}", aoc202403::part2(&input));
}
