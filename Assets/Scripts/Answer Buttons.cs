using UnityEngine;
using TMPro;
using System.Collections;

public class AnswerButtons : MonoBehaviour
{
    private bool isCorrect;
    [SerializeField] private TextMeshProUGUI answer;
    private SetupQuestions setupQuestions;

    private PlayersSetup playersSetup;

    private void Start()
    {
        setupQuestions = FindAnyObjectByType<SetupQuestions>();
        playersSetup = FindAnyObjectByType<PlayersSetup>();
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
            setupQuestions.image.SetActive(false);

            if(setupQuestions.p1Turn)
            {
                playersSetup.p1SPMeter += 1;
                playersSetup.p1SPSlider.value = playersSetup.p1SPMeter;
                setupQuestions.p1AttackButtons.SetActive(true);
                //setupQuestions.p1Turn = false;
                //setupQuestions.p2Turn = true;
            }
            else if (setupQuestions.p2Turn)
            {
                playersSetup.p2SPMeter += 1;
                playersSetup.p2SPSlider.value = playersSetup.p2SPMeter;
                setupQuestions.p2AttackButtons.SetActive(true);
                //setupQuestions.p2Turn = false;
                //setupQuestions.p1Turn = true;
            }

            //setupQuestions.LoadNewQuestion();
        }
        else
        {
            Debug.Log("Wrong");
            StartCoroutine(WrongAnswerPopUp());
            setupQuestions.LoadNewQuestion();
        }
    }

    private IEnumerator WrongAnswerPopUp()
    {
        if (setupQuestions.p1Turn)
        {
            setupQuestions.p1Turn = false;
            setupQuestions.p2Turn = true;
        }
        else if (setupQuestions.p2Turn)
        {
            setupQuestions.p2Turn = false;
            setupQuestions.p1Turn = true;
        }

        setupQuestions.wrongAnswerPopUp.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        setupQuestions.wrongAnswerPopUp.SetActive(false);
    }
}
