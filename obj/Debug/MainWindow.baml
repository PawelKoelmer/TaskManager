   M S B A M L   `   `   `  ����F  BTaskManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:TaskManagerTaskManager  5   	       TaskManager.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:TaskManager     5   	     � Title$  TaskManager��5   	   $	��600��6   $	��800��6*   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��181* �6   �� 5      $
��353* �6   �� 5      $
��258* �6   .+�5   
   �� -   5         ��Name$ 	AddButton��5      $��
Dodaj Task��6$   $
��Left=�69   $��
60,480,0,0q�6T   $	��Top=�6h   $	��178��6�   $��36��6�   $��2��6�   6�   �� 5   
   -   5         ��Name$ Priority��5      $��Center=�6%   $��Center=�6I   $��1��5      $��111,480,65,0q�6#   $	��Top=�69   $��36��6Q   .@�5      ��  �� 
IsSelected . .��6-   	Wszystkie68   �� 5      .��6   Niski6"   �� 5      .��6   
Normalny6&   �� 5      .��6   Wysoki6#   5      �� 5   
   -   5        $ Status��5      $��1��6#   $��Center=�63   $��Center=�6W   $
��Left=�5      $��337,480,0,0q�6.   $	��Top=�6C   $	��177��6[   $��36��6g   $��2��5      .@�5      ��  . .��6-   	Wszystkie68   �� 5      .��6   Nowy6!   �� 5      .��6   W realizacji6*   �� 5      .��6   Zakończone6'   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ TaskGrid��5      $��3��6%   $
��Left=�69   $	��393��6T   $��	60,34,0,0q�6a   $	��Top=�5       $	��635��6+      SelectionMode$ Single=�67      AutoGenerateColumns .     Columns 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn	   
IsReadOnly	 . 
   Header$
 Zadanie��6U      Width5  /System.Windows.Controls.DataGridLengthConverter$	 250 6f      CanUserResize .     MaxWidth$	 250Q�6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   ��  �� Path$
 Text�   ElementStyle 5#      �� 5$       �� 
TargetType" ��6    .�5%      ��  �� Property � �� �� Value$
 Wrap=�6=   5'      5(      5+        5,      	 . $
 	Priorytet��6Y    6%   �� $ priority�6n     5-      	 . $
 Status��6W    6%   �� $ status�6i     5.      	 . $
 Data zakończenia��6Y    6%   �� $ End_Date�6u   4  .System.Windows.Controls.DataGridTemplateColumn  5/      $
 Usuń zadanie��6)      CellTemplate 50      �� 51      .R�52      �� -   5        $��Usuń��52   %   6I   53      55        56      $
 Edytuj��6)    57      �� 58      .R�59      �� -   5        $��Edytuj��59   %   6I   5:      5<      5>      5A      5B      