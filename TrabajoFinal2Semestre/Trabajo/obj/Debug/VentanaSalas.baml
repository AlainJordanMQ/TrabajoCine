   M S B A M L   `   `   `  ����B  >Trabajo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:TrabajoTrabajo  5   	       Trabajo.VentanaSalas   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Trabajo     5   	     � Title$  VentanaSalas��5   	   $	��450��6   $	��800��6+   ��5	      �� 5
   
    �� ImageSource$ Imagenes/nuevo2.jpg��6   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   � $��0��6   .+�5      �� -   5         ��Name$ btnNuevo��5      .��5      �� $��20��6   $��50��6$   $��Iconos/agregar.png��6/   6M   5      �� 5      -   5        $ 	btnEditar��5      .��5      �� $��20��6   $��50��6$   $��Iconos/editar.png��6/   6L   5      �� 5      -   5        $ 
btnGuardar��5      .��5      �� $��20��6   $��50��6$   $��Iconos/guardar.png��6/   6M   5      �� 5      -   5        $ btnCancelar��5      .��5      �� $��20��6   $��50��6$   $��Iconos/cancelar.png��6/   6N   5       �� 5!      -   5        $ btnEliminar��5!      .��5"      �� $��20��6   $��50��6$   $��Iconos/eliminar.png��6/   6N   5#      �� 5$      -   5        $ btnSalir��5$   ,   $��30��6   $��50��6!   .��6U   Salir6\   5%      � 5&   
   $��1��6   .+�5'      ��  �� Orientation$ 
Horizontal=�6   .+�5(      �� $
��Bold"�6   ���	#FFF7F4F4Id:6J   �� 5)      $��50��6   6*   5*      �� 5+      $ 
Horizontal=�6   .+�5,      �� $
��Bold"�6   ���	#FFF7F4F4.��6A   Nombre de la sala6T   �� 5-      -   5        $��	txbNombre��5-      $	��100��6+   69   5.      �� 5/      $ 
Horizontal=�6   .+�50      �� $
��Bold"�6   ���	#FFF7F4F4.��6A   Cantidad de asientos6W   �� 51      -   5         ��Name$ txbCantidadAsientos��51      $	��130��67   6E   52      54      &   System.Windows.Controls.DataGrid  55   
   -	   5          Name$ dtgTabla��55       $��2��6   64   56      57      