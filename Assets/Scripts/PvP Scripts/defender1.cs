using UnityEngine;

public class defender1 : playerActions
{
    public override void playerSpecialAttack()
    {
        if (actionCharges > 1)
        {
            player.gainShield(((100 - player.getHP())) - ((100 - player.getHP())%10));
            actionCharges -= 2;
            turnNumber++;
        }
    }

    public override void playerPass()
    {
        player.gainShield(10);
        turnNumber++;
    }
}
