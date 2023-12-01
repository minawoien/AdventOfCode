# 56322
numbers = {"one":1, "two":2, "three":3, "four":4, "five":5, "six":6, "seven":7, "eight":8, "nine":9}
with open("input.txt", "r") as file:
    calibration_value = 0
    for line in file:
        line = line.strip("\n").lower().strip("")
        digits = [line[0], line[-1]]
        first_digit = ""
        last_digit = ""
        two_digit_number = ""
        word = ""
        for char in line:
            word += char
            for number in numbers:
                if number in word:
                    word = ""
                    index = line.find(number)
                    last_index = index + len(number)
                    line = line[0:int(index)] + str(numbers[number]) + line[int(last_index)-1:]
        for char in line:
            try:
                digit = int(char)
                if first_digit == "":
                    first_digit = digit
                last_digit = digit
            except ValueError:
                pass
        two_digit_number = str(first_digit) + str(last_digit)
        calibration_value += int(two_digit_number)
    print(calibration_value)
        