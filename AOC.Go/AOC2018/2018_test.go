package aoc2018

import (
	"fmt"
	"io/ioutil"
	"os"
	"strings"
	"testing"
)

func Test_2018_01_Sample_1(t *testing.T) {
	do_test(t, 3, AOC2018_01_1, "01", "sample")
}

func Test_2018_01_Actual_1(t *testing.T) {
	do_test(t, 576, AOC2018_01_1, "01", "actual")
}

func Test_2018_01_Sample_2(t *testing.T) {
	do_test(t, 2, AOC2018_01_2, "01", "sample")
}

func Test_2018_01_Actual_2(t *testing.T) {
	do_test(t, 77674, AOC2018_01_2, "01", "actual")
}

func assert(t *testing.T, actual int64, expected int64) {
	if actual != expected {
		t.Errorf("Actual %d Expected %d", actual, expected)
	}
}

type SolInt64 func([]string) int64

func do_test(t *testing.T, expected int64, fn SolInt64, problem string, suffix string) {
	lines := read_input("2018", problem, suffix)
	actual := fn(lines)
	assert(t, actual, expected)
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
