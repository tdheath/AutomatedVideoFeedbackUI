   M S B A M L   `   `   `  ���� [  WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms  K GAxInterop.WMPLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=0clr-namespace:AxWMPLib;assembly=AxInterop.WMPLibAxWMPLib  Wireframe_GUI   Wireframe_GUI.Player   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Owf@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms     ?ax0clr-namespace:AxWMPLib;assembly=AxInterop.WMPLib     -     � Title$  Player��$	��600��$	��750��.���  � 	Resources    textColStyle �� 
TargetType �� Property �� Value��%y   &	        �� " ��.���  � ��$ Center=���  � ��$ Center=���  � ��$
 Wrap=���  � ��$ 18(� � RowDefinitions �� $	��90* ��� $��6* ��� $��6* ��� $	��20* �.+�7  1System.Windows.Forms.Integration.WindowsFormsHost  -     Name$ 	formsHost��$��0��   Child. #  AxWMPLib.AxWindowsMediaPlayer  -   
player���� $��1�� �� Orientation$ 
Horizontal=�$��Center=�.+��� $��Start Time (Secs):��$��5,0,0,5q��� -   	 ��Name$	 startTimeEntry��$	��150��$��5q��� -   
 ��Name$
 setNewStartTime��$��	10,5,10,5q�$��Update Start���� $��Stop Time (Secs):��$��5,0,0,5q��� -   $	 stopTimeEntry��$	��150��$��5q��� -   $
 setNewStopTime��$��	10,5,10,5q�$��
Update End���� $��2��$ 
Horizontal=�$��Center=�.+��� -   $
 
restartBtn��$��Restart Clip��$��	10,5,10,5q�&   System.Windows.Controls.DataGrid  -	     Name$ commentTable��   AutoGenerateColumns .     AlternatingRowBackground �#e9ebf5   CanUserResizeColumns .    RowBackground �#cfd5ea
������ $��0,0,0,10q�$��3��   	CellStyle �� *  $System.Windows.Controls.DataGridCell"  .���  � ��
 �������  � ��$	 1pxq� �� Triggers P�  P� Property �@ 
IsSelected P� Value . . ���  � ��
 �������  � ��# � ����  � ��
 ����    ColumnHeaderStyle �� =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  .���  � �� �#4472c4��  � ��
 �������  � ��$
 14px(���  � ��$ Center=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  -
   	start��,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 1*    Header$ 
Start Time��   
IsReadOnly .  1	  +System.Windows.Controls.DataGridBoundColumn 	  ElementStyle# [   	  Binding ��  �� Path$ start�  -   stop��$ 1* $ 	Stop Time�� .  # [   �� $
 stop�  -   comment��$ 3* $ Comment�� .  # [   �� $ comment�