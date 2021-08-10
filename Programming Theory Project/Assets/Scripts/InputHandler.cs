using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public const int small = 1;
    public const int medium = 2;
    public const int large = 3;

    private SpawnManager spawnManager;
    private GameManager gameManager;

    private void Awake()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (!gameManager.IsGameActive) 
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                gameManager.RestartGame();
            }

            if(Input.GetKeyDown(KeyCode.Q))
            {
                gameManager.QuitGame();
            }
        }
    }

    public void SmallCubeClicked()
    {
        if (gameManager.IsGameActive)
        {
            spawnManager.SpawnCube(small);
        }
    }

    public void MediumCubeClicked()
    {
        if (gameManager.IsGameActive)
        {
            spawnManager.SpawnCube(medium);
        }
    }

    public void LargeCubeClicked()
    {
        if (gameManager.IsGameActive)
        {
            spawnManager.SpawnCube(large);
        }
    }
    public void SmallCylinderClicked()
    {
        if (gameManager.IsGameActive)
        {
            spawnManager.SpawnCylinder(small);
        }
    }

    public void MediumCylinderClicked()
    {
        if (gameManager.IsGameActive)
        {
            spawnManager.SpawnCylinder(medium);
        }
    }

    public void LargeCylinderClicked()
    {
        if (gameManager.IsGameActive)
        {
            spawnManager.SpawnCylinder(large);
        }
    }
    public void SmallSphereClicked()
    {
        if (gameManager.IsGameActive)
        {
            spawnManager.SpawnSphere(small);
        }
    }

    public void MediumSphereClicked()
    {
        if (gameManager.IsGameActive)
        {
            spawnManager.SpawnSphere(medium);
        }
    }

    public void LargeSphereClicked()
    {
        if (gameManager.IsGameActive)
        {
            spawnManager.SpawnSphere(large);
        }
    }
}
