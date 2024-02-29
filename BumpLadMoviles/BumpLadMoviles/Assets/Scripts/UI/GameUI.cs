using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUI : MonoBehaviour
{
    public GameObject pausePanel;
    public TextMeshProUGUI money;
    public TextMeshProUGUI kmTraveled;
    public TextMeshProUGUI onGameKmTraveled;
    public GameObject HighScore;
    private GameManager GM;
    private PlayerManager PM;
    private GameplayManager GPM;
    public GameObject pauseButton;
    public GameObject defeatPanel;


    public GameObject tutorial;

    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<GameManager>();
        PM = FindObjectOfType<PlayerManager>();
        GPM = FindObjectOfType<GameplayManager>();
        money.text = GM.money.ToString();
        Invoke("HideTuto", 2.95f);
    }

    private void HideTuto()
    {
        tutorial.SetActive(false);
    }

    public void UpdateMoney()
    {
        GM.money += PM.money;
        money.text = GM.money.ToString();
    }
    private void Update()
    {
        onGameKmTraveled.text = GPM.kmTraveled.ToString();
    }
    public void ShowGO(GameObject objectToShow)
    {
        objectToShow.SetActive(true);
    }
    public void HideGO(GameObject objectToHide)
    {
        objectToHide.SetActive(false);
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void UnPause()
    {
        Time.timeScale = 1;
    }
    public void LevelEnd()
    {
        GM.money += PM.money;
    }
    public void Defeat()
    {
        Time.timeScale = 0;
        pauseButton.gameObject.SetActive(false);
        defeatPanel.gameObject.SetActive(true);
        GPM.onGame = false;
        kmTraveled.text = GPM.kmTraveled.ToString();
        if (!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }
        if (GPM.kmTraveled > PlayerPrefs.GetInt("HighScore"))
        {
            HighScore.SetActive(true);
            PlayerPrefs.SetInt("HighScore", GPM.kmTraveled);
        }

    }
    public void KeepPlaying()
    {
        if (GM.money >= 75)
        {
            GM.money -= 75;
            UpdateMoney();
            for (int i = 0; i < GPM.cars.Count; i++)
            {
                GPM.cars[i].speed = 0;
                GPM.cars[i].state = 0;
                GPM.cars[i].transform.position = new Vector3(15, 15, -1.0f);
            }
            defeatPanel.gameObject.SetActive(false);
            Time.timeScale = 1;
            GPM.onGame = true;
        }
    }
}
