   M S B A M L   `   `   `  ����@  <NHOM9, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:NHOM9NHOM9  5   	       NHOM9.frmChucVu   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:NHOM9     5   	   -   5          � Title$  Chức vụ��5   	   $	��646��6   $��698.4��6&    � WindowStartupLocation$ CenterScreen=�5	   	    � Icon$ hinhanh/jobs.png��6.    � 	Resources 5
       �� 
TargetType �� Triggers P� Property P� Value �� Property	 �� Value��%�   '��       �� 5   
   " ��6    5      P� 5       � �� . . �5      ��  � ��
	 � � �63   5      5      5      .��5      � -   5        
 �Name$

 Danh��5      $��
0,0,4,-0.2q�6   .+�5   
   o� $��	0,0,0,487q�6   .@�5      m� -   5         m�Name$ 
mniDanhMuc��5      $��
Danh mục��6+   $��95��6=   $��35��6H   $��Center=�6T   $��Center=�6o   $��Times New Roman)�6�   $
��Bold"�6�   ���	#FF008CFF m� Icon 5      �� 5      $��hinhanh/options.png��6   $��Center=�69   $��16��6V   $��16��6a   ��5      u� 5      
 u� Top$ 4Q�6    .@�5      m� -   5        $��Chức vụ��5       5      �� 5      $��hinhanh/jobs.png��6    $��Center=�6:   $��16��6W   $��16��6b   5!      m� 5"      -   5        $��
Phòng ban��5"       5#      �� 5$      $��hinhanh/corporate.png��6    $��Center=�6?   $��16��6\   $��16��6g   5&      m� 5'      -   5        $��Dự án��5'       5(      �� 5)      $��hinhanh/project.png��6    5+      5,      m� 5-      -   5        $ mi_QLHS��5-      $��Quản lí hồ sơ��6(   $	��118��6?   $��35��6K   $��Center=�6W   $��Center=�6r   $��Times New Roman)�6�   $
��Bold"�6�   ���	#FF008CFF 5.      �� 5/      $��hinhanh/resume.png��6   $��Center=�68   $��16��6U   $��16��6`   ��51      u� 52      $ 4Q�6    .@�54      m� -   5        $��Hồ sơ nhân viên��54       55      �� 56      $&�� hinhanh/information-pamphlet.png��6    58      m� 59      -	   5        $ 
mi_TimKiem��59      $(��"Tìm kiếm thông tin nhân viên��6/    5:      �� 5;      $��hinhanh/planing.png��6    5=      5>      m� 5?      -
   5        $ mi_QLHT��5?      $��Quản lí hệ thống��6(   $	��129��6B   $��35��6N   $��Center=�6Z   $��Center=�6u   $��Times New Roman)�6�   $
��Bold"�6�   ���	#FF008CFF 5@      �� 5A      $+��%hinhanh/content-management-system.png��6   $��Center=�6K   $��16��6h   $��16��6s   ��5C      u� 5D      $ 4Q�6    .@�5F      m� -   5        $ mi_QLTK��5F      $��Quản lí tài khoản��6,    5G      �� 5H      $��hinhanh/user.png��6    5J      m� 5K      -   5        $��Bảng thống kê��5K       5L      �� 5M      $��hinhanh/statistics.png��6    5O      5P      m� 5Q      -   5        $ mi_thoat��5Q      $��Thoát��6)   $	��100��68   $��35��6D   $��Center=�6P   $��Center=�6k   $��Times New Roman)�6�   $
��Bold"�6�   
���  �� 5R      �� 5S      $��hinhanh/logout.png��6   $��Center=�68   $��16��6U   $��16��6`   ��5U      u� 5V      $ 4Q�6    5X      5Y      &   System.Windows.Controls.DataGrid  5\   
   -   5          Name$ dgvMain��5\      $
��Left=�6$   $	��276��6?   $��	10,41,0,0q�6L   $	��Top=�6_   $	��672��6w   ���	#FFAFAFAF$��Times New Roman)�6�      ColumnHeaderStyle 5]      �� 5^      =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5_      ��  � ��$	 Center=�6C   5`      5b      �� 5c   
   $��Tìm kiếm��6   $
��Left=�6#   $��	8,330,0,0q�6>   $	��Top=�6Q   $��96��6i   $��Times New Roman)�6t   $��30��6�   �� 5d   
   $��Mã Chức Vụ��6   $
��Left=�6%   $��
10,380,0,0q�6@   $	��Top=�6T    J� RenderTransformOrigin$ 0.091,0.502&�6l   $��96��6�   $��Times New Roman)�6�   $��30��6�   �� 5e   
   -   5         ��Name$ txtmachucvu��5e      $
��Left=�6'   $��136,380,0,0q�6B    �� TextWrapping$
 Wrap=�6W   $	��Top=�6k   $	��541��6�   $
��Left=�6�   $��30��6�   $��Times New Roman)�6�   �� 5f   
   $��Tên Chức Vụ��6   $
��Left=�6&   $��
10,426,0,0q�6A   $	��Top=�6U   $ 0.517,1.242&�6m   $��96��6�   $��Times New Roman)�6�   $��30��6�   �� 5g   
   -   5        $ txttenchucvu��5g      $
��Left=�6(   $��136,426,0,0q�6C   $
 Wrap=�6X   $	��Top=�6l   $	��541��6�   $��30��6�   $��Times New Roman)�6�   �� 5h   
   $��Ghi Chú��6   $
��Left=�6"   $��
10,479,0,0q�6=   $	��Top=�6Q   $��96��6i   $��Times New Roman)�6t   $��32��6�   �� 5i   
   -   5        $ 	txtghichu��5i      $
��Left=�6%   $��137,479,0,0q�6@   $
 Wrap=�6U   $	��Top=�6i   $	��541��6�   $��79��6�   $��Times New Roman)�6�   �� 5j   
   -   5         ��Name$ cbhoten��5j      $
��Left=�6$   $��137,330,0,0q�6?   $	��Top=�6T   $	��541��6l   $��30��6�   $��Times New Roman)�6�   �� 5l   
   -   5         ��Name$ button2��5l      $��Reset��6"   $
��Left=�62   $��284,577,0,0q�6M   $	��Top=�6b   $��30��6z   $��95��6�   $��Times New Roman)�6�   $
��Bold"�6�   ���	#FF0600FF6�   �� 5n   
   -   5        $ button1��5n      $��
Trở về��6"   $
��Left=�63   $��582,577,0,0q�6N   $	��Top=�6c   $ -0.081,0.763&�6{   $��30��6�   $��95��6�   $��Times New Roman)�6�   $
��Bold"�6�   ���	#FF008CFF6�   �� 5o   
   -   5        $ btboqua��5o      $��Bỏ Qua��6"   $
��Left=�63   $��438,577,0,0q�6N   $	��Top=�6c   $��95��6{   $��30��6�   $��Times New Roman)�6�   $
��Bold"�6�   ���	#FF0600FF6�   �� 5p   
   -   5        $ btnThem��5p      $��Cập nhật��6"   $
��Left=�65   $��136,577,0,0q�6P   $	��Top=�6e   $��30��6}   $��95��6�   $��Times New Roman)�6�   $
��Bold"�6�   ���	#FF0600FF6�   �� 5q   
   -   5        $ 	btthemmoi��5q      $��Thêm��6$   $
��Left=�63   $��136,577,0,0q�6N   $	��Top=�6c   $��95��6{   $��30��6�   $��Times New Roman)�6�   $
��Bold"�6�   ���	#FF008CFF6�   �� 5r   
   -   5        $ btnSua��5r      $��Sửa��6!   $
��Left=�6/   $��284,577,0,0q�6J   $	��Top=�6_   $ 
2.655,3.98&�6w   $��30��6�   $��95��6�   $��Times New Roman)�6�   $
��Bold"�6�   ���	#FF008CFF6�   �� 5s   
   -   5        $ btnXoa��5s      $
��Xóa��6!   $
��Left=�6/   $��438,577,0,0q�6J   $	��Top=�6_   $��30��6w   $��95��6�   $��Times New Roman)�6�   $
��Bold"�6�   ���	#FFFF00126�   5u      5v      