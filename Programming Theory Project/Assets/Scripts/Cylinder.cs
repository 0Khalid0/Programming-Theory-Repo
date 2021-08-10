using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinder : Shapes //INHERITANCE
{
    private readonly int scoreMultiplier = 2;

    // Start is called before the first frame update
    void Start()
    {
        SetShapeType("Cylinder");
    }

    public override int GetScoreValue() //POLYMORPHISM
    {
        return base.GetScoreValue() * scoreMultiplier;
    }
}
