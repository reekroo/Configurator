   M S B A M L   `   `   `  ����  Configurator#    Configurator.Views.MainWindow   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      T PCatel.Extensions.Controls, Version=4.3.0.0, Culture=neutral, PublicKeyToken=nullE ACatel.MVVM, Version=4.3.0.0, Culture=neutral, PublicKeyToken=null'catelhttp://catel.codeplex.com   5      <d2http://schemas.microsoft.com/expression/blend/2008   5      Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   6L   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5        � Icon$  ../Configurator.ico��5       � 
ResizeMode$ 	CanResize=�5	      $	��778��6;   $	��400��6J   .��5      � -   5         �Name$ 
LayoutRoot��5      .+�5   
   �� $��	Open File��6   $
��Left=�6%   $	��Top=�6@   $	��120��6X   $��33��6d   $��0,10,0,0q�6p   ��6�   �� *OpenFileCommand+�� 5   
   $��	Save File��6   $
��Left=�6%   $	��Top=�6@   $	��120��6X   $��33��6d   $��
120,10,0,0q�6p   ��6�   �� *SaveFileCommand+�� 5   
   $��Stretch=�6*   $��33��6H    �� TextWrapping$
 Wrap=�6T   $	��Top=�6h   $��240,10,125,0q�6�   ��6   �� *Search+.��6�   .  (System.Windows.Interactivity.Interaction   	Behaviors 5      <  6Catel.Windows.Interactivity.UpdateBindingOnTextChanged  5         UpdateDelay$	 500��63   3  -Catel.Windows.Interactivity.KeyPressToCommand  5      
   Key$ Enter��6*   �  �Catel.Windows.Interactivity.CommandBehaviorBase`1[[System.Windows.FrameworkElement, PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35]]   Command 66   �� *SearchCommand+.��5   '   5      �� 5   
   $��Search��6   $��Right=�6"   $��0,10,0,0q�6>   $	��Top=�6P   $	��125��6h   $��33��6t   ��6�   �� *SearchCommand+�� 5   
   $	��Add��6   $
��Left=�6   $��0,63,0,0q�6:   $	��Top=�6L   $	��171��6d   $��33��6p   ��6}   �� *
AddCommand+�� 5   
   $
��Edit��6   $
��Left=�6    $��
171,63,0,0q�6;   $	��Top=�6O   $	��171��6g   $��33��6s   ��6   �� *EditCommand+�� 5   
   $��Remove��6   $
��Left=�6"   $��
342,63,0,0q�6=   $	��Top=�6Q   $	��171��6i   $��33��6u   ��6�   �� *RemoveCommand+�� 5   
   $��Formatting Packages��6   $��Right=�6/   $��0,63,0,0q�6K   $	��Top=�6]   $	��125��6u   $��33��6�   ��6�   �� *FormatFormsCommand+�� 5   
   $��0,96,0,0q�6    �� SelectionMode$ Single=�6%   ��5      �� *FormsCollection+	 �� SelectedItem	 5      �� *SelectedForm+
 �� View
 5       �� 5!      .P�5"      ��  �� Width$	 190��6%   $��	Form Name��5$       �� DisplayMemberBinding 5#      �� *
FormName+5$      �� 5%      $	 190��6%   $��pdf Name��5'       5&      �� *	PdfName+5'      �� 5(      $	 190��6%   $��pdf Path��5*       5)      �� *PdfFilePath+5*      �� 5+      $	 190��6%   $��Doctype��5-       5,      �� *	Doctype+5-      5.       50        51      $ Enter��6*    66   �� *EditCommand+  52      $ Delete��6*    67   �� *RemoveCommand+54      55      57      