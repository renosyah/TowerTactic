using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSpawner : MonoBehaviour
{
    public GameObject objectSpawn;
    Vector2 whereSpawn;
    float randomF;
  

    public string Owner = "Neutral";
    public int resourcesValue = 50;
    public int MinMineFrequenty = 1;
    public int MaxMineFrequenty = 300;

    public string NameGameObject;

    public int MineTotal = 2;

    public Sprite mine1;
    public Sprite mine2;
    public Sprite mine3;


    // Use this for initialization
    void Start()
    {
       
        for (int i= 1;i <= MineTotal; i++)
        {
            SpawnNow();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   

   
    public void SpawnNow()
    {


        randomF = Random.Range(-8, 8);
        whereSpawn = new Vector2((float)randomF * 4, transform.position.y);

        objectSpawn.GetComponent<GoldMineScript>().NameGameObject = NameGameObject + randomF;
        objectSpawn.GetComponent<GoldMineScript>().resourcesValue = resourcesValue;
        objectSpawn.GetComponent<GoldMineScript>().MinMineFrequenty = MinMineFrequenty;
        objectSpawn.GetComponent<GoldMineScript>().MaxMineFrequenty = MaxMineFrequenty;
        objectSpawn.GetComponent<GoldMineScript>().mine1 = mine1;
        objectSpawn.GetComponent<GoldMineScript>().mine2 = mine2;
        objectSpawn.GetComponent<GoldMineScript>().mine3 = mine3;
        

        Instantiate(objectSpawn, whereSpawn, Quaternion.identity);
          


        }
}