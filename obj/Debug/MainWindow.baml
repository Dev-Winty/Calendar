   M S B A M L   `   `   `  ����C  ?Calendar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:CalendarCalendar  5   	       Calendar.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Calendar     5   	   -   5          � Title$  
MainWindow��5   	   $	��600��6   $
��1000��6)    � 
ResizeMode$ NoResize=�66    � AllowsTransparency .  � WindowStyle$
 None=�6f   ��5	      �� 5
   
    �� Opacity$	 0.3Q�6    �� Color$ Silver��6(   .��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��* �6   .+�5   
   �� 
������� J� Opacity$	 0.6Q�6)    �� Orientation$ 
Horizontal=�67   $��RightToLeft=�6P   .+�5      �� -   5        $��25��5      $��25��6    $��
5, 0, 0, 0q�6,   
���  ��$	 0.7Q�6Q   	 � ToolTip$	 종료��6u   6�   �� 5      -   5        $��25��5      $��25��6    $
��5, 0q�6,   
��� � �$	 0.7Q�6M   $	 	최소화��6u   6�   o� 5      $��40��6   $��25��6   $	 0.7Q�6*   .@�5      m� $��_매뉴��6   .@�5      m� -   5        $��_일정 변경��5      6/   m� 5      -   5        $%��_로그아웃 및 계정 변경��5      66   5      5      5      � 5   
   -   5        $��gridMain��5      $��1��6   $��20q�6,   
 � ColumnDefinitions
 5      �� 5      $��* �6#   �� 5      $��* �6#   �� 5      $��* �6#   �� 5       $��* �6#   �� 5!      $��* �6#   �� 5"      $��* �6#   �� 5#      $��* �6#    5%      �� 5&      $��* �6    �� 5'      $��* �6    �� 5(      $��* �6    �� 5)      $��* �6    �� 5*      $��* �6    5,      5-      5.      