using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : Animal
{

    protected override void SelectTarget()
    {
        // A ovelha não seleciona alvos
    }
    protected override void Move()
    {
        Debug.Log("Sheep has moved");
    }
    protected override void TryEat()
    {
        Debug.Log("Sheep has tried to eat");
    }
    protected override void TryReproduce()
    {
        Debug.Log("Sheep has tried to reproduce");
    }
}
