   M S B A M L   `   `   `  ����  StatClient.Windows#    StatClient.Windows.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5
   
   � $��0��6    � ColumnDefinitions 5      �� 5      �� 5      �� 5      �� 5      .+�5      �� $��Server Name��6   �� 5      $��1��6   ��6*   �� *
ServerName+�� 5      $��2��6   ��6&   �� *LoadLastHour+.��6H   	Last Hour5      �� 5      $��3��6   ��6&   �� *LoadLastDay+.��6G   
Last Day5      5      &   System.Windows.Controls.DataGrid  5   
      AutoGenerateColumns .    SelectionMode$ Single=�5         SelectionUnit$ FullRow=�5         
IsReadOnly . $��1��5   1   ��6   �� *Stats+61   5       5!      