   M S B A M L   `   `   `  ���� K  GFlowchart_Editor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Flowchart_Editor.ViewFlowchart_Editor.View  o<clr-namespace:Flowchart_Editor.View.ConditionCaseFirstOption.Flowchart_Editor.View.ConditionCaseFirstOption  q=clr-namespace:Flowchart_Editor.View.ConditionCaseSecondOption/Flowchart_Editor.View.ConditionCaseSecondOption  !    Flowchart_Editor.MainWindow   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  1control#clr-namespace:Flowchart_Editor.View  Kcontrol1<clr-namespace:Flowchart_Editor.View.ConditionCaseFirstOption  Lcontrol2=clr-namespace:Flowchart_Editor.View.ConditionCaseSecondOption    � Title$  Flowchart Editor��$
��1200��$
��1820�� � 	Resources    OpenMenu �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  	CloseMenu��%�  &	        &	 �	    �� .��U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�$ blockLayoutMenu��.\�  $ 0��$ 0Q�  $ 0:0:0.5��$	 250Q�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�$ blockLayoutMenu��.\�  $ 0��$ 0Q�  $ 0:0:0.5��$ 50Q�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�$ StackPanelMenu��.\�  $ 0��$ 0Q�  $ 0:0:0.5��$	 250Q�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�$ listViewItem��.\�  $ 0��$
 -250Q�  $ 0:0:0.5��$
 -250Q�  $ 0:0:0.7��$ 0Q�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�$ itemViewSave��.\�  $ 0��$
 -250Q�  $ 0:0:0.5��$
 -250Q�  $ 0:0:0.9��$ 0Q�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�$ itemViewUpload��.\�  $ 0��$
 -250Q�  $ 0:0:0.5��$
 -250Q�  $ 0:0:1.1��$ 0Q�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�$ itemViewSaveImg��.\�  $ 0��$
 -250Q�  $ 0:0:0.5��$
 -250Q�  $ 0:0:1.3��$ 0Q�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�$ listViewItem3��.\�  $ 0��$
 -250Q�  $ 0:0:0.5��$
 -250Q�  $ 0:0:1.5��$ 0Q�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�$ listViewItem4��.\�  $ 0��$
 -250Q�  $ 0:0:0.5��$
 -250Q�  $ 0:0:1.7��$ 0Q�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�$ listViewItem5��.\�  $ 0��$
 -250Q�  $ 0:0:0.5��$
 -250Q�  $ 0:0:1.9��$ 0Q�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�$ listViewItem6��.\�  $ 0��$
 -250Q�  $ 0:0:0.5��$
 -250Q�  $ 0:0:2.1��$ 0Q�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�$ listViewItem7��.\�  $ 0��$
 -250Q�  $ 0:0:0.5��$
 -250Q�  $ 0:0:2.3��$ 0Q�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�$ listViewItem8��.\�  $ 0��$
 -250Q�  $ 0:0:0.5��$
 -250Q�  $ 0:0:2.5��$ 0Q��� .��U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�$ blockLayoutMenu��.\�  $ 0��$	 250Q�  $ 0:0:0.5��$ 0Q�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�$ blockLayoutMenu��.\�  $ 0��$ 50Q�  $ 0:0:0.5��$ 0Q�U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�$ StackPanelMenu��.\�  $ 0��$	 250Q�  $ 0:0:0.5��$ 0Q� � Triggers :�  :� RoutedEvent$ ButtonBase.Click�� :� 
SourceName$ buttonOpenMenu��.[��� #��[  :� $ ButtonBase.Click��$ buttonCloseMenu��.[��� -   	 ��Name$	 CloseMenu_BeginStoryboard��#��[ .���   GridLayoutMenuStyle#���  .+��� -   
 ��Name$
 StackPanelMenu��$	��250��$
��Left=�$��
-250 0 0 0q� J� RenderTransformOrigin$ 0.5,0.5&�z�V� .~��� �� �� T� .+��� .@��� -   $��listViewItem��$��60��$ 0.5,0.5&�z�V� .~��� �� �� T� .����  �� Orientation$ 
Horizontal=�$
��10 0q�.+�'  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 Home=�$��30��$��30��$��Center=�$��5q�����  �� 
TargetType"  .���  �� Property � �� �� Value �	#FF040205 �� Triggers ��  �� Binding ��  �� ElementName$ toggleButtonStyleTheme�� �� Path$ 	IsChecked� �� Value True.a���  � �� �	#FFF9F9FB�� $��Главная��$��12(�$	��175��
������ �� -   $��itemViewSave��$��60��$ 0.5,0.5&�z�V� .~��� �� �� T� .���� $ 
Horizontal=�$
��10 0q�.+�  $ ContentSave=�$��30��$��30��$��Center=�$��5q����� "  .���  � �� �	#FF040205 ��  �� $ toggleButtonStyleTheme��$ 	IsChecked� True.a���  � �� �	#FFF9F9FB�� -   $%��Сохранить проект��$��12(�$	��175��
������ �� -   $��itemViewUpload��$��60��$ 0.5,0.5&�z�V� .~��� �� �� T� .���� $ 
Horizontal=�$
��10 0q�.+�  $ upload=�$��30��$��30��$��Center=�$��5q����� "  .���  � �� �	#FF040205 ��  �� $ toggleButtonStyleTheme��$ 	IsChecked� True.a���  � �� �	#FFF9F9FB�� -   $	��175��$%��Загрузить проект��
������ $��12(��� -   $��itemViewSaveImg��$��60��$ 0.5,0.5&�z�V� .~��� �� �� T� .���� $ 
Horizontal=�$
��10 0q�.+�  $ Image=�$��30��$��30��$��Center=�$��5q����� "  .���  � �� �	#FF040205 ��  �� $ toggleButtonStyleTheme��$ 	IsChecked� True.a���  � �� �	#FFF9F9FB�� -	   $	��175��$/��)Сохранить изображение��
������ $��12(��� -
    ��Name$ listViewItem3��$��60��$ 0.5,0.5&�z�V� .~��� �� �� T� .���� $ 
Horizontal=�$
��10 0q�.+�  $
 User=�$��30��$��30��$��Center=�$��5q����� "  .���  � �� �	#FF040205 ��  �� $ toggleButtonStyleTheme��$ 	IsChecked� True.a���  � �� �	#FFF9F9FB�� $	��175��$��Авторизация��
������ $��12(��� -   $ listViewItem4��$��60��$ 0.5,0.5&�z�V� .~��� �� �� T� .���� $ 
Horizontal=�$
��10 0q�.+�  $ Printer=�$��30��$��30��$��Center=�$��5q����� "  .���  � �� �	#FF040205 ��  �� $ toggleButtonStyleTheme��$ 	IsChecked� True.a���  � �� �	#FFF9F9FB�� -   $	��175��$��Печать��
������ $��12(��� -   $ listViewItem5��$��60��$ 0.5,0.5&�z�V� .~��� �� �� T� .���� $ 
Horizontal=�$
��10 0q�.+�  $ UserAdd=�$��30��$��30��$��Center=�$��5q����� "  .���  � �� �	#FF040205 ��  �� $ toggleButtonStyleTheme��$ 	IsChecked� True.a���  � �� �	#FFF9F9FB�� $	��175��$��Регистрация��
������ $��12(��� -   $ listViewItem6��$��60��$ 0.5,0.5&�z�V� .~��� �� �� T� .���� $ 
Horizontal=�$
��10 0q�.+�  $ 
Assignment=�$��30��$��30��$��Center=�$��5q����� "  .���  � �� �	#FF040205 ��  �� $ toggleButtonStyleTheme��$ 	IsChecked� True.a���  � �� �	#FFF9F9FB�� $	��175��$#��Список проектов��
������ $��12(��� -   $ listViewItem7��$��60��$ 0.5,0.5&�z�V� .~��� �� �� T� .���� $ 
Horizontal=�$
��10 0q�.+�  $ Information=�$��30��$��30��$��Center=�$��5q����� "  .���  � �� �	#FF040205 ��  �� $ toggleButtonStyleTheme��$ 	IsChecked� True.a���  � �� �	#FFF9F9FB�� $	��175��$��Информация��
������ $��12(��� -   $ listViewItem8��$��60��$ 0.5,0.5&�z�V� .~��� �� �� T� .���� $ 
Horizontal=�$
��10 0q�.+�  $
 Chat=�$��30��$��30��$��Center=�$��5q����� "  .���  � �� �	#FF040205 ��  �� $ toggleButtonStyleTheme��$ 	IsChecked� True.a���  � �� �	#FFF9F9FB�� $	��175��$��Поддержка��
������ $��12(��� -   $ listViewItem9��$��60��$ 0.5,0.5&�z�V� .~��� �� �� T� .���� $ 
Horizontal=�.+�d� -   $��toggleButtonStyleTheme��$��50��$��50��$��Center=�$��5q����	#FF040205���	#FF040205�� $��10q�$��Center=�  TextBlockToggleButtonStyle#���  � -   $��blockLayoutMenu��$ 0.5,0.5&�  	GridStyle#���  z�V� .~��� �� �� T� .+�� #���   � RowDefinitions �� $��35 ��� $��* � � ColumnDefinitions �� $��5 ��� $	��150 ��� $	��160 ��� $��* �.+��� $��2��$��3��.���  �� $��75 ��� $��75 ��� $	��175 ��� $	��120 ��� $��75 ��� $��75 ��� $��75 ��� $��75 ��� $��75 ��� $��75 ��� $��75 ��� $��75 ��� $��30 � �� $	��150 ��� $	��160 �.+�+   %Flowchart_Editor.View.ActionBlockView  +   %Flowchart_Editor.View.ActionBlockView   	MouseMove$ MouseMoveBlock��$��0��$��0���� $��Блок (1)��$��10(�$��Center=�$
��Left=�$��0��$��1��  TextBlockStyle#���  .   (Flowchart_Editor.View.ConditionBlockView  .   (Flowchart_Editor.View.ConditionBlockView   	MouseMove$ MouseMoveBlock��$��1��$��0���� $��Условие (2)��$��10(�$��Center=�$
��Left=�$��1��$��1��#���  M   GFlowchart_Editor.View.ConditionCaseFirstOption.ConditionCaseFirstOption  $��2��$��0���� $��2��$��1��.+��  �� $��35 ��� $��35 ��� $��35 �.+��� $��Условие (3)��$��10(�$��0��$��Center=�$
��Left=�$
��Wrap=�#���  �� -   $)��#CountLineOfConditionCaseFirstOption��$��1��)  #MaterialDesignThemes.Wpf.HintAssist   Hint$# Количесво линий�� % !MaterialDesignFloatingHintTextBox#��[ �� -   ���#4e6775$��2��$	��120��
�������$��Добавить��O	   IFlowchart_Editor.View.ConditionCaseSecondOption.ConditionCaseSecondOption	  $��3��$��0���� $��3��$��1��.+��  �� $��35 ��� $��35 ��� $��35 �.+��� $��Условие (4)��$��10(�$��0��$��Center=�$
��Left=�$
��Wrap=�#���  �� -   $*��$CountLineOfConditionCaseSecondOption��$��1��$# Количесво линий��#��[ �� -   ���#4e6775$��2��$	��120��
�������$��Добавить��-
   'Flowchart_Editor.View.StartEndBlockView
  -   'Flowchart_Editor.View.StartEndBlockView   	MouseMove$ MouseMoveBlock��$��4��$��0���� $#��Начало / Конец (5)��$��10(�$��1��$��4��$��Center=�$
��Left=�#���  0   *Flowchart_Editor.View.InputOutputBlockView  0   *Flowchart_Editor.View.InputOutputBlockView   	MouseMove$ MouseMoveBlock��$��5��$��0���� $��Ввод / Вывод (6)��$��10(�$��1��$��5��$��Center=�$
��Left=�#���  /   )Flowchart_Editor.View.SubroutineBlockView  /   )Flowchart_Editor.View.SubroutineBlockView   	MouseMove$ MouseMoveBlock��$��6��$��0���� $"��Подпрограмма (7)��$��10(�$��2��$��6��$��Center=�$
��Left=�#���  -   'Flowchart_Editor.View.CycleBlockForView  -   'Flowchart_Editor.View.CycleBlockForView   	MouseMove$ MouseMoveBlock��$��7��$��0���� $��Цикл (8) for��$��10(�$��1��$��7��$��Center=�$
��Left=�#���  4   .Flowchart_Editor.View.CycleBlockWhileBeginView  4   .Flowchart_Editor.View.CycleBlockWhileBeginView    	MouseMove$  MouseMoveBlock��$��8��$��0���� $1��+Цикл (9) do while, while (Начало)��$��10(�$��1��$��8��$��Center=�$
��Left=�#���  2   ,Flowchart_Editor.View.CycleBlockWhileEndView  2   ,Flowchart_Editor.View.CycleBlockWhileEndView!   	MouseMove$! MouseMoveBlock��$��9��$��0���� $0��*Цикл (10) do while, while (Конец)��$��10(�$��1��$��9��$��Center=�$
��Left=�#���  )   #Flowchart_Editor.View.LinkBlockView  )   #Flowchart_Editor.View.LinkBlockView"   	MouseMove$" MouseMoveBlock��$��0��$��10���� $��Ссылка (11)��$��10(�$��1��$��10��$��Center=�$
��Left=�#���  �� -   $��0��$��11��$��75��$	��150��.+�'   !Flowchart_Editor.View.CommentView  �� $ ��Комментарий(12)��$��10(�$��1��$��11��$��Center=�$
��Left=�#���  � $��4��$��12�� �� $��60 ��� $	��150 ��� $��90 ��� $��70 ��� $��60 ��� $��70 ��� $��60 ��� $��70 ��� $��80 ��� $	��150 ��� $��80 ��� $	��150 ��� $��* � �� $��40 ��� $
��850* �.+��� -   $��destination��# J� 	AllowDrop$
# True��$��13��$��1��  CanvasStyle#���  �� $��Шрифт:��$	��Top=�$��Center=�$��0��$��0��$	��0,9q�#���  �� -   $��listOfFontFamily��$��1��$��Center=�$	��Top=�
���   �$	��0,5q�$	��130��.@�*�Times New Roman)�*�Calibri)�*�	Arial)��� $ ��Размер текста:��$��2��$	��Top=�$��Center=�#���  $	��0,9q��� -   $��fontSizeComboBox��
���   �$��3��$��60��$��Center=�$	��Top=�$	��0,5q�.@��� .��8�� .��10�� .��12�� .��14�� .��16�� .��18�� .��20�� .��22�� .��24�� .��26�� $��Ширина:��$��4��$	��Top=�$��Center=�#���  $	��0,9q��� -   $��blockWidthComboBox��
���   �$��5��$��60��$��Center=�$	��Top=�$	��0,5q��� $��Высота:��$��6��$	��Top=�$��Center=�#���  $	��0,9q��� -   $��blockHeightComboBox��
���   �$��7��$��60��$��Center=�$	��Top=�$	��0,5q��� $��Первый блок:��$��8��$	��Top=�$��Center=�#���  $	��0,9q��� -   $#��textNameOfFirstBlockToConnect��$��9��$	��Top=�$��Center=�#���  $	��0,9q��� $��Второй блок:��$��10��$	��Top=�$��Center=�#���  $	��0,9q��� -   $$��textNameOfSecondBlockToConnect��$��11��$	��Top=�$��Center=�#���  $	��0,9q��� -    $��buttonCloseMenu��$��0��$��1�� 0 ,MaterialDesignFloatingActionMiniAccentButton#��[ $��30��$��30��$��0q�$	��Top=�$
��Left=�$��5q�$y�	Collapsed=���Z� ��Z� .��  $
 Menu=��� -!   $��buttonOpenMenu��$��0��$��1��#��[ $��30��$��30��$��0q�$	��Top=�$
��Left=�$��5q���Z� ��Z� .��  $
 Menu=�