   M S B A M L   `   `   `  ����F  BTaskManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:TaskManager.AddWindowTaskManager.AddWindow  5   	   #    TaskManager.AddWindow.AddTask   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:TaskManager.AddWindow     5   	     � Title$  Add Task��5   	   $	��450��6   $	��800��6'   .��5	      � .+�5
   
   �� -   5         ��Name$ TaskText��5
      $
��Left=�6$   $	��189��6?   $��	48,36,0,0q�6L    �� TextWrapping$
 Wrap=�6_    �� 	MaxLength$
 1000��6s   $	��Top=�6�   $	��459��6�   �� 5   
   -   5         ��Name$	 Add��5      $��
Dodaj Task��6   $
��Left=�63   $��46��6N   $��188,334,0,0q�6Z   $	��Top=�6o   $	��165��6�   $��18(�6�   6�   �� 5   
   -   5         ��Name$ priority��5      $��Center=�6%   $��Center=�6G   $
��Left=�6k   $��46��6�   $��
48,248,0,0q�6�   $	��Top=�6�   $	��211��6�   $��18(�6�   .@�5      �� .��6   Niski6"   �� 5       �� 
IsSelected . .��6-   
Normalny67   �� 5      .��6   Wysoki6#   5      �� 5   
   -   5         ��Name$ endDate��5      $6��0Czy posiada termin realizacji                   ��6$   $
��Left=�5      $��
535,36,0,0q�60   $	��Top=�6D   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ endDateCalendar��5      $
��Left=�6.   $��
535,56,0,0q�6I   $	��Top=�6]   $��23��6u   $	��152��6�   �� 5   
   -   5        $ status��5      $��Center=�6#   $��Center=�6E   $
��Left=�6i   $��311,248,0,0q�6�   $	��Top=�6�   $	��196��6�   $��46��6�   $��18(�6�   .@�5      ��  . .��6-   Nowy63   �� 5      .��6   W realizacji6)   �� 5      .��6   Zakończony6'   5      5      5      