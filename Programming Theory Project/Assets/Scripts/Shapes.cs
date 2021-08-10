using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shapes : MonoBehaviour
{
    public const int small = 1;
    public const int medium = 2;
    public const int large = 3;

    public string ShapeType { get; private set; } //ENCAPSULATION
    public string ShapeSize { get; private set; } //ENCAPSULATION

    protected float smallScale = 0.25f;
    protected float mediumScale = 0.5f;
    protected float largeScale = 1.0f;

    private GameManager gameManager;

    public int ScoreValue { get; private set; } //ENCAPSULATION

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        ScoreValue = 2;
    }

    //Set shape type method
    protected void SetShapeType(string shapeType)
    {
        ShapeType = shapeType;
    }

    //Set shape size method
    public void SetShapeSize(int shapeSize)
    {
        ShapeSize = gameManager.shapeSizes[shapeSize - 1];
    }

    public float GetShapeScale(int size)
    {
        switch (size)
        {
            case small:
                return smallScale;
            case medium:
                return mediumScale;
            case large:
                return largeScale;
            default:
                Debug.LogError("Error. The provided value is not a supported shape scale. Setting to 1.0f");
                return 1.0f;
        }
    }

    //Get score value method
    public virtual int GetScoreValue()
    {
        return ScoreValue;
    }
}
