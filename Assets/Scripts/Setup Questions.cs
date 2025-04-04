using UnityEngine;
using TMPro;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UI;
using System.Collections;

public class SetupQuestions : MonoBehaviour
{
    private string questionsToLoad;
    private List<QuestionBank> questions;
    [SerializeField] private AnswerButtons[] answerButtons;
    [SerializeField] public Button[] answerButtonActivation;
    [SerializeField] private Timer timer;
    [SerializeField] private Image questionImage;
    private QuestionBank currentQuestion;

    [SerializeField] private TextMeshProUGUI p1QuestionText;
    [SerializeField] private TextMeshProUGUI p2QuestionText;
    [SerializeField] private TextMeshProUGUI playerTurn;

    [SerializeField] public GameObject image;
    [SerializeField] private GameObject p1Side;
    [SerializeField] private GameObject p2Side;
    public GameObject p1AttackButtons;
    public GameObject p2AttackButtons;

    #region This Is For Temporary Stuff

    public Animator introBattleAnimation;
    public GameObject wrongAnswerPopUp;
    public GameObject winnerPopUp;
    [SerializeField] private TextMeshProUGUI winner;
    #endregion

    public Animator buttonsSwitchingAni;

    private int correctAnswer;
    private int turnDecider;
    public bool p1Turn;
    public bool p2Turn;

    private void Awake()
    {
        p1AttackButtons.SetActive(false);
        p2AttackButtons.SetActive(false);
        p1Side.SetActive(false);
        p2Side.SetActive(false);
        image.SetActive(false);
        wrongAnswerPopUp.SetActive(false);
        winnerPopUp.SetActive(false);

        //Gets all of the questions that are in the Questions folder
        LoadQuestions();
    }

    void Start()
    {
        StartCoroutine(IntroAnimation());

        //before setting up the questions it determines who's turn it is
        //could possibly have a cool animation for this
        turnDecider = Random.Range(0, 2);

        if (turnDecider == 0)
        {
            p1Turn = true;
        }
        else if (turnDecider == 1)
        {
            p2Turn = true;
        }

        //timer.ResetTime();
        LoadNewQuestion();
    }

    private void LoadQuestions()
    {
        if (questionsToLoad == null)
        {
            questions = new List<QuestionBank>(Resources.LoadAll<QuestionBank>("Questions"));
        }
        else if (questionsToLoad != null)
        {
            questions = new List<QuestionBank>(Resources.LoadAll<QuestionBank>(questionsToLoad));
        }
    }

    public void LoadNewQuestion()
    {
        GetNewQuestion();
        //sets up the text in the question area
        SetupQuestion();
        //sets up the buttons in a randomized order and checks which one is the correct answer
        SetupAnswer();
    }

    public void GetNewQuestion()
    {
        if(questions.Count == 0)
        {
            LoadQuestions();
        }    

        //randomly gets a question from the question folder
        int randomQuestion = Random.Range(0, questions.Count);
        //pulls up that random question
        currentQuestion = questions[randomQuestion];
        //removes it from the pool of questions until the quiz is reset
        questions.RemoveAt(randomQuestion);
    }

    public void SetupQuestion()
    {
        timer.ResetTime();

        //this turns off the buttons when the animation is playing
        for (int i = 0; i < answerButtonActivation.Length; i++)
        {
            answerButtonActivation[i].enabled = false;
        }

        if (p1Turn)
        {
            buttonsSwitchingAni.Play("To Player 1 Side", -1, 0f);
            StartCoroutine(DelayForAnimation());
            p2AttackButtons.SetActive(false);
            p1QuestionText.text = currentQuestion.question;
        }
        else if(p2Turn)
        {
            buttonsSwitchingAni.Play("To Player 2 Side", -1, 0f);
            StartCoroutine(DelayForAnimation());
            p1AttackButtons.SetActive(false);
            p2QuestionText.text = currentQuestion.question;
        }
    }

    public void SetupAnswer()
    {
        List<string> answers = RandomizeAnswerButtonsOrder(new List<string>(currentQuestion.answers));

        //sets the answer buttons and checks if the button in the list is or isn't the correct answer
        for (int i = 0; i < answerButtons.Length; i++)
        {
            bool isCorrectAnswer = false;

            if(i == correctAnswer)
            {
                isCorrectAnswer = true;
            }

            answerButtons[i].SetCorrectAnswer(isCorrectAnswer);
            answerButtons[i].SetAnswerText(answers[i]);
        }
    }

    private List<string> RandomizeAnswerButtonsOrder(List<string> originalOrder)
    {
        bool correctAnswerPicked = false;

        List<string> newList = new List<string>();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            //randomly gets the answers from the question
            int random = Random.Range(0, originalOrder.Count);

            //once it randomly gets 0 it recognizes that it's the correct answer for that question
            if (random == 0 && !correctAnswerPicked)
            {
                correctAnswer = i;
                correctAnswerPicked = true;
            }

            //adds the answer in this new order
            newList.Add(originalOrder[random]);
            //removes that answer from the original order that it was on
            originalOrder.RemoveAt(random);
        }

        return newList;
    }

    public void SelectedCustomQuiz(string customQuiz)
    {
        questionsToLoad = customQuiz;
    }

    public void SwitchTurns()
    {
        p1Turn = !p1Turn;
        p2Turn = !p2Turn;

        if (p1Turn)
        {
            playerTurn.text = "Player 1 Turn";
            p1Side.SetActive(true);
            p2Side.SetActive(false);
        }
        else if (p2Turn)
        {
            playerTurn.text = "Player 2 Turn";
            p1Side.SetActive(false);
            p2Side.SetActive(true);
        }

        LoadNewQuestion();
    }

    //This is called in the Attack Buttons script
    public void WinCondition(Slider p1Health, Slider p2Health)
    {
        if (p1Health.value < 0.1f || p2Health.value < 0.1f)
        {
            winnerPopUp.SetActive(true);

            if (p2Turn)
            {
                winner.text = "Player 2 Wins!";
            }
            else if (p1Turn)
            {
                winner.text = "Player 1 Wins!";
            }

            p2AttackButtons.SetActive(false);
            p1AttackButtons.SetActive(false);
        }
        else
        {
            SwitchTurns();
        }
    }

    //this is to turn off the buttons so that they can't be pressed when the animation is playing;
    public IEnumerator DelayForAnimation()
    {
        yield return new WaitForSeconds(2.2f);

        for (int i = 0; i < answerButtonActivation.Length; i++)
        {
            answerButtonActivation[i].enabled = true;
        }

        if (p1Turn)
        {
            p1Side.SetActive(true);
        }
        else if (p2Turn)
        {
            p2Side.SetActive(true);
        }

        //determines if the image UI shows up or not if the question has an image
        if (currentQuestion.image == null)
        {
            image.SetActive(false);
        }
        else
        {
            image.SetActive(true);
            questionImage.sprite = currentQuestion.image;
        }
    }

    private IEnumerator IntroAnimation()
    {
        introBattleAnimation.Play("Players Battle Intro", -1, 0f);
        yield return new WaitForSeconds(2.1f);
        //LoadNewQuestion();
    }
}
