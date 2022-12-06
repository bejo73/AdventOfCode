sum=0
sum2=0

instructions = []
stacks = []

with open('data/05.txt') as f:
    while True:
        line = f.readline()

        if not line:
            break

        if len(line.strip()) == 0 or line.strip().startswith("1"):
            continue

        if line.startswith("move"):
            instructions.append(line.strip())
        else:
            index = 0
            for i in range(1, len(line), 4):
                if len(stacks) <= index:
                    stacks.append([])

                if (line[i] != " "):
                    stacks[index].append(line[i])

                index = index + 1

for s in stacks:
    s.reverse()

import copy
stacks2 = copy.deepcopy(stacks)

# Part I
for i in instructions:
    crates    = int(i.split(" ")[1])
    stackFrom = int(i.split(" ")[3]) - 1
    stackTo   = int(i.split(" ")[5]) - 1

    for m in range(crates):
        crate = stacks[stackFrom].pop()
        stacks[stackTo].append(crate)

b = ""
for a in stacks:
    b = b + a.pop()

print(f'Part  I : {b}')

# Part II
tmp = []

for i in instructions:
    crates    = int(i.split(" ")[1])
    stackFrom = int(i.split(" ")[3]) - 1
    stackTo   = int(i.split(" ")[5]) - 1

    for m in range(crates):
        crate = stacks2[stackFrom].pop()
        tmp.append(crate)

    for m in range(crates):
        stacks2[stackTo].append(tmp.pop())

b = ""
for a in stacks2:
    b = b + a.pop()

print(f'Part II : {b}')