   M S B A M L   `   `   `  ����V  RStudentManagement_DoTheHieu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:StudentManagement_DoTheHieuStudentManagement_DoTheHieu  5      .    (StudentManagement_DoTheHieu.CourseScreen   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:StudentManagement_DoTheHieu     5      -   5          N� Title$  Course List��5	      .��5      � ���#FFA500.+�5   
   �� -   5         ��Name$ 	lblHeader��5      $��COURSE MANAGEMENT��6#   $��Center=�6?   $��0,30,0,0q�6\   $	��Top=�6n   $��37��6�   $	��200��6�   $��16(�6�   $
��Bold"�6�   �� 5   
   -   5        $ lblCourseID��5      $��	Course ID��6%   $
��Left=�69   $��	60,90,0,0q�6T   $	��Top=�6g   �� 5   
   -   5         ��Name$ txtCourseID��5       �� 
IsReadOnly$
 True��6'   $
��Left=�69   $��
150,95,0,0q�6T    �� TextWrapping$
 Wrap=�6h   $�� ��6|   $	��Top=�6�   $	��292��6�   �� 5   
   -   5        $ lblCourseName��5      $��Course Name��6'   $
��Left=�6=   $��
60,130,0,0q�6X   $	��Top=�6l   �� 5   
   -   5        $ txtCourseName��5      $
��Left=�6)   $��150,135,0,0q�6D   $
 Wrap=�6Y   $�� ��6m   $	��Top=�6u   $	��292��6�   �� 5   
   -   5        $ lblStartDate��5      $��
Start Date��6&   $
��Left=�6;   $��
500,90,0,0q�6V   $	��Top=�6j   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dpkStartDate��5      $
��Left=�6+   $��
580,90,0,0q�6F   $	��Top=�6Z   $	��155��6r   �� 5   
   -	   5        $ 
lblEndDate��5      $��End Date��6$   $
��Left=�67   $��500,130,0,0q�6R   $	��Top=�6g     5   
   -
   5        $ 
dpkEndDate��5      $
��Left=�6)   $��580,130,0,0q�6D   $	��Top=�6Y   $	��155��6q   �� 5   
   -   5        $ 	lblCredit��5      $��Credit��6#   $
��Left=�64   $��
60,170,0,0q�6O   $	��Top=�6c   �� 5   
   -   5        $ 	txtCredit��5      $
��Left=�6%   $��150,175,0,0q�6@   $
 Wrap=�6U   $�� ��6i   $	��Top=�6q   $	��292��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	dgvCourse��5      $��60,253,58,215q�6      
IsReadOnly$
 True��6�   �� 5   
   -   5         ��Name$ 	btnSearch��5      $��Search��6$   $
��Left=�65   $��
60,550,0,0q�6P   $	��Top=�6d   $��30��6|   $��80��6�   ���	#FF8481FF6�   �� 5    
   -   5        $ 	txtSearch��5       $
��Left=�6%   $��150,550,0,0q�6@   $
 Wrap=�6U   $�� ��6i   $	��Top=�6q   $	��431��6�   $��30��6�   �� 5"   
   -   5        $ btnAdd��5"      $	��Add��6!   $
��Left=�6/   $��600,550,0,0q�6J   $	��Top=�6_   $��30��6w   $��80��6�   ���	#FF51FF356�   �� 5#   
   -   5        $ 	btnUpdate��5#      $��Update��6$   $
��Left=�65   $��700,550,0,0q�6P   $	��Top=�6e   $��30��6}   $��80��6�   ���	#FFFFF3226�   �� 5$   
   -   5        $ 	btnDelete��5$      $��Delete��6$   $
��Left=�65   $��800,550,0,0q�6P   $	��Top=�6e   $��30��6}   $��80��6�   ���	#FFF6914F6�   5%      5&      