using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using System.Windows.Forms;

namespace MathQuiz.Models
{
    class SumOperation : Operation
    {
        public SumOperation(int firstMax, int secondMax, NumericUpDown numericUpDown)
            : base(firstMax, secondMax, numericUpDown) {
            while (FirstNumber + SecondNumber > 100)
            {
                generateValues(firstMax, secondMax);
            }
        }

        // Check if sum inputted is correct
        public override bool checkCorrect()
        {
            if(FirstNumber+SecondNumber == UserInput.Value)
            {
                return true;
            }
            return false;
        }
    }
}
