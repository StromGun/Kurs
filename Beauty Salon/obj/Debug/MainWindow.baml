   M S B A M L   `   `   `  ????G  CBeauty Salon, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Beauty_SalonBeauty_Salon  5   	       Beauty_Salon.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Beauty_Salon     5   	     ? Title$  Beauty Salon??5   	   $	??600??6   $	??800??6.   $5??//Beauty Salon;component/Resources/Fonts/#Caveat)?6=   $
??Bold"?6z    ? Icon$ Resources/logo.png??6?   .??5	      ?  ? RowDefinitions 5
   
   ?? 5      $
??0.3* ?6   $??90??6*   ?? 5      $
??0.2* ?6   $??40??6*   ?? 5      $??2* ?6   ?? 5      $
??0.2* ?6   $??50??6*   .+?5   
   ?    ColorCommon#??[  6   $??0q?69   .+?5      ?? $??Resources/logo.png??6   $
??Left=?60   $??	20 0 0 10q?6K   ?? 5      $??Center=?6S   $??Center=?6p   $??30(?6?   $
??auto??6?   ??6   ??  ?? ElementName$ 	FrameMain?? ?? Path$ Content.Title?6?   ?? 5      -   5         ??Name$ BtnBack??5      $??Right=?6&   .??5      ??  ?? Orientation$ 
Horizontal=?6   .+?5      ?? $??Resources/undo.png??6   ?? 5      $??
Назад??6    $	??5 0q?6-   5      5      5      ?? 5   
   $??1??6   $ 
Horizontal=?6"   ???	#FFF9D0DF$??0q?6R   .+?5      ?? -   5        $ BtnServices??5   &   $??Услуги??6     miniBtn#??[ 6U   ?? 5       -   5        $ 
BtnClients??5    '   $??Клиенты??6   #??[ 6T   ?? 5!      -   5        $ 	BtnOrders??5!   &   $??Заказы??6   #??[ 6Q   5"       ? 5$   
   -   5        $??	FrameMain??5$   =   $??2??6     ? NavigationUIVisibility$ Hidden=?6     ColorDefault#??[ 6N   ? 5&   
   $??3??6   #??[  6   5(      5)      