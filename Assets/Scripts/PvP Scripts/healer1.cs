using UnityEngine;

public class healer1 : playerActions
{
    public override void playerSpecialAttack()
    {
        if (actionCharges > 1)
        {
            otherPlayerInfo.player.takeDamage(playerAttackDamage * 2);
            player.gainHP(playerAttackDamage);
            actionCharges -= 2;
            turnNumber++;
        }
    }
}
