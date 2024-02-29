using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShopUI : MonoBehaviour
{
 

    public List<Shopper> carsInShop;
    public List<TextMeshProUGUI> buttonsText;
    public TextMeshProUGUI showMoney;
    public Image selectedCar;
    public GameManager GM;
    // Start is called before the first frame update

    private void Awake()
    {
        GM = FindObjectOfType<GameManager>();
    }
    void Start()
    {
        showMoney.text = GM.money.ToString();
        checkBoughtCars();
        selectedCar.sprite = GM.selectedCar;
    }
  
    public void BuyOrSelectCar(int shoperID)
    {      

        if (carsInShop[shoperID].selectable == true)
        {
            GM.selectedCar = carsInShop[shoperID].carSprite;
            selectedCar.sprite = GM.selectedCar;
            PlayerPrefs.SetInt("SelectedCar", shoperID);
           // Logger.AndroidLog("New Car Selected");
        }

        if (carsInShop[shoperID].selectable == false)
        {
            if (GM.money >= carsInShop[shoperID].price)
            {
                GM.money -= carsInShop[shoperID].price;
                showMoney.text = GM.money.ToString();
                carsInShop[shoperID].selectable = true;
                checkBoughtCars();
                GM.selectableCars.Add(shoperID);
                PlayerPrefs.SetInt("ownedCar" + shoperID, shoperID);
              //  Logger.AndroidLog("Buy Car");
              //  GooglePlay.UnlockAchievement(GooglePlay.achievement2ID);
            }
        }

    }

    private void checkBoughtCars()
    {
        for (int i = 0; i < GM.selectableCars.Count; i++)
        {
            carsInShop[GM.selectableCars[i]].selectable = true;
        }

        for (int i = 0; i < carsInShop.Count; i++)
        {
            if (carsInShop[i].selectable == true)
            {
                buttonsText[i].text = "Select";
            }
            else
            {
                buttonsText[i].text = "Buy";
            }

        }
    }


}
