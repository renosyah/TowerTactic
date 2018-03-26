using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TowerScript : MonoBehaviour
{
    Rigidbody2D rd;
    Animator anim;
    public int hp = 50;
    public string EnemyFlagger;
    public string TowerOwner;
    Text Result;
    Text ResourcesMoney;
    GameObject ScoreHolderGameObject;
    ScoreHolder score;
    GameObject cannon;
    string colorForPlayer = "BLUE";
    string ColorForEnemy = "RED";

    // Use this for initialization
    void Start()
    {
        Result = GameObject.Find("Result").GetComponent<Text>();
        ResourcesMoney = GameObject.Find("ResourcesMoney").GetComponent<Text>();
        ScoreHolderGameObject = GameObject.Find("ScoreHolderGameObject");
        score = ScoreHolderGameObject.GetComponent<ScoreHolder>();
        cannon = GameObject.Find(TowerOwner == "Player" ? "cannon" : TowerOwner == "Enemy" ? "cannonEnemy" : "cannon");

        GameObject flagPlayer = GameObject.Find("PlayerMainTower/Flag/flag_flagger");
        GameObject flagEnemy = GameObject.Find("EnemyMainTower/Flag/flag_flagger");

        SpriteRenderer colorFlagPlayer = flagPlayer.GetComponent<SpriteRenderer>();
        colorFlagPlayer.color = CharacterScript.SetColor(colorForPlayer);

        SpriteRenderer colorFlagEnemy = flagEnemy.GetComponent<SpriteRenderer>();
        colorFlagEnemy.color = CharacterScript.SetColor(ColorForEnemy);
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
            if (hp == 0)
            {
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
                   
                }
                Destroy(cannon);
            }
        }
    }
}
