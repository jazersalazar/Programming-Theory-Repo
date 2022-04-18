using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomer : Enemy 
{
    protected override void PlayerInRange()
    {
        // TODO: add boomer logic here
        base.PlayerInRange();
    }

    public override string GetName()
    {
        return "Boomer";
    }
}
