   M S B A M L   `   `   `  ����@  <NHOM9, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:NHOM9NHOM9  5   	       NHOM9.frmTimkiem   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:NHOM9     5   	   -   5          � Title$  Tìm kiếm��5   	   $��536.4��6   $��646.8��6)    � WindowStartupLocation$ CenterScreen=�5	   	    � Icon$ planing.png��6.    � 	Resources 5
       �� 
TargetType �� Triggers P� Property P� Value �� Property	 �� Value��%�   '��       �� 5   
   " ��6    5      P� 5       � �� . . �5      ��  � ��
	 � � �63   5      5      5      .��5      � $��0,0,4.4,-5.6q�6   .+�5   
   o� $��0,0,0.4,482.4q�6   .@�5      m� -   5        
 m�Name$
 
mniDanhMuc��5      $��
Danh mục��6+   $��95��6=   $��35��6H   $��Center=�6T   $��Center=�6o   $��Times New Roman)�6�   $
��Bold"�6�    J� RenderTransformOrigin$ 0.484,1.126&�6�   ���	#FF0071FF m� Icon 5      �� 5      $��hinhanh/options.png��6   $��Center=�69   $��16��6V   $��16��6a   ��5      u� 5      
 u� Top$ 4Q�6    .@�5      m� -   5        $��Chức vụ��5       5      �� 5      $��hinhanh/jobs.png��6    $��Center=�6:   $��16��6W   $��16��6b   5!      m� 5"      -   5        $��
Phòng ban��5"       5#      �� 5$      $��hinhanh/corporate.png��6    $��Center=�6?   $��16��6\   $��16��6g   5&      m� 5'      -   5        $��Dự án��5'       5(      �� 5)      $��hinhanh/project.png��6    5+      5,      m� 5-      -   5        $
 mi_QLHS��5-      $��Quản lí hồ sơ��6(   $	��118��6?   $��35��6K   $��Center=�6W   $��Center=�6r   $��Times New Roman)�6�   $
��Bold"�6�   ���	#FF0071FF 5.      �� 5/      $��hinhanh/resume.png��6   $��Center=�68   $��16��6U   $��16��6`   ��51      u� 52      $ 4Q�6    .@�54      m� -   5        $��Hồ sơ nhân viên��54       55      �� 56      $&�� hinhanh/information-pamphlet.png��6    58      m� 59      -   5        $
 
mi_TimKiem��59      $(��"Tìm kiếm thông tin nhân viên��6/    5:      �� 5;      $��hinhanh/planing.png��6    5=      5>      m� 5?      -	   5        $
 mi_QLHT��5?      $��Quản lí hệ thống��6(   $	��129��6B   $��35��6N   $��Center=�6Z   $��Center=�6u   $��Times New Roman)�6�   $
��Bold"�6�   ���	#FF0071FF 5@      �� 5A      $+��%hinhanh/content-management-system.png��6   $��Center=�6K   $��16��6h   $��16��6s   ��5C      u� 5D      $ 4Q�6    .@�5F      m� -
   5        $
 mi_QLTK��5F      $��Quản lí tài khoản��6,    5G      �� 5H      $��hinhanh/user.png��6    5J      m� 5K      -   5        $��Bảng thống kê��5K       5L      �� 5M      $��hinhanh/statistics.png��6    5O      5P      m� 5Q      -   5        $
 mi_thoat��5Q      $��Thoát��6)   $	��100��68   $��35��6D   $��Center=�6P   $��Center=�6k   $��Times New Roman)�6�   $
��Bold"�6�   ���	#FFFF0009 5R      �� 5S      $��hinhanh/logout.png��6   $��Center=�68   $��16��6U   $��16��6`   ��5U      u� 5V      $ 4Q�6    5X      5Y      �� 5Z   
   $(��"Nhập thông tin tìm kiếm theo��6   $
��Left=�67   $��	25,35,0,0q�6R   $	��Top=�6e   $	��174��6}   $��Times New Roman)�6�   $
��Bold"�6�   �� 5[   
   -   5         ��Name$ 
txtTimKiem��5[      $
��Left=�6&   $��
25,102,0,0q�6A    �� TextWrapping$
 Wrap=�6U   $	��Top=�6i   $	��460��6�   $��28��6�   �� 5\   
   -   5         ��Name$ 	btTimKiem��5\      $
��Left=�6$   $��507,102,0,0q�6?   $	��Top=�6T   $	��111��6l   $��Times New Roman)�6�   $
��Bold"�6�   $��26��6�   .��5]      ��  �� Orientation$ 
Horizontal=�6   .+�5^      �� $��hinhanh/research.png��6   $��16��66   $��16��6A   $��0,0,5,0q�6M   �� 5_      $��Tìm kiếm��6   ���	#FF008CFF6,   5`      5a      &   System.Windows.Controls.DataGrid  5b   
   -   5          Name$ dgvMain��5b      $��25,171,17.6,65q�6$      ColumnHeaderStyle 5c      �� 5d      =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5e      ��  � ��$	 Center=�6C   5f      5h      �� 5i   
   -   5        $ btTroVe��5i      $��
Trở về��6"   $
��Left=�63   $��523,461,0,0q�6N   $	��Top=�6c   $��95��6{   $��Times New Roman)�6�   $
��Bold"�6�   $��30��6�   $ 0.561,1.763&�6�   ���	#FF0071FF6�   �� 5j   
   $)��#Danh sách nhân viên tìm kiếm:��6   $
��Left=�68   $��
26,135,0,0q�6S   $	��Top=�6g   $	��179��6   $��Times New Roman)�6�   $��26��6�   	� 5k   
   -   5         	�Name$ radio2��5k      $��ID Nhân viên��6&   $
��Left=�6=   $��	26,83,0,0q�6X   $	��Top=�6k   $��Times New Roman)�6�   $
��Bold"�6�   	� 5l   
   -   5        $ radio1��5l      $��Tên Nhân viên��6&   $
��Left=�6>   $��	26,64,0,0q�6Y   $	��Top=�6l   $��Times New Roman)�6�   $
��Bold"�6�   5n      5o      