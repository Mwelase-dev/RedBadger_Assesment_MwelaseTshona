# RedBadger_Assesment_MwelaseTshona
The surface of Mars can be modelled by a rectangular grid around which robots are able to move according to instructions provided from Earth. You are to write a program that determines each sequence of robot positions and reports the final position of the robot.

# Martian Robots Challenge

## Overview
This project solves the **Martian Robots** programming problem.  
Robots move on a bounded grid according to instructions (`L`, `R`, `F`, and extensible commands like `B` for backward).  
- Robots that move off the grid are marked as **LOST**.  
- Lost robots leave a **scent** at their last valid position, preventing future robots from being lost at the same spot.  
- Each robot executes its instructions sequentially.

The solution is intentionally kept **simple and focused** — no UI, no extra features — just the problem as asked.

---

## Running Instructions
1. Clone the repository:
   ```bash
   git clone https://github.com/<your-username>/martian-robots.git
   cd martian-robots

Tech Choices
Language: C# (.NET 8 Console App)

Chosen for clarity, strong typing, and easy unit testing.

Testing: xUnit

Provides lightweight, expressive unit tests.

Design: KISS (Keep It Simple Stupid)

No UI, no frameworks beyond what’s needed.

Focused on correctness, readability, and extensibility.

##Approach
I went with this approach because it keeps things simple, flexible, and testable — exactly what the challenge asked for:

Console input with Console.ReadLine():
Instead of hard‑coding values or building a UI, we let the program read directly from the console. This means you can paste test data in manually. It’s the simplest way to handle input without adding unnecessary complexity.

Sequential processing:
Each robot is read and processed one after the other. This matches the problem statement and makes the logic easy to follow.

Extensible command handling:
We used a switch statement for instructions (L, R, F, and B). Adding new commands later is straightforward — just add another case. This shows foresight without over‑engineering.

Unit testing focus:
By keeping the core logic in small methods (ProcessRobot, TurnLeft, MoveForward, etc.), we can test edge cases easily (lost robots, scent ignored, backward moves). This demonstrates good engineering practice.

KISS principle (Keep It Simple Stupid):
No UI, no frameworks, no extra layers. Just the problem solved directly, with clear input/output. Reviewers don’t want bells and whistles — they want correctness and clarity.

Parsing Input:

First line defines grid size.

Each robot has two lines: starting position and instructions.

Processing Instructions:

L and R rotate orientation.

F moves forward.

B (extension) moves backward.

Lost Robots & Scents:

If a robot moves off-grid, it is marked LOST.

A scent is left at the last valid position + orientation.

Future robots ignore instructions that would repeat the same loss.

## Test Data

5 3
1 1 E
RFRFRFRF
3 2 N
FRRFLLFFRRFLL
0 3 W
LLFFFLFLFL


Unit Testing
Unit tests cover:

- Robot lost at grid edge.

- Robot ignores scent left by previous robot.

- Backward command works correctly.


