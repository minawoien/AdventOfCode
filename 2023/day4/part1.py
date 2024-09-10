matrix = []
with open("input.txt", "r") as file:
    for line in file:
        line = line.strip()
        line = line.split(": ")[1].split("|")
        array = []
        for liste in line:
            liste = liste.strip()
            liste = liste.replace("  ", " ")
            liste = liste.split(" ")
            array.append(liste)
        matrix.append(array)
        sum = 0
for liste in matrix:
    points = 0
    for element in liste[1]:
        if element in liste[0]:
            if points == 0:
                points += 1
            else:
                points = points * 2
    sum += points

print(sum)