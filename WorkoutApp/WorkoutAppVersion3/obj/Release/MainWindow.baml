   M S B A M L   `   `   `  ���� M  IWorkoutAppVersion3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WorkoutAppVersion3WorkoutAppVersion3  #    WorkoutAppVersion3.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2local clr-namespace:WorkoutAppVersion3       � Title$  Workout App��$	��700��$
��1000�� � 
ResizeMode$ CanMinimize=� � WindowStartupLocation$ CenterScreen=�.��� $��	2,0,0,-31q�$
��Left=�$
��1000��$	��700�� J� RenderTransformOrigin$ 
0.214,0.45&�.+��� -   $��	DateLabel��$
��Date��$��28��$
��Left=�$��	24,14,0,0q�$	��Top=�(  "System.Windows.Controls.DatePicker  -   $��
datePicker��$��25��$
��Left=�$��	64,15,0,0q�$	��Top=�$	��199��   DisplayDate$  ��   SelectedDateFormat$
 Long=��� -    ��Name$ PreviousDataCheckBox��$;��5I would like to show my previous data for comparison.��$
��Left=�$��	24,54,0,0q�$	��Top=��� -    ��Name$ SubmitButton��$%��Submit and Save My Workout Data��$
��Left=�$��
320,15,0,0q�$	��Top=�$	��200���� -    ��Name$ MainContainer��$
��Left=�$	��700��$��	24,73,0,0q�$	��Top=�$
��1000��.+��� -   	 ��Name$!	 PreviousWorkoutScrollViewer��$��Hidden=�$��Disabled=�$��82��$	��950��$
��Left=�$	��Top=�$y�	Collapsed=�.���� -   $ PreviousWorkoutContainer��$
��Left=�$��82��$	��Top=�$
��1000��$y�	Collapsed=�.+��� -   $ LoadPreviousDataButton��$��Select Previous Workout��$
��Left=�$��0,0,0,0q�$	��Top=�$	��140���� -	   $��PreviousSetLabelStackBox��$
��Left=�$��69��$��0,0,0,0q�$	��Top=�$
��1000��
 �� Orientation$
 
Horizontal=�$y�	Collapsed=�.+��� -
    ��Name$ PreviousDateLabel��$��Label��$	��462��$y�Hidden=��� -   $%	 PreviousWorkoutDataScrollViewer��$��Disabled=�$��Hidden=�$��82��$	��950��$
��Left=�$	��Top=�$y�	Collapsed=�.���� -   $" PreviousWorkoutDataContainer��$
��Left=�$��82��$	��Top=�$
��1000��$y�	Collapsed=��� -   $	 WorkoutScrollViewer��$��Hidden=�$��Disabled=�$	��375��$	��950��$
��Left=�$	��Top=�.���� -   $ CurrentWorkoutContainer��$
��Left=�$	��375��$��0,0,0,0q�$	��Top=�$
��1000��$
 Vertical=�.+��� -   $ SetLabelStackBox��$
��Left=�$��69��$��0,0,0,0q�$	��Top=�$
��1000��$
 
Horizontal=� �� CanVerticallyScroll .  .+��� -   $ AddNewExercise��$��Add New Exercise��$
��Left=�$��Bottom=�$	��121��$��22��$��0,0,0,10q��� ���	#FFF4F4F5
���   �$	��341��$y�Hidden=��� -   $	 WorkoutDataScrollViewer��$��Disabled=�$��Hidden=�$	��306��$	��950��$
��Left=�$	��Top=�.���� -   $ WorkoutDataContainer��$
��Left=�$	��306��$��0,0,0,0q�$	��Top=�$
��1000��$
 Vertical=�