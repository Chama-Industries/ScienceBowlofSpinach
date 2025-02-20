using UnityEngine;
using TMPro;

public class AnswerButtons : MonoBehaviour
{
    private bool isCorrect;
    [SerializeField] private TextMeshProUGUI answer;
    private SetupQuestions setupQuestions;

    private void Start()
    {
        setupQuestions = FindAnyObjectByType<SetupQuestions>();
    }

    public void SetAnswerText(string answerText)
    {
        answer.text = answerText;
    }

    public void SetCorrectAnswer(bool newBool)
    {
        isCorrect = newBool;
    }

    public void OnClick()
    {
        //after one of the buttons are clicked it loads up a new question
        //need to implement the choosing of attack before loading next question

        if (isCorrect)
        {
            Debug.Log("Correct");

            setupQuestions.GetNewQuestion();
            setupQuestions.SetupQuestion();
            setupQuestions.SetupAnswer();
        }
        else
        {
            Debug.Log("Wrong");
        }
    }
}
