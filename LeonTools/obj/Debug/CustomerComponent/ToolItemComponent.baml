   M S B A M L   `   `   `  ����D  @LeonTools, Version=1.0.0.4, Culture=neutral, PublicKeyToken=null9!clr-namespace:LeonTools.ConverterLeonTools.Converter  5      I)clr-namespace:LeonTools.CustomerComponentLeonTools.CustomerComponent  5      3    -LeonTools.CustomerComponent.ToolItemComponent   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local2!clr-namespace:LeonTools.Converter     5      ;local)clr-namespace:LeonTools.CustomerComponent     5      -   5        $��78��5      $	��110��5	      $��0,10,0,0q�5
      $
��5,10q�5      $��1,0,0,0q�5        � 	Resources  5      2   ,LeonTools.Converter.ByteListToImageConverter   IconConverter  ToolItemStyle �� 
TargetType �� Triggers ]� 
Conditions �� Property �� Value �� Property �� Value��%`  &	        &	        5   
   6*   �� 5   
   " ��6&    5      ]� 5       5      �� 5       �@J�IsMouseOver . 6;   /�5      �� 5       � �� �#eee67   5      ]� 5       5      �� 5       �@J�IsMouseOver .  6;   /�5!      �� 5$       � ��
 ���� 67   5'      5)      5*       � ContextMenu 5+      �� 5,   
   .@�5-      m� -   5        $��删除��5-      6#   5.      .��50      �� #��[ 6   	 � ToolTip	 64   �� *
FileName+ 51   
   �� 52      .@�53      m� -   5        $��删除��53      6'   54      ._�56   
   �� -   5        $��
ItemBorder��56   6   $��5q�6   $��3,0,0,0q�6    57      �� 58      .@�59      m� -   5        $��删除��59      6+   5:      
 J� Effect
 5<      3  -System.Windows.Media.Effects.DropShadowEffect  5=         Color$
 Gray��6#      Opacity$	 0.2Q�60   ._�5?      �  � RowDefinitions 5@      �� 5A      $��48 �6$   �� 5B      .+�5D      �� $��48��6   $��48��6&   $��Center=�62   $��Center=�6O    5E      �� 5F      .@�5G      m� -   5        $��管理员权限运行��5G   '   68   m� 5H      -   5        $��删除��5H   '   63   5I      ��5K      �� 5L       �� ImageSource 6%   �� *Icon+ �� 	Converter# [  5N      �� 5O      $��1��6   $��Center=�6@   $��Center=�6]    �� TextAlignment$ Center=�6x   $
��Wrap=�6�   ��6*   �� *Name+ 5P      �� 5Q      .@�5R      m� -   5        $��删除��5R   '   63   5S      5U      5V      5W      5X      5Y      