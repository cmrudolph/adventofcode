package aoc2018

import (
	"regexp"
	"sort"
	"strconv"
)

func Solve2018_04_1(lines []string) int64 {
	infos := buildInfos(lines)

	var most *GuardInfo
	for _, v := range infos {
		if most == nil || v.totalMins > most.totalMins {
			most = v
		}
	}

	best := 0
	for i := 0; i < 60; i++ {
		if most.minuteCounts[i] > most.minuteCounts[best] {
			best = i
		}
	}

	return int64(most.id * (best))
}

func Solve2018_04_2(lines []string) int64 {
	infos := buildInfos(lines)

	var best *Part2Result

	for _, v := range infos {
		for i := 0; i < 60; i++ {
			if best == nil || v.minuteCounts[i] > best.count {
				result := Part2Result{
					id:     v.id,
					minute: i,
					count:  v.minuteCounts[i],
				}
				best = &result
			}
		}
	}

	return int64(best.id * best.minute)
}

func buildInfos(lines []string) map[int]*GuardInfo {
	guardRe := regexp.MustCompile(`Guard #(\d+)`)
	sleepRe := regexp.MustCompile(`:(\d\d)] falls`)
	wakeRe := regexp.MustCompile(`:(\d\d)] wakes`)

	sort.Strings(lines)

	guardInfos := make(map[int]*GuardInfo)

	var currInfo *GuardInfo
	var currSleep int

	for _, s := range lines {
		guardMatches := guardRe.FindStringSubmatch(s)
		sleepMatches := sleepRe.FindStringSubmatch(s)
		wakeMatches := wakeRe.FindStringSubmatch(s)

		if guardMatches != nil {
			found := false
			guardNum, _ := strconv.Atoi(guardMatches[1])
			currInfo, found = guardInfos[guardNum]
			if !found {
				newInfo := GuardInfo{
					id:        guardNum,
					totalMins: 0,
				}
				guardInfos[guardNum] = &newInfo
				currInfo = &newInfo
			}
		} else if sleepMatches != nil {
			currSleep, _ = strconv.Atoi(sleepMatches[1])
		} else if wakeMatches != nil {
			wakeTime, _ := strconv.Atoi(wakeMatches[1])
			mins := wakeTime - currSleep
			currInfo.totalMins += mins

			for i := currSleep; i < wakeTime; i++ {
				currInfo.minuteCounts[i]++
			}
		}
	}

	return guardInfos
}

type Part2Result struct {
	id     int
	minute int
	count  int
}

type GuardInfo struct {
	id           int
	totalMins    int
	minuteCounts [60]int
}
