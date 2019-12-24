using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PiCalculatorVisual {
    public partial class Form1 : Form {

        //List of all stored Pis
        List<decimal> FoundPi;

        /// <summary>
        /// Form constructor
        /// </summary>
        public Form1() {

            InitializeComponent();

            FoundPi = new List<decimal>();
        }

        /// <summary>
        /// Calculate button's click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Calculate_btn_Click(object sender, EventArgs e) {

            int iterations = ValidateInput(Iterations_txt.Text);

            CalculatePi(iterations);
        }

        /// <summary>
        /// Scroll event for the track bar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar1_Scroll(object sender, EventArgs e) {

            Iterations_txt.Text = trackBar1.Value.ToString();

            CalculatePi(trackBar1.Value);
        }

        /// <summary>
        /// Validates if an input was usable for this program
        /// </summary>
        /// <param name="input">The inputed string</param>
        /// <returns>The integer version of the input</returns>
        int ValidateInput(string input) {

            int tempInt;

            //tries to convert the input text
            if (Int32.TryParse(input, out tempInt))

                //checks to see if the input was not smaller than 1
                if (tempInt > 0)

                    //returns the integer value of the input
                    return Convert.ToInt32(Iterations_txt.Text);

            //returns the default value
            return 1000;
        }

        /// <summary>
        /// Caluculates Pi
        /// </summary>
        /// <param name="iterations">Amount of iterations for the algorithm</param>
        void CalculatePi(int iterations) {

            //resets the list 
            FoundPi.Clear();


            //stores the found value of pi
            decimal Pi = 0;

            //used to negate each other fractional add
            decimal flipper = 1;

            //loops through 1000 times
            for (int i = 1; i < iterations; i += 2) {

                //adds on the fraction
                Pi += (1 / (flipper * i));

                //makes the next fraction either negative or positive (reverse of the current flip value)
                flipper *= -1;

                //Adds the new Pi to the list of found Pi s
                FoundPi.Add(Pi * 4);

                Invalidate();
            }
        }

        /// <summary>
        /// Form's paint event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Paint(object sender, PaintEventArgs e) {

            //makes sure that there are values in the pi list
            if (FoundPi.Count() != 0) {

                //calculates the spacing between graph points
                float xSpacing = (float)Width / FoundPi.Count();

                float ySpacing = 1;

                decimal biggest = 0;

                decimal smallest = 10;

                //loops through each point in the list of found pi
                for (int i = 0; i < FoundPi.Count(); i++) {

                    //saves the current value
                    decimal value = FoundPi[i];

                    //if the current point is the smallest yet
                    if (value < smallest)

                        //sets the smallest value to the current value
                        smallest = value;

                    //normalises the current value with the smallest value
                    value -= smallest;

                    //checks to see if a new spacing is needed
                    if (value > biggest) {

                        //sets the biggest value to the current value
                        biggest = value;

                        //recalculates the yspacing
                        ySpacing = Height / (float)biggest;
                    }

                    //draws out the point
                    e.Graphics.DrawEllipse(Pens.Black, xSpacing * i, ySpacing * (float)value, 1, 1);

                    FinalValue_lbl.Text = FoundPi[i].ToString();
                }

            }
        }
    }
}
