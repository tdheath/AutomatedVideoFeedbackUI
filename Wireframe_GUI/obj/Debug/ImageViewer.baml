   M S B A M L   `   `   `  ����  Wireframe_GUI    Wireframe_GUI.ImageViewer   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  ImageViewer��5   	   $	��750��6   $	��750��6*    � 	Resources 5         thumbTemplate ��Name � Cursor ��Name �� Path �� RelativeSource��%�   &	        �� 5   
   .R�5      �� $ thumbBtn��6   
�������$��1q�6>   
������ $
 Hand��6k   $��10q�6y   .��5	      �� $ thumbImg��6   ��6*   �� $	 Tag� �� *TemplatedParent+5
      5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��5* �6   �� 5      $	��90* �6   �� 5      $��5* �6    � RowDefinitions 5   
   �� 5      $	��80* �6   �� 5      $	��20* �6    5   
     changeImgStyle	 �� 
TargetType
 �� Property �� Value �� 
TargetType ��Name ��Name �� Triggers P� Property P� Value��%x  &	       �� 5      "	 ��6+   .�5      �� 
 � ��$ 60(�6-   �� 5      
 � ��$
 Bold"�6/   �� 5      
 �@�Cursor$
 Hand��6+   �� 5      
 �@J�Opacity$	 .25Q�6,   �� 5      
 � ��
 ���� 6/   �� 5      
 � ��
 ���� 60   �� 5      
 � ��
 �����6/   �� 5       
 � �� 5!      �� 5"      " ��6*   .R�5#      �� $ Border��6%   ._�5$   "   �� $ ContentSite��63   $��Center=�6H   $��Center=�6e   5%       5&      P� 5'   "    �@J�IsMouseOver . . �5(   &   �� 
 �@J�Opacity$	 .75Q�6@   5)   #   5+      5-      5.      51      .+�52   
   �� -   5        $ currentImage��52      $��0��6&   $��3��66   $��5q�6J   �� 53   
   -   5        $ leftChangeBtn��53      $��0��6(   $��<��68   #��[ 6H   6p   �� 54   
   -   5        $ rightChangeBtn��54      $��2��6)   $��>��69   #��[ 6H   6p   �� 56   
   $��1��6   $��3��6!   $	��Top=�65   �� 57   
   $��1��6   $��3��6$   $��Disabled=�68   $
��Auto=�6_   .��58      �� 
���   �._�59      �� -   5         ��Name$ 
thumbsList��59       �� Orientation$ 
Horizontal=�62   5:      5;      5<      5=      