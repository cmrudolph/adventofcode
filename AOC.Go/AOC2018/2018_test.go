package aoc2018

import (
	"fmt"
	"io/ioutil"
	"os"
	"strings"
	"testing"
)

func Test_2018_01_Sample_1(t *testing.T) {
	lines := read_input("2018", "01", "sample")
	actual := AOC2018_01_1(lines)
	assert(t, actual, 3)
}

func Test_2018_01_Actual_1(t *testing.T) {
	lines := read_input("2018", "01", "actual")
	actual := AOC2018_01_1(lines)
	assert(t, actual, 576)
}

func assert(t *testing.T, actual int64, expected int64) {
	if actual != expected {
		t.Errorf("Actual %d Expected %d", actual, expected)
	}
}

func read_input(year string, problem string, suffix string) []string {
	path := fmt.Sprintf("../../input/%s/%s-%s.txt", year, problem, suffix)
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
