   M S B A M L   `   `   `  ����C  ?MuzCoWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MuzCoWPF.ViewsMuzCoWPF.Views  5      7 clr-namespace:MuzCoWPF.ViewModelMuzCoWPF.ViewModel  5      !    MuzCoWPF.Views.CustomerPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:MuzCoWPF.Views     5      /vm clr-namespace:MuzCoWPF.ViewModel     5      $	��650��5	   4   .��5      �   � RowDefinitions  5   
   �� 5      �� 5      $��0* �6    � ColumnDefinitions 5   
   �� 5      $��1004* �6   �� 5      $	��47* �6    J� Clip 5   
   �� 5       �� Rect$ 0,0,1050,650�6     �� RadiusX$ 30Q�64    �� RadiusY$ 30Q�6A   .+�5   
   �� $"��/Image/BackgroundProfile.png��6   $
��Fill=�5       K� ZIndex$ 0��5      $
}�True��5      $��2��6    � 5    
   $��2��6    5!      �� 5"      $��* �6#   �� 5#      $
��Auto �6#   .+�5'      �� $��225,0,525,0q�6@   $	��300��6U   $��Center=�6a   ��6   �� *CurrentSubView+ � 	Resources 5(       �� DataType"   MuzCoWPF.ViewModel.ProfileVM    MuzCoWPF.Views.ProfilePage'   !MuzCoWPF.ViewModel.OrderHistoryVM!   MuzCoWPF.Views.HistoryOrder#   MuzCoWPF.ViewModel.FeedbackVM!   MuzCoWPF.Views.FeedbackPage��%�   (��       5)   #   *, +)(�� 2     5.   #   *, +)(�� d     55   #   *, +)�� 5)      "  6#   .R�5*        5+      �� 5.      "  6#   .R�5/        50      �� 55      "  6#   .R�56        57      58      59      �� 5=      $
��Left=�5>      $��Center=�5?      $��	606,0,0,0q�5@      $	��324��5A      $	��294��6%   .+�5D      �� $��Профіль��6   $��50��5E      $��16(�5F      $��SemiBold"�5G      ���	#E58F8F8F
�������
������ $��0q�5K      	 � Cursor$
	 Hand��5L      $��0,0,0,10q�5N      $��Center=�6+   $	��229��6H   ��5M      �� *ProfileCommand+5N   H   �� 5Q      -   5        
 ��Name$
 GetOrderHistory��5Q      $'��!Історія замовлень��62   $��50��5R      $��16(�5S      $��SemiBold"�5T      ���	#E58F8F8F
�������
������ $��0q�5X      $
	 Hand��5Y      $��0,0,0,10q�5[      $��Center=�6+   $	��232��6H   ��5Z      �� *ShowOrdersCommand+5[   H   �� 5_      $��Відгуки��6   $��50��5`      $��16(�5a      $��SemiBold"�5b      ���	#E58F8F8F
�������
������ $��0q�5f      $
	 Hand��5h      $��Center=�6'   $	��229��6D   ��5g      �� *ShowFeedbackCommand+ �� Mode$ OneWay=�5h   D   �� 5j      $��На Головну��6   $��50��5l      $��16(�5m      $��SemiBold"�5n      ���	#E58F8F8F
�������
������ $��0q�5r      $
	 Hand��5s      $	��228��5t      $��0,10,0,0q�6%   ��5k      �� *PizzeriaCommand+5t   %   �� 5v      $��
Вийти��6   $��50��5x   	   $��16(�5y   	   $��SemiBold"�5z   	   ���	#FFB23B3B
�������
������ $��0q�5~   	   $
	 Hand��5   	   $	��228��5�   	   $��0,10,0,0q�6   ��5w   	   �� *LogoutCommand+5�      5�      5�      5�      5�      