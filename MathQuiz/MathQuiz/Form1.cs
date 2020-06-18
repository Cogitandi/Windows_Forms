using MathQuiz.Models;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class MathQuiz : Form
    {
        int timeLeft;
        SumOperation sumOperation;
        MinusOperation minusOperation;
        DivideOperation divideOperation;
        MultiplyOperation multiplyOperation;

        public MathQuiz()
        {
            InitializeComponent();
        }

        private void startTheQuiz()
        {
            // Create object to corresponding operation
            sumOperation = new SumOperation(50, 50,sum);
            minusOperation = new MinusOperation(50, 50, subtraction);
            divideOperation = new DivideOperation(50, 50, division);
            multiplyOperation = new MultiplyOperation(50, 50, multiplication);

            // Change labels with question mark to value
            setLabels(plusLeftLabel, plusRightLabel, sumOperation);
            setLabels(minusLeftLabel, minusRightLabel, minusOperation);
            setLabels(divideLeftLabel, divieRightLabel, divideOperation);
            setLabels(timesLeftLabel, timesRightLabel, multiplyOperation);

            // Start the timer
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer.Start();
        }

        private bool checkTheResult()
        {
            if (!sumOperation.checkCorrect()) return false;
            if (!minusOperation.checkCorrect()) return false;
            if (!divideOperation.checkCorrect()) return false;
            if (!multiplyOperation.checkCorrect()) return false;
            return true;
        }

        private void setLabels(Label left, Label right, Operation operation)
        {
            left.Text = operation.FirstNumber.ToString();
            right.Text = operation.SecondNumber.ToString();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            startTheQuiz();
            startButton.Enabled = false;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            // Check if user done all excercise
            if(checkTheResult())
            {
                timer.Stop();
                MessageBox.Show("Congratulations! Everything is correct");
                startButton.Enabled = true;
            }

            if(timeLeft>0)
            {
                timeLeft -= 1;
                timeLabel.Text = timeLeft.ToString()+" seconds";
            } else
            {
                timer.Stop();
                timeLabel.Text = "The end";
                MessageBox.Show("You didn't finished in time!");
                startButton.Enabled = true;
            }
        }

        private void cleanNumeric(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;
            if( answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length ;
                answerBox.Select(0, lengthOfAnswer);
            }

        }
    }
}
