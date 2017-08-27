using BackLogProject.Helper;
using System.Windows.Controls;

namespace BackLogProject
{
	/// <summary>
	/// Interaction logic for BacklogItem.xaml
	/// </summary>
	public partial class BacklogItem : UserControl
	{
		public Enumerators.BacklogStates State
		{
			get;
			set;
		}
		public BacklogItem()
		{
			InitializeComponent();
		}
	}
}
