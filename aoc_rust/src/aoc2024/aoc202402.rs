fn is_safe(vals: &Vec<i32>) -> bool {
    let up = vals[1] > vals[0];
    for i in 0..vals.len() - 1 {
        let n1 = vals[i];
        let n2 = vals[i + 1];

        if n1 == n2 || (n1 - n2).abs() > 3 {
            return false;
        }

        if (n1 > n2 && up) || (n1 < n2 && !up) {
            return false;
        }
    }

    true
}

pub fn part1(input: &str) -> i32 {
    let lines = input.lines();

    let mut safe_count = 0;

    for line in lines {
        let nums = line
            .split_whitespace()
            .map(|x| x.parse::<i32>().unwrap())
            .collect();

        let safe = is_safe(&nums);
        safe_count += if safe { 1 } else { 0 };
    }

    safe_count
}

pub fn part2(input: &str) -> i32 {
    let lines = input.lines();

    let mut safe_count = 0;

    for line in lines {
        let nums = line
            .split_whitespace()
            .map(|x| x.parse::<i32>().unwrap())
            .collect();

        let mut mod_safe = false;
        let orig_safe = is_safe(&nums);
        for i in 0..nums.len() {
            let mut modified = nums.clone();
            modified.remove(i);

            mod_safe |= is_safe(&modified);
            if mod_safe {
                break;
            }
        }

        safe_count += if orig_safe || mod_safe { 1 } else { 0 };
    }

    safe_count
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
        let input = read("02-sample.txt");
        assert_eq!(part1(&input), 2);
    }

    #[test]
    fn test_part1_actual() {
        let input = read("02-actual.txt");
        assert_eq!(part1(&input), 591);
    }

    #[test]
    fn test_part2_sample() {
        let input = read("02-sample.txt");
        assert_eq!(part2(&input), 4);
    }

    #[test]
    fn test_part2_actual() {
        let input = read("02-actual.txt");
        assert_eq!(part2(&input), 621);
    }
}
