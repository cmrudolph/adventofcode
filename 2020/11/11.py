import copy

Edge = '-'
Floor = '.'
Empty = 'L'
Full = '#'


def make_empty_row(length):
    return [list(Edge * length)]


def pad(lines):
    padded = [[Edge] + list(x.strip('\n')) + [Edge] for x in lines]
    length = len(padded[0])
    return make_empty_row(length) + padded + make_empty_row(length)


def count_occupied_neighbors(lines, r, c, term_chs):
    moves = [(-1, -1), (0, -1), (1, -1),
             (-1, 0), (1, 0),
             (-1, 1), (0, 1), (1, 1)]

    occupied_sum = 0
    all_term = [Empty, Full] + term_chs
    for m in moves:
        new_c = c + m[0]
        new_r = r + m[1]
        while lines[new_r][new_c] not in all_term:
            new_c = new_c + m[0]
            new_r = new_r + m[1]
        if lines[new_r][new_c] == Full:
            occupied_sum += 1

    return occupied_sum


def transform(lines, term_chs, threshold):
    changed = copy.deepcopy(lines)
    count = 0
    for r in range(1, len(lines)-1):
        for c in range(1, len(lines[r])-1):
            occ_neighbors = count_occupied_neighbors(lines, r, c, term_chs)
            if lines[r][c] == Empty and occ_neighbors == 0:
                changed[r][c] = Full
                count += 1
            elif lines[r][c] == Full and occ_neighbors >= threshold:
                changed[r][c] = Empty
                count += 1
    return (changed, count)


def count_occupied(lines):
    count = 0
    for r in range(1, len(lines)-1):
        for c in range(1, len(lines[r])-1):
            count += 1 if lines[r][c] == Full else 0
    return count


p1_lines = pad(open('11.txt', 'r').readlines())
p2_lines = copy.deepcopy(p1_lines)

changed = -1
while changed != 0:
    (p1_lines, changed) = transform(p1_lines, [Edge, Floor], 4)

changed = -1
while changed != 0:
    (p2_lines, changed) = transform(p2_lines, [Edge], 5)

print(count_occupied(p1_lines))
print(count_occupied(p2_lines))
