   M S B A M L   `   `   `  ����V  RStudentManagement_DoTheHieu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:StudentManagement_DoTheHieuStudentManagement_DoTheHieu  5      /    )StudentManagement_DoTheHieu.StudentScreen   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:StudentManagement_DoTheHieu     5      -   5          N� Title$  Student List��5	      .��5      � ���#bcb5f5.+�5   
   �� -   5         ��Name$ 	lblHeader��5      $ ��STUDENT PROFILE MANAGEMENT��6#   $��Center=�6H   $��0,30,0,0q�6e   $	��Top=�6w   $��37��6�   $	��291��6�   $��16(�6�   $
��Bold"�6�   �� 5   
   -   5        $ lblStudentID��5      $��
Student ID��6&   $
��Left=�6;   $��	60,90,0,0q�6V   $	��Top=�6i   �� 5   
   -   5         ��Name$ txtStudentID��5       �� 
IsReadOnly$
 True��6(   $
��Left=�6:   $��
150,95,0,0q�6U    �� TextWrapping$
 Wrap=�6i   $�� ��6}   $	��Top=�6�   $	��155��6�   �� 5   
   -   5        $ lblFullName��5      $��FullName��6%   $
��Left=�68   $��
60,130,0,0q�6S   $	��Top=�6g   �� 5   
   -   5        $ txtFullName��5      $
��Left=�6'   $��150,135,0,0q�6B   $
 Wrap=�6W   $�� ��6k   $	��Top=�6s   $	��155��6�   �� 5   
    �� Orientation$ 
Horizontal=�6   $
��Left=�6.   $	��Top=�6I   $��
60,170,0,0q�6a   .+�5      �� $��Select Gender:��6   $��	5,0,15,10q�6.   	� 5      -   5        $��rbMale��5   <   $
��Male��6    	� 	GroupName$ Gender��6)   $��0,2,15,0q�6J    d� 	IsChecked$
 TrueY�6\   	� 5      -   5        $��rbFemale��5   >   $��Female��6   $ Gender��6+   $��0,2,0,0q�6N   5      �� 5   
   -	   5        $ lblBirthday��5      $��Birthday��6%   $
��Left=�68   $��
60,200,0,0q�6S   $	��Top=�6g   (  "System.Windows.Controls.DatePicker  5   
   -
   5          Name$ dpkBirthday��5      $
��Left=�6*   $��150,200,0,0q�6E   $	��Top=�6Z   $	��155��6r   �� 5   
   -   5        $ lblPhoneNumber��5      $��Phone Number��6(   $
��Left=�6?   $��
450,90,0,0q�6Z   $	��Top=�6n   �� 5   
   -   5        $ txtPhoneNumber��5      $
��Left=�6*   $��
550,95,0,0q�6E   $
 Wrap=�6Y   $�� ��6m   $	��Top=�6u   $	��292��6�   �� 5    
   -   5        $ lblEmail��5       $��Email��6"   $
��Left=�62   $��450,130,0,0q�6M   $	��Top=�6b   �� 5!   
   -   5        $ txtEmail��5!      $
��Left=�6$   $��550,135,0,0q�6?   $
 Wrap=�6T   $�� ��6h   $	��Top=�6p   $	��292��6�   �� 5#   
   -   5        $ 
lblAddress��5#      $��Address��6$   $
��Left=�66   $��450,170,0,0q�6Q   $	��Top=�6f   �� 5$   
   -   5        $ 
txtAddress��5$      $
��Left=�6&   $��550,175,0,0q�6A   $
 Wrap=�6V   $	��Top=�6j   $	��292��6�   $��21��6�   �� 5&   
   -   5        $ 	lblStatus��5&      $��Status��6#   $
��Left=�64   $��450,200,0,0q�6O   $	��Top=�6d   �� 5'   
   -   5        	 ��Name$	 	cbxStatus��5'      $
��Left=�6&   $��550,205,0,0q�6A   $	��Top=�6V   $	��140��6n   
 �� SelectedIndex$
 0��6z   .@�5(      �� $��Active��6   �� 5)      $��Inactive��6   5*      &   System.Windows.Controls.DataGrid  5,   
   -   5          Name$ dgvStudenProfile��5,      $��60,253,58,215q�6�      
IsReadOnly$
 True��6�   �� 5.   
   -   5         ��Name$ 	btnSearch��5.      $��Search��6$   $
��Left=�65   $��
60,550,0,0q�6P   $	��Top=�6d   $��30��6|   $��80��6�   ���	#FF8481FF6�   �� 5/   
   -   5        $ 	txtSearch��5/      $
��Left=�6%   $��150,550,0,0q�6@   $
 Wrap=�6U   $�� ��6i   $	��Top=�6q   $	��431��6�   $��30��6�   �� 51   
   -   5        $ btnAdd��51      $	��Add��6!   $
��Left=�6/   $��600,550,0,0q�6J   $	��Top=�6_   $��30��6w   $��80��6�   ���	#FF51FF356�   �� 52   
   -   5        $ 	btnUpdate��52      $��Update��6$   $
��Left=�65   $��700,550,0,0q�6P   $	��Top=�6e   $��30��6}   $��80��6�   ���	#FFFFF3226�   �� 53   
   -   5        $ 	btnDelete��53      $��Delete��6$   $
��Left=�65   $��800,550,0,0q�6P   $	��Top=�6e   $��30��6}   $��80��6�   ���	#FFF6914F6�   54      55      