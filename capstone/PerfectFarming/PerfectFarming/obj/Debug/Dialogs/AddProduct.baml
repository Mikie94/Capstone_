   M S B A M L   `   `   `  ����I  EPerfectFarming, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:PerfectFarming.DialogsPerfectFarming.Dialogs  5   	   '    !PerfectFarming.Dialogs.AddProduct   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:PerfectFarming.Dialogs     5   	     � Title$  
AddProduct��5   	   $	��250��6   $	��400��6)   .��5	      � $��0,0,20,0q�6    � ColumnDefinitions 5
   
   �� 5      $	��100 �6   �� 5       � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��40 �6   .+�5   
   �� $��Add Product��6   $��2��6&   $��Center=�6:   $��16(�6W   $
��Bold"�6e   $��0q�6w   $��Center=�6�   �� 5   
   $��Name:��6   $��1��6!   $��Right=�6.   $��DemiBold"�6J   $��14(�6`   $��Center=�6n   $��0,0,4,0q�6�   �� 5   
   $��	Category:��6   $��2��6%   $��Right=�62   $��DemiBold"�6N   $��14(�6d   $��Center=�6r   $��0,0,4,0q�6�   �� 5   
   $��	Quantity:��6   $��3��6%   $��Right=�62   $��DemiBold"�6N   $��14(�6d   $��Center=�6r   $��0,0,4,0q�6�   �� 5   
   $��Price per item:��6   $��4��6+   $��Right=�68   $��DemiBold"�6T   $��14(�6j   $��Center=�6x   $��0,0,4,0q�6�   �� 5   
   -   5         ��Name$ txtName��5      $��1��6#   $��1��63   $��4q�6@   �� 5   
   -   5        $ txtCategory��5      $��1��6'   $��2��67   $��4q�6D   �� 5   
   -   5        $ txtQuantity��5      $��1��6'   $��3��67   $��4q�6D   �� 5   
   -   5        $ txtPrice��5      $��1��6$   $��4��64   $��4q�6A   �� 5   
   $��1��6   $��10��6%    �� Orientation$ 
Horizontal=�63   $��Right=�6L   $��4q�6h   .+�5       �� -   5         ��Name$ btnAdd��5    #   $	��Add��6   $��4q�63   $	��100��6>   6J   �� 5!      -   5        $ 	txtCancel��5!   &   $��Cancel��6   $��4q�69   $	��100��6D   6P   5"      5#      5$      