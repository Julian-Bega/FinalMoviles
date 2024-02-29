using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using GooglePlayGames;

public class GameplayManager : MonoBehaviour
{    
    public List<Car> cars;

    public float[] Xposition;
    public float[] Yposition;

    public List<int> maxSpeed;
    public int minSpeed;
    public int actualMaxSpeed;

    public int kmTraveled;
    public bool onGame;
    float timeAux;
    public bool allTrue;
    private void Start()
    {
        InvokeRepeating("spawner", 2.0f, 0.5f);
      //  GooglePlay.Init();
        kmTraveled = 0;
        onGame = true;
        actualMaxSpeed = maxSpeed[0];
        allTrue = true;
    }
    private void Update()
    {
        if(onGame)
        {
            timeAux += Time.deltaTime;
            kmTraveled = Mathf.RoundToInt(timeAux);
        }
        {
            if (kmTraveled > 30)
            {
                actualMaxSpeed = maxSpeed[1];
            }
            if (kmTraveled > 60)
            {
                actualMaxSpeed = maxSpeed[2];
            }
            if (kmTraveled > 90)
            {
                actualMaxSpeed = maxSpeed[3];
            }
            if (kmTraveled > 120)
            {
                actualMaxSpeed = maxSpeed[4];
            }
            if (kmTraveled > 150)
            {
                actualMaxSpeed = maxSpeed[5];
            }
            if (kmTraveled > 180)
            {
                actualMaxSpeed = maxSpeed[6];
              //  GooglePlay.UnlockAchievement(GooglePlay.achievement3ID);
            }
        }
    }

    public void spawnCar(int id)
    {
        int intAux;
        intAux = Random.Range(1, 3);
        cars[id].state = intAux;
        float floatAux;
        floatAux = Random.Range(minSpeed, actualMaxSpeed);
        float aux = Random.Range(Xposition[0], Xposition[5]);
        cars[id].speed = floatAux;
        if (cars[id].state == 1)
        {
            cars[id].gameObject.transform.position = new Vector3(aux, Yposition[0], transform.position.z);
        }
        else if (cars[id].state == 2)
        {
            cars[id].gameObject.transform.position = new Vector3(aux, Yposition[1], transform.position.z);
        }
        
    }

    public void setBackToIdle(GameObject carToBack)
    {
        carToBack.GetComponent<Car>().speed = 0;
        carToBack.transform.position = new Vector3(0, 0, 0);
    }

    public void spawner()
    {
        int intAux;
        intAux = Random.Range(0, 11);

       
        for (int i = 0; i < 11; i++)
        {
            if (cars[intAux].state == 0)
                allTrue = false;
        }

        while (cars[intAux].state != 0 && allTrue == false)
        {
            intAux = Random.Range(0, 11);
        }
        if (allTrue) return;
        spawnCar(intAux);
    }


}
