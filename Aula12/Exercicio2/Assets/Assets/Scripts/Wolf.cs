using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : Animal
{
    protected override void SelectTarget()
    {
        Debug.Log("Wolf has selected his target");
    }
    protected override void Move()
    {
        Debug.Log("Wolf has moved");
    }
    protected override void TryEat()
    {
        Debug.Log("Wolf has tried to eat");
    }
    protected override void TryReproduce()
    {
        Debug.Log("Wolf has tried to reproduce");
    }

}
