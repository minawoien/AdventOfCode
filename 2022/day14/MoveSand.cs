static class MoveSand
{
    public static (decimal x, decimal y) move_sand(List<(decimal, decimal)> rocks_position, (decimal x, decimal y) sand, decimal y_pos)
    {
        if (y_pos - 2 < sand.y)
        {
            return (-1, -1);
        }
        // Part 2
        // if (sand == (500, 0) && (rocks_position.Contains((sand.x, sand.y + 1))) && (rocks_position.Contains((sand.x + 1, sand.y + 1))) && (rocks_position.Contains((sand.x - 1, sand.y + 1))))
        // {
        //     return (-1, -1);
        // }
        // if (y_pos - 1 > sand.y)
        // {
        // Move sand one down
        if (!(rocks_position.Contains((sand.x, sand.y + 1))))
        {
            sand.y = sand.y + 1;
            return move_sand(rocks_position, sand, y_pos);

        }
        // if blocked by sand or rock try one step down and to the left
        else if (!(rocks_position.Contains((sand.x - 1, sand.y + 1))))
        {
            sand.x = sand.x - 1;
            sand.y = sand.y + 1;
            return move_sand(rocks_position, sand, y_pos);
        }
        // if down and left is blocked, one step down and to the right
        else if (!(rocks_position.Contains((sand.x + 1, sand.y + 1))))
        {
            sand.x = sand.x + 1;
            sand.y = sand.y + 1;
            return move_sand(rocks_position, sand, y_pos);
        }
        // }
        return sand;
    }
}