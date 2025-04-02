using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Question", menuName = "ScriptableObjects/Question", order = 1)]
public class QuestionBank : ScriptableObject
{
    public string question;
    [Header ("the correct answer should be the 1st value")] public string[] answers;
    public string difficulty;
    public Sprite image;
}
