   M S B A M L   `   `   `  ����I  EPerfectFarming, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:PerfectFarming.ControlsPerfectFarming.Controls  5      '    !PerfectFarming.Controls.Warehouse   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:PerfectFarming.Controls     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $��30 �6   �� 5      $��25 �6   �� 5      $��* �6   �� 5      $��40 �6    � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      .+�5   
   �� $	��0.5q�6   
����������#4CAF50._�5      �� $��Products��6   $��16(�6'   $
��Bold"�65   $
��Left=�6G   
�������$��10,0,0,0q�6u   5      �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Stretch=�6;   .+�5      �� $��Search:��6   $��Center=�6(   
���   �6C   �� 5      -   5         ��Name$ searchField��5      $�� ��6   $��Stretch=�63   $	��160��6Q   $��2,2,0,2q�6]    �� TextAlignment$
 Left=�6n   6�   5      �� 5   
   -   5         ��Name$ listProducts��5      $	��200��6)   $��2��65   ��5      �� 5      .R�5      � $��5q�6     5      �� 5       �� 5!      .+�5#      �� $��14(�6$   $
��Bold"�62   ��6D   �� *name+�� 5$      $ 
Horizontal=�6%   $��1��6>   .+�5%      �� $��
Category: ��6(   �� 5&      ��6(   �� *
category+�� 5'      $��  ��6(   �� 5(      $��price: ��6(   �� 5)      ��6(   �� *price_per_item+�� 5*      $��$��6(   5+      5,      5-      5/      �� 50   
   -   5        $��3��50      ���#4CAF50._�51      �� $ 
Horizontal=�6   $��Center=�62   .+�52      �� $��/Resources/add.png��6   $��Uniform=�64   $��25��6F   �� 53      $��Add Product��6   $��16(�6.   $
��Bold"�6<   
�������$��Center=�6b   54      55      � 56   
   -   5         �Name$ 
detailGrid��56      $y�Hidden=�6#   $��1��67   $��1��6G   $��2��6T   $	��Top=�6f   $��	12,10,0,0q�6~     57      �� 58      �� 59      �� 5:      �� 5;      .+�5=      �� $ 
Horizontal=�6   $��0��62   .+�5>      �� $��Name: ��6   $��18(�6)   $
��Bold"�67   $��Center=�6I   �� 5?      -   5         ��Name$ productName��5?      $��18(�6-   5@      �� 5A      $ 
Horizontal=�6   $��1��62   .+�5B      �� $��
Category: ��6   $��18(�6-   $
��Bold"�6;   $	��Top=�6M   �� 5C      -   5         ��Name$ category��5C      $��18(�6.   $��5q�6<   $
��Wrap=�6G   $	��300��6[   $
��Left=�6g   $	��Top=�6�   5D      �� 5E      $ 
Horizontal=�6   $��2��62   .+�5F      �� $��
Quantity: ��6   $��18(�6-   $
��Bold"�6;   $��Center=�6M   �� 5G      -   5        $ quantity��5G      $��Center=�6.   $��18(�6I   5H      �� 5I      $ 
Horizontal=�6   $��3��62   .+�5J      �� $��Price per item: ��6   $��18(�63   $
��Bold"�6A   $��Center=�6S   �� 5K      -   5        $ price��5K      $��Center=�6+   $��18(�6F   �� 5L      $�� $��6   $��14(�6&   $��Center=�64   5M      5N      5P      5Q      