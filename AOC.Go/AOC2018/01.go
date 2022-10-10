package aoc2018

import (
	"strconv"
)

func Solve2018_01_1(lines []string) int64 {
	var sum int64 = 0
	for _, line := range lines {
		num, _ := strconv.ParseInt(line, 10, 64)
		sum += num
	}

	return sum
}

func Solve2018_01_2(lines []string) int64 {
	var sum int64 = 0
	seen := make(map[int64]int)
	for {
		for _, line := range lines {
			num, _ := strconv.ParseInt(line, 10, 64)
			sum += num
			if _, ok := seen[sum]; ok {
				return sum
			}

			seen[sum] = 1
		}
	}
}
