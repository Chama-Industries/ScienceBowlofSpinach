using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCustomQuestions : MonoBehaviour
{
    public TMP_InputField questionText;
    public TMP_InputField correctAnswer;
    public TMP_InputField wrongAnswer1;
    public TMP_InputField wrongAnswer2;
    public TMP_InputField wrongAnswer3;
    public TMP_InputField questionDifficulty;
    public Button saveQuestion;
    public Button uploadImageButton;

    private Sprite uploadedImage;
    private string folderPath;

    private void Start()
    {
        uploadImageButton.onClick.AddListener(UploadImageForQuestion);
    }

    public void SaveImage(Texture2D texture, string assetPath)
    {
        AssetDatabase.CreateAsset(texture, assetPath);
        AssetDatabase.SaveAssets();
        AssetDatabase.ImportAsset(assetPath, ImportAssetOptions.ForceUpdate);
    }

    public void UploadImageForQuestion()
    {
        string path = EditorUtility.OpenFilePanel("Select An Image For The Question", "", "jpg,png");

        if (path != null)
        {
            byte[] fileDate = System.IO.File.ReadAllBytes(path);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(fileDate);
            string assetPath = "Assets/Sprites/Custom Images/" + System.IO.Path.GetFileName(path);
            SaveImage(texture, assetPath);
            uploadedImage = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        }
    }

    public void OnSaveQuestionsClick()
    {
        string question = questionText.text;
        string answer = correctAnswer.text;
        string wrong1 = wrongAnswer1.text;
        string wrong2 = wrongAnswer2.text;
        string wrong3 = wrongAnswer3.text;
        string difficulty = questionDifficulty.text;

        if(string.IsNullOrEmpty(question) || string.IsNullOrEmpty(answer) || string.IsNullOrEmpty(wrong1)
            || string.IsNullOrEmpty(wrong2) || string.IsNullOrEmpty(wrong3) || string.IsNullOrEmpty(difficulty))
        {
            Debug.Log("something is missing");
            return;
        }

        QuestionBank questionBank = ScriptableObject.CreateInstance<QuestionBank>();
        questionBank.question = question;
        questionBank.answers = new string[] { answer, wrong1, wrong2, wrong3 };
        questionBank.difficulty = difficulty;

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

        if (string.IsNullOrEmpty(folderPath))
        {
            Debug.Log("Please select custom quiz file to save questions in!");
            return;
        }

        if(!System.IO.Directory.Exists(folderPath))
        {
            System.IO.Directory.CreateDirectory(folderPath);
        }

        string path = folderPath + "/" + questionBank.name + ".asset";
        AssetDatabase.CreateAsset(questionBank, path);
        AssetDatabase.SaveAssets();
    }

    public void SetFolderPath(string customQuizFolder)
    {
        folderPath = customQuizFolder;
    }
}
