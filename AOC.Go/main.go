package main

import (
	a "aoc/aoc2018"
	"fmt"
	"io/ioutil"
	"os"
	"strings"
)

func main() {
	lines := read_input("2018", "02", "actual")
	fmt.Println(a.Solve2018_02_1(lines))
}

func read_input(year string, problem string, suffix string) []string {
	path := fmt.Sprintf("../input/%s/%s-%s.txt", year, problem, suffix)
	fileBytes, err := ioutil.ReadFile(path)

	if err != nil {
		fmt.Println(err)
		os.Exit(1)
	}

	lines := strings.Split(string(fileBytes), "\n")
	for i := range lines {
		lines[i] = strings.TrimSpace(lines[i])
	}

	return lines
}
