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

		public MainWindow()
		{
			InitializeComponent();
			DataContext = this;
			ButtonAdd = new DelegateCommand(AddSomethingNew);
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

		public void AddSomethingNew()
		{

			lolo.Children.Add(new TextBox() { Text = "Babau" });
		}
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
