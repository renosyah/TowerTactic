using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterScript : MonoBehaviour {

    Rigidbody2D rd;
    Animator anim;
    public string NameGameObject;
    public string Tag;
    public float Speed;
    public int HP;
    public int MaxHP;
    public bool facingRight;
    public string EnemySwordTag;
    public string SwordTag;
    public int layer;
    public string side;
    public int UnitCost;
    public Color color;

    GameObject ScoreHolderGameObject;
    ScoreHolder score;
    Text ResourcesMoney, MoneyText;

    public GameObject soundManagement;

     public static Color SetColor(string colorChoose)
    {

        

        if (colorChoose == "RED")
        {
            return Color.red;
        }
        else if (colorChoose == "BLUE")
        {
            return Color.blue;
        }
        else if (colorChoose == "GREEN")
        {
            return Color.green;
        }
        else if (colorChoose == "YELLOW")
        {
            return Color.yellow;
        }
        else if (colorChoose == "GREY")
        {
            return Color.grey;
        }
        else if (colorChoose == "MAGENTA")
        {
            return Color.magenta;

        }else {
            return Color.white;
        }

        
    }

    GameplaySoundMangement gs;

    OptionSetting ruleAndUi;

    void Start () {
        rd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        this.gameObject.name = NameGameObject;
        this.gameObject.tag = Tag;
        this.gameObject.layer = layer;

        ScoreHolderGameObject = GameObject.Find("ScoreHolderGameObject");
        score = ScoreHolderGameObject.GetComponent<ScoreHolder>();
        soundManagement = GameObject.Find("GameplaySoundManagementGameObject");
        gs  = soundManagement.GetComponent<GameplaySoundMangement>();

        ruleAndUi = GameObject.Find("GamePlayUIandRuleManagement").GetComponent<OptionSetting>();

        ResourcesMoney = GameObject.Find("ResourcesMoney").GetComponent<Text>();
        MoneyText = GameObject.Find("MoneyText").GetComponent<Text>();



        if (GameObject.Find(NameGameObject + "/arm_1/sword_swordman") != null)
        {
            GameObject.Find(NameGameObject + "/arm_1/sword_swordman").tag = SwordTag;
            GameObject.Find(NameGameObject + "/arm_1/sword_swordman").layer = layer;
        }
        if (GameObject.Find(NameGameObject + "/arm_1/Flag/flag_flagger") != null)
        {

            SpriteRenderer render = GameObject.Find(NameGameObject + "/arm_1/Flag/flag_flagger").GetComponent<SpriteRenderer>();
            

            if (side == "Player")
            {
                render.color = SetColor(ruleAndUi.colorForPlayer);
               

            }
            else if (side == "Enemy")
            {
                render.color = SetColor(ruleAndUi.colorForEnemy);


            }
        }
        if (GameObject.Find(NameGameObject + "/head/helm_swordman") != null)
        {

            SpriteRenderer render = GameObject.Find(NameGameObject + "/head/helm_swordman").GetComponent<SpriteRenderer>();


            if (side == "Player")
            {
                render.color = SetColor(ruleAndUi.colorForPlayer);


            }
            else if (side == "Enemy")
            {
                render.color = SetColor(ruleAndUi.colorForEnemy);


            }
        }

        HP = HP + ruleAndUi.GetPlushHP();
    }

 
    void Update()
    {
        MoveObject(Speed);
        

    }

    void MoveObject(float speed)
    {
        if (!facingRight)
        {
            Vector3 temp = transform.localScale;
            temp.x = -1;
            transform.localScale = temp;

        }
        rd.velocity = new Vector3(speed, rd.velocity.y, 0);

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == EnemySwordTag)
        {
            
            gs.playFight();
            gs.PlayHurt();
            HP--;
            if (HP <= 0)
            {
                
                if (side == "Enemy")
                {
                    
                    ResourcesMoney.color = Color.white;
                    MoneyText.color = Color.white;
                    ResourcesMoney.text = (int.Parse(ResourcesMoney.text) + Random.Range(1, 100)) + "";
                    score.YourSoldierKill = score.YourSoldierKill + 1;

                }else if (side == "Player")
                {
                    score.YourSoldierLost = score.YourSoldierLost + 1;
                }
                Destroy(this.gameObject);
                gs.PlayDead();

            }
            else if (HP == 2 || HP == 3 || HP == 4 && GameObject.Find(NameGameObject + "/head/helm_swordman") != null)
            {
                Destroy(GameObject.Find(NameGameObject + "/head/helm_swordman"));
            }
        }else if(collision.gameObject.tag == "CannonBall")
        {

            HP = HP - ruleAndUi.GetCannonBallDamage();
            Destroy(collision.gameObject);
            if (HP <= 0)
            {

                if (side == "Enemy")
                {

                    ResourcesMoney.color = Color.white;
                    MoneyText.color = Color.white;
                    ResourcesMoney.text = (int.Parse(ResourcesMoney.text) + Random.Range(1,100)) + "";
                    score.YourSoldierKill = score.YourSoldierKill + 1;
                    score.EnemySoldierLost = score.EnemySoldierLost + 1;
                }
                else if (side == "Player")
                {
                    score.YourSoldierLost = score.YourSoldierLost + 1;
                    score.EnemySoldierKill = score.EnemySoldierKill + 1;

                }
                gs.PlayDead();
                Destroy(this.gameObject);
            }
            
        }
    }


}
