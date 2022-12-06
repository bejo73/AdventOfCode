line = ""

with open('data/06.txt') as f:
    while True:
        line = f.readline()

        break

# Sets are lists with no duplicate entries - lesson learned
marker = 0
for i in range(len(line)):
    if len(set(line[i - 4 : i])) == 4:
        marker = i
        break

"""" First solution - before I knew set. I realized in part II that or'ing is not the way to go.
for i in range(len(line)-3):
    if line[i] == line[i+1] or line[i] == line[i+2] or line[i] == line[i+3]:
        marker = i + 4

    if marker == i:
       break

marker = marker + 1
"""
print(f'Part  I : {marker}')


for i, _ in enumerate(line):
    if len(set(line[i - 14 : i])) == 14:
        marker = i
        break

print(f'Part II : {marker}')