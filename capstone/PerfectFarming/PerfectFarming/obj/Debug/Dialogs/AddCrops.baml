   M S B A M L   `   `   `  ����I  EPerfectFarming, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:PerfectFarming.DialogsPerfectFarming.Dialogs  5   	   %    PerfectFarming.Dialogs.AddCrops   5   	   k gTelerik.Windows.Controls.Input, Version=2020.1.218.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2020.1.218.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Atelerik1http://schemas.telerik.com/2008/xaml/presentation   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:PerfectFarming.Dialogs     5   	     � Title$  AddCrops��5   	   $	��250��6   $	��400��6'   .��5	      � $��0,0,20,0q�6    � 	Resources 5
   
   4  .Telerik.Windows.Controls.ColorToBrushConverter   colorToBrushConverter��%   &	          5      6,   5       � ColumnDefinitions 5   
   �� 5      $	��130 �6   �� 5       � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��40 �6   .+�5   
   �� $��Add Crop��6   $��2��6#   $��Center=�67   $��16(�6T   $
��Bold"�6b   $��0q�6t   $��Center=�6   �� 5   
   $��Name:��6   $��1��6!   $��Right=�6.   $��DemiBold"�6J   $��14(�6`   $��Center=�6n   $��0,0,4,0q�6�   �� 5   
   $��Description:��6   $��2��6(   $��Right=�65   $��DemiBold"�6Q   $��14(�6g   $��Center=�6u   $��0,0,4,0q�6�   �� 5   
   $��Color:��6   $��3��6"   $��Right=�6/   $��DemiBold"�6K   $��14(�6a   $��Center=�6o   $��0,0,4,0q�6�   �� 5   
   -   5         ��Name$ txtName��5      $��1��6#   $��1��63   $��4q�6@   �� 5   
   -   5        $ txtDescripton��5      $��1��6)   $��2��69   $��4q�6F   �� 5    
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��3��6>   $��4q�6K   .+�5!      -  'Telerik.Windows.Controls.RadColorPicker  -   5          Name$ colorSelector��5!   ;      SelectedColor$ Black��6%   $
��Left=�6R      ContentTemplate 5"      �� 5#      .R�5$      �� $��20��6%   $��18��61   $��-2q�6<   .+�5%      �� $��/Resources/farm.png��6$   �� 5&      $��2��6(   $��18��63   ��5'   (   �� *SelectedColor+	 �� ElementName$	 textForegroundPicker��
 �� 	Converter#
 [  5(      5)      5,      �� 5-      -   5         ��Name$ colordisplay��5-   !   $	��120��6   6!   5.      �� 5/   
   $��Expense Planned:��6   $��4��6,   $��Right=�69   $��DemiBold"�6U   $��14(�6k   $��Center=�6y   $��0,0,4,0q�6�   �� 50   
   -   5        $ 
txtExpense��50      $��1��6&   $��4��66   $��4q�6C   �� 51   
   $��1��6   $��10��6%   $ 
Horizontal=�63   $��Right=�6L   $��4q�6h   .+�52      �� -   5         ��Name$ btnAdd��52   #   $	��Add��6   $��4q�63   $	��100��6>   6J   �� 53      -   5        $ 	txtCancel��53   &   $��Cancel��6   $��4q�69   $	��100��6D   6P   54      55      56      