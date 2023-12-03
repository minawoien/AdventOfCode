with open("input.txt", "r") as file:
    sum = 0
    for line in file:
        index = line.find(":")
        identifier = line[0:index]
        line = line[index+1:]
        game = line.split(";")
        least = {}
        for draws in game:
            draws = draws.strip("\n")
            draws = draws.split(",")
            sum_draw = {}
            for draw in draws:
                draw = draw.strip(" ")
                draw = draw.split(" ")
                if draw[1] in least:
                    if int(draw[0]) > least[draw[1]]:
                        least[draw[1]] = int(draw[0])
                else:
                    least[draw[1]] = int(draw[0])
        power = 1
        for color, value in least.items():
            power = power * value
        sum += power
    print(sum)