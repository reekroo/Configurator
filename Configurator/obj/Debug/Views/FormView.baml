   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5       Configurator!   Configurator.Views.FormView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      T PCatel.Extensions.Controls, Version=4.3.0.0, Culture=neutral, PublicKeyToken=nullE ACatel.MVVM, Version=4.3.0.0, Culture=neutral, PublicKeyToken=null'catelhttp://catel.codeplex.com   5      <d2http://schemas.microsoft.com/expression/blend/2008   6;   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5      $��564.794��6�   $��289.411��6�   .��5      � .+�5	   
   �� $��	Form Name��6   $
��Left=�6$   $��1,4,0,0q�6?   $	��Top=�6P   �� 5
   
   $
��Left=�6,   $��23��6G   $��78,7,0,0q�6S     �� TextWrapping$
  Wrap=�6e   $	��Top=�6y   $	��180��6�   ��6   �� *
FormName+6�   �� 5   
   $��PDF Name��6   $
��Left=�6#   $��1,30,0,0q�6>   $	��Top=�6P   �� 5   
   $
��Left=�6+   $��23��6F   $��	78,33,0,0q�6R   $
  Wrap=�6e   $	��Top=�6y   $	��180��6�   ��6   �� *	PdfName+6�   �� 5   
   $��Doctype��6   $
��Left=�6"   $��1,56,0,0q�6=   $	��Top=�6O   �� 5   
   $
��Left=�6+   $��23��6F   $��	78,58,0,0q�6R   $
  Wrap=�6e   $	��Top=�6y   $	��180��6�   ��6   �� *	Doctype+6�   �� 5   
   $��DataNamePrefix��6   $
��Left=�6)   $��	268,4,0,0q�6D   $	��Top=�6W   �� 5   
   $
��Left=�62   $��23��6M   $��	370,7,0,0q�6Y   $
  Wrap=�6l   $	��Top=�6�   $	��180��6�   ��6   �� *DataNamePrefix+6�   �� 5   
   $��MergeID��6   $
��Left=�6"   $��
268,30,0,0q�6=   $	��Top=�6Q   �� 5   
   $
��Left=�6+   $��23��6F   $��
370,33,0,0q�6R   $
  Wrap=�6f   $	��Top=�6z   $	��180��6�   ��6   �� *	MergeId+6�   �� 5   
   $��
Attachment��6   $
��Left=�6%   $��
268,56,0,0q�6@   $	��Top=�6T   �� 5   
   $
��Left=�6.   $��23��6I   $��
370,58,0,0q�6U   $
  Wrap=�6i   $	��Top=�6}   $	��180��6�   ��6   �� *
Attachment+6�   �� 5   
   $��Docdesc��6   $
��Left=�6"   $��
268,82,0,0q�6=   $	��Top=�6Q   �� 5   
   $
��Left=�6+   $��23��6F   $��
370,84,0,0q�6R   $
  Wrap=�6f   $	��Top=�6z   $	��180��6�   ��6   �� *	Docdesc+6�   �� 5   
   $��PDF Path��6   $
��Left=�6#   $��	0,107,0,0q�6>   $	��Top=�6Q   �� 5   
   $
��Left=�6/   $��23��6J   $��
77,110,0,0q�6V   $
  Wrap=�6j   $	��Top=�6~   $	��472��6�   ��6   �� *PdfFilePath+6�   �� 5#   
   $��Packages��6   $
��Left=�6#   $��	1,133,0,0q�6>   $	��Top=�6Q   �� 5%   
    �� SelectionMode$ Single=�6   $
��Left=�6*   $	��114��6E   $��
78,136,0,0q�6R   $	��Top=�6f   $	��230��6~   ��5&      �� *UsedPackages+ �� Mode$ TwoWay=� �� SelectedItem 6E   �� *SelectedUsedPackage+.   (System.Windows.Interactivity.Interaction   Triggers 5'      /   )System.Windows.Interactivity.EventTrigger  5(         	EventName$ MouseDoubleClick��6!   .   (System.Windows.Interactivity.TriggerBase   Actions. 5)      0  *Catel.Windows.Interactivity.EventToCommand  -   &DisableAssociatedObjectOnCannotExecute .     PassEventArgsToCommand . �  �Catel.Windows.Interactivity.CommandTriggerActionBase`1[[System.Windows.FrameworkElement, PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35]]	   Command	 6+   �� *Edit+6s   5*      5,      �� 5.   
   $ Single=�6   $
��Left=�6*   $	��114��6E   $��319,136,0,0q�6R   $	��Top=�6g   $	��230��6   ��5/      �� *UnusedPackages+$ TwoWay=� 6F   �� *SelectedUnusedPackage+ 50        51      $ MouseDoubleClick��6!   . 52         .   . 	 6+   �� *Edit+6s   53      55      56      58      