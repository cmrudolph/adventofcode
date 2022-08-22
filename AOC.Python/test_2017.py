import pytest
import test_utils
from aoc2017 import *


@pytest.mark.parametrize("line,expected", [
    ("1122", 3),
    ("1111", 4),
    ("1234", 0),
    ("91212129", 9)])
def test_aoc2017_01_1_cases(line, expected):
    result = aoc2017_01.solve1([line])
    assert result == expected


def test_aoc2017_01_1_sample():
    sample(9, aoc2017_01.solve1, "01")


def test_aoc2017_01_1_actual():
    actual(1144, aoc2017_01.solve1, "01")


@pytest.mark.parametrize("line,expected", [
    ("1212", 6),
    ("1221", 0),
    ("123425", 4),
    ("123123", 12),
    ("12131415", 4)
])
def test_aoc2017_01_2_cases(line, expected):
    result = aoc2017_01.solve2([line])
    assert result == expected


def test_aoc2017_01_2_sample():
    sample(6, aoc2017_01.solve2, "01")


def test_aoc2017_01_2_actual():
    actual(1194, aoc2017_01.solve2, "01")


def test_aoc2017_02_1_sample():
    sample(18, aoc2017_02.solve1, "02")


def test_aoc2017_02_1_actual():
    actual(45972, aoc2017_02.solve1, "02")


def test_aoc2017_02_2_sample():
    sample(9, aoc2017_02.solve2, "02")


def test_aoc2017_02_2_actual():
    actual(326, aoc2017_02.solve2, "02")


def sample(expected, solver, day):
    lines = test_utils.read_input('2017', day, 'sample')
    test_utils.runtest(expected, solver, lines)


def actual(expected, solver, day):
    lines = test_utils.read_input('2017', day, 'actual')
    test_utils.runtest(expected, solver, lines)
