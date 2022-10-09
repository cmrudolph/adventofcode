package aoc2018

import (
	"strconv"
)

func AOC2018_01_1(lines []string) int64 {
	var sum int64 = 0
	for _, line := range lines {
		num, _ := strconv.ParseInt(line, 10, 64)
		sum += num
	}

	return sum
}
