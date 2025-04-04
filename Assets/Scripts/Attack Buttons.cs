using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AttackButtons : MonoBehaviour
{
    private SetupQuestions setupQuestions;
    [HideInInspector] public PlayersSetup playersSetup;

    [HideInInspector] public playerActions playerActions;
    [HideInInspector] public attacker1 attacker1;
    [HideInInspector] public healer1 healer1;

    //stuff here is possibly temporary
    public Slider p1Health;
    public Slider p2Health;
    //

    private void Start()
    {
        setupQuestions = FindAnyObjectByType<SetupQuestions>();
        playersSetup = FindAnyObjectByType<PlayersSetup>();
        //healer1 = FindAnyObjectByType<healer1>();
        //attacker1 = FindAnyObjectByType<attacker1>();
    }

    public void PassTurn()
    {
        setupQuestions.SwitchTurns();
    }

    public void Attack1()
    {
        if (playersSetup.p1SPMeter >= 1 || playersSetup.p2SPMeter >= 1)
        {
            //temporary
            //right now this is calling from the script playersSetup, which was something temporary
            //until the actual script for handling health and stuff was made
            if (setupQuestions.p1Turn)
            {
                playersSetup.p1SPMeter -= 1;
                playersSetup.p1SPSlider.value = playersSetup.p1SPMeter;
                //attacker1.playerAttack();
            }
            else if (setupQuestions.p2Turn)
            {
                playersSetup.p2SPMeter -= 1;
                playersSetup.p2SPSlider.value = playersSetup.p2SPMeter;
                //healer1.playerAttack();
            }
            //

            playerActions.playerAttack();
            setupQuestions.WinCondition(p1Health, p2Health);
        }
    }

    public void Attack2()
    {
        if (playersSetup.p1SPMeter >= 2 || playersSetup.p2SPMeter >= 2)
        {
            //temporary
            if (setupQuestions.p1Turn)
            {
                playersSetup.p1SPMeter -= 2;
                playersSetup.p1SPSlider.value = playersSetup.p1SPMeter;
                //attacker1.playerStrongAttack();
            }
            else if (setupQuestions.p2Turn)
            {
                playersSetup.p2SPMeter -= 2;
                playersSetup.p2SPSlider.value = playersSetup.p2SPMeter;
                //healer1.playerStrongAttack();
            }
            //

            playerActions.playerStrongAttack();
            setupQuestions.WinCondition(p1Health, p2Health);
        }
    }

    public void SpecialAttack1()
    {
        if (playersSetup.p1SPMeter >= 2 || playersSetup.p2SPMeter >= 2)
        {
            //temporary
            if (setupQuestions.p1Turn)
            {
                playersSetup.p1SPMeter -= 2;
                playersSetup.p1SPSlider.value = playersSetup.p1SPMeter;
                attacker1.playerSpecialAttack();
            }
            else if (setupQuestions.p2Turn)
            {
                playersSetup.p2SPMeter -= 2;
                playersSetup.p2SPSlider.value = playersSetup.p2SPMeter;
                healer1.playerSpecialAttack();
            }
            //

            setupQuestions.WinCondition(p1Health, p2Health);
        }
    }
}
