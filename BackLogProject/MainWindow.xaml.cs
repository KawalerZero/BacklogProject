using BackLogProject.Helper;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace BackLogProject
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>

	public partial class MainWindow : Window, INotifyPropertyChanged
	{
		private static MainWindow _instance;
		private ICommand _addSomething;
		private ICommand _return;
		public ListOfBacklogItemsElements ListOfBacklogItemsElements;



		private MainWindow()
		{
			InitializeComponent();
			DataContext = this;
			ButtonAdd = new DelegateCommand(AddNewBacklogItem);
			ButtonReturn = new DelegateCommand(ReturnToHelloView);
			ListOfBacklogItemsElements = new ListOfBacklogItemsElements();
		}
		public static MainWindow Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new MainWindow();
				}
				return _instance;
			}
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

		public void AddNewBacklogItem()
		{
			BacklogItemWindow backlogItemWindow = new BacklogItemWindow();
			backlogItemWindow.Show();
		}

		public void LoadElements()
		{
			foreach (var backlogItem in ListOfBacklogItemsElements.listOfIdeaStateElements)
			{
				Instance.Idea.Children.Add(backlogItem);
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
			this.Visibility = Visibility.Hidden;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
