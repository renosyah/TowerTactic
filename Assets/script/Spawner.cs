using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Spawner : MonoBehaviour
{
    public GameObject objectSpawn;
    Vector2 whereSpawn;
    public float SpawnRate;
    float randomF;
    float NextSpawn = 0.0f;

    public bool enableAutomaticSpawn = false;
    public string NameGameObject;
    public string Tag;
    public float Speed;
    public int HP;
    public int MaxHP;
    public bool facingRight;
    public string EnemySwordTag;
    public string SwordTag;
    public int layer;
    public Color32 color;
    public int spawnerFrequent;
    public int UnitCost;
    public string Side;
    GameObject ScoreHolderGameObject;
    ScoreHolder score;
    Text ResourcesMoney, MoneyText;

    public GameObject soundManagement;
    GameplaySoundMangement gs;


    OptionSetting ruleAndUi;
    // Use this for initialization
    void Start()
    {
        
        ResourcesMoney = GameObject.Find("ResourcesMoney").GetComponent<Text>();
        MoneyText = GameObject.Find("MoneyText").GetComponent<Text>();
        ScoreHolderGameObject = GameObject.Find("ScoreHolderGameObject");
        score = ScoreHolderGameObject.GetComponent<ScoreHolder>();

        soundManagement = GameObject.Find("GameplaySoundManagementGameObject");
        gs = soundManagement.GetComponent<GameplaySoundMangement>();

        ruleAndUi = GameObject.Find("GamePlayUIandRuleManagement").GetComponent<OptionSetting>();
        SpawnRate = SpawnRate + ruleAndUi.GetSpawnRate();
    }

    // Update is called once per frame
    void Update()
    {
        if (enableAutomaticSpawn)
        {
            if (Random.Range(1, (ruleAndUi.GetSpawnRate())) == Random.Range(1, (ruleAndUi.GetSpawnRate())))
            {
                SpawnNow();
            }
            

        }
        

    }
    public void EnableNow()
    {
        enableAutomaticSpawn = true;
    }
    public void DisableNow()
    {
        enableAutomaticSpawn = false;
    }

    int SpawnOnce = 1;
    public void SpawnNow()
    {

     


        if (SpawnOnce == 1 && UnitCost > (int.Parse(ResourcesMoney.text)))
        {
            ResourcesMoney.color = Color.red;
            MoneyText.color = Color.red;
            gs.FailRecruit();
            
        }
            if (SpawnOnce == 1 && !enableAutomaticSpawn && UnitCost <= (int.Parse(ResourcesMoney.text)))
        {

            gs.playSound();
            ResourcesMoney.color = Color.white;
            MoneyText.color = Color.white;
            NextSpawn = Time.time + SpawnRate;
            randomF = Random.Range(1.4f, 100.4f);
            whereSpawn = new Vector2(transform.position.x, transform.position.y);

            objectSpawn.GetComponent<CharacterScript>().NameGameObject = NameGameObject + randomF;
            objectSpawn.GetComponent<CharacterScript>().Tag = Tag;
            objectSpawn.GetComponent<CharacterScript>().Speed = Speed;
            objectSpawn.GetComponent<CharacterScript>().HP = HP;
            objectSpawn.GetComponent<CharacterScript>().MaxHP = MaxHP;
            objectSpawn.GetComponent<CharacterScript>().facingRight = facingRight;
            objectSpawn.GetComponent<CharacterScript>().EnemySwordTag = EnemySwordTag;
            objectSpawn.GetComponent<CharacterScript>().SwordTag = SwordTag;
            objectSpawn.GetComponent<CharacterScript>().layer = layer;
            objectSpawn.GetComponent<CharacterScript>().color = color;
            objectSpawn.GetComponent<CharacterScript>().UnitCost = UnitCost;
            objectSpawn.GetComponent<CharacterScript>().side = Side;
           

            Instantiate(objectSpawn, whereSpawn, Quaternion.identity);
            ResourcesMoney.text = (int.Parse(ResourcesMoney.text) - UnitCost) + "";

            score.YourTroopTrainTotal = score.YourTroopTrainTotal + 1;


        }
        else if (enableAutomaticSpawn)
        {
            NextSpawn = Time.time + SpawnRate;
            randomF = Random.Range(1.4f, 100.4f);
            whereSpawn = new Vector2(transform.position.x, transform.position.y);

            objectSpawn.GetComponent<CharacterScript>().NameGameObject = NameGameObject + randomF;
            objectSpawn.GetComponent<CharacterScript>().Tag = Tag;
            objectSpawn.GetComponent<CharacterScript>().Speed = Speed;
            objectSpawn.GetComponent<CharacterScript>().HP = HP;
            objectSpawn.GetComponent<CharacterScript>().MaxHP = MaxHP;
            objectSpawn.GetComponent<CharacterScript>().facingRight = facingRight;
            objectSpawn.GetComponent<CharacterScript>().EnemySwordTag = EnemySwordTag;
            objectSpawn.GetComponent<CharacterScript>().SwordTag = SwordTag;
            objectSpawn.GetComponent<CharacterScript>().layer = layer;
            objectSpawn.GetComponent<CharacterScript>().color = color;
            objectSpawn.GetComponent<CharacterScript>().side = Side;
            

            Instantiate(objectSpawn, whereSpawn, Quaternion.identity);

            score.EnemyTroopTrainTotal = score.EnemyTroopTrainTotal + 1;
        }
        SpawnOnce = 0;
    }
    public void RecargeSpawn()
    {
        SpawnOnce = 1;
    }
}
