use std::collections::HashMap;
use std::collections::HashSet;

pub fn part1(input: &str) -> i32 {
    let lines = input.lines();
    let mut lookup = HashMap::new();
    let mut sum = 0;

    let mut first_part = true;
    for line in lines {
        if line.len() == 0 {
            first_part = false;
        } else {
            if first_part {
                //1|2
                let splits: Vec<&str> = line.split('|').collect();
                let val1 = splits[0].parse::<i32>().unwrap();
                let val2 = splits[1].parse::<i32>().unwrap();
                lookup.entry(val2).or_insert_with(HashSet::new).insert(val1);
            } else {
                //1,2,3,4
                let splits: Vec<&str> = line.split(',').collect();
                let mut is_good = true;
                let mut lookup_copy = lookup.clone();
                let mut values_this_pass = HashSet::new();

                // Figure out which values are represented by this line
                for s in &splits {
                    let val = s.parse::<i32>().unwrap();
                    values_this_pass.insert(val);
                }

                // Prune the lookup down to only the values we care about for this line. This lets
                // us later use "empty set" as valid criteria for all fulfilled dependencies
                for set in lookup_copy.values_mut() {
                    for set_val in set {
                        if !values_this_pass.contains(set_val) {
                            set.remove(set_val);
                        }
                    }
                }

                // Each iteration is an update (its own case)
                for s in &splits {
                    let val = s.parse::<i32>().unwrap();

                    let entry = lookup_copy.entry(val).or_default();

                    // An empty dependency array means we have no unsatisfied dependencies and
                    // the current value is therefore a valid move
                    if !entry.is_empty() {
                        println!("{:?} | {:?} | {}", splits, entry, val);
                        is_good = false;
                        break;
                    }

                    // Remove the value from all lookups. We have visited it so it is no longer
                    // an unsatisfied dependency of any other numbers
                    for e in lookup_copy.values_mut() {
                        e.remove(&val);
                    }
                }

                if is_good {
                    let middle_idx = splits.len() / 2;
                    let val = splits[middle_idx].parse::<i32>().unwrap();

                    // println!("{:?} -> {1}", splits, middle_idx);
                    sum += val;
                }
            }
        }
    }

    sum
}

pub fn part2(_: &str) -> i32 {
    -1
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
        let input = read("05-sample.txt");
        assert_eq!(part1(&input), 18);
    }

    #[test]
    fn test_part1_actual() {
        let input = read("05-actual.txt");
        assert_eq!(part1(&input), 2536);
    }

    #[test]
    fn test_part2_sample() {
        let input = read("05-sample.txt");
        assert_eq!(part2(&input), 9);
    }

    #[test]
    fn test_part2_actual() {
        let input = read("05-actual.txt");
        assert_eq!(part2(&input), 1875);
    }
}
