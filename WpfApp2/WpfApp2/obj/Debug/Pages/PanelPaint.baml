   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WpfApp2.PagesWpfApp2.Pages  5          WpfApp2.Pages.PanelPaint   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:WpfApp2.Pages     5        � 	Resources  5	         MenuOpen �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  	MenuClose��%�  &	        &	 �     �� 5
   
   .��5      U� $ (FrameworkElement.Height)�6,   $ NameList��6b   .\�5        $ 0��6'   $ 0Q�63     5      $ 0:0:0.5��6'   $	 150Q�69   5      5      �� 5   
   .��5      U� $ (FrameworkElement.Height)�6,   $ NameList��6b   .\�5        $ 0��6'   $	 150Q�63     5      $ 0:0:0.5��6'   $ 0Q�69   5      5      5       � Triggers 5      :� 5   
    :� RoutedEvent$ ButtonBase.Click��6    :� 
SourceName$ ButtonOpenMenu��66   .[�5      �� #��[  6   6G   5      :� 5   
   $ ButtonBase.Click��6   $ ButtonCloseMenu��66   .[�5      �� #��[ 6   6H   5      .��5      �  � RowDefinitions 5    
   �� 5!      $��30 �6   �� 5"      .+�5$   
   �� -   5        $��ButtonCloseMenu��5$      $y�	Collapsed=�6E   
�������
����  �$��Right=�6�   $��80��6�   ��6(   �� *
NameMess+6�   �� 5%   
   -   5        $��ButtonOpenMenu��5%      
�������
����  �$��80��6i   $��Right=�6�   ��6'   �� *
NameMess+6�   � 5'   
   -   5        	 �Name$	 NameList��5'      $��2��6"   $��0��63   $	��100��6>   $
��0 50q�6J   $	��Top=�6X   $��Right=�6p    5(      �� 5)      6"   �� 5*      $��25 �6    6.   .+�5,      �� ��6   �� *Registrations+
 �� SelectedItem
 6=   �� *SelectedName+��5-      �� 5.      .R�5/      �� .+�50      �� ��6(   �� *Name+51      52      54      � 55      $��1��6   .+�56      �� $��Добавить��6   ��6,   �� *
AddCommand+57      58      59      5:      