using UnityEngine;
using TMPro;
using System.Collections;

public class AnswerButtons : MonoBehaviour
{
    private bool isCorrect;
    [SerializeField] private TextMeshProUGUI answer;
    private SetupQuestions setupQuestions;
    private Timer timer;
    private PlayersSetup playersSetup;
    private int p1RAStreak = 0;
    private int p2RAStreak = 0;

    private void Start()
    {
        timer = FindAnyObjectByType<Timer>();
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

        if (isCorrect)
        {
            Debug.Log("Correct");
            setupQuestions.image.SetActive(false);

            if(setupQuestions.p1Turn)
            {
                p1RAStreak++;

                if(playersSetup.p1SPMeter < 10)
                {
                    if (p1RAStreak >= 5)
                    {
                        playersSetup.p1SPMeter += 2;
                    }
                    else
                    {
                        playersSetup.p1SPMeter += 1;
                    }
                }

                playersSetup.p1SPSlider.value = playersSetup.p1SPMeter;
                setupQuestions.p1AttackButtons.SetActive(true);
            }
            else if (setupQuestions.p2Turn)
            {
                p2RAStreak++;

                if (playersSetup.p2SPMeter < 10)
                {
                    if (p2RAStreak >= 5)
                    {
                        playersSetup.p2SPMeter += 2;
                    }
                    else
                    {
                        playersSetup.p2SPMeter += 1;
                    }
                }

                playersSetup.p2SPSlider.value = playersSetup.p2SPMeter;
                setupQuestions.p2AttackButtons.SetActive(true);
            }

            for (int i = 0; i < setupQuestions.answerButtonActivation.Length; i++)
            {
                setupQuestions.answerButtonActivation[i].enabled = false;
            }

            timer.timerOn = false;
        }
        else
        {
            Debug.Log("Wrong");

            if (setupQuestions.p1Turn)
            {
                p1RAStreak = 0;
            }
            else if (setupQuestions.p2Turn)
            {
                p2RAStreak = 0;
            }

            StartCoroutine(WrongAnswerPopUp());
        }
    }

    private IEnumerator WrongAnswerPopUp()
    {
        setupQuestions.wrongAnswerPopUp.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        setupQuestions.wrongAnswerPopUp.SetActive(false);
        setupQuestions.SwitchTurns();
    }
}
