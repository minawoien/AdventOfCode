configuration = {"red": 12, "green": 13, "blue": 14}
with open("input.txt", "r") as file:
    sum = 0
    for line in file:
        index = line.find(":")
        identifier = line[0:index]
        line = line[index+1:]
        game = line.split(";")
        end = 0
        for draws in game:
            draws = draws.strip("\n")
            draws = draws.split(",")
            sum_draw = {}
            for draw in draws:
                draw = draw.strip(" ")
                draw = draw.split(" ")
                if draw[1] in sum_draw:
                    sum_draw[draw[1]] += int(draw[0])
                else:
                    sum_draw[draw[1]] = int(draw[0])
            
            for color, value in sum_draw.items():
                if end == 1:
                    break
                if color not in configuration:
                    end = 1
                    break
                if value > configuration[color]:
                    end = 1
                    break
        if end != 1:
            id = identifier.split(" ")[1]
            sum += int(id)
    print(sum)
        
