   M S B A M L   `   `   `  ����   Wireframe_GUI    Wireframe_GUI.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$  	WIREFRAME��$	��750��$
��1250��.��� -    �Name$ mainGrid�� � ColumnDefinitions �� $	��15* ��� $	��25* ��� $	��15* ��� $	��15* ��� $	��15* ��� $	��15* � � RowDefinitions �� $��3* ��� $��9* ��� $	��88* � � 	Resources    tabTemplate �� 
TargetType  screenTemplate �� DataType ��Name � Cursor
	 � Tag
 ��Name  RoundedButtonStyle �� 
TargetType �� Property �� Value ��Name �� CornerRadius �� Padding �� Triggers P� Property P� Value �� 
TargetName  textColStyle  textEditColStyle  textEditElementStyle  tabStyle ��Name��%w  &	        &	 ,     &	 �     &	 �    &	 F    &	 �    &	 �    �� " ��.R��� ���#4472c4
��������� $ Image��.R��� $ 	screenBtn��-   $��5px,10pxq�
������ 
������ $
 Hand��	 �� *	videoPath+.���� $
 	screenImg������ *
screenPath+�� " ��.���  � ��
 �������  � �� �� " ��.R��� $ Border��$ 5��#��z��$��1q�$
 20,5q�
���   �._��� $��Center=�$��Center=� P�  � �� . . ��� $ Border�� � ��$ 2q��� $ Border�� � ��
 ���� �� " ��.���  � ��$ Center=���  � ��$ Center=���  � ��$
 Wrap=���  � ��$ 18(��� " ��.���  � ��$ Stretch=���  � ��$ Stretch=���  � ��$
 Wrap=���  � ��$
 10pxq���  � ��
 ������� " ��.���  � ��$ Stretch=���  � ��$ Stretch=���  �@��TextWrapping$
 Wrap=���  �@��AcceptsReturn . ��  � ��$	 2pxq���  � ��
 ���� ��  � ��$
 Auto����  � ��$
 Auto����  � ��$
 10pxq��� " ��.���  � ��$ 18(���  � ��$
 Bold"���  �@�Cursor$
 Hand����  � �� �� " ��.R��� $ Border��$ 	10,0,10,0q�._��� $ ContentSite��$��Header�� P�  �@��
IsSelected . . ��� $ ContentSite�� � ��
 ������� $ Border�� � �� �#4472c4�� $ Border�� � ��
 ���� .+�]� $��6��
������ .+�o� $	��Top=�.@�m� $
��File��.@�m� -   $��Set Source Directory���� m� $��_Exit���� -    ��Name$ prefixCombo��$��1��$
��Left=�$��Center=� �� Text$ Select�� �� 
IsEditable .  �� 
IsReadOnly . |�.  $��25,5,5,5q�$	��100���� -   $ playVideoBtn��$��1��$��3��$��Play Full Video��#���  ���#d9d9d9$��	15px,15pxq��� $��4��$��1��.+��� -   $ showGraphBtn��$��1��$��3��$��Show Video Graphs��#���  ���#d9d9d9$	��5,2q��� -   $ showCompGraphBtn��$��1��$��4��$��Show Compare Graphs��#���  ���#d9d9d9$	��5,2q��� $��5��$��1��.+��� -	   $ saveBtn��$��1��$��5��$��Save Notes and Comments��#���  ���#d9d9d9$	��5,2q��� -
   $ 	exportBtn��$��1��$��5��$��Export Video Clips��#���  ���#d9d9d9$	��5,2q�]� $��2��$��0��$��6��$��10q�.+��� -    ��Name$ tabCtrl��$	��Top=�$��1,1,1,-8q�&   System.Windows.Controls.DataGrid  -     Name$ 	dataTable��   AutoGenerateColumns .     AlternatingRowBackground �#e9ebf5   CanUserResizeColumns .    RowBackground �#cfd5ea    GridLinesVisibility$
  None=�
������ !   CanUserAddRows! .  "   	CellStyle" �� *  $System.Windows.Controls.DataGridCell"  .���  � ��
 �������  � ��$	 1pxq�# �� Triggers# P�  �@ 
IsSelected . . ���  � ��
 �������  � ��# � ����  � ��
 ���� $   ColumnHeaderStyle$ �� =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  .���  � �� �#4472c4��  � ��
 �������  � ��$
 20px(���  � ��$ Center=�%   Columns% 0  *System.Windows.Controls.DataGridTextColumn  -   timeCol��,  &System.Windows.Controls.DataGridColumn&   Width5  /System.Windows.Controls.DataGridLengthConverter$& 3* '   Header$' Video Time (Sec)��(   
IsReadOnly( . 1  +System.Windows.Controls.DataGridBoundColumn)   ElementStyle#) [ *   Binding* �� + �� Path$+ 	timeRange�  -   audioLblCol��$& 2* $' Audio Label��( . #) [ * �� $+ 
audioLabel�  -   
attnLblCol��$& 2* $' 
Attn Label��( . #) [ * �� $+ 	attnLabel�4  .System.Windows.Controls.DataGridTemplateColumn  -   	screenCol��$& 4* $' 
Video Clip��,   CellTemplate#, [   -   
commentCol��$& 5* $' Comments��( .  #) [ -   EditingElementStyle#- [ * �� $+ comment�. �� Mode$. TwoWay=�  -   notesCol��$& 5* $' Notes��( .  #) [ #- [ * �� $
+ note�$. TwoWay=�