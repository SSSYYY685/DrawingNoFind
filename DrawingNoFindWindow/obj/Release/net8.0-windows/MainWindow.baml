   M S B A M L   `   `   `  ���� N  JDrawingNoFindWindow, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:DrawingNoFindWindowDrawingNoFindWindow  $    DrawingNoFindWindow.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     3local!clr-namespace:DrawingNoFindWindow       � Title$  
MainWindow��$	��450��$	��800��.���  � ColumnDefinitions �� �� $��0* �.+��� -    ��Name$ Button_TXTVsFile��$��文本与文件对比��$
��Left=�$��
74,232,0,0q�$	��Top=�$��48��$	��146��$��20(��� -   $ Button_FileVsTXT��$��文件与文本对比��$
��Left=�$��
74,323,0,0q�$	��Top=�$��48��$	��146��$��20(��� -    ��Name$ TextBox_txtData��$��354,69,36,99q� �� TextWrapping$
 Wrap=�$��TextBox��$
{�True�� �� AcceptsReturn$
 True��" �� VerticalScrollBarVisibility$ Visible=��� -   $ TextBox_Path��$��
34,113,0,0q�$ NoWrap=�$
{�True��$��TextBox��$	��Top=�$��18��$
��Left=�$	��248���� -    ��Name$ TextBlock_PathDate��$��34,87,625,327q�$
��Wrap=���  � Language$ zh-cn�$�文件路径:��$��15(�o� $��20��$	��Top=�.@�m� -   $��帮助��.@�m� -   $'��!点击获取文件信息后使用���� -   $ Button_IsPath��$��获取文件信息��$
��Left=�$��190,136,0,0q�$	��Top=�$��36��$	��130��$��20(�