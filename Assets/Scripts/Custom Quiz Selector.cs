using UnityEngine;
using UnityEngine.UI;

public class CustomQuizSelector : MonoBehaviour
{
    [SerializeField] private Button customQuizButton;
    [SerializeField] private string customQuizPath;
    [SerializeField] private string customQuizFolder;
    private PlayerCustomQuestions PlayerCustomQuestions;
    private SetupQuestions SetupQuestions;

    private void Start()
    {
        SetupQuestions = FindAnyObjectByType<SetupQuestions>();
        PlayerCustomQuestions = FindAnyObjectByType<PlayerCustomQuestions>();
    }

    public void SetCustomQuizFolderPath()
    {
        PlayerCustomQuestions.SetFolderPath(customQuizPath);
    }

    public void CustomQuizSelected()
    {
        SetupQuestions.SelectedCustomQuiz(customQuizFolder);
    }

    public void DisplaySOQuestions()
    {

    }
}
