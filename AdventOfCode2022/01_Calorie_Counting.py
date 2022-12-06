list = []
calories = 0
next = True

with open('data/01.txt') as f:
    while True:
        line = f.readline()

        if not line:
            list.append(calories)
            break

        if len(line.strip()) > 0:
            calories = calories + int(line)
            next = False

        else:
            list.append(calories)
            next = True
            calories = 0
            
index = 0
max = list[0]
for i in range(1,len(list)):
    if list[i] > max:
        max = list[i]
        index = i

print(f'Part  I : {list[index]}')

list.sort(reverse=True)
topThree = list[0]+list[1]+list[2]

print(f'Part II : {topThree}')