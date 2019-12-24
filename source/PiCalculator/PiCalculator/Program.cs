using System;

namespace PiCalculator {

    class Program {

        static void Main(string[] args) {

            //stores the found value of pi
            decimal Pi = 0;

            //used to negate each other fractional add
            decimal flipper = 1;

            //loops through 1000 times
            for (int i = 1; i < 999999999; i += 2) {

                //adds on the fraction
                Pi += (1 / (flipper * i));

                //makes the next fraction either negative or positive (reverse of the current flip value)
                flipper *= -1;

                //writes out what iteration of the formula we are on
                Console.Write("Iteration " + (i) + " = ");

                //writes out pi
                Console.WriteLine(Pi * 4);
            }

            //stops the program from closing right away
            Console.Read();
        }
    }
}
