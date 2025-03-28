using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCustomQuestions : MonoBehaviour
{
    public InputField questionText;
    public InputField correctAnswer;
    public InputField wrongAnswer1;
    public InputField wrongAnswer2;
    public InputField wrongAnswer3;
    public Button saveQuestion;
    public Image displayImage;

    private Sprite uploadedImage;
    private string folderPath = "Assets/Resources/Questions";

    void OnSaveQuestionsClick()
    {
        string question = questionText.text;
        string answer = correctAnswer.text;
        string wrong1 = wrongAnswer1.text;
        string wrong2 = wrongAnswer2.text;
        string wrong3 = wrongAnswer3.text;

        if(string.IsNullOrEmpty(question) || string.IsNullOrEmpty(answer) || string.IsNullOrEmpty(wrong1)
            || string.IsNullOrEmpty(wrong2) || string.IsNullOrEmpty(wrong3))
        {
            Debug.Log("something is missing");
            return;
        }

        QuestionBank questionBank = ScriptableObject.CreateInstance<QuestionBank>();
        questionBank.question = question;
        questionBank.answers = new string[] { answer, wrong1, wrong2, wrong3 };

        if (uploadedImage != null)
        {
            questionBank.image = uploadedImage;
        }
        else
        {
            questionBank.image = null;
        }

        if(questionBank.question.Contains("?"))
        {
            questionBank.name = questionBank.question.Remove(questionBank.question.IndexOf("?"));
        }
        else
        {
            questionBank.name = questionBank.question;
        }

        if(!System.IO.Directory.Exists(folderPath))
        {
            System.IO.Directory.CreateDirectory(folderPath);
        }

        string path = folderPath + "/" + questionBank.name + ".asset";
        AssetDatabase.CreateAsset(questionBank, path);
        AssetDatabase.SaveAssets();
    }
}
