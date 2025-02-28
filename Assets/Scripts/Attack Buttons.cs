using UnityEngine;

public class AttackButtons : MonoBehaviour
{
    private SetupQuestions setupQuestions;
    public PlayersSetup playersSetup;

    public bool attack1;
    public bool attack2;

    private void Start()
    {
        setupQuestions = FindAnyObjectByType<SetupQuestions>();
    }

    public void OnClick()
    {
        if (attack1)
        {
            DamagePlayer();
            setupQuestions.LoadNewQuestion();
        }
        else if (attack2)
        {
            DamagePlayer();
            setupQuestions.LoadNewQuestion();
        }
    }

    public void DamagePlayer()
    {
        if(!setupQuestions.p1Turn && attack1)
        {
            playersSetup.p2Health -= 10;
        }
        else if(!setupQuestions.p1Turn && attack2)
        {
            playersSetup.p2Health -= 5;
        }
        else if(!setupQuestions.p2Turn && attack1)
        {
            Debug.Log("i'm damaging player 1");
            Debug.Log("Player 1 health is " + playersSetup.p1Health);
            playersSetup.p1Health -= 10;
            playersSetup.p1HealthSlider.value = playersSetup.p1Health;
            Debug.Log("now it's " + playersSetup.p1Health);
        }
        else if (!setupQuestions.p2Turn && attack2)
        {
            Debug.Log("i'm damaging player 1");
            Debug.Log("Player 1 health is " + playersSetup.p1Health);
            playersSetup.p1Health -= 5;
            playersSetup.p1HealthSlider.value = playersSetup.p1Health;
            Debug.Log("now it's " + playersSetup.p1Health);
        }
    }
}
