   M S B A M L   `   `   `  ����N  JChildrensCreativity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ChildrensCreativityChildrensCreativity  5   	   "    ChildrensCreativity.Products   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:ChildrensCreativity     5   	     � Title$  
MainWindow��5   	   $	��800��6   $
��1000��6)    � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��* �6   .+�5   
   ]� $��0��5      
�������.+�5      �� -   5         ��Name$ buttonOrderBin��5      $��Корзина��5      $��15(�5      $
��Bold"�5      $	��100��5      $��0 0 10 0q�5      
�������$��Right=�5      5      5!      ]� 5#   
   $��1��5$      .+�5&      �� -   5         ��Name$ listProducts��5'      $��Disabled=�5(       � ContextMenu 5*      �� 5+      .@�5,      m� -   5        $(��"Добавить в коризну��5-      5.      5/      ��52      �� 53      .R�54      �  � Orientation$ 
Horizontal=�55      $��Center=�56      57      ��5:      �� 5;      .R�5<      �� $��20q�6%   .+�5=      �� $��Наименование��5>   !   $��15(�5?   !   $
��Bold"�5@   !   �� 5A       ��Name$ product_name��5B   !   $��15(�5D   !   ��5C   !   �� *product_name+5D   !   �� 5E      $��Описание��5F   !   $��15(�5G   !   $
��Bold"�5H   !   �� 5I      $ product_desc��5J   !   $��15(�5L   !   ��5K   !   �� *product_desc+5L   !   �� 5M      $ ��Производитель��5N   !   $��15(�5O   !   $
��Bold"�5P   !   �� 5Q      $ producer_name��5R   !   $��15(�5T   !   ��5S   !   �� *producers.producer_name+5T   !   �� 5U      $	��100��5V   !   $	��100��5W   !   ��5X   "   �� 5Y   &    �� Path$ product_photo�6.   	 �� TargetNullValue	 5Z   *   ��5[   .   Resources/no-image.png��6R   5]   '   5_      �� 5`      $��Стоимость��5a   !   $��15(�5b   !   $
��Bold"�5c   !   �� 5d      $ product_price��5e   !   $��15(�5g   !   ��5f   !   �� *product_price+5g   !   �� 5h      $��Скидка��5i   !   $��15(�5j   !   $
��Bold"�5k   !   �� 5l      $ product_discount��5m   !   $��15(�5o   !   ��5n   !   �� *product_discount+
 �� StringFormat$

 {0}%��5o   !   5p      5q      5t      5x      5z      5{      