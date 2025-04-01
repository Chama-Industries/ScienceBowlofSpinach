using UnityEngine;

public class attacker1 : playerActions
{
    public override void playerSpecialAttack()
    {
        if (actionCharges > 1)
        {
            otherPlayerInfo.player.takeDamage(playerAttackDamage * (turnNumber/2));
            actionCharges -= 2;
            turnNumber++;
        }
    }
}
