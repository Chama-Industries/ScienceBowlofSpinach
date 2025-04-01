using UnityEngine;

public class healer1 : playerActions
{
    public override void playerSpecialAttack()
    {
        if (actionCharges > 1)
        {
            player.gainHP(20);
            actionCharges -= 2;
            turnNumber++;
        }
    }
}
