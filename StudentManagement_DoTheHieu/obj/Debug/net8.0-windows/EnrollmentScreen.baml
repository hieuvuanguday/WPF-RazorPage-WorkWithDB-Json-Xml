   M S B A M L   `   `   `  ����V  RStudentManagement_DoTheHieu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:StudentManagement_DoTheHieuStudentManagement_DoTheHieu  5      2    ,StudentManagement_DoTheHieu.EnrollmentScreen   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:StudentManagement_DoTheHieu     5      -   5          N� Title$  Enrollment List��5	      .��5      � ���#90EE90.+�5   
   �� -   5         ��Name$ 	lblHeader��5      $��ENROLLMENT MANAGEMENT��6#   $��Center=�6C   $��0,30,0,0q�6`   $	��Top=�6r   $��37��6�   $	��237��6�   $��16(�6�   $
��Bold"�6�   �� 5   
   -   5        $ lblEnrollmentID��5      $��Enrollment ID��6)   $
��Left=�6A   $��	60,90,0,0q�6\   $	��Top=�6o   �� 5   
   -   5         ��Name$ txtEnrollmentID��5       �� 
IsReadOnly$
 True��6+   $
��Left=�6=   $��
150,95,0,0q�6X    �� TextWrapping$
 Wrap=�6l   $�� ��6�   $	��Top=�6�   $	��155��6�   �� 5   
   -   5        $ lblStudentID��5      $��
Student ID��6&   $
��Left=�6;   $��
60,130,0,0q�6V   $	��Top=�6j   �� 5   
   -   5        $ txtStudentID��5      $
��Left=�6(   $��150,135,0,0q�6C   $
 Wrap=�6X   $�� ��6l   $	��Top=�6t   $	��155��6�   �� 5   
   -   5        $ lblCourseID��5      $��	Course ID��6%   $
��Left=�69   $��
60,170,0,0q�6T   $	��Top=�6h   �� 5   
   -   5        $ txtCourseID��5      $
��Left=�6'   $��150,175,0,0q�6B   $
 Wrap=�6W   $�� ��6k   $	��Top=�6s   $	��155��6�   �� 5   
   -	   5        $ lblEnrollmentDate��5      $��Enrollment Date��6+   $
��Left=�6E   $��
450,90,0,0q�6`   $	��Top=�6t   (  "System.Windows.Controls.DatePicker  5   
   -
   5          Name$ dpkEnrollmentDate��5      $
��Left=�60   $��
550,90,0,0q�6K   $	��Top=�6_   $	��155��6w   �� 5   
   -   5        $ lblGrade��5      $��Grade��6"   $
��Left=�62   $��450,130,0,0q�6M   $	��Top=�6b   �� 5   
   -   5        $ txtGrade��5      $
��Left=�6$   $��550,135,0,0q�6?   $
 Wrap=�6T   $�� ��6h   $	��Top=�6p   $	��292��6�   �� 5   
   -   5        $ 	lblStatus��5      $��Status��6#   $
��Left=�64   $��450,170,0,0q�6O   $	��Top=�6d   �� 5   
   -   5         ��Name$ 	cbxStatus��5      $
��Left=�6&   $��550,175,0,0q�6A   $	��Top=�6V   $	��140��6n    �� SelectedIndex$ 0��6z   .@�5      �� $��Enrolled��6   �� 5       $��	Completed��6   5!      &   System.Windows.Controls.DataGrid  5#   
   -   5          Name$ dgvEnrollment��5#      $��60,253,58,215q�6�   �� 5%   
   -   5        	 ��Name$	 	btnSearch��5%      $��Search��6$   $
��Left=�65   $��
60,550,0,0q�6P   $	��Top=�6d   $��30��6|   $��80��6�   ���	#FF8481FF6�   �� 5&   
   -   5        $ 	txtSearch��5&      $
��Left=�6%   $��150,550,0,0q�6@   $
 Wrap=�6U   $�� ��6i   $	��Top=�6q   $	��431��6�   $��30��6�   �� 5(   
   -   5        $	 btnAdd��5(      $	��Add��6!   $
��Left=�6/   $��600,550,0,0q�6J   $	��Top=�6_   $��30��6w   $��80��6�   ���	#FF51FF356�   �� 5)   
   -   5        $	 	btnUpdate��5)      $��Update��6$   $
��Left=�65   $��700,550,0,0q�6P   $	��Top=�6e   $��30��6}   $��80��6�   ���	#FFFFF3226�   �� 5*   
   -   5        $	 	btnDelete��5*      $��Delete��6$   $
��Left=�65   $��800,550,0,0q�6P   $	��Top=�6e   $��30��6}   $��80��6�   ���	#FFF6914F6�   5+      5,      