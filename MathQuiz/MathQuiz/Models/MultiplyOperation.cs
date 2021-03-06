﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using System.Windows.Forms;

namespace MathQuiz.Models
{
    class MultiplyOperation : Operation
    {
        public MultiplyOperation(int firstMax, int secondMax, NumericUpDown numericUpDown)
            : base(firstMax, secondMax, numericUpDown) {
            while(FirstNumber*SecondNumber>100)
            {
                generateValues(firstMax,secondMax);
            }
        }

        // Check if value passed by user to
        // input field is correct
        public override bool checkCorrect()
        {
            if(FirstNumber*SecondNumber == UserInput.Value)
            {
                return true;
            }
            return false;
        }
    }
}
