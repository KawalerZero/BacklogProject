using BackLogProject.Helper;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BackLogProject
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>

	public partial class MainWindow : Window, INotifyPropertyChanged
	{
		private ICommand _addSomething;
		private ICommand _return;

		public MainWindow()
		{
			InitializeComponent();
			DataContext = this;
			ButtonAdd = new DelegateCommand(AddSomethingNew);
			ButtonReturn = new DelegateCommand(ReturnToHelloView);
		}
		public ICommand ButtonAdd
		{
			get
			{
				return _addSomething;
			}
			set
			{
				_addSomething = value;
				OnPropertyChanged();
			}
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

		public void AddSomethingNew()
		{

			lolo.Children.Add(new TextBox() { Text = "Babau" });
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
