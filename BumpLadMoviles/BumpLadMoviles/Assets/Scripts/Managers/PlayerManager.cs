using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public SpriteRenderer playerCar;
    public int money;
    public Vector3 startPos;
    private GameManager GM;
    private GameUI GUI;

    private void Awake()
    {
        GM = FindObjectOfType<GameManager>();
        GUI = FindObjectOfType<GameUI>();
    }
    void Start()
    {
        this.transform.position = startPos;
        playerCar.sprite = GM.selectedCar;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Car"))
        {
            Debug.Log("ChoquePlayer-Auto");
            GUI.Defeat();
        }

        
    }



}
