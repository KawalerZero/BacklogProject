using BackLogProject.Helper;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace BackLogProject
{
	/// <summary>
	/// Interaction logic for OptionsWindow.xaml
	/// </summary>
	public partial class OptionsWindow : Window
	{
		private ICommand _return;

		public OptionsWindow()
		{
			InitializeComponent();
			DataContext = this;
			ButtonReturn = new DelegateCommand(ReturnToHelloView);
		}


		public ICommand ButtonReturn
		{
			get
			{
				return _return;
			}
			set
			{
				_return = value;
				OnPropertyChanged();
			}
		}
		public void ReturnToHelloView()
		{
			HelloView hello = new HelloView();
			hello.Show();
			ExitExecute();
		}

		private void ExitExecute()
		{
			this.Close();
		}
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
