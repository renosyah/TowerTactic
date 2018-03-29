using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TowerScript : MonoBehaviour
{
    Rigidbody2D rd;
    Animator anim;
    int hp = 1;
    public string EnemyFlagger;
    public string TowerOwner;
    Text Result;
    Text ResourcesMoney;
    GameObject ScoreHolderGameObject;
    ScoreHolder score;
    public GameObject cannon;
    
    OptionSetting ruleAndUi;

    public GameObject resultGameCanvas;
    // Use this for initialization
    void Start()
    {
        

        ruleAndUi = GameObject.Find("GamePlayUIandRuleManagement").GetComponent<OptionSetting>();

        ResourcesMoney = GameObject.Find("ResourcesMoney").GetComponent<Text>();
        ScoreHolderGameObject = GameObject.Find("ScoreHolderGameObject");
        score = ScoreHolderGameObject.GetComponent<ScoreHolder>();

        hp = hp + ruleAndUi.GetComponent<OptionSetting>().GetPlushHP();






        Result = GameObject.Find("Result").GetComponent<Text>();


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == EnemyFlagger)
        {
            hp--;
            
            if (hp >= 0)
            {
                Destroy(GameObject.Find("PlayerTroopSpawner"));
                Destroy(cannon);
                Destroy(this.gameObject);
                if (TowerOwner == "Player")
                {
                    score.MoneyTotal = int.Parse(ResourcesMoney.text);
                    Result.text = "You Lose, Enemy Troops Hass Captured Your Tower!\n\n" + "Your Troop Kill " + score.YourSoldierKill;
                    Result.text += "\n" + "Your Troop Lost " + score.YourSoldierLost;
                    Result.text += "\n" + "Enemy Troop Kill " + score.EnemySoldierKill ;
                    Result.text += "\n" + "Enemy Troop Lost " + score.EnemySoldierLost;
                    Result.text += "\n" + "Your Troop Train " + score.YourTroopTrainTotal;
                    Result.text += "\n" + "Enemy Troop Train " + score.EnemyTroopTrainTotal;
                    Result.text += "\n" + "Your Money " + score.MoneyTotal;
                    Result.text += "\n" + "Thanks For Playing";

                    Destroy(GameObject.Find("EnemyTroopSpawner"));
                    Destroy(GameObject.Find("PlayerTroopSpawner"));
                    resultGameCanvas.SetActive(true);
                }
                else if (TowerOwner == "Enemy")
                {
                    score.MoneyTotal = int.Parse(ResourcesMoney.text);
                    Result.text = "You Win, Enemy Tower Hass been Captured!\n\n" + "Your Troop Kill " + score.YourSoldierKill;
                  
                    Result.text += "\n" + "Your Troop Lost " + score.YourSoldierLost;
                    Result.text += "\n" + "Enemy Troop Kill " + score.EnemySoldierKill;
                    Result.text += "\n" + "Enemy Troop Lost " + score.EnemySoldierLost;
                    Result.text += "\n" + "Your Troop Train " + score.YourTroopTrainTotal;
                    Result.text += "\n" + "Enemy Troop Train " + score.EnemyTroopTrainTotal;
                    Result.text += "\n" + "Your Money " + score.MoneyTotal;
                    Result.text += "\n" + "Thanks For Playing";

                    Destroy(GameObject.Find("EnemyTroopSpawner"));
                    Destroy(GameObject.Find("PlayerTroopSpawner"));
                    resultGameCanvas.SetActive(true);
                }
                
            }
        }
       
        
    }
}
