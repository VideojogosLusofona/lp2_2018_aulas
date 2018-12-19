using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal : MonoBehaviour
{

    // Template method
    void Update()
    {
        SelectTarget();
        Move();
        TryEat();
        TryReproduce();
    }

    // Passos concretos do algoritmo são definidos pelas subclasses
    protected abstract void SelectTarget();
    protected abstract void Move();
    protected abstract void TryEat();
    protected abstract void TryReproduce();
}
