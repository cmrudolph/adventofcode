package aoc2018

func Solve2018_02_1(lines []string) int64 {
	twos := 0
	threes := 0

	for _, line := range lines {
		letterCounts := make(map[string]int)
		seenTwo := false
		seenThree := false

		for _, ch := range line {
			typed := string(ch)
			letterCounts[typed] = letterCounts[typed] + 1
		}

		for _, v := range letterCounts {
			if !seenTwo && v == 2 {
				twos += 1
				seenTwo = true
			}
			if !seenThree && v == 3 {
				threes += 1
				seenThree = true
			}
		}
	}

	return int64(twos * threes)
}

func Solve2018_02_2(lines []string) string {
	lineCount := len(lines)

	for i := 0; i < lineCount; i++ {
		for j := i + 1; j < lineCount; j++ {
			line1 := lines[i]
			line2 := lines[j]
			combined := ""
			mismatches := 0

			for k := range line1 {
				ch1 := string(line1[k])
				ch2 := string(line2[k])
				if ch1 == ch2 {
					combined += ch1
				} else {
					mismatches++
				}
			}

			if mismatches == 1 {
				return combined
			}
		}
	}

	return ""
}
