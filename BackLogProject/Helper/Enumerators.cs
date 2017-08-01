namespace BackLogProject.Helper
{
	public class Enumerators
	{
		private static Enumerators _instance;
		public string Background = Themes.Blue.ToString();

		private Enumerators() { }

		public static Enumerators Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new Enumerators();
					_instance.Background = "Blue";
				}
				return _instance;
			}
		}

		public enum Themes { DarkGreen, Blue, White, DeepPink };

		public enum BacklogStates { Idea, ToDo, InProgress, ToReview, Done };
	}
}
