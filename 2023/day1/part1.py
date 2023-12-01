with open("input.txt", "r") as file:
    calibration_value = 0
    for line in file:
        line = line.strip("\n")
        digits = [line[0], line[-1]]
        first_digit = ""
        last_digit = ""
        two_digit_number = ""
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
        
