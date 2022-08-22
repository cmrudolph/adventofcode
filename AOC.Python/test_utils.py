def read_input(year, problem, suffix):
    path = f'../input/{year}/{problem}-{suffix}.txt'
    f = open(path, 'r')
    lines = f.readlines()
    lines = [x.strip() for x in lines]

    return lines


def runtest(expected, solver, lines):
    result = solver(lines)
    assert result == expected
