   M S B A M L   `   `   `  ����@  <NHOM9, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:NHOM9NHOM9  5   	       NHOM9.frmThongKe   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:NHOM9     5   	   -   5          � Title$  Thống kê��5   	   $	��450��6   $	��800��6'    � WindowStartupLocation$ CenterScreen=�5	   	    � Icon$ statistics.png��6.    � 	Resources 5
       �� 
TargetType �� Triggers P� Property P� Value �� Property	 �� Value��%�   '��       �� 5   
   " ��6    5      P� 5       � �� . . �5      ��  � ��
	 � � �63   5      5      5      .��5      � .+�5   
   o� $��0,0,0.6,389q�6   .@�5      m� -   5        
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
��Bold"�6�   
���  �� 5R      �� 5S      $��hinhanh/logout.png��6   $��Center=�68   $��16��6U   $��16��6`   ��5U      u� 5V      $ 4Q�6    5X      5Y      �� 5Z   
   $��Thống Kê
��6   $��51,36,42.6,161q�6/   $��Times New Roman)�6G   .��5[      �  � RowDefinitions 5\      �� 5]      $
��109* �6$   �� 5^      $
��105* �6$   .+�5`      �� -   5         ��Name$ lblSoluongnv��5`      $!��Số lượng nhân viên: ��6.   $
��Left=�6M   $��
43,36,0,24q�6h   $	��233��6|   $��Times New Roman)�6�   �� 5a      -   5        $ lblSoluongphongban��5a      $ ��Số lượng phòng ban: ��64   $
��Left=�6S   $��	43,17,0,0q�6n   $	��Top=�6�   $��32��6�   $	��257��6�   $��1��6�   $��Times New Roman)�6�   �� 5b      -   5        $ lblSoluongduan��5b      $)��#Số lượng các dự án lớn: ��60   $
��Left=�6S   $��432,19.4,0,0q�6n   $	��Top=�6�   $	��218��6�   $��30��6�   $��1��6�   $��Times New Roman)�6�   �� 5c      -   5        $ lblSoluongtk��5c      $-��'Số lượng tài khoản đã cấp: ��6.   $
��Left=�6T   $��
432,36,0,0q�6o   $	��Top=�6�   $��34��6�   $	��217��6�   $��Times New Roman)�6�   5d      5e      �� 5f   
   -   5        $ label1��5f      $����Yêu cầu tất cả mọi người tập trung hoàn thành tất cả các công việc được giao phó để hoàn thành sản phẩm cho bên đối tác 
                                                                                                                                                                	 Kí tên Giám đốc
                                                                                                                    

��6    $
��Left=�6�  $��
45,273,0,0q�6�  $	��Top=�6  $��44��6'  $	��706��63  $��Times New Roman)�6?  �� 5g   
   -   5        $ label2��5g      $��Hoàng Thị Khuyên
��6    $
��Left=�6E   $��571,317,0,0q�6`   $	��Top=�6u   $��Times New Roman)�6�   �� 5h   
   -   5         ��Name$ button1��5h      $��
Trở về��6"   $
��Left=�63   $��656,359,0,0q�6N   $	��Top=�6c   $��95��6{   $��Times New Roman)�6�   $
��Bold"�6�   $��30��6�   5j      5k      