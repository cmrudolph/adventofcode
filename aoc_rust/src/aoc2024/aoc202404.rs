fn check1(grid: &Vec<Vec<char>>, r_start: usize, c_start: usize, r_move: i32, c_move: i32) -> i32 {
    let mut r = r_start as i32;
    let mut c = c_start as i32;

    for i in 0..4 {
        if r < 0 || c < 0 {
            return 0;
        }

        let (ru, cu) = (r as usize, c as usize);

        if ru > grid.len() || cu > grid[0].len() {
            return 0;
        }

        if r < 0 || r >= grid.len() as i32 {
            return 0;
        }
        if c < 0 || c >= grid[0].len() as i32 {
            return 0;
        }
        if i == 0 && grid[ru][cu] != 'X' {
            return 0;
        }
        if i == 1 && grid[ru][cu] != 'M' {
            return 0;
        }
        if i == 2 && grid[ru][cu] != 'A' {
            return 0;
        }
        if i == 3 && grid[ru][cu] != 'S' {
            return 0;
        }

        r += r_move;
        c += c_move;
    }

    1
}

fn check2(grid: &Vec<Vec<char>>, r: usize, c: usize) -> i32 {
    if r == 0 || (r + 1) >= grid.len() {
        return 0;
    }
    if c == 0 || (c + 1) >= grid[0].len() {
        return 0;
    }

    if grid[r][c] != 'A' {
        return 0;
    }

    fn is_mas(grid: &Vec<Vec<char>>, r: usize, c: usize, r_move: i32, c_move: i32) -> i32 {
        if grid[r as usize][c as usize] != 'A' {
            return 0;
        }

        if grid[r + (r_move as usize)][c + (c_move as usize)] == 'M'
            && grid[r - (r_move as usize)][c - (c_move as usize)] == 'S'
        {
            return 1;
        }

        0
    }

    let mut sums = 0;

    sums += is_mas(grid, r as usize, c as usize, -1, -1);
    sums += is_mas(grid, r as usize, c as usize, 1, -1);
    sums += is_mas(grid, r as usize, c as usize, 1, 1);
    sums += is_mas(grid, r as usize, c as usize, -1, 1);

    if sums == 2 {
        1
    } else {
        0
    }
}

pub fn part1(input: &str) -> i32 {
    let grid: Vec<Vec<char>> = input.lines().map(|line| line.chars().collect()).collect();
    let mut sum = 0;

    for (r, row) in grid.iter().enumerate() {
        for (c, _) in row.iter().enumerate() {
            sum += check1(&grid, r, c, -1, 0); // N
            sum += check1(&grid, r, c, -1, 1); // NE
            sum += check1(&grid, r, c, 0, 1); // E
            sum += check1(&grid, r, c, 1, 1); // SE
            sum += check1(&grid, r, c, 1, 0); // S
            sum += check1(&grid, r, c, 1, -1); // SW
            sum += check1(&grid, r, c, 0, -1); // W
            sum += check1(&grid, r, c, -1, -1); // NW
        }
    }

    sum
}

pub fn part2(input: &str) -> i32 {
    let grid: Vec<Vec<char>> = input.lines().map(|line| line.chars().collect()).collect();
    let mut sum = 0;

    for (r, row) in grid.iter().enumerate() {
        for (c, _) in row.iter().enumerate() {
            sum += check2(&grid, r, c);
        }
    }

    sum
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
        assert_eq!(part2(&input), 9);
    }

    #[test]
    fn test_part2_actual() {
        let input = read("04-actual.txt");
        assert_eq!(part2(&input), 1875);
    }
}
