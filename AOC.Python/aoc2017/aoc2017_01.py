def solve1(lines):
    digits = lines[0]
    digits += digits[0]

    result = 0
    for i in range(len(digits) - 1):
        if digits[i] == digits[i + 1]:
            result += int(digits[i])

    return result


def solve2(lines):
    digits = lines[0]
    half = len(digits) // 2

    result = 0
    for i in range(len(digits)):
        compare_idx = (i + half) % len(digits)
        if digits[i] == digits[compare_idx]:
            result += int(digits[i])

    return result
