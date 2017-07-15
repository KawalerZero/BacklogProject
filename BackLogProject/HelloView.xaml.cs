using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace BackLogProject
{
	/// <summary>
	/// Interaction logic for HelloView.xaml
	/// </summary>
	public partial class HelloView : Window, INotifyPropertyChanged

	{

		private ICommand _buttonGoToMainCommand;
		private ICommand _buttonExitCommand;
		private ICommand _buttonOptionsCommand;


		public HelloView()
		{
			InitializeComponent();
			DataContext = this;
			ButtonOk = new DelegateCommand(NextExecute);
			ButtonOptions = new DelegateCommand(OptionsExecute);
			ButtonExit = new DelegateCommand(ExitExecute);

		}
		public ICommand ButtonOk
		{
			get
			{
				return _buttonGoToMainCommand;
			}
			set
			{
				_buttonGoToMainCommand = value;
				OnPropertyChanged();
			}
		}
		public ICommand ButtonOptions
		{
			get
			{
				return _buttonOptionsCommand;
			}
			set
			{
				_buttonOptionsCommand = value;
				OnPropertyChanged();
			}
		}
		public ICommand ButtonExit
		{
			get
			{
				return _buttonExitCommand;
			}
			set
			{
				_buttonExitCommand = value;
				OnPropertyChanged();
			}
		}

		private void NextExecute()
		{
			MainWindow main = new MainWindow();
			main.Show();
			ExitExecute();
		}

		private void OptionsExecute()
		{
			OptionsWindow options = new OptionsWindow();
			options.Show();
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
