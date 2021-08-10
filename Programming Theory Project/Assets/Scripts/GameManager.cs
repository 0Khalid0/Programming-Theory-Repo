using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI RequestText;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI TimerText;
    public TextMeshProUGUI GameoverText;

    private Sensor sensor;
    private ConveyorBelt conveyorBelt;

    public float startingConveyorSpeed = 4.0f;

    public string[] shapeNames = { "Cube", "Cylinder", "Sphere" };
    public string[] shapeSizes = { "Small", "Medium", "Large" };

    public int Score { get; private set; }

    public int ExpectedShape { get; private set; } //ENCAPSULATION
    public int ExpectedSize { get; private set; } //ENCAPSULATION
    public bool IsGameActive { get; private set; } //ENCAPSULATION
    public bool IsDelivered { get; private set; } //ENCAPSULATION

    public int Timer { get; private set; }

    private void Awake()
    {
        sensor = GameObject.Find("Sensor").GetComponent<Sensor>();
        conveyorBelt = GameObject.Find("Conveyor Belt").GetComponent<ConveyorBelt>();

        Score = 0;
        Timer = 120;
        UpdateTimer(Timer);
        AddScore(0);

        IsGameActive = true;
        RequestShape();
        StartCoroutine(CountdownTimer());
    }

    IEnumerator CountdownTimer()
    {
        while (IsGameActive)
        {
            yield return new WaitForSeconds(1);
            Timer--;
            UpdateTimer(Timer);
        }
    }

    void RequestShape()
    {
        int randomShape = Random.Range(1, 4);
        int randomSize = Random.Range(1, 4);

        ExpectedShape = randomShape;
        ExpectedSize = randomSize;

        UpdateDeliveryStatus(false);

        RequestText.text = shapeSizes[randomSize - 1] + " " + shapeNames[randomShape - 1];
    }

    //Get expected shape name method
    public string GetExpectedShapeName()
    {
        return shapeNames[ExpectedShape - 1];
    }

    //Get expected shape size method
    public string GetExpectedSize()
    {
        return shapeSizes[ExpectedSize - 1];
    }

    //Add Score method
    public void AddScore(int score)
    {
        Score += score;

        if (Score < 0) { Score = 0; }

        ScoreText.text = "Score: " + Score;
    }

    //Update timer method
    private void UpdateTimer(int newTime)
    {
        TimerText.text = "Time: " + newTime;

        if (newTime == 0)
        {
            GameOver();
        }
    }

    public void UpdateDeliveryStatus(bool status)
    {
        if (status)
        {
            IsDelivered = true;
            RequestShape();
        }
        else
        {
            IsDelivered = false;
        }
    }

    public void AdjustGameSpeed()
    {
        if (Score < 40)
        {
            conveyorBelt.SetConveyorSpeed(startingConveyorSpeed);
        }
        else if (Score >= 40 && Score < 60)
        {
            conveyorBelt.SetConveyorSpeed(startingConveyorSpeed * 2.0f);
        }
        else if (Score >= 60 && Score < 80)
        {
            conveyorBelt.SetConveyorSpeed(startingConveyorSpeed * 4.0f);
        }
        else
        {
            conveyorBelt.SetConveyorSpeed(startingConveyorSpeed * 6.0f);
        }
    }

    private void GameOver()
    {
        RequestText.text = "";
        IsGameActive = false;
        GameoverText.gameObject.SetActive(true);
    }

    // Restart game by reloading the scene
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        //MainManager.Instance.SavePlayerData();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
