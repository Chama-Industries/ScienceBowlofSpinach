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


            if(setupQuestions.p1Turn)
            {
                setupQuestions.p1AttackButtons.SetActive(true);
                setupQuestions.p1Turn = false;
                setupQuestions.p2Turn = true;
                //setupQuestions.LoadNewQuestion();
            }
            else if (setupQuestions.p2Turn)
            {
                Debug.Log("Setting up attack buttons");
                setupQuestions.p2AttackButtons.SetActive(true);
                setupQuestions.p2Turn = false;
                setupQuestions.p1Turn = true;
            }

            //setupQuestions.LoadNewQuestion();
        }
        else
        {
            Debug.Log("Wrong");
        }

        //setupQuestions.LoadNewQuestion();
    }
}
