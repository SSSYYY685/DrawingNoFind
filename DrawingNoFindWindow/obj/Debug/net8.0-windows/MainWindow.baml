   M S B A M L   `   `   `  ����N  JDrawingNoFindWindow, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:DrawingNoFindWindowDrawingNoFindWindow  5   	   $    DrawingNoFindWindow.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:DrawingNoFindWindow     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      �� 5      $��0* �6   .+�5   
   �� -   5         ��Name$ Button_TXTVsFile��5      $��文本与文件对比��6+   $
��Left=�6=   $��
74,232,0,0q�6X   $	��Top=�6l   $��48��6�   $	��146��6�   $��20(�6�   �� 5   
   -   5        $ Button_FileVsTXT��5      $��文件与文本对比��6+   $
��Left=�6=   $��
74,323,0,0q�6X   $	��Top=�6l   $��48��6�   $	��146��6�   $��20(�6�   �� 5   
   -   5         ��Name$ TextBox_txtData��5      $��400,69,36,99q�6+    �� TextWrapping$
 Wrap=�6A   $$��请在此处输入核查内容��6V   $
{�True��6h    �� AcceptsReturn$
 True��6y   " �� VerticalScrollBarVisibility$ Visible=�5      5      �� 5   
   -   5         ��Name$ TextBlock_PathDate��5      $��	34,87,0,0q�60   $
��Wrap=�6C   $
��Left=�6W   $��66��6r   $��21��6}   $	��Top=�6�   �� 6�    � Language$ zh-cn�6�   $�文件路径:��6�   $��15(�6�   6�   �� 5   
   -   5        $ TextBox_Path��5      $��
34,113,0,0q�6(   $ NoWrap=�6<   $
{�True��6S   $��请在此处输入路径��5      $	��Top=�6"   $��20��6:   $
��Left=�6m   $	��302��6�   o� 5   
   $��20��6   $	��Top=�6   .@�5      m� -   5        $��帮助��5      .@�5      m� -   5        $'��!点击获取文件信息后使用��5      60   5      5      �� 5   
   -   5        $ Button_IsPath��5      $��获取文件信息��6(   $
��Left=�69   $��206,138,0,0q�6T   $	��Top=�6i   $��36��6�   $	��130��6�   $��20(�6�   5       5!      