using BackLogProject.Helper;
using System.Collections.Generic;
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
			SetBackgroundTheme();
			DataContext = this;
			ButtonOk = new DelegateCommand(NextExecute);
			ButtonOptions = new DelegateCommand(OptionsExecute);
			ButtonExit = new DelegateCommand(ExitExecute);

		}

		private void SetBackgroundTheme()
		{
			var listOfElements = new List<FrameworkElement>();
			listOfElements.Add(GridHello);
			listOfElements.Add(HelloTextBlock);
			BackgroundController.SetBackgroundTheme(listOfElements);
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
			InstanceMainWindowHandler.instanceMainWindow.Visibility = Visibility.Visible;
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
