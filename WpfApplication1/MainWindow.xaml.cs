using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using TelestrationWPF;
using WPF_VCS_Common;
using WPFMediaKit;
using HelixToolkit;
using HelixToolkit.Wpf;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public double scalingValue = 1;

        string controlPanelPaletteButton;
        Color controlPanelColorButton;
        public static TelestrationWPF.AvailableColors availColors = new TelestrationWPF.AvailableColors();
        private const string PALETTE_COLOR_FILE = "colorpalette.xml";

        public MainWindow()
        {
            InitializeComponent();

            load3DTelestrationPalette();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Scale the entire window for different resolutions
            scalingValue = Convert.ToDouble(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) / 1080;
            ScaleTransform myScaleTransform = new ScaleTransform();
            myScaleTransform.ScaleY = scalingValue;
            myScaleTransform.ScaleX = scalingValue;
            myScaleTransform.CenterX = .5;
            myScaleTransform.CenterY = .5;

            RotateTransform myRotateTransform = new RotateTransform();
            myRotateTransform.Angle = 0;

            TranslateTransform myTranslate = new TranslateTransform();
            myTranslate.X = 0;
            myTranslate.Y = 0;

            SkewTransform mySkew = new SkewTransform();
            mySkew.AngleX = 0;
            mySkew.AngleY = 0;

            TransformGroup myTransformGroup = new TransformGroup();
            myTransformGroup.Children.Add(myScaleTransform);
            myTransformGroup.Children.Add(myRotateTransform);
            myTransformGroup.Children.Add(myTranslate);
            myTransformGroup.Children.Add(mySkew);

            scaledElements.RenderTransform = myTransformGroup;
        }


        public void load3DTelestrationPalette()
        {
            // 3D palette
            myPalette3D.PaletteRows = 5;
            myPalette3D.PaletteColumns = 1;

            SolidColorBrush scb = new SolidColorBrush();
            Color teleBGColor = new Color();
            teleBGColor = (Color)System.Windows.Media.ColorConverter.ConvertFromString("#D7D4D5");
            scb = new SolidColorBrush(teleBGColor);
            myPalette3D.AddToolButton(PaletteButton.TYPE_DRAW_ARROW_DESC, 60, 60, scb, 50, 50, false, false, 1, 1);
            myPalette3D.AddToolButton(PaletteButton.TYPE_X_HL_DESC, 60, 60, scb, 50, 50, false, false, 2, 1);
            myPalette3D.AddToolButton(PaletteButton.TYPE_SPIN_HL_DESC, 60, 60, scb, 50, 50, false, false, 3, 1);
            myPalette3D.AddToolButton(PaletteButton.TYPE_UNDO_DESC, 60, 60, scb, 50, 50, false, false, 4, 1);
            myPalette3D.AddToolButton(PaletteButton.TYPE_UNDOALL_DESC, 60, 60, scb, 50, 50, false, false, 5, 1);

            myPalette3D.InitializePalette();
            myPalette3D.SelectDefaultButtons();
            myPalette3D.CloseMe(true);

            SetDrawingCanvasDefaults(myPalette3D.CurrentColor, myPalette3D.CurrentTool);

            myPalette3D.AddHandler(PaletteButton.PaletteButtonPressedEvent, new RoutedEventHandler(PaletteButtonPressedHandler)); 
        }

        private void PaletteButtonPressedHandler(object sender, RoutedEventArgs e)
        {
            MainWindow theMainWindow = (MainWindow)Application.Current.MainWindow;
            DrawingCanvas canvas3D = theMainWindow.myCanvas3D;

            try
            {
                if (e.OriginalSource != null)
                {
                    // code here to perform button press actions for the palette
                    // get a reference to the Palette button
                    PaletteButton pb = e.OriginalSource as PaletteButton;

                    if (pb.ButtonType == PaletteButton.TYPE_PALETTE_DESC && sender == myPalette3D)
                    {
                        switch (myPalette3D.PaletteIsOpen)
                        {
                            case false:
                                myPalette3D.OpenMe(true);
                                canvas3D.IsHitTestVisible = true;
                                SetDrawingCanvasDefaults(myPalette3D.CurrentColor, myPalette3D.CurrentTool);
                                break;
                            case true:
                                myPalette3D.CloseMe(true);
                                canvas3D.IsHitTestVisible = false;
                                break;
                        }
                    }
                    else
                    {
                        // set the properties of the drawing canvas based on the button type
                        switch (pb.ButtonType)
                        {
                            case PaletteButton.TYPE_COLOR_DESC:
                                controlPanelColorButton = pb.ButtonColor;

                                canvas3D.CurrentDrawColor = pb.ButtonColor;
                                myPalette3D.SelectColorButton(pb.ButtonColor);
                                break;
                            case PaletteButton.TYPE_UNDO_DESC:
                                canvas3D.ClearLastChange();
                                break;
                            case PaletteButton.TYPE_UNDOALL_DESC:
                                canvas3D.ClearAllChanges();
                                break;
                            default:
                                controlPanelPaletteButton = pb.ButtonType;
                                canvas3D.CurrentButtonType = pb.ButtonType;
                                myPalette3D.SelectToolButton(pb.ButtonType);
                                break;
                        }
                    }
                }
                // we are done with this bubbled event
                e.Handled = true;
            }
            catch (Exception ex)
            {
                //Debug.WriteLine("ERROR ** " + AppUtils.GetMethodName() + " ** " + ex.Message);
            }
        }

        private void SetDrawingCanvasDefaults(PaletteButton sourceColorBtn, PaletteButton sourceToolBtn)
        {
            MainWindow theMainWindow = (MainWindow)Application.Current.MainWindow;
            DrawingCanvas canvas3D = theMainWindow.myCanvas3D;
            try
            {
                if (sourceColorBtn != null)
                {
                    canvas3D.CurrentDrawColor = sourceColorBtn.ButtonColor;
                }
                else
                {
                    // have white be the default color in case one is not selected
                    canvas3D.CurrentDrawColor = availColors.GetColorByName("white");
                }
                if (sourceToolBtn != null)
                {
                    canvas3D.CurrentButtonType = sourceToolBtn.ButtonType;
                }
                else
                {
                    canvas3D.CurrentButtonType = PaletteButton.TYPE_DEFAULT_DESC;
                }
            }
            catch (Exception ex)
            {
                //Debug.WriteLine("ERROR ** " + AppUtils.GetMethodName() + " ** " + ex.Message);
            }
        }

        private void PaletteClosedHandler(object sender, RoutedEventArgs e)
        {
            MainWindow theMainWindow = (MainWindow)Application.Current.MainWindow;
            DrawingCanvas canvas3D = theMainWindow.myCanvas3D;

            try
            {
                // clear any changes on the drawing canvas
                canvas3D.ClearAllChanges();
                // reset properties of the drawing canvas
                canvas3D.CurrentButtonType = PaletteButton.TYPE_DEFAULT_DESC;
                canvas3D.CurrentDrawColor = Colors.Transparent;
            }
            catch (Exception ex)
            {
                //Debug.WriteLine("ERROR ** " + AppUtils.GetMethodName() + " ** " + ex.Message);
            }
        }

        private void PaletteOpenedHandler(object sender, RoutedEventArgs e)
        {
            MainWindow theMainWindow = (MainWindow)Application.Current.MainWindow;
            DrawingCanvas canvas3D = theMainWindow.myCanvas3D;

            try
            {
                // make sure the defaults are showing in the palette
                myPalette3D.SelectDefaultButtons();

                // set properties of the drawing canvas
                if (myPalette3D.CurrentTool != null)
                {
                    canvas3D.CurrentButtonType = myPalette3D.CurrentTool.ButtonType;
                }
                else
                {
                    canvas3D.CurrentButtonType = PaletteButton.TYPE_DEFAULT_DESC;
                }
                if (myPalette3D.CurrentColor != null)
                {
                    canvas3D.CurrentDrawColor = myPalette3D.CurrentColor.ButtonColor;
                }
                else
                {
                    canvas3D.CurrentDrawColor = Colors.Transparent;
                }
            }
            catch (Exception ex)
            {
                //Debug.WriteLine("ERROR ** " + AppUtils.GetMethodName() + " ** " + ex.Message);
            }
        }
    }
}
