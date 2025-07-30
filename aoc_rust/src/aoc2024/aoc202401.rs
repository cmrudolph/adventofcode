use std::collections::HashMap;

pub fn part1(input: &str) -> i32 {
    let lines = input.lines();

    let mut left: Vec<i32> = Vec::new();
    let mut right: Vec<i32> = Vec::new();

    for line in lines {
        let words: Vec<&str> = line.split_whitespace().collect();
        left.push(words[0].parse::<i32>().unwrap());
        right.push(words[1].parse::<i32>().unwrap());
    }

    left.sort();
    right.sort();

    let mut total_diff = 0;

    for i in 0..left.len() {
        let left_val = left[i];
        let right_val = right[i];
        let diff = (left_val - right_val).abs();
        total_diff += diff;
    }

    return total_diff;
}

pub fn part2(input: &str) -> i32 {
    let lines = input.lines();

    let mut left: Vec<i32> = Vec::new();

    let mut map: HashMap<i32, i32> = HashMap::new();

    for line in lines {
        let words: Vec<&str> = line.split_whitespace().collect();
        left.push(words[0].parse::<i32>().unwrap());

        let right_val = words[1].parse::<i32>().unwrap();
        *map.entry(right_val).or_insert(0) += 1;
    }

    let mut result = 0;
    for left_val in left {
        let count = map.get(&left_val).unwrap_or(&0);
        result += left_val * count;
    }

    return result;
}

#[cfg(test)]
mod tests {
    use super::*;

    fn read(filename: &str) -> String {
        let path = format!("input/{}", filename);
        std::fs::read_to_string(path).expect("Missing input file")
    }

    #[test]
    fn test_part1_sample() {
        let input = read("01-sample.txt");
        assert_eq!(part1(&input), 11);
    }

    #[test]
    fn test_part1_actual() {
        let input = read("01-actual.txt");
        assert_eq!(part1(&input), 1970720);
    }

    #[test]
    fn test_part2_sample() {
        let input = read("01-sample.txt");
        assert_eq!(part2(&input), 31);
    }

    #[test]
    fn test_part2_actual() {
        let input = read("01-actual.txt");
        assert_eq!(part2(&input), 17191599);
    }
}
