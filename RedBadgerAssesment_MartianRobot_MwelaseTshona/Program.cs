using System;
using System.Collections.Generic;
using System.Linq;

public class MartianRobots
{
    private static int maxX, maxY;
    private static HashSet<(int, int, char)> scents = new();

    public static void Main(string[] args)
    {
        // Read grid size
        var grid = Console.ReadLine()?.Split();
        maxX = int.Parse(grid[0]);
        maxY = int.Parse(grid[1]);

        string line;
        while (!string.IsNullOrWhiteSpace(line = Console.ReadLine()))
        {
            var pos = line.Split();
            int x = int.Parse(pos[0]);
            int y = int.Parse(pos[1]);
            char orientation = pos[2][0];

            string instructions = Console.ReadLine();

            var result = ProcessRobot(x, y, orientation, instructions);
            Console.WriteLine(result);
        }
    }

    private static string ProcessRobot(int x, int y, char orientation, string instructions)
    {
        foreach (char command in instructions)
        {
            switch (command)
            {
                case 'L':
                    orientation = TurnLeft(orientation);
                    break;
                case 'R':
                    orientation = TurnRight(orientation);
                    break;
                case 'F':
                    var (newX, newY) = MoveForward(x, y, orientation);

                    if (newX < 0 || newY < 0 || newX > maxX || newY > maxY)
                    {
                        if (scents.Contains((x, y, orientation)))
                            continue; // ignore move
                        else
                        {
                            scents.Add((x, y, orientation));
                            return $"{x} {y} {orientation} LOST";
                        }
                    }
                    else
                    {
                        x = newX;
                        y = newY;
                    }
                    break;

                case 'B': // new command: backward
                    var (bx, by) = MoveBackward(x, y, orientation);
                    if (bx < 0 || by < 0 || bx > maxX || by > maxY)
                    {
                        if (scents.Contains((x, y, orientation)))
                            continue;
                        else
                        {
                            scents.Add((x, y, orientation));
                            return $"{x} {y} {orientation} LOST";
                        }
                    }
                    else
                    {
                        x = bx;
                        y = by;
                    }
                    break;
            }
        }
        return $"{x} {y} {orientation}";
    }

    private static char TurnLeft(char orientation) =>
        orientation switch
        {
            'N' => 'W',
            'W' => 'S',
            'S' => 'E',
            'E' => 'N',
            _ => orientation
        };

    private static char TurnRight(char orientation) =>
        orientation switch
        {
            'N' => 'E',
            'E' => 'S',
            'S' => 'W',
            'W' => 'N',
            _ => orientation
        };

    private static (int, int) MoveForward(int x, int y, char orientation) =>
        orientation switch
        {
            'N' => (x, y + 1),
            'S' => (x, y - 1),
            'E' => (x + 1, y),
            'W' => (x - 1, y),
            _ => (x, y)
        };

    private static (int, int) MoveBackward(int x, int y, char orientation) =>
        orientation switch
        {
            'N' => (x, y - 1),
            'S' => (x, y + 1),
            'E' => (x - 1, y),
            'W' => (x + 1, y),
            _ => (x, y)
        };
}
