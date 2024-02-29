using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuUI : MonoBehaviour
{
    GameManager GM;
    public TextMeshProUGUI money;

    private void Awake()
    {
        GM = FindObjectOfType<GameManager>();
    }

    void Start()
    {
        Invoke("UpdateMoney", 0.04f);
    }
    public void UpdateMoney()
    {
        money.text = GM.money.ToString();
    }


    public void cheatGainMoney()
    {
        GM.money += 50;
    }
    public void cheatMoneyToZero()
    {
        GM.money = 0;
    }
    public void cheatResetSkins()
    {
        for (int i = 0; i < GM.shoppers.Count - 1; i++)
        {
            GM.shoppers[i].selectable = false;
            GM.selectableCars.Clear();
            GM.selectableCars.Add(4);
            GM.selectedCar = GM.allCars[4];
            for (int j = 0; j < 5; j++)
            {
                if (PlayerPrefs.HasKey("ownedCar" + j))
                    PlayerPrefs.DeleteKey("ownedCar" + j);
            }
            PlayerPrefs.SetInt("SelectedCar", 4);
        }
    }
    public void cheatScoreToZero()
    {
        PlayerPrefs.SetInt("HighScore", 0);
    }
}
