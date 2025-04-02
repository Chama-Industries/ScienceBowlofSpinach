using UnityEngine;
using UnityEngine.UI;

public class playerActions : MonoBehaviour
{
    // NOTE: THIS IS MEANT TO BE INHERITED BY FUTURE THINGS
    public playerInfo player = new playerInfo();
    protected playerActions otherPlayerInfo;

    // Variables for logic calcualtions
    public double HP;
    public double Shield;
    public int actionCharges;
    public Slider HPDisplay;
    public double playerAttackDamage;
    // Divide by 2 to get the turn number
    protected static int turnNumber = 0;

    // variable to hold a reference to the other player
    public GameObject otherPlayer;

    public virtual void Start()
    {
        // get the other player for reference purposes
        otherPlayerInfo = otherPlayer.GetComponent<playerActions>();

        player.setHP(HP);
        player.setShield(Shield);
        player.setActionBarCharges(actionCharges);
    }

    // ensures that the player's HP is accurate
    public virtual void FixedUpdate()
    {
        if(HPDisplay.value != player.getHP()/100)
        {
            HPDisplay.value = (float)player.getHP() / 100.0f;
        }
    }

    // Basic Attack for Combat Mechanics
    public virtual void playerAttack()
    {
        if (actionCharges > 0)
        {
            otherPlayerInfo.player.takeDamage(playerAttackDamage);
            actionCharges--;
            turnNumber++;
        }
    }

    // Stronger Attack for Combat Mechanics 
    public virtual void playerStrongAttack()
    {
        if (actionCharges > 1)
        {
            otherPlayerInfo.player.takeDamage(playerAttackDamage * 3);
            actionCharges -= 2;
            turnNumber++;
        }
    }

    // Generic Base in case nothing else can be found for the class
    public virtual void playerSpecialAttack()
    {
        if (actionCharges > 0)
        {
            player.gainHP(25);
            actionCharges -= 2;
            turnNumber++;
        }
    }

    // Queues a Hard Question for the Opponent (Unimplemented)
    public virtual void playerTactic1()
    {
        
    }

    // Defined in Children
    public virtual void playerTactic2()
    {
        
    }

    // Defined in Children, if applicable
    public virtual void playerPass()
    {
        // Does Nothing on Purpose
        turnNumber++;
    }
}
