   M S B A M L   `   `   `  ����[  WHelixToolkit.Wpf, Version=2014.2.13.1, Culture=neutral, PublicKeyToken=52aa3500039caf0dM8clr-namespace:HelixToolkit.Wpf;assembly=HelixToolkit.WpfHelixToolkit.Wpf  5      I EVideoPlayerWPF, Version=1.4.4.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:VideoPlayerWPF;assembly=VideoPlayerWPFVideoPlayerWPF 5      K GTelestrationWPF, Version=1.6.13.0, Culture=neutral, PublicKeyToken=nullJ6clr-namespace:TelestrationWPF;assembly=TelestrationWPFTelestrationWPF 5      F BWPFMediaKit, Version=1.4.0.0, Culture=neutral, PublicKeyToken=nullfBclr-namespace:WPFMediaKit.DirectShow.Controls;assembly=WPFMediaKitWPFMediaKit.DirectShow.Controls 5       WpfApplication1    WpfApplication1.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6@   Ght8clr-namespace:HelixToolkit.Wpf;assembly=HelixToolkit.Wpf     5      OVideoPlayerWPF4clr-namespace:VideoPlayerWPF;assembly=VideoPlayerWPF     5      RTelestrationWPF6clr-namespace:TelestrationWPF;assembly=TelestrationWPF     5      aDirectShowControlsBclr-namespace:WPFMediaKit.DirectShow.Controls;assembly=WPFMediaKit     5      -   5          �Name$  Window��5	       � Title$ 
MainWindow��5
   	   $
��1920��5   	   $
��1080��6    � WindowStyle$
 None=�6$    � WindowState$ 	Maximized=�67   .��5      �� $
��1920��6
   $
��1080��6   $
��Left=�6%   $	��Top=�6@   .+�5      �� -   5         ��Name$ scaledElements��5      $
��1920��6#   $
��1080��60   $
��Left=�6>   $	��Top=�6Y   $��0q�6q    J� RenderTransformOrigin$	 0,0&�6|   z�5      V� 5   	   .~�5   
   ��  �� ScaleX$ 1Q�6   �� 5   
   �� 5   
   T� 5   
   5   
   .+�5      � $
��1920��6   $
��1080��6    .+�5      &    HelixToolkit.Wpf.HelixViewport3D  -   5          Name$ helixViewport��5         ModelUpDirection$ 0,1,05�60   	   ShowViewCube	 .  
   ShowCameraInfo
 .    IsHeadLightEnabled .     Camera 5      =� 5       � Position$ 290, 326, -5681�6,    � LookDirection$ -209, -286, 4395�6F    � UpDirection$ 0,1,05�6f    =� FieldOfView$ 60Q�6z    � NearPlaneDistance$	 0.5Q�6�      Children. 5!      $   HelixToolkit.Wpf.DefaultLights  -   5        defaultLights��5!      (   "HelixToolkit.Wpf.FileModelVisual3D  5#         System.Windows.UIElement3D   IsHitTestVisible . -   5        	arena��   Source$ model\cube.obj��5#   R    "� 	Transform 5$      Y� 5%   	   .�5&   
   ��  �� ScaleX$ 10Q�6    �� ScaleY$ 10Q�6'    �� ScaleZ$ 10Q�63   �� 5'   
    �� Rotation 5(      �� 5)       �� Angle$ 90Q�6     �� Axis$ 0,1,05�6+   5+      S� 5,   
    S� OffsetX$ 0Q�6    S� OffsetY$ 0Q�6+    S� OffsetZ$ 0Q�67   5-   
      DefaultMaterial 5/      �� 50      .��51      u�   u� Brush  52      �� 53      ! �� Color$
! Gray��6"   " �� Opacity$" 1Q�6/   55      �� 56      # �� SpecularPower$	# 100Q�6!   $ �� Brush$ 57      �� 58      $! White��6"   $" 1Q�60   5:      5;      5=      5  /System.Windows.Media.Media3D.Viewport2DVisual3D  5?       5@      Y� 5A   	   .�5B   
   ��  5C      �� 5D      -   5        	rotationY��$ -1, 0, 05�5D   3   $ 90Q�6C   5F      S� 5G   
   $ 0Q�6   $ 1Q�6+   $ 0Q�67   5H   
   %   Geometry% 5K      k� 5L   	   & k� 	Positions5& �    ]� �	 ]���1� ����1� �� �	' k� TextureCoordinates' �   ( k� TriangleIndices( �     6}   )   Material) 5N      u� 5O   	   *   IsVisualHostMaterial* . 6   +   Visual.+ 5Q      �� -   5        $ TelestrationCanvas3D��5Q      , K� ZIndex$
, 1000��6-   $
��1200��6A   $	��600��6N   .+�5R   	   �� -   5        $ courtCanvas��5R      $
��1200��6%   $	��600��62   ��5S   
   �� 5T      $! Green��6   5V   
   #  TelestrationWPF.DrawingCanvas  5W   	   -	   5        -  Name$- 
myCanvas3D��5W   '   $y�Visible=�6;   .   CanvasWidth$
. 1200Q�6P   /   CanvasHeight$	/ 600Q�6c   0 J� IsHitTestVisible0 .  1 �� Left$1 0��6�   
2 �� Top$2 0��6�   $��0q�6�   $	��100��6�   $	��100��6�   $	, 999��6�   5X   	   5Y      5[      5]      �� 5_      $	��100��6   $
��1080��6   .+�5`      $  TelestrationWPF.DynamicPalette  -
   5        3  Name$3 myPalette3D��5`   %   $1 0��6:   $	2 833��6J   0 . $y�Visible=�6s   $
, 1000��6�   5a      5c   
   5e      5g      