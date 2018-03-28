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
    public Sprite mine4;
    public Sprite mine5;

    OptionSetting ruleAndUi;

    // Use this for initialization
    void Start()
    {
        ruleAndUi = GameObject.Find("GamePlayUIandRuleManagement").GetComponent<OptionSetting>();

        for (int i= 1;i <= ruleAndUi.GetMineQuantity(); i++)
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
        objectSpawn.GetComponent<GoldMineScript>().mine1 = Random.Range(1, 5) == 1 ? mine1 : Random.Range(1, 5) == 2 ? mine2 : Random.Range(1, 5) == 3 ? mine3 : Random.Range(1, 5) == 4 ? mine4 : mine5;
        objectSpawn.GetComponent<GoldMineScript>().mine2 = Random.Range(1, 5) == 1 ? mine1 : Random.Range(1, 5) == 2 ? mine2 : Random.Range(1, 5) == 3 ? mine3 : Random.Range(1, 5) == 4 ? mine4 : mine5;
        objectSpawn.GetComponent<GoldMineScript>().mine3 = Random.Range(1, 5) == 1 ? mine1 : Random.Range(1, 5) == 2 ? mine2 : Random.Range(1, 5) == 3 ? mine3 : Random.Range(1, 5) == 4 ? mine4 : mine5;
        objectSpawn.GetComponent<GoldMineScript>().mine4 = Random.Range(1, 5) == 1 ? mine1 : Random.Range(1, 5) == 2 ? mine2 : Random.Range(1, 5) == 3 ? mine3 : Random.Range(1, 5) == 4 ? mine4 : mine5;
        objectSpawn.GetComponent<GoldMineScript>().mine5 = Random.Range(1, 5) == 1 ? mine1 : Random.Range(1, 5) == 2 ? mine2 : Random.Range(1, 5) == 3 ? mine3 : Random.Range(1, 5) == 4 ? mine4 : mine5;

        Instantiate(objectSpawn, whereSpawn, Quaternion.identity);
          


        }
}