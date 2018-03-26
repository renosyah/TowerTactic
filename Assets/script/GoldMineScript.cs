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

    string colorForPlayer = "BLUE";
    string ColorForEnemy = "RED";
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
        
        sprt.sprite = Random.Range(1,3) == 1 ? mine1 : Random.Range(1,3) == 2 ? mine2 : mine3;
    }
	
	// Update is called once per frame
	void Update () {
	    if (Owner == "Player" && Random.Range(MinMineFrequenty, MaxMineFrequenty) == Random.Range(MinMineFrequenty, MaxMineFrequenty))
        {
            
            ResourcesMoney.text = (int.Parse(ResourcesMoney.text) + resourcesValue) + "";
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

            flagColor.color =CharacterScript.SetColor(colorForPlayer);
            this.gameObject.layer = 13;
            Owner = "Player";

        }
        else if (collision.gameObject.tag == "EnemyFlagger")
        {
            
            flagColor.color = CharacterScript.SetColor(ColorForEnemy); ;
            this.gameObject.layer = 12;
            Owner = "Enemy";
        }
    }

}
