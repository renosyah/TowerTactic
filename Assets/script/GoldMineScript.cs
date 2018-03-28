using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GoldMineScript : MonoBehaviour {

    Rigidbody2D rd;
    Animator anim;
    Text ResourcesMoney;
    public string Owner = "Neutral";
    public int resourcesValue = 50;
    public int MinMineFrequenty = 1;
    public int MaxMineFrequenty = 300;
    GameObject findMineFlag; SpriteRenderer flagColor;
    public string NameGameObject;
    SpriteRenderer sprt;
    public Sprite mine1;
    public Sprite mine2;
    public Sprite mine3;
    public Sprite mine4;
    public Sprite mine5;
    public GameObject soundManagement;
    GameplaySoundMangement gs;

    OptionSetting ruleAndUi;

    // Use this for initialization
    void Start () {
        rd = this.gameObject.GetComponent<Rigidbody2D>();
        anim = this.gameObject.GetComponent<Animator>();
        sprt = this.gameObject.GetComponent<SpriteRenderer>();
        this.gameObject.layer = 14;
        this.gameObject.name = NameGameObject;
        ResourcesMoney = GameObject.Find("ResourcesMoney").GetComponent<Text>();
        findMineFlag = GameObject.Find(NameGameObject + "/Flag/flag_flagger");
        flagColor = findMineFlag.GetComponent<SpriteRenderer>();

        soundManagement = GameObject.Find("GameplaySoundManagementGameObject");
        gs = soundManagement.GetComponent<GameplaySoundMangement>();

        sprt.sprite = Random.Range(1,5) == 1 ? mine1 : Random.Range(1,5) == 2 ? mine2 : Random.Range(1, 5) == 3 ? mine3 : Random.Range(1, 5) == 4 ? mine4 : mine5;

        ruleAndUi = GameObject.Find("GamePlayUIandRuleManagement").GetComponent<OptionSetting>();
    }
	
	// Update is called once per frame
	void Update () {
	    if (Owner == "Player" && Random.Range(MinMineFrequenty, MaxMineFrequenty) == Random.Range(MinMineFrequenty, MaxMineFrequenty))
        {
            
            ResourcesMoney.text = (int.Parse(ResourcesMoney.text) + resourcesValue) + "";
            gs.PlayCaptureMine();
        }
        else if (Owner == "Enemy")
        {

        }else
        {

        }
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.gameObject.tag == "PlayerFlagger")
        {

            flagColor.color =CharacterScript.SetColor(ruleAndUi.colorForPlayer);
            this.gameObject.layer = 13;
            Destroy(GameObject.Find(collision.gameObject.name));
            Owner = "Player";

        }
        else if (collision.gameObject.tag == "EnemyFlagger")
        {
            
            flagColor.color = CharacterScript.SetColor(ruleAndUi.colorForEnemy); ;
            this.gameObject.layer = 12;
            Destroy(GameObject.Find(collision.gameObject.name));
            Owner = "Enemy";
        }
    }

}
