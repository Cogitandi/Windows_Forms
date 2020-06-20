using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchingGame.Models
{
    class Game
    {
        // Game configuration
        public static List<string> icons = new List<string>()
                                {"!","!",",",",","d","d",";",";",
                                "w","w",".",".","p","p","f","f"};
        // For program uses
        ClickedIcons clickedIcons = new ClickedIcons();
        List<Label> labels = new List<Label>();
        //private bool isClickedIcon = false;

        public Game(TableLayoutControlCollection controls)
        {
            // Fetch label which will contain icons 
            fetchIconLabels(controls);
            // Set properties to label (fill,align,etc)
            setLabelProperties(labels);
            // Set icon from to each label
            assignIconsToLabels(labels);

        }
        private void fetchIconLabels(TableLayoutControlCollection controls)
        {
            foreach(Control control in controls)
            {
                Label label = control as Label;
                if(label != null)
                {
                    labels.Add(label);
                }
            }
        }
        private void setLabelProperties(List<Label> labels)
        {
            
            foreach (Label label in labels)
            {
                label.BorderStyle = BorderStyle.FixedSingle;
                label.Dock = System.Windows.Forms.DockStyle.Fill;
                label.Font = new System.Drawing.Font("Webdings", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                label.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
                label.Text = "c";
                label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                label.Click += new EventHandler(onClickIcon);
            }
        }
        private void assignIconsToLabels(List<Label> labels)
        {
            Random random = new Random();
            foreach (Label label in labels)
            {
                int randomPosition = random.Next(0, icons.Count-1);
                label.Text = icons[randomPosition];
                icons.RemoveAt(randomPosition);
            }
        }
        private void onClickIcon(object sender, EventArgs e)
        {
            
            // While icon has beed clicked do nothing on click
            if (clickedIcons.isClicked)
            {
                return;
            }
            Label label = sender as Label;
            if (label == null) return;
            clickedIcons.clickIcon(label);
        }

    }
}
