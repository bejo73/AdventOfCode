sum=0
sum2=0

with open('data/04.txt') as f:
    while True:
        a = f.readline()

        if not a:
            break

        elfs = a.strip().split(",")
        
        e1a = int(elfs[0].split("-")[0])
        e1b = int(elfs[0].split("-")[1])

        e2a = int(elfs[1].split("-")[0])
        e2b = int(elfs[1].split("-")[1])

        if (e1a >= e2a) and (e1b <= e2b)  or (e2a >= e1a) and (e2b <= e1b) : 
            sum = sum + 1
        
        if (e1a >= e2a) and (e1a <= e2b)  or (e1b >= e2a) and (e1b <= e2b) or (e2a >= e1a) and (e2a <= e1b)  or (e2b >= e1a) and (e2b <= e1b) : 
            sum2 = sum2 + 1

print(f'Part  I : {sum}')
print(f'Part II : {sum2}')