   M S B A M L   `   `   `  ����F  BOpenWeather, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:OpenWeather.ViewModelOpenWeather.ViewModel  5      ;"clr-namespace:OpenWeather.BehaviorOpenWeather.Behavior  5          OpenWeather.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      2vm#clr-namespace:OpenWeather.ViewModel     5      2bvr"clr-namespace:OpenWeather.Behavior     5      U QMahApps.Metro, Version=0.10.0.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f;Controls,http://metro.mahapps.com/winfx/xaml/controls  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5	      ���	#FFF9F9F9  � 	Resources  5       �� MergedDictionaries �� Source   ForecastDataTemplate �� Orientation �� Padding �� TextAlignment�� 5   
    5      �� 5      $H Bpack://application:,,,/MahApps.Metro;component/Styles/Colours.xaml?�6%   �� 5      $F @pack://application:,,,/MahApps.Metro;component/Styles/Fonts.xaml?�6%   �� 5      $I Cpack://application:,,,/MahApps.Metro;component/Styles/Controls.xaml?�6%   �� 5      $M Gpack://application:,,,/MahApps.Metro;component/Styles/Accents/Blue.xaml?�6%   �� 5      $R Lpack://application:,,,/MahApps.Metro;component/Styles/Accents/BaseLight.xaml?�6%   %�	  &	        �� 5      .R�5      � $��0,2,0,0q�6   $	��100��6(   .+�5      �� ���	#FF5E727C$��0,1,0,0q�65   $��Center=�6O   $	��100��6l   $��0q�5      $��Center=�6   $	��265��6-   ._�5      �� $��0q�6%   .+�5      � $��24��6#   $��0,5,0,0q�6/   .+�5   "   �� $ 
Horizontal=�6-   .+�5   &   �� $
��Wrap=�60   $��12(�6D   ���	#FF333B42$ 2,0,0,0q�6i   $
��72.5��6{   $��0q�5   )   $ Center=�64   $
��Bold"�6K   $
��Left=�6^   ��5   )   �� *
WeatherDay+�� 5    &   $
��Wrap=�60   $��12(�6D   ���	#FF292929$ 0q�6i   $��
47.5,0,0,0q�6u   $
 Left=�5!   )   $��Normal"�6>   $��Segoe UI Semibold)�6S   ��5"   )   �� *Time+5#   #   5$      � 5%      $
��67.5��6#   .+�5&   "   �� $��0q�6-   $ 
Horizontal=�68   $
��Left=�6Q   .+�5'   &   �� $
��Left=�6,   $
��71.5��6G   ��6T   �� *WeatherIcon+�� 5(   &   $
��Left=�60   $
��51.5��6K   $
��Wrap=�6Y   $	��Top=�6m   $
��83.5��5)   )   $��Segoe UI)�66   $��24(�6L   $ Center=�6Z   $ 0,5,0,0q�5*   )   ���	#FFA47D14��6S   �� *Temperature+5+   #   �� 5,   "   $��
0,26,0,3.5q�6-   $ 
Horizontal=�6A   $��Right=�6Z   $	��115��6v   .+�5-   &   �� $
��Wrap=�60   $��Wind:��6D   $��Segoe UI Semibold)�6Q   $��14(�6p   ���	#FF056C9C$ Center=�5.   @   $
��49.5��6W   �� 5/   &   $
��Wrap=�60   $��Segoe UI Semibold)�6D   $��14(�6c   ���	#FF9B8C5E$ 0q�50   @   $��76.666��6L   ��6[   �� *	WindSpeed+51   #   �� 52   "   $��20,46,0,3.5q�6-   $ 
Horizontal=�6B   $��Right=�6[   $	��115��6w   .+�53   &   �� $
��Wrap=�60   $��
Humidity: ��6D   $��Segoe UI Semibold)�6V   $��14(�6u   ���	#FF056C9C$ Center=�54   @   $
��65.5��6W   �� 55   &   $
��Wrap=�60   $��Segoe UI Semibold)�6D   $��14(�6c   ���	#FF9B8C5E$ 0q�56   @   $��76.666��6L   ��6[   �� *
Humidity+57   #   �� 58   "   $��0,4,0,25q�6-   $ 
Horizontal=�6?   $��Right=�6X   $	��120��6t   .+�59   &   �� $��22��60   $
��Wrap=�6<   $	��Top=�6P   $��65��6h   $��Segoe UI Semibold)�5:   )   $��14(�6H   ���	#FF333B42$
��Left=�5;   )   $ 0q�6D   $ Center=�6P   ��5<   )   �� *MaxTemperature+�� 5=   &   $
��Wrap=�60   $��Segoe UI Semibold)�6D   $��14(�6c   ���	#FF6F7C87$��0q�5>   @   $ 0q�6K   $��67��6W   ��5?   )   �� *MinTemperature+5@   #   5A      5B      5C      5D      5E      5F       � DataContext 5H      /  )OpenWeather.ViewModel.MainWindowViewModel  5I   
   .��5K      �  +� FocusedElement 6   ��  �� ElementName$ LocationTextBox��.+�5L   
   �� -   5        	 ��Name$	 LocationTextBox��5L      $��25��6+   $	��270��67   
�������$	��Top=�5M      $��0,5,0,0q�6%   $��Center=�66   
 �� SelectionBrush
 �	#FFB21212*  $MahApps.Metro.Controls.TextboxHelper   	Watermark$" Enter location & press ENTER��5N      ��5O      �� *
Location+ �� UpdateSourceTrigger$ PropertyChanged=�.��6L   .  (System.Windows.Interactivity.Interaction   	Behaviors 5P      ?   9OpenWeather.Behavior.SelectAllTextOnEnterKeyPressBehavior  5Q      .��5R   '    J� InputBindings 5S      �� 5T      
 �� Key$ Enter��6@    �� Command 6   �� *WeatherCommand+6@   .��5U   %   5V      �� 5X   
   $��0,18,0,0q�6   $ 
Horizontal=�6'   $��Center=�6@   $	��Top=�5Y      .+�5Z      �� -   5         ��Name$ CurrentWeatherImage��5Z      $��95��61   $	��Top=�6=   $	��137��6U   $��4,0,0,0q�6a   ��5[      �� *CurrentWeather.WeatherIcon+�� 5\      -   5         ��Name$ CurrentWeatherTemperature��5\      $��Right=�6;   $��95��6W   $
��Wrap=�5]      $	��Top=�6%   $	��143��6=   $��45.333(�6I   ���	#FF1D1C13$ Center=�5^   (   $ 5,15,0,0q�6?   $��Segoe UI)�6R   ��5_      �� *CurrentWeather.Temperature+5`      �� 5a   
   -   5        $ CurrentWeatherTextBlock��5a      $��Center=�65   $��25��6R   $��7.5,114,7.5,0q�5b      $
��Wrap=�6$   $	��Top=�68   $	��274��6P   $��14.667(�5c      ���	#FF6A0505$��Segoe UI Semibold)�66   $ 0q�6U   $ Center=�5d      ��6$   �� *CurrentWeather.Weather+�� 5e   
   -   5         ��Name$ CurrentWeatherStackPanel��5e      $��16,132,14,0q�67   $ 
Horizontal=�6L   $	��Top=�6e   .+�5f      �� -   5        $ MaxTempTextBlock��5f      $��22��62   $
��Wrap=�6>   $	��Top=�6R   $��65��5g      $��Segoe UI Semibold)�6   $��14.667(�6;   ���	#FF333B42$
��Left=�5h      $ 0q�6,   $ Center=�68   ��5i      �� *CurrentWeather.MaxTemperature+�� 5j      $
��Left=�6   $��22��60   $	��Top=�6<   $��67��6T   $	��1,0q�5k      ���	#FF5E727C._�5l      �� -   5        $ MinTempTextBlock��5l      $
��Wrap=�66   $��Segoe UI Semibold)�6J   $��14.667(�5m      ���	#FF627380$��0,0,-1,0q�6>   $ 0q�6P   $ Center=�6\   ��5n      �� *CurrentWeather.MinTemperature+5o      �� 5p      $ Vertical=�6   .+�5q      �� $ 
Horizontal=�6   .+�5r      �� $
��Wrap=�6   $��Wind:��6,   $��Segoe UI Semibold)�69   $��14.667(�6X   ���	#FF333B42$
��54.5��5s   (   $ Right=�65   �� 5t      $
��Wrap=�6   $��Segoe UI Semibold)�6,   $��14.667(�6K   ���	#FF9B8C5E$��79.999��5u   (   $ 7,0,0,0q�67   ��5v      �� *CurrentWeather.WindSpeed+5w      �� 5x      $ 
Horizontal=�6   $��15,0,0,0q�62   .+�5y      �� $
��Wrap=�6   $��	Humidity:��60   $��Segoe UI Semibold)�6A   $��14.667(�6`   ���	#FF333B42$
��65.5��5z   (   $ Right=�65   �� 5{      $
��Wrap=�6   $��Segoe UI Semibold)�60   $��14.667(�6O   ���	#FF9B8C5E$��77.999��5|   (   $ 7,0,0,0q�67   ��5}      �� *CurrentWeather.Humidity+5~      5      5�      �� 5�   
   -   5         ��Name$ listForcast��5�      $��16,172,14,0q�6-   .��5�      �� $��Center=�6   $	��Top=�69   #���   5�   2   ��6   �� *
Forecast+62   5�      5�      5�      