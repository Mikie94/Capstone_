   M S B A M L   `   `   `  ����I  EPerfectFarming, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:PerfectFarming.ControlsPerfectFarming.Controls  5      #    PerfectFarming.Controls.Notes   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:PerfectFarming.Controls     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $��30 �6    �� 5      $��25 �6    �� 5      $��* �6    �� 5      $
��auto �6     � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      .+�5   
   �� $	��0.5q�6   ���#4CAF50���#4CAF50._�5      �� $��Notes��6   $��16(�6(   
�������$
��Bold"�6I   $
��Left=�6[   $��10,0,0,0q�6v   5      �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Stretch=�6;   .+�5      �� $��Search:��6   $��Center=�6(   
���   �6C   �� 5      -   5         ��Name$ searchField��5      $�� ��6   $��Stretch=�63   $	��160��6Q   $��2,2,0,2q�6]    �� TextAlignment$
 Left=�6n   6�   5      �� 5   
   -   5         ��Name$ 	listNotes��5      $	��200��6&   $��2��62   ��5      �� 5      .R�5      � $��5q�6     5       �� 5!      �� 5"      .+�5$      �� $��14(�6$   $
��Bold"�62   ��6D   �� *name+�� 5%      $ 
Horizontal=�6%   $��1��6>   .+�5&      �� $��File attached: ��6(   �� 5'      ��6(   �� *
filename+5(      5)      5*      5,      �� 5.   
   -   5         ��Name$ 
btnAddNote��5.   3   $��3��6   ���#4CAF50._�5/      �� $ 
Horizontal=�6   $��Center=�62   .+�50      �� $��/Resources/add.png��6   $��Uniform=�64   $��25��6F   �� 51      $��	Add Notes��6   $��16(�6,   $
��Bold"�6:   
�������$��Center=�6`   52      53      � 54   
   -   5         �Name$ 
detailGrid��54      $y�Hidden=�6#   $��1��67   $��1��6G   $��2��6T   $	��Top=�6f   $��2q�6~     55      �� 56      �� 57      $	��200 �6    �� 58      .+�5:      �� $ 
Horizontal=�6   $��0��62   .+�5;      �� $��Name:��6   $��18(�6(   $
��Bold"�66   $��Center=�6H   �� 5<      -   5         ��Name$ noteName��5<      $��18(�6*   5=      �� 5>      $ Vertical=�6   $��1��60   .+�5?      �� $��Description:��6   $��18(�6/   $
��Bold"�6=   $	��Top=�6O   �� 5@      -   5        	 ��Name$	 description��5@      $��18(�61   $��5q�6?   $
��Wrap=�6J   $	��300��6^   $
��Left=�6j   $	��Top=�6�   5A      �� 5B      $ 
Horizontal=�6   $��2��62   .+�5C      �� $��File Attached: ��6   $��18(�62   $
��Bold"�6@   $��Center=�6R   �� 5D      -   5        $	 fileName��5D      $��Center=�6.   $��18(�6I   �� 5E      -   5        
 ��Name$
 btnDownload��5E      $��
Download..��6.   $��69��6C   $��5q�6h   5F      5G      5H      5I      