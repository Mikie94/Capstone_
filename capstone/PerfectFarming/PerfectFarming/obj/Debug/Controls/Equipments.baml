   M S B A M L   `   `   `  ����I  EPerfectFarming, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:PerfectFarming.ControlsPerfectFarming.Controls  5      (    "PerfectFarming.Controls.Equipments   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:PerfectFarming.Controls     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $��30 �6   �� 5      $��25 �6   �� 5      $��* �6   �� 5      $��40 �6    � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      .+�5   
   �� $	��0.5q�6   
����������#4CAF50._�5      �� $��
Equipments��6   $��16(�6)   $
��Bold"�67   $
��Left=�6I   
�������$��10,0,0,0q�6w   5      �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Stretch=�6;   .+�5      �� $��Search:��6   $��Center=�6(   
���   �6C   �� 5      -   5         ��Name$ searchField��5      $�� ��6   $��Stretch=�63   $	��160��6Q   $��2,2,0,2q�6]    �� TextAlignment$
 Left=�6n   6�   5      �� 5   
   -   5         ��Name$ listEquipments��5      $	��200��6+   $��2��67   ��5      �� 5      .R�5      � $��5q�6     5      �� 5       �� 5!      .+�5#      �� $��14(�6$   $
��Bold"�62   ��6D   �� *name+�� 5$      $ 
Horizontal=�6%   $��1��6>   .+�5%      �� $��Model: ��6(   �� 5&      ��6(   �� *model+5'      5(      5)      5+      �� 5,   
   -   5        $��3��5,      ���#4CAF50._�5-      �� $ 
Horizontal=�6   $��Center=�62   .+�5.      �� $��/Resources/add.png��6   $��Uniform=�64   $��25��6F   �� 5/      $��Add Equipment��6   $��16(�60   $
��Bold"�6>   
�������$��Center=�6d   50      51      � 52   
   -   5         �Name$ 
detailGrid��52      $y�Hidden=�6#   $��1��67   $��1��6G   $��2��6T   $	��Top=�6f   $��2q�6~     53      �� 54      �� 55      �� 56      .+�58      �� $ 
Horizontal=�6   $��0��62   .+�59      �� $��Name:��6   $��18(�6(   $
��Bold"�66   $��Center=�6H   �� 5:      -   5         ��Name$ equipmentName��5:      $��18(�6/   5;      �� 5<      $ 
Horizontal=�6   $��1��62   .+�5=      �� $��Make:��6   $��18(�6(   $
��Bold"�66   $	��Top=�6H   �� 5>      -   5         ��Name$
 make��5>      $��18(�6*   $��5q�68   $
��Wrap=�6C   $	��300��6W   $
��Left=�6c   $	��Top=�6~   5?      �� 5@      $ 
Horizontal=�6   $��2��62   .+�5A      �� $��Model: ��6   $��18(�6*   $
��Bold"�68   $��Center=�6J   �� 5B      -   5        $ model��5B      $��Center=�6+   $��18(�6F   5C      5D      5F      5G      