   M S B A M L   `   `   `  ����B  >Trabajo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:TrabajoTrabajo  5   	       Trabajo.IngresarPeliculas   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Trabajo     5   	     � Title$  IngresarPeliculas��5   	   $	��450��6#   $	��800��60   ��5	      �� 5
   
    �� ImageSource$ Imagenes/nuevo.jpg��6   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   � $��0��6   .+�5      �� -   5         ��Name$ btnNuevo��5      .��5      �� $��20��6   $	��50 ��6$   $��Iconos/agregar.png��5      6!   5      �� 5      -   5        $ 	btnEditar��5      .��5      �� $��20��6   $	��50 ��6$   $��Iconos/editar.png��5      6    5      �� 5      -   5        $ 
btnGuardar��5      .��5      �� $��20��6   $	��50 ��6$   $��Iconos/guardar.png��5      6!   5       �� 5!      -   5        $ btnCancelar��5!      .��5"      �� $��20��6   $	��50 ��6$   $��Iconos/cancelar.png��5#      6"   5$      �� 5%      -   5        $ btnEliminar��5%      .��5&      �� $��20��6   $	��50 ��6$   $��Iconos/eliminar.png��5'      6"   5(      �� 5)      -   5        $ btnSalir��5*      $��30��5)      $	��50 ��6!   .��5*   ,   Salir63   �� 5+      -   5        $ btnExportar��5+      .��6D   
Exportar6N   5,      � 5-   
   $��1��6   .+�5.      ��  �� Orientation$ 
Horizontal=�6   .+�5/      �� $
��Bold"�6   ���	#FFF7F4F4Id:6J   �� 50      $��50��6   6*   51      �� 52      $ 
Horizontal=�6   .+�53      �� $
��Bold"�6   ���	#FFF7F4F4.��6A   Nombre de la pelicula6X   �� 54      -   5        $��	txbNombre��54      $	��100��6+   69   55      �� 56      $ 
Horizontal=�6   .+�57      �� $
��Bold"�6   ���	#FFF7F4F4.��6A   Costo6H   �� 58      -	   5         ��Name$ txbCosto��58      $	��130��6,   6:   59      �� 5:      $ 
Horizontal=�6   .+�5;      �� $
��Bold"�6   ���	#FFF7F4F4.��6A   Descripcion6N   �� 5<      -
   5        $ txbDescripcion��5<      $	��130��62   6@   5=      �� 5>      $ 
Horizontal=�6   .+�5?      �� $
��Bold"�6   ���	#FFF7F4F4.��6A   Fecha De Estreno6S   (  "System.Windows.Controls.DatePicker  5@      -   5          Name$ dtpFechaDeEstreno��5@      6:   5A      5C      &   System.Windows.Controls.DataGrid  5D   
   -   5          Name$ dtgTabla��5D       $��2��6   64   5E      5F      