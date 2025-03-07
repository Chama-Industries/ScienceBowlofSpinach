using UnityEngine;

public class AttackButtons : MonoBehaviour
{
    private SetupQuestions setupQuestions;
    public PlayersSetup playersSetup;

    public playerActions playerActions;

    public bool attack1;
    public bool attack2;
    public bool pass;

    private void Start()
    {
        setupQuestions = FindAnyObjectByType<SetupQuestions>();
        playersSetup = FindAnyObjectByType<PlayersSetup>();
    }

    public void OnClick()
    {
        if (attack1 && (playersSetup.p1SPMeter >= 1 || playersSetup.p2SPMeter >= 1))
        {
            //temporary
            if (setupQuestions.p1Turn)
            {
                playersSetup.p1SPMeter -= 1;
                playersSetup.p1SPSlider.value = playersSetup.p1SPMeter;
                setupQuestions.p1Turn = false;
                setupQuestions.p2Turn = true;
            }
            else if (setupQuestions.p2Turn)
            {
                playersSetup.p2SPMeter -= 1;
                playersSetup.p2SPSlider.value = playersSetup.p2SPMeter;
                setupQuestions.p2Turn = false;
                setupQuestions.p1Turn = true;
            }
            //

            playerActions.playerAttack();
            setupQuestions.LoadNewQuestion();
        }
        else if (attack2 && (playersSetup.p1SPMeter >= 2 || playersSetup.p2SPMeter >= 2))
        {
            //temporary
            if (setupQuestions.p1Turn)
            {
                playersSetup.p1SPMeter -= 2;
                playersSetup.p1SPSlider.value = playersSetup.p1SPMeter;
                setupQuestions.p1Turn = false;
                setupQuestions.p2Turn = true;
            }
            else if (setupQuestions.p2Turn)
            {
                playersSetup.p2SPMeter -= 2;
                playersSetup.p2SPSlider.value = playersSetup.p2SPMeter;
                setupQuestions.p2Turn = false;
                setupQuestions.p1Turn = true;
            }
            //

            playerActions.playerStrongAttack();
            setupQuestions.LoadNewQuestion();
        }
        else if(pass)
        {
            if(setupQuestions.p1Turn)
            {
                setupQuestions.p1Turn = false;
                setupQuestions.p2Turn = true;
            }
            else if(setupQuestions.p2Turn)
            {
                setupQuestions.p2Turn = false;
                setupQuestions.p1Turn = true;
            }

            setupQuestions.LoadNewQuestion();
        }
        else
        {
            Debug.Log("pick another attack");
        }
    }
}
