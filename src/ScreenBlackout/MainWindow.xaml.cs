using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Shapes;
using HorizontalAlignment = System.Windows.HorizontalAlignment;

namespace ScreenBlackout
{
	public partial class MainWindow
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void WindowLoaded(object sender, RoutedEventArgs e)
		{
			RenderScreens();
		}

		private void RenderScreens()
		{
			var allScreens = Screen.AllScreens;
			var minX = Math.Abs(allScreens.Min(s => s.Bounds.X));
			var minY = Math.Abs(allScreens.Min(s => s.Bounds.Y));

			var screenId = 1;
			foreach (var screen in allScreens)
			{
				var screenGrid = new Grid
				{
					Width = screen.Bounds.Width,
					Height = screen.Bounds.Height,
					HorizontalAlignment = HorizontalAlignment.Left,
					VerticalAlignment = VerticalAlignment.Top,
					Margin = new Thickness(screen.Bounds.X + minX, screen.Bounds.Y + minY, 0, 0)
				};

				var screenRectangle = new Rectangle
				{
					Fill = new SolidColorBrush(Colors.LightGray),
					Stroke = new SolidColorBrush(Colors.Gray),
					StrokeThickness = 10
				};
				screenGrid.Children.Add(screenRectangle);

				var screenIdTextBlock = new TextBlock
				{
					Text = screenId++.ToString(),
					FontSize = 500,
					HorizontalAlignment = HorizontalAlignment.Center,
					VerticalAlignment = VerticalAlignment.Center
				};
				screenGrid.Children.Add(screenIdTextBlock);

				screenGrid.MouseLeftButtonUp += (sender, args) => ScreenClicked(screen);

				ScreensCanvas.Children.Add(screenGrid);
			}
		}

		private static void ScreenClicked(Screen screen)
		{
			var blackoutWindow = new BlackoutWindow
			{
				Left = screen.Bounds.X,
				Top = screen.Bounds.Y,
				Width = screen.Bounds.Width,
				Height = screen.Bounds.Height
			};

			blackoutWindow.Show();
		}
	}
}
