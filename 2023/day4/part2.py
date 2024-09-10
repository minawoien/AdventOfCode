matrix = []
with open("input.txt", "r") as file:
    for i, line in enumerate(file):
        line = line.strip()
        line = line.split(": ")[1].split("|")
        dic = {}
        array = []
        for liste in line:
            liste = liste.strip()
            liste = liste.replace("  ", " ")
            liste = liste.split(" ")
            array.append(liste)
        dic[i] = array
        matrix.append(dic)

total_cards = [1] * len(matrix)  # Start with 1 instance of each card

for i in range(len(matrix)):
    # Get the number of matching numbers for the current card
    matches = len(set(matrix[i][i][0]) & set(matrix[i][i][1]))

    # Calculate wins for the current card and its copies
    for j in range(i+1, min(i+1+matches, len(matrix))):
        total_cards[j] += total_cards[i]

# Calculate the total number of scratchcards
total_scratchcards = sum(total_cards)
print("Total scratchcards:", total_scratchcards)