   M S B A M L   `   `   `  ����[  WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms  5   	   K GAxInterop.WMPLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=0clr-namespace:AxWMPLib;assembly=AxInterop.WMPLibAxWMPLib 5   	    Wireframe_GUI   Wireframe_GUI.Player   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Owf@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms     5   	   ?ax0clr-namespace:AxWMPLib;assembly=AxInterop.WMPLib     5   	   -   5          � Title$  Player��5   	   $	��600��6   $	��750��6%   .��5      �  � 	Resources 5   
      textColStyle �� 
TargetType �� Property �� Value��%�   &	        �� 5	      " ��6)   .�5
      ��  � ��$ Center=�68   �� 5       � ��$ Center=�66   �� 5       � ��$
 Wrap=�61   �� 5       � ��$ 18(�6-   5      5       � RowDefinitions 5   
   �� 5      $	��90* �6   �� 5      $��6* �6   �� 5      $��6* �6   �� 5      $	��20* �6   .+�5   
   7  1System.Windows.Forms.Integration.WindowsFormsHost  -   5          Name$ 	formsHost��5      $��0��6.      Child. 5      #  AxWMPLib.AxWindowsMediaPlayer  -   5        
player��5   &   5      �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   .+�5      �� $��Start Time (Secs):��6   $��5,0,0,5q�61   �� 5      -   5        	 ��Name$	 startTimeEntry��5      $	��150��6.   $��5q�6:   �� 5      -   5        
 ��Name$
 setNewStartTime��5      $��	10,5,10,5q�6.   $��Update Start��6A   6X   �� 5      $��Stop Time (Secs):��6   $��5,0,0,5q�60   �� 5       -   5        $	 stopTimeEntry��5       $	��150��6-   $��5q�69   �� 5!      -   5        $
 setNewStopTime��5!      $��	10,5,10,5q�6-   $��
Update End��6@   6U   5"      �� 5$   
   $��2��6   $ 
Horizontal=�6"   $��Center=�6;   .+�5%      �� -   5        $
 
restartBtn��5%      $��Restart Clip��6)   $��	10,5,10,5q�6@   6S   5&      &   System.Windows.Controls.DataGrid  5(      -	   5          Name$ commentTable��5(         AutoGenerateColumns .     AlternatingRowBackground �#e9ebf5   CanUserResizeColumns .    RowBackground �#cfd5ea
������ $��0,0,0,10q�6�   $��3��6�      	CellStyle 5)      �� 5*      *  $System.Windows.Controls.DataGridCell"  6   .�5+      ��  � ��
 �����68   �� 5,       � ��$	 1pxq�6<    �� Triggers 5/      P� 50       P� Property �@ 
IsSelected P� Value . . �51   "   ��  � ��
 �����6@   �� 52   "    � ��# � ��6?   �� 53   "    � ��
 ���� 6?   54      56         ColumnHeaderStyle 58      �� 59      =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5:      ��  � �� �#4472c467   �� 5;       � ��
 �����67   �� 5<       � ��$
 14px(�65   �� 5=       � ��$ Center=�6G   5>         Columns 5@      0  *System.Windows.Controls.DataGridTextColumn  5A      -
   5        	start��,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 5A   4      Header$ 
Start Time��6?      
IsReadOnly .  1	  +System.Windows.Controls.DataGridBoundColumn 	  ElementStyle# [  6�    	  Binding 6S   ��  �� Path$ start�6�     5B      -   5        stop��$ 1* 5B   7   $ 	Stop Time��6B    .  # [  6�    6V   �� $
 stop�6�     5C      -   5        comment��$ 3* 5C   :   $ Comment��6E    .  # [  6�    6W   �� $ comment�6�   5E      5G      5H      