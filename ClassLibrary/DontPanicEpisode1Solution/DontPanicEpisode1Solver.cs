namespace DontPanicEpisode1Solution
{
    using System;
    using System.Linq;
    using System.IO;
    using System.Text;
    using System.Collections;
    using System.Collections.Generic;

    /**
     * This is a solution to the puzzle at https://www.codingame.com/ide/puzzle/don't-panic-episode-1
     * Worked as of 7/26/22
     */
    class Player
    {

        private static int nbFloors;
        private static int width; // width of the area
        private static int nbRounds; // maximum number of rounds
        private static int exitFloor; // floor on which the exit is found
        private static int exitPos; // position of the exit on its floor
        private static int nbTotalClones; // number of generated clones
        private static int nbAdditionalElevators; // ignore (always zero)
        private static int nbElevators; // number of elevators

        private static Dictionary<int, int> elevatorFloorPositionDict; // Holds elevator floors mapped to positions (won't work if there are multiple elveators)

        private const string leftDirection = "LEFT";
        private const string rightDirection = "RIGHT";
        private const string waitString = "WAIT";
        private const string blockString = "BLOCK";

        static void Main(string[] args)
        {
            string[] inputs;
            inputs = Console.ReadLine().Split(' ');
            nbFloors = int.Parse(inputs[0]); // number of floors
            width = int.Parse(inputs[1]); // width of the area
            nbRounds = int.Parse(inputs[2]); // maximum number of rounds
            exitFloor = int.Parse(inputs[3]); // floor on which the exit is found
            exitPos = int.Parse(inputs[4]); // position of the exit on its floor
            nbTotalClones = int.Parse(inputs[5]); // number of generated clones
            nbAdditionalElevators = int.Parse(inputs[6]); // ignore (always zero)
            nbElevators = int.Parse(inputs[7]); // number of elevators

            elevatorFloorPositionDict = new Dictionary<int, int>(); 
            for (int i = 0; i < nbElevators; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                int elevatorFloor = int.Parse(inputs[0]); // floor on which this elevator is found
                int elevatorPos = int.Parse(inputs[1]); // position of the elevator on its floor
                elevatorFloorPositionDict.Add(elevatorFloor, elevatorPos); 
            }

            // game loop
            while (true)
            {
                inputs = Console.ReadLine().Split(' ');
                int cloneFloor = int.Parse(inputs[0]); // floor of the leading clone
                int clonePos = int.Parse(inputs[1]); // position of the leading clone on its floor
                string direction = inputs[2]; // direction of the leading clone: LEFT or RIGHT

                if (HeadingToExit(cloneFloor, clonePos, direction))
                {
                    Console.WriteLine(waitString);
                }
                else if( HeadingToElevator(cloneFloor, clonePos, direction))
                {
                    Console.WriteLine(waitString);
                }
                else
                {
                    Console.WriteLine(blockString);
                }
            }
        }

        /**
         * Used to determine if the lead clone is heading to an elevator.
         */
        private static bool HeadingToElevator(int cloneFloor, int clonePos, string direction)
        {
            var valueToReturn = false;
            int elevatorPos;
            if (elevatorFloorPositionDict.TryGetValue(cloneFloor, out elevatorPos))
            {
                valueToReturn = HeadingToPosition(clonePos, elevatorPos, direction);
            }
            return valueToReturn;
        }


        /**
         * Used to check if the head clone is heading to the exit.
         */
        private static bool HeadingToExit(int cloneFloor, int clonePos, string direction)
        {
            var valueToReturn = false;
            if (cloneFloor == exitFloor )
            {
                valueToReturn = HeadingToPosition(clonePos, exitPos, direction);
            }
            return valueToReturn;
        }

        /*
         * Used to check if the direction that the lead clone is heading is towards or away from the position input.
         */
        private static bool HeadingToPosition(int clonePos, int toOrFromPos, string direction)
        {
            var valueToReturn = false;
            switch (direction){
                case leftDirection:
                    valueToReturn = clonePos >= toOrFromPos;
                    break;
                case rightDirection:
                    valueToReturn = clonePos <= toOrFromPos;
                    break;
                default:
                    break;
            }
            return valueToReturn;
        }
    }
}