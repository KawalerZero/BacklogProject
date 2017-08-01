using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace BackLogProject.Helper
{
	public class BackgroundController
	{

		public static void SetBackgroundTheme(List<FrameworkElement> ListOfFrameworkElements)
		{
			try
			{
				Enumerators enumerators = Enumerators.Instance;
				var value = typeof(System.Windows.Media.Brushes).GetProperty(enumerators.Background).GetValue(null);
				if (value != null)
				{
					foreach (var frameworkItem in ListOfFrameworkElements)
					{
						if (frameworkItem is TextBlock)
						{
							var item = frameworkItem as TextBlock;
							item.Background = value as System.Windows.Media.Brush;
						}
						else if (frameworkItem is Grid)
						{
							var item = frameworkItem as Grid;
							item.Background = value as System.Windows.Media.Brush;
						}
						else if (frameworkItem is DockPanel)
						{
							var item = frameworkItem as DockPanel;
							item.Background = value as System.Windows.Media.Brush;
						}
					}
				}
			}
			catch (NullReferenceException)
			{
				MessageBox.Show(Properties.Resources.ResourceManager.GetString("ExceptionNullReferenceTheme"));
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.ToString());
			}
		}
	}
}
