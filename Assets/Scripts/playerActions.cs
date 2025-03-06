using UnityEngine;
using UnityEngine.UI;

public class playerActions : MonoBehaviour
{
    // NOTE: THIS IS MEANT TO BE INHERITED BY FUTURE THINGS
    playerInfo player = new playerInfo();
    playerActions otherPlayerInfo;

    // Variables for easy assignment, action charges remain unused for the midterm demo
    public double HP;
    public double Shield;
    //public int actionCharges;
    public Slider HPDisplay;
    public double playerAttackDamage;

    // variable to hold a reference to the other player
    public GameObject otherPlayer;

    protected virtual void Start()
    {
        // get the other player for reference purposes
        otherPlayerInfo = otherPlayer.GetComponent<playerActions>();

        player.setHP(HP);
        player.setShield(Shield);
        //player.setActionBarCharges(actionCharges);
    }

    protected virtual void FixedUpdate()
    {
        if(HPDisplay.value != player.getHP()/100)
        {
            HPDisplay.value = (float)player.getHP() / 100.0f;
        }
    }

    public virtual void playerAttack()
    {
        otherPlayerInfo.player.takeDamage(playerAttackDamage);
    }

    public virtual void playerStrongAttack()
    {
        otherPlayerInfo.player.takeDamage(playerAttackDamage*3);
    }

    public virtual void playerSpecialAttack()
    {
        // N/A, defined in child classes
    }

    public virtual void playerTactic1()
    {
        // N/A, for the midterm
    }

    public virtual void playerTactic2()
    {
        // N/A, for the midterm
    }

    public virtual void playerDefend()
    {
        // N/A, defined in child classes if applicable
    }
}
