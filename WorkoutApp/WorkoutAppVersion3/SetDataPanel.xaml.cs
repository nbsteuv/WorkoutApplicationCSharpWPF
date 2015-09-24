using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WorkoutAppVersion3
{
    /// <summary>
    /// Interaction logic for SetDataPanel.xaml
    /// </summary>
    public partial class SetDataPanel : UserControl
    {

        int holdWarning = 0;

        Set newSet = new Set();


        public SetDataPanel(ExerciseDataPanel.Exercise exercise, int exerciseID, int setNumber)
        {
            InitializeComponent();

            newSet.ExerciseNumber = exerciseID;
            newSet.Identifier = "Set" + setNumber;

            ExerciseDataPanel.Exercise exerciseReference = exercise as ExerciseDataPanel.Exercise;

            exerciseReference.Sets.Add(newSet);
        }

        public class Set
        {
            public string Identifier { get; set; }
            public int ExerciseNumber { get; set; }
            public int Weight { get; set; }
            public int Reps { get; set; }
            public Set()
            {
                Weight = 0;
                Reps = 0;
            }
        }

        private void Weight_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (WeightBox.Text == "")
            {
                newSet.Weight = 0;
            }
            else
            {
                int weightBoxText;
                bool isInteger = int.TryParse(WeightBox.Text, out weightBoxText);
                if (isInteger == false)
                {
                    WeightBox.Text = String.Empty;
                    if (holdWarning > 1)
                    {
                        MessageBox.Show("Input must be a positive number.");
                    }
                    holdWarning++;
                }
                else
                {
                    newSet.Weight = weightBoxText;
                }
                if (WeightBox.Text != "")
                {
                    RepBox.IsEnabled = true;
                }
                else
                {
                    RepBox.IsEnabled = false;
                }
            }
        }

        private void Rep_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (RepBox.Text == "")
            {
                newSet.Reps = 0;
            }
            else
            {
                int repBoxText;
                bool isInteger = int.TryParse(RepBox.Text, out repBoxText);
                if (isInteger == false)
                {
                    RepBox.Text = String.Empty;
                    if (holdWarning > 1)
                    {
                        MessageBox.Show("Input must be a positive number.");
                    }
                    holdWarning++;
                }
                else
                {
                    newSet.Reps = repBoxText;
                }
            }
        }
    }
}
