import re


def solve1(lines):
    parsed_lines = [parse_and_sort(x) for x in lines]
    result = 0
    for nums in parsed_lines:
        result += (nums[-1] - nums[0])

    return result


def solve2(lines):
    parsed_lines = [parse_and_sort(x) for x in lines]
    result = 0
    for nums in parsed_lines:
        result += divide_evenly_divisible(nums)

    return result


def parse_and_sort(line):
    splits = re.split(' |\t', line)
    nums = [int(x) for x in splits]
    nums.sort()

    return nums


def divide_evenly_divisible(ordered_nums):
    for i in range(len(ordered_nums) - 1, -1, -1):
        for j in range(i - 1, -1, -1):
            bigger = ordered_nums[i]
            smaller = ordered_nums[j]
            if bigger % smaller == 0:
                return bigger // smaller
