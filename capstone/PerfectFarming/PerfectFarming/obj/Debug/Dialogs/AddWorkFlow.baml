   M S B A M L   `   `   `  ����  PerfectFarming(    "PerfectFarming.Dialogs.AddWorkFlow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   k gTelerik.Windows.Controls.Input, Version=2020.1.218.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2020.1.218.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Atelerik1http://schemas.telerik.com/2008/xaml/presentation   6P     � Title$  AddWorkFlow��5   	   $	��310��6   $	��430��6*   .��5      � $��0,0,20,0q�6    � ColumnDefinitions 5	   
   �� 5
      $	��100 �6   �� 5       � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��40 �6   .+�5   
   �� $��Add Work Flow��6   $��2��6(   $��Center=�6<   $��16(�6Y   $
��Bold"�6g   $��0q�6y   $��Center=�6�   �� 5   
   $��Name:��6   $��1��6!   $��Right=�6.   $��DemiBold"�6J   $��14(�6`   $��Center=�6n   $��0,0,4,0q�6�   �� 5   
   $��Crop:��6   $��2��6!   $��Right=�6.   $��DemiBold"�6J   $��14(�6`   $��Center=�6n   $��0,0,4,0q�6�   �� 5   
   $��Field:��6   $��3��6"   $��Right=�6/   $��DemiBold"�6K   $��14(�6a   $��Center=�6o   $��0,0,4,0q�6�   �� 5   
   $��Stage:��6   $��4��6"   $��Right=�6/   $��DemiBold"�6K   $��14(�6a   $��Center=�6o   $��0,0,4,0q�6�   �� 5   
   $��Work:��6   $��5��6!   $��Right=�6.   $��DemiBold"�6J   $��14(�6`   $��Center=�6n   $��0,0,4,0q�6�   �� 5   
   $��Revenue:��6   $��6��6$   $��Right=�61   $��DemiBold"�6M   $��14(�6c   $��Center=�6q   $��0,0,4,0q�6�   �� 5!   
   -   5         ��Name$ txtName��5!      $��1��6#   $��1��63   $��4q�6@   �� 5"   
   $��1��6   $��2��6%   $��4q�62    �� Orientation$ 
Horizontal=�6=   .+�5#      �� -   5         ��Name$ 
comboCrops��5#       �� 
IsEditable . $	��210��6=   �� 5$      -   5         ��Name$ 
btnAddCrop��5$      $	��Add��6)   $��60��6P   $��10,0,0,0q�6[   5%      �� 5'   
   -   5        $ comboFields��5'       . $��1��6:   $��3��6J   $��4q�6W   �� 5(   
   -   5        $ txtStage��5(      $��1��6$   $��4��64   $��4q�6A   �� 5)   
   -   5        $ 
txtRevenue��5)      $��1��6&   $��6��66   $��4q�6C   �� 5*   
   $ 
Horizontal=�6   $��1��6.   $��5��6>   $��4q�6K   .+�5+      1  +Telerik.Windows.Controls.RadAutoCompleteBox  -   5          Name$ txtOperation��5/   L   	   SelectionMode$	 Multiple=�5+   )   
   WatermarkContent$
 Type a name��5,   1      TextSearchMode$ Contains=�5-   1      TextSearchPath$
 name��5.   1      AutoCompleteMode$ Suggest=�5/   1   $��1��6c   $��3��6s   $	��220��6�   +  %Telerik.Windows.Controls.StyleManager   Theme-  'Telerik.Windows.Controls.ThemeConverter$ VisualStudio2019 6�      DropDownItemTemplate 50      �� 51      .R�52      �� $ 
Horizontal=�6%   .+�53      F� ������ا �ا ��ا A]� �A]� A]� �A]� �ا �zo �?�ا �zo �?A]� ���]  @A]� ���]  @�ا p�ا A�!  @��ا AT� �A]� AT� QA]� A�!  @�k�_k  �?��j �k�_k  �?@T� ����  @@T� ����  @��j p�ا ���  @Q�ا A�!  @QA]� A�!  @QA]� ���  @0zo �?���  @zo �?A�!  @��]  @A�!  @��]  @���  @�        �zo �?    zo �?�7�  �?��]  @�7�  �?���]  @    ��ا     Q�ا �7�  �?QA]� �7�  �?�A]�     р��     р��  $� �A]�  $� �A]� ��� ��ا ��� ��ا  $� ���]  @ $� ���]  @��� �zo �?��� �zo �? $� �     $� 	���	#FF307EBA$
��Left=�54      $��7 0 0 0q�64    �� Stretch$
 Fill=�6E   $��14��6T   $��16��6_   $��Center=�6k   �� 55      $��10 0 0 0q�6>   ��6(   �� *name+6>   56      57      59      �� 5:      -   5        $ 
btnAddWork��5:   9   $��Add Work��6   $��4,0,0,0q�6(   6M   5;      �� 5>   
   $��1��6   $��7��6%   $ 
Horizontal=�62   $��Right=�6K   $��0,0,0,0q�6g   .+�5?      �� -	   5        $ btnAdd��5?      $	��Add��6%   $��4q�63   $	��100��6>   6J   �� 5@      -
   5        $ 	btnCancel��5@      $��Cancel��6(   $��4q�69   $	��100��6D   6P   5A      5B      5C      