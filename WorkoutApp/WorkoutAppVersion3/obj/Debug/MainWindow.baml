   M S B A M L   `   `   `  ����M  IWorkoutAppVersion3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WorkoutAppVersion3WorkoutAppVersion3  5   	   #    WorkoutAppVersion3.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:WorkoutAppVersion3     5   	     � Title$  Workout App��5   	   $	��700��6   $
��1000��6*    � 
ResizeMode$ CanMinimize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	   .��5      � $��	2,0,0,-31q�6   $
��Left=�6   $
��1000��69   $	��700��6F    J� RenderTransformOrigin$ 
0.214,0.45&�6T   .+�5   
   �� -   5        $��	DateLabel��5   Y   $
��Date��6   $��28��6   $
��Left=�6+   $��	24,14,0,0q�6F   $	��Top=�6j   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��
datePicker��5   O   $��25��6   $
��Left=�6!   $��	64,15,0,0q�6<   $	��Top=�6a   $	��199��6y      DisplayDate$  ��6�      SelectedDateFormat$
 Long=�6�   �� 5   
   -   5         ��Name$ PreviousDataCheckBox��5      $;��5I would like to show my previous data for comparison.��61   $
��Left=�6q   $��	24,54,0,0q�6�   $	��Top=�6�   6�   �� 5   
   -   5         ��Name$ SubmitButton��5      $%��Submit and Save My Workout Data��6'   $
��Left=�6Q   $��
320,15,0,0q�6l   $	��Top=�6�   $	��200��6�   6�   �� 5   
   -   5         ��Name$ MainContainer��5      $
��Left=�6,   $	��700��6G   $��	24,73,0,0q�6T   $	��Top=�6g   $
��1000��6   .+�5      �� -   5        	 ��Name$!	 PreviousWorkoutScrollViewer��5      $��Hidden=�6@   $��Disabled=�6g   $��82��6�   $	��950��6�   $
��Left=�6�   $	��Top=�6�   $y�	Collapsed=�6�   .��5      �� -   5        $ PreviousWorkoutContainer��5      $
��Left=�6?   $��82��6Z   $	��Top=�6f   $
��1000��6~   $y�	Collapsed=�6�   .+�5      �� -   5        $ LoadPreviousDataButton��5      $��Select Previous Workout��6=   $
��Left=�6_   $��0,0,0,0q�6z   $	��Top=�6�   $	��140��6�   6�   �� 5      -	   5        $��PreviousSetLabelStackBox��5   !   $
��Left=�6A   $��69��6\   $��0,0,0,0q�6h   $	��Top=�6y   $
��1000��6�   
 �� Orientation$
 
Horizontal=�6�   $y�	Collapsed=�6�   .+�5      �� -
   5         ��Name$ PreviousDateLabel��5       $��Label��6;   $	��462��6K   $y�Hidden=�6W   5      �� 5      -   5        $%	 PreviousWorkoutDataScrollViewer��5   #   $��Disabled=�6L   $��Hidden=�6u   $��82��6�   $	��950��6�   $
��Left=�6�   $	��Top=�6�   $y�	Collapsed=�6�   .��5      �� -   5        $" PreviousWorkoutDataContainer��5   %   $
��Left=�6K   $��82��6f   $	��Top=�6r   $
��1000��6�   $y�	Collapsed=�6�   5      5      5      5      �� 5      -   5        $	 WorkoutScrollViewer��5      $��Hidden=�68   $��Disabled=�6_   $	��375��6�   $	��950��6�   $
��Left=�6�   $	��Top=�6�   .��5      �� -   5        $ CurrentWorkoutContainer��5      $
��Left=�6>   $	��375��6Y   $��0,0,0,0q�6f   $	��Top=�6w   $
��1000��6�   $
 Vertical=�6�   .+�5      �� -   5        $ SetLabelStackBox��5   !   $
��Left=�6;   $��69��6V   $��0,0,0,0q�6b   $	��Top=�6s   $
��1000��6�   $
 
Horizontal=�6�    �� CanVerticallyScroll .  .+�5       �� -   5        $ AddNewExercise��5    !   $��Add New Exercise��69   $
��Left=�6T   $��Bottom=�6o   $	��121��6�   $��22��6�   $��0,0,0,10q�6�   6�   �� 5!      ���	#FFF4F4F5
���   �$	��341��6D   $y�Hidden=�6P   5"      �� 5#      -   5        $	 WorkoutDataScrollViewer��5#   #   $��Disabled=�6D   $��Hidden=�6m   $	��306��6�   $	��950��6�   $
��Left=�6�   $	��Top=�6�   .��5$      �� -   5        $ WorkoutDataContainer��5$   %   $
��Left=�6C   $	��306��6^   $��0,0,0,0q�6k   $	��Top=�6|   $
��1000��6�   $
 Vertical=�6�   5%      5&      5'      5(      5)      5*      5+      