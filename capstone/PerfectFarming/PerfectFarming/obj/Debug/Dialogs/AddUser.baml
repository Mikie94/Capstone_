   M S B A M L   `   `   `  ����I  EPerfectFarming, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:PerfectFarming.DialogsPerfectFarming.Dialogs  5   	   $    PerfectFarming.Dialogs.AddUser   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:PerfectFarming.Dialogs     5   	     � Title$  AddUser��5   	   $	��480��6   $	��400��6&   .��5	      � $��0,0,20,0q�6    � ColumnDefinitions 5
   
   �� 5      $	��120 �6   �� 5       � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��40 �6   �� 5      $
��auto �6   .+�5   
   �� $��Add User��6   $��2��6#   $��Center=�67   $��16(�6T   $
��Bold"�6b   $��0q�6t   $��Center=�6   �� 5   
   $��
User Name:��6   $��1��6&   $��Right=�63   $��DemiBold"�6O   $��14(�6e   $��Center=�6s   $��0,0,4,0q�6�   �� 5   
   $��First Name:��6   $��2��6'   $��Right=�64   $��DemiBold"�6P   $��14(�6f   $��Center=�6t   $��0,0,4,0q�6�   �� 5   
   $��
Last Name:��6   $��3��6&   $��Right=�63   $��DemiBold"�6O   $��14(�6e   $��Center=�6s   $��0,0,4,0q�6�   �� 5   
   $��Email:��6   $��4��6"   $��Right=�6/   $��DemiBold"�6K   $��14(�6a   $��Center=�6o   $��0,0,4,0q�6�   �� 5   
   $��	Password:��6   $��5��6%   $��Right=�62   $��DemiBold"�6N   $��14(�6d   $��Center=�6r   $��0,0,4,0q�6�   �� 5    
   $��Repeat Password:��6   $��6��6,   $��Right=�69   $��DemiBold"�6U   $��14(�6k   $��Center=�6y   $��0,0,4,0q�6�   �� 5!   
   $��
User Type:��6   $��7��6&   $��Right=�63   $��DemiBold"�6O   $��14(�6e   $��Center=�6s   $��0,0,4,0q�6�   �� 5#   
   -   5         ��Name$ txtUserName��5#      $��1��6'   $��1��67   $��4q�6D   �� 5$   
   -   5        $ txtFirstName��5$      $��1��6(   $��2��68   $��4q�6E   �� 5%   
   -   5        $ txtLastName��5%      $��1��6'   $��3��67   $��4q�6D   �� 5&   
   -   5        $ txtEmail��5&      $��1��6$   $��4��64   $��4q�6A   G� 5'   
   -   5         G�Name$ txtPassword��5'      $��1��6+   $��5��6;   $��4q�6H   G� 5(   
   -   5        $ txtRepeatPassword��5(      $��1��61   $��6��6A   $��4q�6N   �� 5)   
   -   5         ��Name$ comboUserType��5)      $��1��6*   $��7��6:   $��4q�6G   .@�5*      �� $��Client��6    �� 
IsSelected . 6,   �� 5+      $��Admin��6   5,      �� 5.   
   $��1��6   $��8��6%    �� Orientation$ 
Horizontal=�62   $��Right=�6K   $��4q�6g   .+�5/      �� -   5         ��Name$ btnAdd��5/   #   $	��Add��6   $��4q�63   $	��100��6>   6J   �� 50      -	   5        $ 	txtCancel��50   &   $��Cancel��6   $��4q�69   $	��100��6D   6P   51      &   System.Windows.Controls.DataGrid  52   
   -
   5        	  Name$	 	userTable��52      
   
IsReadOnly
 . $��9��68   $��2��6E   $	��150��6Y   $��10,0,0,0q�6f      Columns 53      0  *System.Windows.Controls.DataGridTextColumn  54      ,  &System.Windows.Controls.DataGridColumn   Header$ 	User Name��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   �� *	user_name+  55      $ 
First Name��6%    69   �� *
first_name+  56      $ 	Last Name��6%    68   �� *	last_name+  57      $ Email��6%    64   �� *email+  58      $ 	User Type��6%    68   �� *	user_type+5:      5;      5<      