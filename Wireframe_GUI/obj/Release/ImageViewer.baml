   M S B A M L   `   `   `  ����   Wireframe_GUI    Wireframe_GUI.ImageViewer   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  ImageViewer��$	��750��$	��750�� � 	Resources    thumbTemplate ��Name � Cursor ��Name �� Path �� RelativeSource��%�   &	        �� .R��� $ thumbBtn��
�������$��1q�
������ $
 Hand��$��10q�.���� $ thumbImg������ $	 Tag� �� *TemplatedParent+.���  � ColumnDefinitions �� $��5* ��� $	��90* ��� $��5* � � RowDefinitions �� $	��80* ��� $	��20* �   changeImgStyle	 �� 
TargetType
 �� Property �� Value �� 
TargetType ��Name ��Name �� Triggers P� Property P� Value��%u  &	       �� "	 ��.��� 
 � ��$ 60(��� 
 � ��$
 Bold"��� 
 �@�Cursor$
 Hand���� 
 �@J�Opacity$	 .25Q��� 
 � ��
 ���� �� 
 � ��
 ���� �� 
 � ��
 ������� 
 � �� �� " ��.R��� $ Border��._��� $ ContentSite��$��Center=�$��Center=� P�  �@J�IsMouseOver . . ��� 
 �@J�Opacity$	 .75Q�.+��� -   $ currentImage��$��0��$��3��$��5q��� -   $ leftChangeBtn��$��0��$��<��#��[ �� -   $ rightChangeBtn��$��2��$��>��#��[ �� $��1��$��3��$	��Top=��� $��1��$��3��$��Disabled=�$
��Auto=�.���� 
���   �._��� -    ��Name$ 
thumbsList�� �� Orientation$ 
Horizontal=�