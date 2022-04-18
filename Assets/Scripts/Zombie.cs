using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// POLYMORPHISM
public class Zombie : Enemy
{
    protected override void PlayerInRange()
    {
        // TODO: add the zombie logic here
        base.PlayerInRange();
    }

    public override string GetName()
    {
        return "Zombie";
    }
}