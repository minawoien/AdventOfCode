
import numbers
matrix = []

with open("input.txt", "r") as file:
    for line in file:
        array = []
        array.append(".")
        for char in line.strip():
            try:
                array.append(int(char))
            except:
                array.append((char))
        array.append(".")
        matrix.append(array)
    matrix.append(["." for i in range(len(matrix[0]))])
    matrix.insert(0, ["." for i in range(len(matrix[0]))])
    
number = []
for i in range(len(matrix)):
    for j, x in enumerate(matrix[i]):
        if isinstance(x, numbers.Number):
            number.append({x: (i, j)})

saved_positions = []
for x in range(len(number)):
    for numb, position in number[x].items():
        i, j = position
        if matrix[i+1][j] == "*":
            if type(matrix[i+1][j]) != int:
                saved_positions.append((numb, position, (i+1,j)))
                continue
        if matrix[i-1][j] == "*":
            if type(matrix[i-1][j]) != int:
                saved_positions.append((numb, position, (i-1,j)))
                continue
        if matrix[i][j+1] == "*":
            if type(matrix[i][j+1]) != int:
                saved_positions.append((numb, position, (i,j+1)))
                continue
        if matrix[i][j-1] == "*":
            if type(matrix[i][j-1]) != int:
                saved_positions.append((numb, position, (i,j-1)))
                continue
        if matrix[i-1][j-1] == "*":
            if type(matrix[i-1][j-1]) != int:
                saved_positions.append((numb, position, (i-1,j-1)))
                continue
        if matrix[i+1][j+1] == "*":
            if type(matrix[i+1][j+1]) != int:
                saved_positions.append((numb, position, (i+1,j+1)))
                continue
        if matrix[i-1][j+1] == "*":
            if type(matrix[i+1][j+1]) != int:
                saved_positions.append((numb, position, (i-1,j+1)))
                continue
        if matrix[i+1][j-1] == "*":
            if type(matrix[i+1][j+1]) != int:
                saved_positions.append((numb, position, (i+1,j-1)))
                continue

concatenated_info_final = []
used_positions = set()  

for dict1 in number:
    num1, pos1 = list(dict1.items())[0]
    if pos1 in used_positions:
        continue

    concatenated_str = str(num1)
    positions = [pos1]
    for dict2 in number:
        num2, pos2 = list(dict2.items())[0]
        if pos1[0] == pos2[0] and pos1[1] + 1 == pos2[1] and pos2 not in used_positions:
            concatenated_str += str(num2)
            positions.append(pos2)
            pos1 = pos2
            used_positions.add(pos2)
    concatenated_info_final.append((int(concatenated_str), positions))


sum = 0
final = []
for info in concatenated_info_final:
    for i, (value, position, star_pos) in enumerate(saved_positions):
        if position in info[1]:
            final.append((info[0], star_pos))
            break      

for i in range(len(final)):
    for j in range(i+1, len(final)):
        if final[i][1] == final[j][1]:
            sum += final[i][0] * final[j][0]

print(sum)
            
