   M S B A M L   `   `   `  ���� ?  ;Lab7, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Lab7.WindowsLab7.Windows  +    %Lab7.Windows.AddAndUpdatePersonWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:Lab7.Windows     -     � Title$  AddPersonWindow��$	��450��$	��300��.��� .+��� -    ��Name$ 
TitleLabel��$)��#Добавление персоны��$
��Left=�$��	10,10,0,0q�$	��Top=�$	��280��$��Center=�$��Yu Gothic UI Light)�$��18(� � UseLayoutRounding .  �� -    ��Name$ SurnameTextbox��$
��Left=�$��23��$��	50,62,0,0q� �� TextWrapping$
 Wrap=�$�� ��$	��Top=�$	��200��$��Center=��� -   $ SurnameLabel��$��Фамилия��$
��Left=�$��	50,35,0,0q�$	��Top=�$	��200��$��Center=�$��Yu Gothic UI Light)��� -   $ NameTextbox��$
��Left=�$��23��$��
50,110,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��200��$��Center=��� -   $ 	NameLabel��$��Имя��$
��Left=�$��	50,84,0,0q�$	��Top=�$	��200��$��Center=�$��Yu Gothic UI Light)��� -   $ PatronymicTextbox��$
��Left=�$��23��$��
50,164,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��200��$��Center=��� -   $ PatronymicLabel��$��Отчество��$
��Left=�$��
50,138,0,0q�$	��Top=�$	��200��$��Center=�$��Yu Gothic UI Light)��� -	   $ DateOfBirthTextbox��$
��Left=�$��23��$��
50,213,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��200��$��Center=��� -
   $ DayOfBirthLabel��$��День рождения��$
��Left=�$��
50,187,0,0q�$	��Top=�$	��200��$��Center=�$��Yu Gothic UI Light)��� -    ��Name$ GenderCombobox��$
��Left=�$��
50,265,0,0q�$	��Top=�$	��200��$��23��.@��� $��Мужской���� $��Женский���� -   $ GenderLabel��$��Пол��$
��Left=�$��
50,236,0,0q�$	��Top=�$	��200��$��Center=�$��Yu Gothic UI Light)��� -   $ AddressTextbox��$
��Left=�$��23��$��
50,314,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��200��$��Center=��� -   $ AddressLabel��$��
Адрес��$
��Left=�$��
50,288,0,0q�$	��Top=�$	��200��$��Center=�$��Yu Gothic UI Light)��� -   $ 
ErrorLabel��$�� ��$
��Left=�$��0,342,-0.4,0q�$	��Top=�$	��294��$��Center=�$��Yu Gothic UI Light)�$��10(����	#FFD02424$y�Hidden=��� -    ��Name$ Button��$��Добавить��$
��Left=�$��
50,368,0,0q�$	��Top=�$	��200��$��30��