fn check(grid: &Vec<Vec<char>>, r_start: usize, c_start: usize, r_move: i32, c_move: i32) -> i32 {
    let mut r = r_start as i32;
    let mut c = c_start as i32;

    for i in 0..4 {
        if r < 0 || r >= grid.len() as i32 {
            return 0;
        }
        if c < 0 || c >= grid[0].len() as i32 {
            return 0;
        }
        if i == 0 && grid[r as usize][c as usize] != 'X' {
            return 0;
        }
        if i == 1 && grid[r as usize][c as usize] != 'M' {
            return 0;
        }
        if i == 2 && grid[r as usize][c as usize] != 'A' {
            return 0;
        }
        if i == 3 && grid[r as usize][c as usize] != 'S' {
            return 0;
        }

        r += r_move;
        c += c_move;
    }

    1
}

pub fn part1(input: &str) -> i32 {
    let grid: Vec<Vec<char>> = input.lines().map(|line| line.chars().collect()).collect();
    let mut sum = 0;

    for (r, row) in grid.iter().enumerate() {
        for (c, _) in row.iter().enumerate() {
            sum += check(&grid, r, c, -1, 0); // N
            sum += check(&grid, r, c, -1, 1); // NE
            sum += check(&grid, r, c, 0, 1); // E
            sum += check(&grid, r, c, 1, 1); // SE
            sum += check(&grid, r, c, 1, 0); // S
            sum += check(&grid, r, c, 1, -1); // SW
            sum += check(&grid, r, c, 0, -1); // W
            sum += check(&grid, r, c, -1, -1); // NW
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
        let input = read("04-sample.txt");
        assert_eq!(part1(&input), 18);
    }

    #[test]
    fn test_part1_actual() {
        let input = read("04-actual.txt");
        assert_eq!(part1(&input), 2536);
    }

    #[test]
    fn test_part2_sample() {
        let input = read("04-sample.txt");
        assert_eq!(part2(&input), 48);
    }

    #[test]
    fn test_part2_actual() {
        let input = read("04-actual.txt");
        assert_eq!(part2(&input), 102467299);
    }
}
