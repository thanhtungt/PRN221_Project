   M S B A M L   `   `   `  ����H  DProjectAssWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:TranMinhThienWPFTranMinhThienWPF  5   	       TranMinhThienWPF.Login   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   0localclr-namespace:TranMinhThienWPF     5   	   -   5          � Title$  Login��5   	   $	��550��6   $	��800��6$    � 
ResizeMode$ NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	   .��5      �� $��2q�6   ��5   
   �� 5       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 1,1&�63   .��5      �  � Color$ #C120CF��6    � Offset$ 0Q�6/   � 5      $ #20FCF4��6   $
 0.75Q�6/   � 5      $ #008B86��6   $ 1Q�6/   5      ��5   
   �� 5      $	 0,1&�6"   $	 1,0&�63   .��5      � $ #0096FF��6   $ 0Q�6/   � 5      $ 	#FFE60872��6   $ 1Q�61   � 5      $ 	#FF124783��6   $ 0.171Q�61   5      ._�5   
   �� $	��300��6    �� Orientation$ Vertical=�6!   $��248,35,248,8q�68   .+�5      �� 
������� �� TextAlignment$ Center=�6+   $��30(�6B   $��Heavy"�6P   $
��Wrap=�6c   Flower Bouquet Management6�   �� 5      
�������$ Center=�6+   $��15(�6B   $��Light"�6P   $
��Wrap=�6c   $��0,10,0,0q�6w   !Please input email and password6�   �� 5      
�������$
 Left=�6+   $��15(�6@   $��Medium"�6N   $
��Wrap=�6b   $��0,50,0,0q�5       Email5"      �� 5#      -   5        	 ��Name$	 Email��5#      
 �� TextAlignment$

 Left=�6%   $��13(�6:   $��Medium"�6H   
�������
������  �� 
CaretBrush
 ��������#CA9CCA$��0,0,0,1q�5$   [   $��0,5,0,0q�5%      .��6*   5&      �� 5(      
�������$
 Left=�6+   $��15(�6@   $��Medium"�6N   $
��Wrap=�6b   $��0,30,0,0q�5)      
Password5+      G� 5,      -   5         G�Name$ Password��5,      $��13(�6,   $��Medium"�6:   
�������
������  G� 
CaretBrush
 ��������#CA9CCA$��0,0,0,1q�5-   X   $��0,5,0,0q�5.      5/      �� 51      -   5        $��Login��51      
�������$��Light"�68   $��0,50,0,0q�52      $��0q�6'   ��53      �� 54       �� 
TargetType" ��6   .�55      ��  �� Property � �� �� Value �#C120CF6J    �� Triggers 56      P� 57       P� Property �@J�IsMouseOver P� Value$
 true��6=   . �58   "   ��  � �� �#C597C56Q   59      P� 5:       � ��$
 true��6;   . �5;   "   ��  � �� �#FFE7FF6Q   5<      5>      ��5B      �� 5C       �� 
TargetType" ��6%   .R�5D      �� $	��150��6    $��40��6,   #��z��68    �� CornerRadius$ 10��6b   ._�5E      �� $��Center=�6.   $��Center=�6K   5F      5H      5J      5M      5N      5O      