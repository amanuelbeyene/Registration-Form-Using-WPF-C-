   M S B A M L   `   `   `  ����   Condominium Registraion Form,    &CondominiumRegistrationForm.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$/  )Addis Ababa Condominium Registration Form��5   	   $	��500��6;   $	��900��6H   .��5      �� .��5      �  � ColumnDefinitions 5   
   �� 5	      $��1* �6   �� 5
      $��2* �6   .+�5      �� $��0��6   $��10q�6)   .+�5      �� $��Registration Form��6   $��24(�61   $
��Bold"�6?   $��Center=�6Q   $
��0,10q�6n   �� 5      $��
First Name��6   �� 5      -   5        $��FirstNameTextBox��5      �� 5      $��Middle Name��6   �� 5      -   5        $��MiddleNameTextBox��5      �� 5      $��	Last Name��6   �� 5      -   5        $��LastNameTextBox��5      �� 5      $��Gender��6   �� 5       �� Orientation$ 
Horizontal=�6   $��21,0,0,0q�62   .+�5      	� -   5        $��MaleRadioButton��5   @   $
��Male��6    	� 	GroupName$ Gender��6-   6@   	� 5      -   5        $��FemaleRadioButton��5   B   $��Female��6   $ Gender��6/   $��17,0,0,0q�6[   5      �� 5!      $��Date of Birth��6   (  "System.Windows.Controls.DatePicker  5"      -   5        $��DateOfBirthPicker��5"      �� 5$      $��Phone Number��6   �� 5%      -   5        $��PhoneNumberTextBox��5%      �� 5'      $��Home Number��6   �� 5(      -   5        $��HomeNumberTextBox��5(      � 5*       � Orientation$ 
Horizontal=�6   .+�5+      �� -	   5        $��Create��5+      $��
10,10,0,10q�6E   $��70��6Y   �� 5,      6   �� 5-      -
   5        $��Update��5-      $��
10,10,0,10q�6E   $��70��6Y   �� 5.      6   �� 5/      -   5        $��Delete��5/      $��
10,10,0,10q�6E   $��70��6Y   50      �� 52      $ 
Horizontal=�6   $��Center=�66   $��10q�6S   $	��258��6_   .+�53      �� -   5         ��Name$ SaveButtonn��53      $
��Save��62   $��80��6A   $��5q�6L   6W   �� 54      -   5        $ SaveAsButtonn��54      $��Save As��64   $��80��6F   $��-1,5,5,5q�6Q   6c   �� 55      -   5        $ 
OpenButton��55      $
��Open��61   $��80��6@   $��1,5,5,5q�6K   6\   56      58      &   System.Windows.Controls.DataGrid  5;   
   -   5        $��DataGrid��5;      $��1��6#   $��10q�63      AutoGenerateColumns$
 True��6?      
IsReadOnly$
 True��6Z   5<      5=      5>      5?      