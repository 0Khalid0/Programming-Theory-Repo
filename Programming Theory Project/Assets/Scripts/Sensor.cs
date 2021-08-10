using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        string detectedShapeType = other.gameObject.GetComponent<Shapes>().ShapeType;
        string expectedShapeType = gameManager.GetExpectedShapeName();
        string detectedShapeSize = other.gameObject.GetComponent<Shapes>().ShapeSize;
        string expectedShapeSize = gameManager.GetExpectedSize();

        if (detectedShapeType == expectedShapeType && detectedShapeSize == expectedShapeSize)
        {
            gameManager.AddScore(other.gameObject.GetComponent<Shapes>().GetScoreValue());
            gameManager.UpdateDeliveryStatus(true);
        }
        else
        {
            gameManager.AddScore(-other.gameObject.GetComponent<Shapes>().GetScoreValue());
        }

        gameManager.AdjustGameSpeed();
        Destroy(other.gameObject);
    }
}
