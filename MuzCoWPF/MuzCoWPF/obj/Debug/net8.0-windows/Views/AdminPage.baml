   M S B A M L   `   `   `  ����C  ?MuzCoWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MuzCoWPF.ViewsMuzCoWPF.Views  5      7 clr-namespace:MuzCoWPF.ViewModelMuzCoWPF.ViewModel  69       MuzCoWPF.Views.AdminPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:MuzCoWPF.Views     5      /vm clr-namespace:MuzCoWPF.ViewModel     69   .��5	      �   J� Clip  5   
   �� 5       �� Rect$ 0,0,1050,650�6     �� RadiusX$ 30Q�64    �� RadiusY$ 30Q�6A   .+�5   
   �� $"��/Image/BackgroundProfile.png��6   $
��Fill=�5       K� ZIndex$ 0��5      � 5   
   $��60q�6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��Auto �6#   .+�5      �� $	��400��6B   $��Center=�6O   ��6   �� *CurrentAdminView+ � 	Resources 5       �� DataType'   !MuzCoWPF.ViewModel.ProfileAdminVM%   MuzCoWPF.Views.ProfileAdminPage#   MuzCoWPF.ViewModel.AddPizzaVM   MuzCoWPF.Views.AddPizza'   !MuzCoWPF.ViewModel.ManageOrdersVM!   MuzCoWPF.Views.ManageOrders��%�   (��       5   #   *, +)(�� 2     5   #   *, +)(�� d     5#   #   *, +)�� 5      "  6#   .R�5        5      �� 5      "  6#   .R�5         5!      �� 5#      "  6#   .R�5$        5%      5,      5-      �� 51      $��1��6   $��Right=�52      $��Center=�53      $��60,0,0,0q�54      $	��250��55      .+�57      �� $��Профіль��6   $��50��58      $��16(�59      $��SemiBold"�5;      ���	#E58F8F8F
�������
������ $��0q�5?       � Cursor$
 Hand��5@      $��0,0,0,10q�5A      ��5:   
   �� *ProfileCommand+5A      �� 5D      $B��<Видалити замовлення користувача��6   $��50��5E      $��16(�5F      $��SemiBold"�5H      ���	#E58F8F8F
�������
������ $��0q�5L      $
 Hand��5M      $��0,0,0,10q�5N      ��5G      �� *ShowOrdersCommand+5N      �� 5Q      $$��Додати нову піцу��6   $��50��5R      $��16(�5S      $��SemiBold"�5T      ���	#E58F8F8F
�������
������ $��0q�5Y      $
 Hand��5Z      $��0,0,0,10q�5[      ��5W      �� *ShowAddPizzaCommand+5[      �� 5^      $��На Головну��6   $��50��5`      $��16(�5a      $��SemiBold"�5b      ���	#E58F8F8F
�������
������ $��0q�5f      $
 Hand��5g      $	��228��5h      $��0,10,0,0q�6   ��5_      �� *PizzeriaCommand+5h      5j      5k      5l      5m      