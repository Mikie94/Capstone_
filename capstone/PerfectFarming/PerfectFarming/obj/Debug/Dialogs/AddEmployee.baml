   M S B A M L   `   `   `  ����I  EPerfectFarming, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:PerfectFarming.DialogsPerfectFarming.Dialogs  5   	   (    "PerfectFarming.Dialogs.AddEmployee   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:PerfectFarming.Dialogs     5   	     � Title$  AddEmployee��5   	   $	��400��6   $	��400��6*   .��5	      � $��0,0,20,0q�6    � ColumnDefinitions 5
   
   �� 5      $	��100 �6   �� 5       � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��40 �6   �� 5      $
��auto �6   .+�5   
   �� $��Add Employee��6   $��2��6'   $��Center=�6;   $��16(�6X   $
��Bold"�6f   $��0q�6x   $��Center=�6�   �� 5   
   $��First Name:��6   $��1��6'   $��Right=�64   $��DemiBold"�6P   $��14(�6f   $��Center=�6t   $��0,0,4,0q�6�   �� 5   
   $��
Last Name:��6   $��2��6&   $��Right=�63   $��DemiBold"�6O   $��14(�6e   $��Center=�6s   $��0,0,4,0q�6�   �� 5   
   $��Gender:��6   $��3��6#   $��Right=�60   $��DemiBold"�6L   $��14(�6b   $��Center=�6p   $��0,0,4,0q�6�   �� 5   
   $
��Age:��6   $��4��6    $��Right=�6-   $��DemiBold"�6I   $��14(�6_   $��Center=�6m   $��0,0,4,0q�6�   �� 5   
   -   5         ��Name$ txtFirstName��5      $��1��6(   $��1��68   $��4q�6E   �� 5   
   -   5        $ txtLastName��5      $��1��6'   $��2��67   $��4q�6D   �� 5   
   -   5         ��Name$ comboGender��5      $��1��6(   $��3��68   $��4q�6E   .@�5       �� $
��Male��6    �� 
IsSelected . 6*   �� 5!      $��Female��6   5"      �� 5#   
   -   5        $ txtAge��5#      $��1��6"   $��4��62   $��4q�6?   �� 5$   
   $��1��6   $��5��6%    �� Orientation$ 
Horizontal=�62   $��Right=�6K   $��4q�6g   .+�5%      �� -   5         ��Name$ btnAdd��5%   #   $	��Add��6   $��4q�63   $	��100��6>   6J   �� 5&      -   5        $ 	txtCancel��5&   &   $��Cancel��6   $��4q�69   $	��100��6D   6P   5'      &   System.Windows.Controls.DataGrid  5(   
   -   5          Name$ employeeTable��5(      	   
IsReadOnly	 . $��6��6<   $��2��6I   $	��150��6]   $��10,0,0,0q�6j   
   Columns
 5)      0  *System.Windows.Controls.DataGridTextColumn  5*      ,  &System.Windows.Controls.DataGridColumn   Header$ 
First Name��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *
first_name+  5+      $ 	Last Name��6%    68   �� *	last_name+  5,      $ Gender��6%    65   �� *gender+  5-      $	 Age��6%    62   �� *age+5/      50      51      