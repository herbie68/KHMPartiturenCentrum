namespace KHM.ViewModels;

public class NewScoreViewModel : BaseScoreViewModel
{
	public NewScoreViewModel()
	{
		//Scores = DBCommands.GetEmptyScores ( DBNames.AvailableScoresView, DBNames.AvailableScoresFieldNameNumber );
		AvailableScores = DBCommands.GetAvailableScores();
	}
}
