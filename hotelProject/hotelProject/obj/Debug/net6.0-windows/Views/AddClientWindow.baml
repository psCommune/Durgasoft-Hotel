   M S B A M L   `   `   `  ????G  ChotelProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:hotelProject.ViewshotelProject.Views  5   	   (    "hotelProject.Views.AddClientWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:hotelProject.Views     5   	     ? Title$7  1Durgasoft Hotel | Добавить клиента??5   	   $	??450??64   $	??600??6A   .??5	      ?  ? RowDefinitions 5
   
   ?? 5      $??* ?6   ?? 5      $??* ?6   ?? 5      $??30 ?6   ?? 5      $??* ?6   ?? 5      $??* ?6    ? ColumnDefinitions 5   
   ?? 5      ?? 5      .+?5   
   ?? $??0??6   $??2??6   $??20q?6M   ??63   ?? *
Fullname+6M   ?? 5   
   $??1??6   $??2??6   $??20q?6P   ??63   ?? *PhoneNumber+6P   ?? 5   
   $??2??6   $ ??Дата рождения:??6!   $??20,0,0,0q?67   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ birthdayPicker??5   W   $??3??67   $??	20,0,20,0q?6D   $??2??6o      SelectedDate 6   ?? *
Birthday+6o   ?? 5   
   -   5        $??4??5      $??2??6   $??Добавить??62   $??20q?6E   6Q   5      5      