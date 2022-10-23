package aoc2018

import (
	"fmt"
	"io/ioutil"
	"os"
	"strings"
	"testing"
)

func Test_2018_01_Sample_1(t *testing.T) {
	doTestInt64(t, 3, Solve2018_01_1, "01", "sample")
}

func Test_2018_01_Actual_1(t *testing.T) {
	doTestInt64(t, 576, Solve2018_01_1, "01", "actual")
}

func Test_2018_01_Sample_2(t *testing.T) {
	doTestInt64(t, 2, Solve2018_01_2, "01", "sample")
}

func Test_2018_01_Actual_2(t *testing.T) {
	doTestInt64(t, 77674, Solve2018_01_2, "01", "actual")
}

func Test_2018_02_Sample_1(t *testing.T) {
	doTestInt64(t, 12, Solve2018_02_1, "02", "sample")
}

func Test_2018_02_Actual_1(t *testing.T) {
	doTestInt64(t, 8892, Solve2018_02_1, "02", "actual")
}

func Test_2018_02_Sample_2(t *testing.T) {
	doTestStr(t, "abcde", Solve2018_02_2, "02", "sample")
}

func Test_2018_02_Actual_2(t *testing.T) {
	doTestStr(t, "zihwtxagifpbsnwleydukjmqv", Solve2018_02_2, "02", "actual")
}

func Test_2018_03_Sample_1(t *testing.T) {
	doTestInt64(t, 4, Solve2018_03_1, "03", "sample")
}

func Test_2018_03_Actual_1(t *testing.T) {
	doTestInt64(t, 104126, Solve2018_03_1, "03", "actual")
}

func Test_2018_03_Sample_2(t *testing.T) {
	doTestInt64(t, 3, Solve2018_03_2, "03", "sample")
}

func Test_2018_03_Actual_2(t *testing.T) {
	doTestInt64(t, 695, Solve2018_03_2, "03", "actual")
}

func Test_2018_04_Sample_1(t *testing.T) {
	doTestInt64(t, 240, Solve2018_04_1, "04", "sample")
}

func Test_2018_04_Actual_1(t *testing.T) {
	doTestInt64(t, 39698, Solve2018_04_1, "04", "actual")
}

func Test_2018_04_Sample_2(t *testing.T) {
	doTestInt64(t, 4455, Solve2018_04_2, "04", "sample")
}

func Test_2018_04_Actual_2(t *testing.T) {
	doTestInt64(t, 14920, Solve2018_04_2, "04", "actual")
}

func assertInt64(t *testing.T, actual int64, expected int64) {
	if actual != expected {
		t.Errorf("Actual %d Expected %d", actual, expected)
	}
}

func assertStr(t *testing.T, actual string, expected string) {
	if actual != expected {
		t.Errorf("Actual %s Expected %s", actual, expected)
	}
}

type SolInt64 func([]string) int64
type SolString func([]string) string

func doTestInt64(t *testing.T, expected int64, fn SolInt64, problem string, suffix string) {
	lines := readInput("2018", problem, suffix)
	actual := fn(lines)
	assertInt64(t, actual, expected)
}

func doTestStr(t *testing.T, expected string, fn SolString, problem string, suffix string) {
	lines := readInput("2018", problem, suffix)
	actual := fn(lines)
	assertStr(t, actual, expected)
}

func readInput(year string, problem string, suffix string) []string {
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
