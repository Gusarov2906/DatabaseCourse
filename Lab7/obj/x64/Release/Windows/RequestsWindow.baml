   M S B A M L   `   `   `  ���� ?  ;Lab7, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Lab7.WindowsLab7.Windows  !    Lab7.Windows.RequestsWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:Lab7.Windows     -     � Title$  RequestsWindow��$	��600��$	��800��.��� .+�&   System.Windows.Controls.DataGrid  -     Name$ 	DataTable��$
��Left=�$	��550��$��
269,10,0,0q�$	��Top=�$	��515��   
IsReadOnly . �� -    ��Name$ Request1��$D��>Все группы с количетсво человек >15��$
��Left=�$��	10,10,0,0q�$	��Top=�$	��240��$��30���� -   $ Request2��$(��"Все студенты из М-11��$
��Left=�$��	10,58,0,0q�$	��Top=�$	��240��$��30���� -   $ Request3��$6��0Группы по кол-во студентов��$
��Left=�$��
10,106,0,0q�$	��Top=�$	��240��$��30���� -   $ Request4��$?��9Все студенты конкретной группы��$
��Left=�$��
10,171,0,0q�$	��Top=�$	��240��$��30���� -   $ Request5��$3��-Все группы на факультете��$
��Left=�$��
10,245,0,0q�$	��Top=�$	��240��$��30���� -   $ Request6��$+��%Все персоны по имени��$
��Left=�$��
10,320,0,0q�$	��Top=�$	��240��$��30���� -	   $ Request7��$%��Добавить персону��$
��Left=�$��
10,419,0,0q�$	��Top=�$	��240��$��30���� -
   $ Request8��$:��4Удалить студентов группы М-12��$
��Left=�$��
10,466,0,0q�$	��Top=�$	��240��$��30���� -   $ Request9��$8��2Понизить вместимость групп��$
��Left=�$��
10,511,0,0q�$	��Top=�$	��240��$��30���� -    ��Name$ Param1��$
��Left=�$��34��$��
10,206,0,0q� �� TextWrapping$
 Wrap=�$�� ��$	��Top=�$	��240��$��Center=��� -   $ Param2��$
��Left=�$��34��$��
10,281,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��240��$��Center=��� -   $ Param3��$
��Left=�$��34��$��
10,357,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��240��$��Center=��� -    ��Name$ 
ErrorLabel��$�� ��$
��Left=�$��
269,51,0,0q�$	��Top=�$	��515��$��Center=�$��Yu Gothic UI Light)�$��12(����	#FFD02424$y�Hidden=�