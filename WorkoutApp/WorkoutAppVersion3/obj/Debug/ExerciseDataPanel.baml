   M S B A M L   `   `   `  ����M  IWorkoutAppVersion3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WorkoutAppVersion3WorkoutAppVersion3  5      *    $WorkoutAppVersion3.ExerciseDataPanel   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:WorkoutAppVersion3     5      $��32.612��5      $	��462��6   .��5	      � $��0,0,-422,237q�6     � ColumnDefinitions  5
   
   �� 5      $
��200* �6   �� 5      $
��200* �6   .+�5   
   �� -   5        $��ExerciseStackPanel��5      $��30��6/   $��0,0,422,-30q�6;   $	��Top=�6P    �� Orientation$ 
Horizontal=�6h   $��2��6�   .+�5      �� -   5         ��Name$ MuscleGroupLabel��5      $��Muscle Group��6.   $��84��6E   �� 5      -   5         ��Name$ MuscleGroupSelector��5      $	��120��64   .@�5      �� -   5         ��Name$ Chest��5   /   $��Chest��6   6/   �� 5      -   5        $
 Back��5   .   $
��Back��6   6.   �� 5      -   5        $
 Arms��5   .   $
��Arms��6   6.   �� 5      -   5        $	 Abs��5   -   $	��Abs��6   6-   �� 5      -   5        $ 	Shoulders��5   3   $��	Shoulders��6   63   �� 5      -	   5        $
 Legs��5   .   $
��Legs��6   6.   5      �� 5      -
   5        $ ExerciseLabel��5      $��52��6+   $��Exercise��67   �� 5      -   5        $ ExerciseSelector��5      $	��120��61   6=   �� 5      -   5         ��Name$ AddSetButton��5      $��Add Set��6+   $��65��6=   $��20��6H   $	��5,5q�6o   5      � 5   
   $
��Left=�6   $��0��6*   $��331,30,0,-30q�65   $	��Top=�6K   $	��100��6c   5      5      