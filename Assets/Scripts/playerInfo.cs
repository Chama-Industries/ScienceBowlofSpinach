using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class playerInfo
{
    private int playerID;
    private double playerHP;
    private double playerShield;
    private int playerActionBarCharges = 0;

    public int getID()
    {
        return playerID;
    }

    public void setID(int input)
    {
        playerID = input;
    }

    public double getHP()
    {
        return playerHP;
    }

    public void setHP(double input)
    {
        playerHP = input;
    }

    public double getShield()
    {
        return playerShield;
    }
   
    public void setShield(double input)
    {
        playerShield = input;
    }

    public int getActionBarCharges()
    {
        return playerActionBarCharges;
    }

    public void setActionBarCharges(int input)
    {
        playerActionBarCharges += input;
        if(playerActionBarCharges > 10)
        {
            playerActionBarCharges = 10;
        }
    }

    public void takeDamage(double incomingDamage)
    {
        if(playerShield > 0)
        {
            incomingDamage -= playerShield;
        }
        playerHP -= incomingDamage;
    }
}
