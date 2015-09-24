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
using System.IO;

namespace WorkoutAppVersion3
{
    /// <summary>
    /// Interaction logic for ExerciseDataPanel.xaml
    /// </summary>
    public partial class ExerciseDataPanel : UserControl
    {
        int totalSetLabels = 0;
        int setNumber = 1;

        Exercise newExercise = new Exercise();

        public ExerciseDataPanel(int identifier)
        {
            InitializeComponent();

            newExercise.Identifier = identifier;

            MainWindow.MasterExerciseList.Exercises.Add(newExercise);
        }

        public static event EventHandler AddSetButtonLabelCreate;

        private void LabelCreateEvent()
        {
            if (AddSetButtonLabelCreate != null)
            {
                AddSetButtonLabelCreate(this, EventArgs.Empty);
            }
        }

        public class Exercise
        {
            public int Identifier { get; set; }
            public string MuscleGroupType { get; set; }
            public string ExerciseType { get; set; }
            public List<SetDataPanel.Set> Sets { get; set; }
            public Exercise()
            {
                MuscleGroupType = "muscleGroupType";
                ExerciseType = "exerciseType";
                Sets = new List<SetDataPanel.Set>();
            }
        }

        private void AddSetButton_Click(object sender, RoutedEventArgs e)
        {
            SetDataPanel newSetDataPanel = new SetDataPanel(newExercise, newExercise.Identifier, setNumber);
            StackPanel parentPanel = this.Parent as StackPanel;
            parentPanel.Children.Add(newSetDataPanel);

            if (MainWindow.MiscDataStorage.SetLabelCount <= totalSetLabels)
            {
                LabelCreateEvent();
            }

            totalSetLabels++;
        }

        private void MuscleGroupSelector_DropDownClosed(object sender, EventArgs e)
        {
            string muscleGroupSelected = MuscleGroupSelector.Text;

            string[] exerciseList = File.ReadAllLines(muscleGroupSelected + "ExerciseList.txt");

            ExerciseSelector.Items.Clear();

            foreach (var exercise in exerciseList)
            {
                ExerciseSelector.Items.Add(exercise);
            }

            newExercise.MuscleGroupType = MuscleGroupSelector.Text;
        }

        private void ExerciseSelector_DropDownClosed(object sender, EventArgs e)
        {
            newExercise.ExerciseType = ExerciseSelector.Text;
        }
    }
}
