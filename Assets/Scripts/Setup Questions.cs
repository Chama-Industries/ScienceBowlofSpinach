using UnityEngine;
using TMPro;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UI;

public class SetupQuestions : MonoBehaviour
{
    [SerializeField] private List<QuestionBank> questions;
    [SerializeField] private AnswerButtons[] answerButtons;
    [SerializeField] private Image questionImage;
    private QuestionBank currentQuestion;

    [SerializeField] private TextMeshProUGUI p1QuestionText;
    [SerializeField] private TextMeshProUGUI p2QuestionText;
    [SerializeField] private TextMeshProUGUI playerTurn;

    [SerializeField] private GameObject image;
    [SerializeField] private GameObject p1Side;
    [SerializeField] private GameObject p2Side;

    [SerializeField] private int correctAnswer;
    private int turnDecider;
    private bool p1Turn;
    private bool p2Turn;

    private void Awake()
    {
        //Gets all of the questions that are in the Questions folder
        LoadQuestions();
    }

    void Start()
    {
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

        GetNewQuestion();
        //sets up the text in the question area
        SetupQuestion();
        //sets up the buttons in a randomized order and checks which one is the correct answer
        SetupAnswer();
    }

    private void LoadQuestions()
    {
        questions = new List<QuestionBank>(Resources.LoadAll<QuestionBank>("Questions"));
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
        
        if (p1Turn)
        {
            p1Side.SetActive(true);
            p2Side.SetActive(false);
            p1Turn = false;
            playerTurn.text = "Player 1 Turn";
            p1QuestionText.text = currentQuestion.question;
            p2Turn = true;
        }
        else if(p2Turn)
        {
            p2Side.SetActive(true);
            p1Side.SetActive(false);
            p2Turn = false;
            playerTurn.text = "Player 2 Turn";
            p2QuestionText.text = currentQuestion.question;
            p1Turn = true;
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
}
