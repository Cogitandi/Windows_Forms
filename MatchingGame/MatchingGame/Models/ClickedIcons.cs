using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchingGame.Models
{
    class ClickedIcons
    {
        private Label firstClicked;
        private Label secondClicked;
        public bool isClicked { get; set; } = false;
        public void clickIcon(Label label)
        {
            if (label.ForeColor == Color.Black) return;
            isClicked = true;
            
            if(firstClicked == null)
            {
                firstClicked = label;
                firstClicked.ForeColor = Color.Black;
                isClicked = false;
                return;
            }
            if (secondClicked == null)
            {
                secondClicked = label;
                secondClicked.ForeColor = Color.Black;
                clickedBoth();
                return;
            }
            return;


        }
        private async void clickedBoth()
        {
            if (checkMatch() == true)
            {
                Game.icons.RemoveAll((string s) => { return s.Equals(firstClicked.Text); });
                firstClicked = null;
                secondClicked = null;
            }
            else
            {
                await Task.Delay(1000);
                firstClicked.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
                secondClicked.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;

                firstClicked = null;
                secondClicked = null;
            }
            isClicked = false;

        }
        private bool checkMatch()
        {
            return firstClicked.Text.Equals(secondClicked.Text) ? true : false;
        }

        private void matchedEffect()
        {

        }


    }
}
