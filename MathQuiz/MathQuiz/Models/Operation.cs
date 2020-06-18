using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MathQuiz.Models
{
    abstract class Operation
    {
        // Left number used in operation
        public int FirstNumber { get; set; }
        // Right number generated
        public int SecondNumber { get; set; }
        // NumericUpDown to which user pass value
        public NumericUpDown UserInput { get; }

        public Operation(int firstMax, int secondMax, NumericUpDown numericUpDown)
        {
            generateValues(firstMax,secondMax);
            UserInput = numericUpDown;
            UserInput.Value = 0;
        }
        // Generate values to operation
        protected void generateValues(int firstMax,int secondMax)
        {
            Random randomizer = new Random();
            FirstNumber = randomizer.Next(firstMax);
            SecondNumber = randomizer.Next(firstMax);
        }

        // Check is value passed by user is correct
        public abstract bool checkCorrect();
    }
}
