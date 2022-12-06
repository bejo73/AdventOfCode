lowerOffset = ord('a') - 1
upperOffset = ord('A') - 27 

sum = 0

with open('data/03.txt') as f:
    while True:
        line = f.readline()

        if not line:
            break

        source = line.strip()
        half = int(len(source)/2)
        one = source[0:half]
        two = source[half:len(source)]

        for c in one:
            if c in two:
                if (ord(c) > lowerOffset):
                    sum = sum + (ord(c) - lowerOffset)
                else:
                    sum = sum + (ord(c) - upperOffset)
                break

print(f'Part  I : {sum}')

sum = 0

with open('data/03.txt') as f:
    while True:
        one = f.readline()
        if not one:
            break
        one = one.strip()
        two = f.readline().strip()
        thr = f.readline().strip()

        for c in one:
            if c in two and c in thr:
                if (ord(c) > lowerOffset):
                    sum = sum + (ord(c) - lowerOffset)
                else:
                    sum = sum + (ord(c) - upperOffset)
                break

print(f'Part II : {sum}')