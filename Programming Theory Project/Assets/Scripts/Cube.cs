using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : Shapes //INHERITANCE
{
    private readonly int scoreMultiplier = 6;

    // Start is called before the first frame update
    void Start()
    {
        SetShapeType("Cube");
    }

    public override int GetScoreValue() //POLYMORPHISM
    {
        return base.GetScoreValue() * scoreMultiplier;
    }
}
