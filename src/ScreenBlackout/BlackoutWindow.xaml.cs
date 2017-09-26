using System.Windows.Input;

namespace ScreenBlackout
{
	public partial class BlackoutWindow
	{
		public BlackoutWindow()
		{
			InitializeComponent();
		}

		private void MouseLeftButtonUpHandler(object sender, MouseButtonEventArgs e)
		{
			Close();
		}
	}
}
