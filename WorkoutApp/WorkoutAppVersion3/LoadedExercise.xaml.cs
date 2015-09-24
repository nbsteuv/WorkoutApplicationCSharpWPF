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
    /// Interaction logic for LoadedExercise.xaml
    /// </summary>
    public partial class LoadedExercise : UserControl
    {
        public LoadedExercise(string MuscleGroup, string Exercise)
        {
            InitializeComponent();

            MuscleGroupBox.Content = MuscleGroup;
            ExerciseBox.Content = Exercise;
        }
    }
}
