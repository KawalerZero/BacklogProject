using BackLogProject.Helper;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace BackLogProject
{
	/// <summary>
	/// Interaction logic for BacklogItemWindow.xaml
	/// </summary>
	public partial class BacklogItemWindow : Window
	{
		private ICommand _exit;
		private ICommand _save;
		public BacklogItemWindow()
		{
			InitializeComponent();
			SetBackgroundTheme();
			DataContext = this;
			ButtonExit = new DelegateCommand(ExitExecute);
			ButtonSave = new DelegateCommand(SaveBackLogItem);
		}

		private void SetBackgroundTheme()
		{
			var listOfElements = new List<FrameworkElement>();
			listOfElements.Add(BacklogItemGrid);
			BackgroundController.SetBackgroundTheme(listOfElements);
		}

		public ICommand ButtonExit
		{
			get
			{
				return _exit;
			}
			set
			{
				_exit = value;
				OnPropertyChanged();
			}
		}

		public ICommand ButtonSave
		{
			get
			{
				return _save;
			}
			set
			{
				_save = value;
				OnPropertyChanged();
			}
		}

		public void ExitExecute()
		{
			this.Close();
		}

		public void SaveBackLogItem()
		{
			BacklogItem backlogItem = new BacklogItem();
			backlogItem.Height = 100;
			backlogItem.Width = 200;
			backlogItem.TopicText.Content = "ELO";
			backlogItem.CategoryText.Content = "ELO2";
			backlogItem.State = Enumerators.BacklogStates.Idea;
			MainWindow.Instance.ListOfBacklogItemsElements.AddElement(backlogItem);
			MainWindow.Instance.LoadElements();
			ExitExecute();
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
