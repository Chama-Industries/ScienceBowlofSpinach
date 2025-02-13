using UnityEngine;
using TMPro;
using System.Collections.Generic;
using Unity.VisualScripting;

public class SetupQuestions : MonoBehaviour
{
    [SerializeField]
    private List<QuestionBank> questions;
    private QuestionBank currentQuestion;
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private AnswerButtons[] answerButtons;
    [SerializeField] private int correctAnswer;

    private void Awake()
    {
        //Gets all of the questions that are in the Questions folder
        LoadQuestions();
    }

    void Start()
    {
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

    private void GetNewQuestion()
    {
        //randomly gets a question from the question folder
        int randomQuestion = Random.Range(0, questions.Count);
        //pulls up that random question
        currentQuestion = questions[randomQuestion];
        //removes it from the pool of questions until the quiz is reset
        questions.RemoveAt(randomQuestion);
    }

    private void SetupQuestion()
    {
        questionText.text = currentQuestion.question;
    }

    private void SetupAnswer()
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
