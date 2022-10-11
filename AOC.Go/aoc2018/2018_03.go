package aoc2018

import (
	"regexp"
	"strconv"
)

func Solve2018_03_1(lines []string) int64 {
	overlapping, _ := solve(lines)
	return overlapping
}

func Solve2018_03_2(lines []string) int64 {
	_, nonOverlappingId := solve(lines)
	return nonOverlappingId
}

func solve(lines []string) (int64, int64) {
	var grid [1000][1000]int
	allParsed := parse(lines)

	for _, p := range allParsed {
		for row := p.rowOffset; row < p.rowOffset+p.numRows; row++ {
			for col := p.colOffset; col < p.colOffset+p.numCols; col++ {
				grid[row][col]++
			}
		}
	}

	var overlapping int64
	for row := 0; row < 1000; row++ {
		for col := 0; col < 1000; col++ {
			if grid[row][col] > 1 {
				overlapping++
			}
		}
	}

	for i, p := range allParsed {
		isTheOne := true
		for row := p.rowOffset; isTheOne && row < p.rowOffset+p.numRows; row++ {
			for col := p.colOffset; isTheOne && col < p.colOffset+p.numCols; col++ {
				if grid[row][col] > 1 {
					isTheOne = false
				}
			}
		}

		if isTheOne {
			return overlapping, int64(i + 1)
		}
	}

	return -1, -1
}

func parse(lines []string) []Parsed {
	re := regexp.MustCompile(`#\d+ @ (\d+),(\d+): (\d+)x(\d+)`)

	allParsed := make([]Parsed, len(lines))
	for i, line := range lines {
		matches := re.FindStringSubmatch(line)
		colOffset, _ := strconv.Atoi(matches[1])
		rowOffset, _ := strconv.Atoi(matches[2])
		numCols, _ := strconv.Atoi(matches[3])
		numRows, _ := strconv.Atoi(matches[4])

		parsed := Parsed{
			colOffset: colOffset,
			rowOffset: rowOffset,
			numCols:   numCols,
			numRows:   numRows,
		}

		allParsed[i] = parsed
	}

	return allParsed
}

type Parsed struct {
	colOffset int
	rowOffset int
	numCols   int
	numRows   int
}
