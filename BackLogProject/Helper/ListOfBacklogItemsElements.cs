using System.Collections.Generic;
using System.Windows;

namespace BackLogProject.Helper
{
	public class ListOfBacklogItemsElements
	{
		public List<BacklogItem> listOfIdeaStateElements = new List<BacklogItem>();
		public List<BacklogItem> listOfToDoStateElements = new List<BacklogItem>();
		public List<BacklogItem> listOfInProgressStateElements = new List<BacklogItem>();
		public List<BacklogItem> listOfToReviewStateElements = new List<BacklogItem>();
		public List<BacklogItem> listOfDoneStateElements = new List<BacklogItem>();

		public void AddElement(BacklogItem backlogItem)
		{
			switch (backlogItem.State)
			{
				case Enumerators.BacklogStates.Idea:
					listOfIdeaStateElements.Add(backlogItem);
					break;
				case Enumerators.BacklogStates.ToDo:
					listOfToDoStateElements.Add(backlogItem);
					break;
				case Enumerators.BacklogStates.InProgress:
					listOfInProgressStateElements.Add(backlogItem);
					break;
				case Enumerators.BacklogStates.ToReview:
					listOfToReviewStateElements.Add(backlogItem);
					break;

				case Enumerators.BacklogStates.Done:
					listOfDoneStateElements.Add(backlogItem);
					break;
				default:
					MessageBox.Show("Invalid backlog state");
					break;
			}
		}

	}
}
