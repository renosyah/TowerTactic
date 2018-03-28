using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingEnemyCollor : MonoBehaviour {

    int colorStateEnemy = 1;

    
    OptionSetting saveData;
    OptionSetting.SaveFile dataBefore;
    SpriteRenderer sprite;
    public Sprite red, blue, green, yellow, cyan, magenta;
    public GameObject spriteGameObject;
    public  GameObject GamePlayUIandRuleManagementOption;
    OptionSetting option;


    private void Start()
    {
        
        option = GamePlayUIandRuleManagementOption.GetComponent<OptionSetting>();
        dataBefore = option.data;


        sprite = spriteGameObject.GetComponent<SpriteRenderer>();

        colorStateEnemy = dataBefore.colorForEnemy == "BLUE" ? 0 : dataBefore.colorForEnemy == "RED" ? 1 : dataBefore.colorForEnemy == "YELLOW" ? 2 : dataBefore.colorForEnemy == "GREEN" ? 3 : dataBefore.colorForEnemy == "CYAN" ? 4 : dataBefore.colorForEnemy == "MAGENTA" ? 5 : 1;
        sprite.sprite = dataBefore.colorForEnemy == "BLUE" ? blue : dataBefore.colorForEnemy == "RED" ? red : dataBefore.colorForEnemy == "YELLOW" ? yellow : dataBefore.colorForEnemy == "GREEN" ? green : dataBefore.colorForEnemy == "CYAN" ? cyan : dataBefore.colorForEnemy == "MAGENTA" ? magenta : red;

    }

    private void Update()
    {

    }



    public void ChangeEnemyColor()
        {

            if (colorStateEnemy == 0)
            {

            GamePlayUIandRuleManagementOption.GetComponent<OptionSetting>().data.colorForEnemy = "BLUE";
                sprite.sprite = blue;
                colorStateEnemy++;
            }
            else if (colorStateEnemy == 1)
            {

            GamePlayUIandRuleManagementOption.GetComponent<OptionSetting>().data.colorForEnemy = "RED";
                sprite.sprite = red;
                colorStateEnemy++;
            }
            else if (colorStateEnemy == 2)
            {
            GamePlayUIandRuleManagementOption.GetComponent<OptionSetting>().data.colorForEnemy = "YELLOW";
                sprite.sprite = yellow;
                colorStateEnemy++;
            }
            else if (colorStateEnemy == 3)
            {
            GamePlayUIandRuleManagementOption.GetComponent<OptionSetting>().data.colorForEnemy = "GREEN";
                sprite.sprite = green;
                colorStateEnemy++;
            }
            else if (colorStateEnemy == 4)
            {

            GamePlayUIandRuleManagementOption.GetComponent<OptionSetting>().data.colorForEnemy = "CYAN";
                sprite.sprite = cyan;
                colorStateEnemy++;
            }
            else if (colorStateEnemy == 5)
            {

            GamePlayUIandRuleManagementOption.GetComponent<OptionSetting>().data.colorForEnemy = "MAGENTA";
                sprite.sprite = magenta;
                colorStateEnemy = 0;
            }


    }



    
}
