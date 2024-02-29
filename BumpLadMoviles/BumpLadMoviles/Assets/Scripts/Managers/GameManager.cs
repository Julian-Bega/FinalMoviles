using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  
    
    public static GameManager Instance { get; private set; }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
    
    public int money;
    public float highscore;
    public Sprite selectedCar;
    public List<int> selectableCars;
    public List<Sprite> allCars;
    public List<Shopper> shoppers;


    void Start()
    {
        money = PlayerPrefs.GetInt("money");
        for (int i = 0; i < 5; i++)
        {
            if (PlayerPrefs.HasKey("ownedCar" + i))
            selectableCars.Add(PlayerPrefs.GetInt("ownedCar" + i));
        }
        selectedCar = allCars[PlayerPrefs.GetInt("SelectedCar")];
    }
    public void UnlockAchivments(string name)
    {
        //GooglePlay.UnlockAchievement(name);
    }


}
