   M S B A M L   `   `   `  ����  MuzCoWPF    MuzCoWPF.Views.Pizzeria   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      �� ���#F0F0F0  �� CornerRadius$  30��5	      
�������$��1q�5       J� SnapsToDevicePixels$
 True��5      ._�5   
   � .+�5      �� $��0,20,0,0q�6    �� Orientation$ 
Horizontal=�6+   $	��Top=�6D   $	��990��6\   .+�5      �� $��/Image/logoMuzCo.png��6   $��60��66   $��60��6A   $��0,0,20,0q�6M   5      �� 5      $	��Top=�6   $ 
Horizontal=�61   $��Center=�6J   $��0,35,0,0q�6g   .+�5      �� $ 
Horizontal=�6   $��Center=�66   $��Center=�6Q   .+�5      �� $ 
Horizontal=�6!   $��Center=�6:   $��Center=�6U   .+�5      �� $
��📍��6$   $��Center=�6.   ���	#00000000 J� OpacityMask
 �  ��
���  ��6r   �� 5      $	��120��5      $��10q�5      $
��Left=�5      
������ ��5   #   �� *Cities+ �� SelectedItem 5      �� *SelectedCity+��5      �� 5   "    �� EndPoint$	 0,1&�66   .��5   &   �  � Color$ 	#FFF0F0F0��63   � 5   &   $ 	#00E5E5E5��63    � Offset$ 1Q�6E   5    #   5"      5#      5$      5%      �� 5(      $ 
Horizontal=�6   $	��Top=�62   $��Right=�6J   $��	0,35,45,0q�6f   .+�5)      �� $��32��6   $��32��6$    � ToolTip$ 
Кошик��60      IconButtonStyle#��[  6@   ��6i   �� *OpenCartCommand+.��5*      �� .+�5+      �� $
��🛒��6$   $��16(�6.   �� 5,      $��10(�6$   
���  ��$��Right=�6C   5-      5.      �� 50      #��[  6@   $��32��6i   $��32��6t   $ Профiль��6�   ��6   �� *GoToProfileCommand+.��51      �� $
��👤��6    $��16(�6*   52      53      �� 55      $��0,80,0,0q�6   $  20��6'   $��50��6:   $	��Top=�6F   ���#FFF$��Center=�6p   ._�56      �� $ 
Horizontal=�6   $��Center=�66   $��Center=�6S   .+�58      	� $��Піца��6"   $��Pizza��5:        BtnStyle#��[ 5;      	 d� 	IsChecked$
	 TrueY�5<      ��59      �� *SetCategoryCommand+5<      	� 5>      $��
Соуси��6"   $��Sauce��5@      #��[ 5A      ��5?      �� *SetCategoryCommand+5A      	� 5C      $��
Напої��6"   $��Drink��5E      #��[ 5F      ��5D      �� *SetCategoryCommand+5F      5H      5I      �� 5L      $��30,150,30,20q�6   .��5M      �� 
������ ��6   �� *FilteredProducts+��5N      �� 5O      .R�5P      � 
 � Orientation$
 
Horizontal=�6(   $��Center=�6A   5Q      ��5S      �� 5T      .R�5U      �� 
�������$  20��68   $��10q�6J   $	��220��6V    �� Padding$ 10q�6b   ._�5V   "   �� .+�5X   &   � .+�5Y   *   �� ��60   �� *Image+5[   '   � 5^   &   .+�5_   *   �� $��16(�6J   $��SemiBold"�6X   ��64   �� *Name+6X   �� 5`   *   $��14(�5a   0   
�������$��Right=�6P   ��5`   4   �� *Price+ �� StringFormat$ {0}₴��5a   P   5b   '   �� 5g   &   $��32��6-   $��32��68   ���#FD573E
������ $��0,10,0,0q�5h   8   $, &Додати до замовлення��5i   	   ��5j   	   �� *DataContext.AddToCartCommand+ �� RelativeSource ��  �� AncestorType UserControl��5k      �� .��5l   *   �� $	��➤��64   $��16(�6=   
�������6K   5m   '   5n   #   5o      5p      5r      5s      5t      5u      5v      