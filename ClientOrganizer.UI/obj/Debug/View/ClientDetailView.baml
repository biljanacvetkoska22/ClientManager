   M S B A M L   `   `   `  ����M  IClientOrganizer.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:ClientOrganizer.UI.ViewClientOrganizer.UI.View  5      .    (ClientOrganizer.UI.View.ClientDetailView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:ClientOrganizer.UI.View     5      .��5	      � .+�5
   
   �   � RowDefinitions  5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $��* �6    .+�5      �� $��	Full Name��6   $��
10 10 10 0q�6(   �� 5      $��1��6   $��
10 0 10 10q�5   D   ��5   #   �� *Client.FullName+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5   D   �� 5!      $��2��6   $��Party Id��6!   $
��10 0q�64   �� 5"      $��3��6   $��
10 0 10 10q�5#   D   ��5"   #   �� *Client.PartyId+$ TwoWay=�$ PropertyChanged=�5#   D   �� 5%      $��4��6   $��
Party Code��6!   $
��10 0q�66   �� 5&      $��5��6   $��
10 0 10 10q�5'   D   ��5&   #   �� *Client.PartyCode+$ TwoWay=�$ PropertyChanged=�5'   D   �� 5)      $��6��6   $��Tax Code��6!   $
��10 0q�64   �� 5*      $��7��6   $��
10 0 10 10q�5+   D   ��5*   #   �� *Client.TaxCode+$ TwoWay=�$ PropertyChanged=�5+   D   �� 5-      $��8��6   $��Country Code��6!   $
��10 0q�68   �� 5.      $��9��6   $��
10 0 10 10q�5/   D   ��5.   #   �� *Client.CountryCode+$ TwoWay=�$ PropertyChanged=�5/   D   �� 51      $��10��6   $��Registration Date��6"   $
��10 0q�6>   �� 52      $��11��6   $��
10 0 10 10q�53   D   ��52   $   �� *Client.RegistrationDate+$ TwoWay=�$ PropertyChanged=�53   D   �� 55      $��12��6   $��Client Type��6"   $
��10 0q�68   �� 56      $��13��6   $��
10 0 10 10q�57   D   ��56   $   �� *Client.ClientType+$ TwoWay=�$ PropertyChanged=�57   D   �� 59      $��14��6    �� Orientation$ 
Horizontal=�6'   .+�5:      �� $
��Save��6   $	��125��6(   $��10q�64   ��5;      �� *SaveCommand+�� 5<      $��Delete��6   $	��120��6*   $��10q�66   ��5=      �� *DeleteCommand+5>      5?      5@      5A      