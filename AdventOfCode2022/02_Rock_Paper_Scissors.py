myScore = 0

with open('data/02.txt') as f:
    while True:
        line = f.readline()

        if not line:
            break

        match line.strip():
            case "A X" | "B Y" | "C Z": # Draw
                myScore = myScore + 3
            case "A Y" | "B Z" | "C X": # I win
                myScore = myScore + 6

        if line.strip().endswith("X"):
            myScore = myScore + 1
        elif line.strip().endswith("Y"):
            myScore = myScore + 2
        elif line.strip().endswith("Z"):
            myScore = myScore + 3
         
print(f'Part  I : {myScore}')

myScore = 0

with open('data/02.txt') as f:
    while True:
        line = f.readline()

        if not line:
            break

        if line.strip().endswith("X"):
            if line.startswith("A"):
                line = "A Z"
            elif line.startswith("B"):
                line = "B X"
            else:
                line ="C Y"

        elif line.strip().endswith("Y"):
            if line.startswith("A"):
                line = "A X"
            elif line.startswith("B"):
                line = "B Y"
            else:
                line ="C Z"

        elif line.strip().endswith("Z"):
            if line.startswith("A"):
                line = "A Y"
            elif line.startswith("B"):
                line = "B Z"
            else:
                line ="C X"

        match line.strip():
            case "A X" | "B Y" | "C Z": # Draw
                myScore = myScore + 3
            case "A Y" | "B Z" | "C X": # I win
                myScore = myScore + 6

        if line.strip().endswith("X"):
            myScore = myScore + 1
        elif line.strip().endswith("Y"):
            myScore = myScore + 2
        elif line.strip().endswith("Z"):
            myScore = myScore + 3

print(f'Part II : {myScore}')