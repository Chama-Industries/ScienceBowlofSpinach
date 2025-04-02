using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AttackButtons : MonoBehaviour
{
    private SetupQuestions setupQuestions;
    public PlayersSetup playersSetup;
    public playerActions playerActions;

    //stuff here is possibly temporary
    public Slider p1Health;
    public Slider p2Health;
    public GameObject winningScreen;
    [SerializeField] private TextMeshProUGUI winner;
    //

    public bool attack1;
    public bool attack2;
    public bool pass;

    private void Start()
    {
        winningScreen.SetActive(false);
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
            }
            else if (setupQuestions.p2Turn)
            {
                playersSetup.p2SPMeter -= 1;
                playersSetup.p2SPSlider.value = playersSetup.p2SPMeter;
            }
            //

            playerActions.playerAttack();

            if (p1Health.value < 0.1f || p2Health.value < 0.1f) 
            {
                winningScreen.SetActive(true);

                if (setupQuestions.p2Turn)
                {
                    winner.text = "Player 2 Wins!";
                }
                else if(setupQuestions.p1Turn)
                {
                    winner.text = "Player 1 Wins!";
                }

                setupQuestions.p2AttackButtons.SetActive(false);
                setupQuestions.p1AttackButtons.SetActive(false);
            }
            else
            {
                setupQuestions.SwitchTurns();
            }
        }
        else if (attack2 && (playersSetup.p1SPMeter >= 2 || playersSetup.p2SPMeter >= 2))
        {
            //temporary
            if (setupQuestions.p1Turn)
            {
                playersSetup.p1SPMeter -= 2;
                playersSetup.p1SPSlider.value = playersSetup.p1SPMeter;
            }
            else if (setupQuestions.p2Turn)
            {
                playersSetup.p2SPMeter -= 2;
                playersSetup.p2SPSlider.value = playersSetup.p2SPMeter;
            }
            //

            playerActions.playerStrongAttack();

            if (p1Health.value <= 0 || p2Health.value <= 0)
            {
                winningScreen.SetActive(true);

                if (setupQuestions.p2Turn)
                {
                    winner.text = "Player 2 Wins!";
                }
                else if (setupQuestions.p1Turn)
                {
                    winner.text = "Player 1 Wins!";
                }

                setupQuestions.p2AttackButtons.SetActive(false);
                setupQuestions.p1AttackButtons.SetActive(false);
            }
            else
            {
                setupQuestions.SwitchTurns();
            }
        }
        else if(pass)
        {
            setupQuestions.SwitchTurns();
        }
        else
        {
            Debug.Log("pick another attack");
        }
    }

    public void SpecialAttack1()
    {

    }
}
