   M S B A M L   `   `   `  ����H  DTrabajoVentas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:TrabajoTrabajo  5   	       Trabajo.VentaBoletos   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Trabajo     5   	     � Title$  VentaBoletos��5   	   $	��450��6   $	��800��6+   ��5	      �� 5
   
    �� ImageSource$/ )Imagenes/color-slices-wallpaper-57040.jpg��6   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   � $��0��6   .+�5      �� $
��Bold"�6   ���	#FFF7F4F4.��6>   	Nombre:6G   �� 5      -   5         ��Name$ 	txbNombre��5      $	��150��6)   67   5      � 5   
   $��1��6   .+�5      �� $
��Bold"�6   ���	#FFF7F4F4.��6>   
Pelicula6H   �� 5      -   5         ��Name$ cmbPelicula��5   #   $	��100��6   6:   5      � 5    
   $��2��6   .+�5!      �� $
��Bold"�6   ���	#FFF7F4F4.��6>   Sala6D   �� 5"      -   5        $ cmbSala��5"   #   $	��100��6   67   �� 5#      -   5         ��Name$ 
btnAceptar��5#      .��6B   	Aceptar6K   5$      � 5%   
   $��3��6   .+�5&      �� $
��Bold"�6   ���	#FFF7F4F4.��6>   No.Asiento Disponibles6V   �� 5(      -   5        $ cmbNoAsiento��5(      6/   5)      � 5*   
   $��4��6   .+�5+      �� $
��Bold"�6   ���	#FFF7F4F4.��6>   Dulces6F   �� 5,      -   5        $ cmbDulce��5,   #   $	��100��6   67   5-      � 5.   
   $��5��6   .+�5/      �� $
��Bold"�6   ���	#FFF7F4F4.��6>   Total a Pagar6M   �� 50      -   5        $ txbTotalPagar��50   "   $	��100��6   6;   �� 51      -   5        $ btnCalcularPagar��51      .��6N   
Calcular6X   �� 52      $
��Bold"�6   ���	#FFF7F4F4.��6>   Dinero Recibido6O   �� 53      -	   5        $ txbRecibido��53   "   $	��100��6   69   �� 54      $
��Bold"�6   ���	#FFF7F4F4.��6>   Cambio6F   �� 55      -
   5        $ 	txbCambio��55   "   $	��100��6   67   �� 56      -   5        $ txbCalcular��56      .��6D   
Calcular6N   57      � 58   
   $��6��6   .+�59      �� -   5        $	��100��59      $��30��6!   .��6B   	Finalizar6M   �� 5:      -   5        $ btnCancelar��5:   -   $	��100��6   $��30��6!   .��6\   
Cancelar6f   �� 5;      -   5        $ btnSalir��5;   .   $	��100��6   $��30��6"   .��6W   Salir6^   5<      &   System.Windows.Controls.DataGrid  5=   
   -   5          Name$ dtgTabla��5=       $��7��6   64   5?      5@      