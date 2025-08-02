use regex::Regex;

fn get_products(re: &Regex, s: &str) -> Vec<i32> {
    let products: Vec<i32> = re
        .captures_iter(s)
        .map(|caps| {
            let (_, [a, b]) = caps.extract();
            let val1 = a.parse::<i32>().unwrap();
            let val2 = b.parse::<i32>().unwrap();
            val1 * val2
        })
        .collect();

    return products;
}

pub fn part1(input: &str) -> i32 {
    let re = Regex::new(r"mul\((\d{1,3}),(\d{1,3})\)").unwrap();
    let products = get_products(&re, input);
    products.iter().sum()
}

pub fn part2(input: &str) -> i32 {
    let re = Regex::new(r"mul\((\d{1,3}),(\d{1,3})\)").unwrap();
    let mut valid_chunks: Vec<&str> = Vec::new();

    let splits1: Vec<&str> = input.split("don't()").collect();
    valid_chunks.push(splits1[0]);

    for s1 in splits1[1..].iter() {
        let splits2: Vec<&str> = s1.split("do()").collect();
        if splits2.len() > 1 {
            for i in 1..splits2.len() {
                valid_chunks.push(splits2[i]);
            }
        }
    }

    let mut result: i32 = 0;
    for x in valid_chunks {
        let products = get_products(&re, x);
        for p in products {
            result += p;
        }
    }
    result
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
        let input = read("03-sample.txt");
        assert_eq!(part1(&input), 161);
    }

    #[test]
    fn test_part1_actual() {
        let input = read("03-actual.txt");
        assert_eq!(part1(&input), 178538786);
    }

    #[test]
    fn test_part2_sample() {
        let input = read("03-sample.txt");
        assert_eq!(part2(&input), 48);
    }

    #[test]
    fn test_part2_actual() {
        let input = read("03-actual.txt");
        assert_eq!(part2(&input), 102467299);
    }
}
