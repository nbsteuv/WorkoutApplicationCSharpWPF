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
using System.Diagnostics;
using Microsoft.Win32;

namespace WorkoutAppVersion3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        OpenFileDialog selectWorkoutData = new OpenFileDialog();

        public MainWindow()
        {
            InitializeComponent();

            ExerciseDataPanel.AddSetButtonLabelCreate += new EventHandler(AddSetButton_Clicked);

            datePicker.SelectedDate = DateTime.Now;
        }

        public static class MiscDataStorage
        {
            public static bool DateChosen = false;
            public static string Date = "";
            public static int ExerciseNumber = 1;
            public static int SetLabelNumber = 1;
            public static int SetLabelCount = 0;
            public static int WorkoutContainerHeight = 0;
            public static int WorkoutContainerWidth = 0;
            public static int WorkoutHeightBuffer = 75;
            public static int WorkoutHeightMax = 375;
            public static int WorkoutWidthBuffer = 500;
            public static int WorkoutWidthMax = 1000;
            public static int SetLabelsWidth = 120;
            public static int WorkoutExerciseHeight = 33;
        }

        public static class MasterExerciseList
        {
            public static List<ExerciseDataPanel.Exercise> Exercises = new List<ExerciseDataPanel.Exercise>();
            public static List<string> SetHeaderList = new List<string> {",," };
            public static List<string> ExerciseHeaderList = new List<string>();
        }

        public static class PreviousExercise
        {
            public static string PreviousWorkoutPath = Directory.GetCurrentDirectory() + "\\Workouts";
            public static string LoadedFileName = "";
            public static string PreviousWorkoutDate = "";
            public static int PreviousSetCount = 0;
            public static int PreviousWorkoutContainerHeight = 0;
            public static int PreviousWorkoutContainerWidth = 0;
            public static int PreviousWorkoutWidthBuffer = 462;
            public static int PreviousWorkoutWidthMax = 995;
            public static int PreviousWorkoutHeightBuffer = 91;
            public static int PreviousWorkoutExerciseHeight = 33;
            public static int PreviousWorkoutHeightMax = 200;
            public static int OriginalWorkoutDataContainerHeight = 82;
            public static int OriginalPreviousWorkoutWidth = 1000;
        }

        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            MiscDataStorage.DateChosen = true;
            MiscDataStorage.Date = datePicker.Text;
        }

        private void AddNewExercise_Click(object sender, RoutedEventArgs e)
        {
            StackPanel newStackPanel = new StackPanel();
            newStackPanel.Orientation = Orientation.Horizontal;
            WorkoutDataContainer.Children.Add(newStackPanel);

            ExerciseDataPanel newDataPanel = new ExerciseDataPanel(MiscDataStorage.ExerciseNumber);
            newDataPanel.HorizontalAlignment = HorizontalAlignment.Left;
            newDataPanel.VerticalAlignment = VerticalAlignment.Top;
            newDataPanel.Margin = new Thickness(0, 0, 0, 0);
            newStackPanel.Children.Add(newDataPanel);

            MiscDataStorage.WorkoutContainerHeight = MiscDataStorage.WorkoutHeightBuffer + (MiscDataStorage.ExerciseNumber * MiscDataStorage.WorkoutExerciseHeight);
            if (MiscDataStorage.WorkoutContainerHeight > MiscDataStorage.WorkoutHeightMax)
            {
                WorkoutDataContainer.Height = MiscDataStorage.WorkoutContainerHeight - SetLabelStackBox.Height;
                CurrentWorkoutContainer.Height = MiscDataStorage.WorkoutContainerHeight;
                WorkoutDataScrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
            }

            MiscDataStorage.ExerciseNumber++;
        }

        public void NewSetLabel()
        {
            SetLabels newSetLabels = new SetLabels(MiscDataStorage.SetLabelNumber);
            newSetLabels.HorizontalAlignment = HorizontalAlignment.Left;
            newSetLabels.VerticalAlignment = VerticalAlignment.Top;
            newSetLabels.Margin = new Thickness(0, 0, 0, 0);
            newSetLabels.Width = MiscDataStorage.SetLabelsWidth;
            SetLabelStackBox.Children.Add(newSetLabels);

            string newSetLabelsName = "Set " + MiscDataStorage.SetLabelNumber;
            MasterExerciseList.SetHeaderList.Add(newSetLabelsName + ",");

            MiscDataStorage.SetLabelNumber++;
            MiscDataStorage.SetLabelCount++;

            MiscDataStorage.WorkoutContainerWidth = MiscDataStorage.WorkoutWidthBuffer + (MiscDataStorage.SetLabelCount * MiscDataStorage.SetLabelsWidth);
            if (MiscDataStorage.WorkoutContainerWidth > MiscDataStorage.WorkoutWidthMax)
            {
                CurrentWorkoutContainer.Width = MiscDataStorage.WorkoutContainerWidth;
                SetLabelStackBox.Width = MiscDataStorage.WorkoutContainerWidth;
                WorkoutDataContainer.Width = MiscDataStorage.WorkoutContainerWidth;
                WorkoutDataScrollViewer.Width = MiscDataStorage.WorkoutContainerWidth;
                WorkoutScrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
            }
        }

        private void AddSetButton_Clicked(object sender, EventArgs e)
        {
            NewSetLabel();
        }

        private void PreviousDataCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            PreviousWorkoutScrollViewer.Visibility = Visibility.Visible;
            PreviousWorkoutContainer.Visibility = Visibility.Visible;
            PreviousSetLabelStackBox.Visibility = Visibility.Visible;
            PreviousWorkoutDataScrollViewer.Visibility = Visibility.Visible;
            PreviousWorkoutDataContainer.Visibility = Visibility.Visible;
        }

        private void PreviousDataCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            PreviousWorkoutScrollViewer.Visibility = Visibility.Collapsed;
            PreviousWorkoutContainer.Visibility = Visibility.Collapsed;
            PreviousSetLabelStackBox.Visibility = Visibility.Collapsed;
            PreviousWorkoutDataScrollViewer.Visibility = Visibility.Collapsed;
            PreviousWorkoutDataContainer.Visibility = Visibility.Collapsed;
        }

        private void LoadPreviousDataButton_Click(object sender, RoutedEventArgs e)
        {
            selectWorkoutData.InitialDirectory = PreviousExercise.PreviousWorkoutPath;

            Nullable<bool> result = selectWorkoutData.ShowDialog();

            if (result == true)
            {
                PreviousExercise.LoadedFileName = selectWorkoutData.FileName;
                LoadPreviousWorkoutData();

            }
        }

        public void LoadPreviousWorkoutData()
        {
            PreviousSetLabelStackBox.Children.RemoveRange(1, (PreviousSetLabelStackBox.Children.Count - 1));
            PreviousWorkoutDataContainer.Children.Clear();

            PreviousWorkoutContainer.Width = PreviousExercise.OriginalPreviousWorkoutWidth;
            PreviousSetLabelStackBox.Width = PreviousExercise.OriginalPreviousWorkoutWidth;
            PreviousWorkoutDataScrollViewer.Width = PreviousExercise.OriginalPreviousWorkoutWidth;
            PreviousWorkoutDataContainer.Width = PreviousExercise.OriginalPreviousWorkoutWidth;
            PreviousWorkoutScrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;

            PreviousWorkoutContainer.Height = PreviousExercise.OriginalWorkoutDataContainerHeight;
            PreviousWorkoutScrollViewer.Height = PreviousExercise.OriginalWorkoutDataContainerHeight;
            PreviousWorkoutDataContainer.Height = PreviousExercise.OriginalWorkoutDataContainerHeight;
            PreviousWorkoutDataScrollViewer.Height = PreviousExercise.OriginalWorkoutDataContainerHeight;
            PreviousWorkoutDataScrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;

            List<string> rawLoadedData = new List<string>();

            using (StreamReader CSVReader = new StreamReader(PreviousExercise.LoadedFileName))
            {
                string dataLine;
                while ((dataLine = CSVReader.ReadLine()) != null)
                {
                    rawLoadedData.Add(dataLine);
                }
            }

            int totalExercises = (rawLoadedData.Count - 3);

            PreviousExercise.PreviousWorkoutDate = rawLoadedData[0];
            PreviousDateLabel.Content = PreviousExercise.PreviousWorkoutDate;
            PreviousDateLabel.Visibility = Visibility.Visible;

            string tempSetCountString = rawLoadedData[1];
            int tempSetCountStringLength = tempSetCountString.Length;
            int replacedTempStringLength = tempSetCountString.Replace(",", "").Length;
            PreviousExercise.PreviousSetCount = (tempSetCountString.Length - replacedTempStringLength -2)/2;

            PreviousExercise.PreviousWorkoutContainerWidth = PreviousExercise.PreviousWorkoutWidthBuffer + (PreviousExercise.PreviousSetCount * MiscDataStorage.SetLabelsWidth);
            if (PreviousExercise.PreviousWorkoutContainerWidth > PreviousExercise.PreviousWorkoutWidthMax)
            {

                PreviousWorkoutContainer.Width = PreviousExercise.PreviousWorkoutContainerWidth;
                PreviousSetLabelStackBox.Width = PreviousExercise.PreviousWorkoutContainerWidth;
                PreviousWorkoutDataScrollViewer.Width = PreviousExercise.PreviousWorkoutContainerWidth;
                PreviousWorkoutDataContainer.Width = PreviousExercise.PreviousWorkoutContainerWidth;
                PreviousWorkoutScrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
            }

            for (int set = 1; set <= PreviousExercise.PreviousSetCount; set++)
            {
                SetLabels newSetLabels = new SetLabels(set);
                newSetLabels.HorizontalAlignment = HorizontalAlignment.Left;
                newSetLabels.VerticalAlignment = VerticalAlignment.Top;
                newSetLabels.Margin = new Thickness(0, 0, 0, 0);
                PreviousSetLabelStackBox.Children.Add(newSetLabels);
            }

            for (int rawDataLine = 3; rawDataLine < rawLoadedData.Count(); rawDataLine++)
            {
                List<string> exerciseLine = rawLoadedData[rawDataLine].Split(',').ToList<string>();
                LoadedExercise newLoadedExercise = new LoadedExercise(exerciseLine[1], exerciseLine[2]);
                newLoadedExercise.Margin = new Thickness(0, 0, 0, 0);
                newLoadedExercise.HorizontalAlignment = HorizontalAlignment.Left;
                newLoadedExercise.VerticalAlignment = VerticalAlignment.Top;
                newLoadedExercise.Width = PreviousExercise.PreviousWorkoutContainerWidth;
                newLoadedExercise.LoadedExerciseDataContainer.Width = PreviousExercise.PreviousWorkoutContainerWidth;
                PreviousWorkoutDataContainer.Children.Add(newLoadedExercise);
                
                for (int dataPoint = 3; dataPoint < exerciseLine.Count(); dataPoint++)
                {
                    if (dataPoint % 2 == 1)
                    {
                        Label weightLabel = new Label();
                        weightLabel.Content = exerciseLine[dataPoint];
                        weightLabel.Width = 45;
                        weightLabel.Margin = new Thickness(0, 0, 0, 0);
                        weightLabel.HorizontalContentAlignment = HorizontalAlignment.Center;
                        newLoadedExercise.LoadedExerciseDataContainer.Children.Add(weightLabel);
                    }
                    else if (dataPoint % 2 == 0)
                    {
                        Label repLabel = new Label();
                        repLabel.Content = exerciseLine[dataPoint];
                        repLabel.Width = 45;
                        repLabel.Margin = new Thickness(0, 0, 0, 0);
                        repLabel.HorizontalContentAlignment = HorizontalAlignment.Center;
                        newLoadedExercise.LoadedExerciseDataContainer.Children.Add(repLabel);

                        Rectangle newSpace = new Rectangle();
                        newSpace.Height = 32.612;
                        newSpace.Width = 30;
                        newSpace.Visibility = Visibility.Hidden;
                        newLoadedExercise.LoadedExerciseDataContainer.Children.Add(newSpace);
                    }
                }

            }

            PreviousExercise.PreviousWorkoutContainerHeight = PreviousExercise.PreviousWorkoutHeightBuffer + (totalExercises * PreviousExercise.PreviousWorkoutExerciseHeight);
            if (PreviousExercise.PreviousWorkoutContainerHeight <= PreviousExercise.PreviousWorkoutHeightMax)
            {
                PreviousWorkoutContainer.Height = PreviousExercise.PreviousWorkoutContainerHeight;
                PreviousWorkoutScrollViewer.Height = PreviousExercise.PreviousWorkoutContainerHeight;
                PreviousWorkoutDataContainer.Height = PreviousExercise.PreviousWorkoutContainerHeight - PreviousExercise.PreviousWorkoutHeightBuffer;
                PreviousWorkoutDataScrollViewer.Height = PreviousExercise.PreviousWorkoutContainerHeight - PreviousExercise.PreviousWorkoutHeightBuffer;
            }
            else if (PreviousExercise.PreviousWorkoutContainerHeight > PreviousExercise.PreviousWorkoutHeightMax)
            {
                PreviousWorkoutContainer.Height = PreviousExercise.PreviousWorkoutContainerHeight;
                PreviousWorkoutScrollViewer.Height = PreviousExercise.PreviousWorkoutHeightMax;
                PreviousWorkoutDataContainer.Height = PreviousExercise.PreviousWorkoutContainerHeight - PreviousExercise.PreviousWorkoutHeightBuffer;
                PreviousWorkoutDataScrollViewer.Height = PreviousExercise.PreviousWorkoutHeightMax - PreviousExercise.PreviousWorkoutHeightBuffer;
                PreviousWorkoutDataScrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
            }
            
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (MiscDataStorage.DateChosen == false)
            {
                MessageBox.Show("Choose a date before submitting!");
            }
            else
            {
                string fileName = MiscDataStorage.Date + ".csv";
                using (StreamWriter file = new StreamWriter("Workouts\\" + fileName))
                {
                    file.Write(MiscDataStorage.Date);
                    file.Write(Environment.NewLine);

                    file.Write(string.Join(",", MasterExerciseList.SetHeaderList));
                    file.Write(Environment.NewLine);

                    StringBuilder exerciseHeader = new StringBuilder();
                    exerciseHeader.Append("Exercise ID,Muscle Group,Exercise");
                    for (int setNumber = 0; setNumber < MiscDataStorage.SetLabelCount; setNumber++)
                    {
                        exerciseHeader.Append(",Weight,Reps");
                    }

                    file.Write(exerciseHeader.ToString());
                    file.Write(Environment.NewLine);

                    foreach (ExerciseDataPanel.Exercise exercise in MasterExerciseList.Exercises)
                    {
                        List<string> exerciseLine = new List<string>();
                        exerciseLine.Add(exercise.Identifier.ToString());
                        exerciseLine.Add(exercise.MuscleGroupType);
                        exerciseLine.Add(exercise.ExerciseType);

                        foreach (SetDataPanel.Set setData in exercise.Sets)
                        {
                            exerciseLine.Add(setData.Weight.ToString());
                            exerciseLine.Add(setData.Reps.ToString());
                        }

                        file.Write(string.Join(",", exerciseLine));
                        file.Write(Environment.NewLine);
                    }
                }

                MessageBoxResult showCSV = MessageBox.Show("Done! Would you like to view your file?", "All done!", MessageBoxButton.YesNo);
                if (showCSV == MessageBoxResult.Yes)
                {
                    Process.Start("Workouts\\" + fileName);
                }
                else if (showCSV == MessageBoxResult.No)
                {
                    MessageBox.Show("Fine. Find it yourself when you get around to it.");
                }
            }
        }
    }
}
