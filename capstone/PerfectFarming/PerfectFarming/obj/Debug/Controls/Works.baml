   M S B A M L   `   `   `  ����I  EPerfectFarming, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:PerfectFarming.ControlsPerfectFarming.Controls  5      #    PerfectFarming.Controls.Works   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:PerfectFarming.Controls     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $��30 �6   �� 5      $��25 �6   �� 5      $��* �6   �� 5      $��40 �6    � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      .+�5   
   �� $	��0.5q�6   
����������#4CAF50._�5      �� $��
Work Flows��6   $��16(�6)   $
��Bold"�67   $
��Left=�6I   
�������$��10,0,0,0q�6w   5      �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Stretch=�6;   .+�5      �� $��Search:��6   $��Center=�6(   
���   �6C   �� 5      -   5         ��Name$ searchField��5      $�� ��6   $��Stretch=�63   $	��160��6Q   $��2,2,0,2q�6]    �� TextAlignment$
 Left=�6n   6�   5      �� 5   
   -   5         ��Name$ listWorkflow��5      $	��200��6)   $��2��65   $��2��6B   ��5      �� 5      .R�5      � $��5q�6     5      �� 5       �� 5!      .+�5#      �� $��14(�6$   $
��Bold"�62   ��6D   �� *WorkflowName+�� 5$      $ 
Horizontal=�6%   $��1��6>   .+�5%      �� $��
Expenses: ��6(   �� 5&      ��6(   �� *TotalExpense+�� 5'      $��$��6(   �� 5(      $��  ��6(   �� 5)      $��/Resources/equipment1.png��6$   $��10��6G   $��10��6R   �� 5*      ��6(   �� *TotalEquipments+�� 5+      $��  ��6(   �� 5,      $��/Resources/user1.png��6$   $��10��6B   $��10��6M   �� 5-      ��6(   �� *TotalWorkers+�� 5.      $��  ��6(   �� 5/      $��/Resources/products.png��6$   $��10��6E   $��10��6P   �� 50      ��6(   �� *TotalProducts+51      52      53      55      �� 56   
   -   5        $��3��56      ���#4CAF50$y�Visible=�63   ._�57      �� $ 
Horizontal=�6   $��Center=�62   .+�58      �� $��/Resources/add.png��6   $��Uniform=�64   $��25��6F   �� 59      $��Add Work Flow��6   $��16(�60   $
��Bold"�6>   
�������$��Center=�6d   5:      5;      � 5<   
   -   5         �Name$ 
detailGrid��5<      $y�Hidden=�6#   $��1��67   $��0��6G   $��4��6T   
�������$��5q�6x    � 	Resources 5=      1  +PerfectFarming.Controls.BoolInvertConverter   boolConvert.  (PerfectFarming.Controls.BoolStringCovert  boolStringConvert��%:   &	        &	        5>      6,     5?      6)   5@        5A      �� 5B      $��80 �6    �� 5C      $��* �6    �� 5D      $
��auto �6    �� 5E      $
��auto �6    .+�5G      �� $ Vertical=�6   $��0,10,0,0q�60   .+�5H      �� -   5         ��Name$ workflowName��5H      $��2,0,0,0q�6P   $��20(�6a   $��	ExtraBold"�6o   ��62   �� *WorkflowName+6o   �� 5I      $��Main Parameters��6   $��2,0,0,0q�62   $��18(�6C   $
��Bold"�6Q   5J      � 5K      $��1��6     5L      �� 5M      $	��100 �6$   �� 5N      $
��auto �6$   �� 5O      $
��auto �6$   �� 5P      $��* �6$    5T      �� 5U      �� 5V      �� 5W      �� 5X      �� 5Y      .+�5[      �� .+�5\      �� $
��Crop��6    $��15(�6,   $��Black"�6:   $��Center=�6M   �� 5]      $��20(�6;   $��Center=�6I   ��6    �� *	Crop.name+6I   5^      �� 5_      $��1��6   .+�5`      �� $��Field��6    $��15(�6-   $��Black"�6;   $��Center=�6N   �� 5a      $��20(�6<   $��Center=�6J   ��6    �� *
Field.name+6J   �� 5b      -   5        	 ��Name$	 btnUse��5b      $	��USE��6-   $��	20,0,20,0q�6;   $��60��6N   6Y   5c      �� 5d      $��2��6   .+�5e      �� $��Stage��6    $��15(�6-   $��Black"�6;   $��Center=�6N   �� 5f      $��20(�67   $��Center=�6E   ��6    �� *Stage+6E   5g      �� 5h      $��3��6   .+�5i      �� $��Total Expense��6    $��15(�65   $��Black"�6C   $��Center=�6V   �� 5j      $ 
Horizontal=�6!   $��Center=�6:   .+�5k      �� $��20(�6B   $��Center=�6P   ��6$   �� *TotalExpense+6P   �� 5l      $��$��6$   $��14(�6-   $��Center=�6;   5m      5n      �� 5o      $��4��6   .+�5p      �� $��Revenue��6    $��15(�6/   $��Black"�6=   $��Center=�6P   �� 5q      $ 
Horizontal=�6!   $��Center=�6:   .+�5r      �� $��20(�6=   $��Center=�6K   ��6$   �� *	Revenue+6K   �� 5s      $��$��6$   $��14(�6-   $��Center=�6;   5t      5u      �� 5w      $��1��6   .+�5x      �� $��Total Equipments��6    $��15(�68   $��Black"�6F   $��Center=�6Y   �� 5y      $��20(�6A   $��Center=�6O   ��6    �� *TotalEquipments+6O   5z      �� 5{      $��1��6   $��1��6*   .+�5|      �� $��Total Workers��6    $��15(�65   $��Black"�6C   $��Center=�6V   �� 5}      $��20(�6>   $��Center=�6L   ��6    �� *TotalWorkers+6L   5~      �� 5      $��1��6   $��2��6*   .+�5�      �� $��Total Products��6    $��15(�66   $��Black"�6D   $��Center=�6W   �� 5�      $��20(�6?   $��Center=�6M   ��6    �� *TotalProducts+6M   5�      �� 5�      $��1��6   $��3��6+   .+�5�      �� $��
Total Days��6    $��15(�62   $��Black"�6@   $��Center=�6S   �� 5�      $��20(�6;   $��Center=�6I   ��6    �� *	TotalDays+6I   5�      �� 5�      $��Works��6   $��18(�6(   $
��Bold"�66   $��2��6H   �� 5�      $
��Auto=�6   $
��Auto=�6B   $��3��6h   $��Stretch=�6u   $	��Top=�6�   $��4��6�   .��5�      �� ��6   �� *
Operations+��5�      �� 5�      .R�5�      � $��0,2,0,0q�6#   .+�5�   "   �� ���	#FF5E727C$��10,1,0,0q�6A   $
��Left=�6\   $��0q�5�      $��Center=�6   ._�5�   &   �� $��0q�61   .+�5�   *   � $��0,5,0,0q�6/   .+�5�   .   �� $ Vertical=�69   .+�5�   2   �� $ 
Horizontal=�6=   .+�5�   :   �� $
��Wrap=�6D   $��14(�6X   ���	#FF333B42
 �� Padding$
 2,0,0,0q�6}   $��0q�5�   -    �� TextAlignment$
 Left=�68   $
��Bold"�6M   $
��Left=�6`   ��5�   -   �� *OperationName+�� 5�   :   $ 
Horizontal=�6E   $��20,0,0,0q�6^   .+�5�   >   �� $��Wages: ��6H   $
��Bold"�6W   �� 5�   >   ��6H   �� *Wages+�� 5�   >   $��$��6H   �� 5�   >   $��10,0,0,0q�6c   ��6H   �� *	StartDate+6c   �� 5�   >   $	�� - ��6H   �� 5�   >   ��6H   �� *	EndDate+�� 5�   >   $��10,0,0,0q�6�   $
��Bold"�6�   ��6H   ��  �� Path$ IsCompleted� �� 	Converter# [ 6�   �� 5�   >   -   5        $��
Completed?��5�   E   $��10,0,0,0q�6�   $��80��6�   
 � Tag 6Z   �� *OperationId+{�6v   �� $ IsCompleted�# [  6�   5�   ;   5�   3   �� 5�   2   $��	Equipmets��6<   $��	20,10,0,0q�6M   $��15(�6`   $
��Bold"�6n   �� 5�   2   $��20,0,0,0q�6?   $
��Left=�6t   $��3��6�   $��9��6�   $	��Top=�6�   ��6Q   �� *
Equipments+��5�   6   �� 5�   :   .R�5�   >   � $��10,2,0,0q�6C   .+�5�   B   �� ���	#FF5E727C$��0,1,0,0q�6a   $
��Left=�6{   $��0q�5�      $��Center=�6   ._�5�   F   �� $��0q�6Q   .+�5�   J   � $��0,5,0,0q�6O   .+�5�   N   �� $ 
Horizontal=�6Y   .+�5�   R   �� $
��Wrap=�6\   $��12(�6p   ���	#FF333B42$
 2,0,0,0q�6�   $��0q�5�   )   $
 Left=�64   $
��Bold"�6I   $
��Left=�6\   ��5�   )   �� *name+�� 5�   R   $��10,0,0,0q�6]   $ 
Horizontal=�6o   .+�5�   V   �� ��6`   �� *make+�� 5�   V   $	�� - ��6`   �� 5�   V   ��6`   �� *model+5�   S   5�   O   5�   K   5�   G   5�   C   5�   ?   5�   ;   5�   3   �� 5�   6   $��	Employees��6@   $��	20,10,0,0q�6Q   $��15(�6d   $
��Bold"�6r   �� 5�   6   $��20,0,0,0q�6C   $
��Left=�6w   $��3��6�   $��9��6�   $	��Top=�6�   ��6U   �� *	Employees+��5�   :   �� 5�   >   .R�5�   B   � $��10,2,0,0q�6G   .+�5�   F   �� ���	#FF5E727C$��0,1,0,0q�6e   $
��Left=�6   $��0q�5�      $��Center=�6   ._�5�   J   �� $��0q�6U   .+�5�   N   � $��0,5,0,0q�6S   .+�5�   R   �� $ 
Horizontal=�6]   .+�5�   V   �� $
��Wrap=�6`   $��12(�6t   ���	#FF333B42$
 2,0,0,0q�6�   $��0q�5�   )   $
 Left=�64   $
��Bold"�6I   $
��Left=�6\   ��5�   )   �� *
first_name+�� 5�   V   $�� ��6`   �� 5�   V   ��6`   �� *	last_name+5�   S   5�   O   5�   K   5�   G   5�   C   5�   ?   5�   7   �� 5�   6   $��Products��6@   $��	20,10,0,0q�6P   $��15(�6c   $
��Bold"�6q   �� 5�   6   $��20,0,0,0q�6C   $
��Left=�6v   $��3��6�   $��9��6�   $	��Top=�6�   ��6U   �� *
Products+��5�   :   �� 5�   >   .R�5�   B   � $��10,2,0,0q�6G   .+�5�   F   �� ���	#FF5E727C$��0,1,0,0q�6e   $
��Left=�6   $��0q�5�      $��Center=�6   ._�5�   J   �� $��0q�6U   .+�5�   N   � $��0,5,0,0q�6S   .+�5�   R   �� $ 
Horizontal=�6]   .+�5�   V   �� $
��Wrap=�6`   $��12(�6t   ���	#FF333B42$
 2,0,0,0q�6�   $��0q�5�   )   $
 Left=�64   $
��Bold"�6I   $
��Left=�6\   ��5�   )   �� *name+�� 5�   V   $��10,0,0,0q�6a   $ 
Horizontal=�6s   .+�5�   Z   �� ��6d   �� *
quantity+�� 5�   Z   $	�� - ��6d   �� 5�   Z   ��6d   �� *price_per_item+�� 5�   Z   $��$��6d   5�   W   5�   S   5�   O   5�   K   5�   G   5�   C   5�   ?   5�   7   5�   3   5�   +   5�   '   5�   #   5�      5�      5�      5�      5�      5      5     5     