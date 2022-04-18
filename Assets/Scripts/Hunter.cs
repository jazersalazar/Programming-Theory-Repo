using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : Enemy 
{
    protected override void PlayerInRange()
    {
        // TODO: add hunter logic here
        base.PlayerInRange();
    }

    public override string GetName()
    {
        return "Hunter";
    }
}
