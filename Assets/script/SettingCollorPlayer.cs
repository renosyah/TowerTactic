using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingCollorPlayer : MonoBehaviour {

    int colorStatePlayer = 1;

    
    OptionSetting saveData;
    OptionSetting.SaveFile dataBefore;
    SpriteRenderer sprite;
    public Sprite red, blue, green, yellow, cyan, magenta;
    public GameObject spriteGameObject;
    public GameObject GamePlayUIandRuleManagementOption;
    OptionSetting option;

    private void Start()
    {
        sprite = spriteGameObject.GetComponent<SpriteRenderer>();

        
        option = GamePlayUIandRuleManagementOption.GetComponent<OptionSetting>();
        dataBefore = option.data;

        colorStatePlayer = dataBefore.colorForPlayer == "BLUE" ? 0 : dataBefore.colorForPlayer == "RED" ? 1 : dataBefore.colorForPlayer == "YELLOW" ? 2 : dataBefore.colorForPlayer == "GREEN" ? 3 : dataBefore.colorForPlayer == "CYAN" ? 4 : dataBefore.colorForPlayer == "MAGENTA" ? 5 : 0;
        sprite.sprite = dataBefore.colorForPlayer == "BLUE" ? blue : dataBefore.colorForPlayer == "RED" ? red : dataBefore.colorForPlayer == "YELLOW" ? yellow : dataBefore.colorForPlayer == "GREEN" ? green : dataBefore.colorForPlayer == "CYAN" ? cyan : dataBefore.colorForPlayer == "MAGENTA" ? magenta : blue;

    }



    public void ChangeColorPlayer()
    {
        if (colorStatePlayer == 0)
        {

            GamePlayUIandRuleManagementOption.GetComponent<OptionSetting>().data.colorForPlayer = "BLUE";
            sprite.sprite = blue;
            colorStatePlayer++;
        }
        else if (colorStatePlayer == 1)
        {

            GamePlayUIandRuleManagementOption.GetComponent<OptionSetting>().data.colorForPlayer = "RED";
            sprite.sprite = red;
            colorStatePlayer++;
        }
        else if (colorStatePlayer == 2)
        {
            GamePlayUIandRuleManagementOption.GetComponent<OptionSetting>().data.colorForPlayer = "YELLOW";
            sprite.sprite = yellow;
            colorStatePlayer++;
        }
        else if (colorStatePlayer == 3)
        {
            GamePlayUIandRuleManagementOption.GetComponent<OptionSetting>().data.colorForPlayer = "GREEN";
            sprite.sprite = green;
            colorStatePlayer++;
        }
        else if (colorStatePlayer == 4)
        {

            GamePlayUIandRuleManagementOption.GetComponent<OptionSetting>().data.colorForPlayer = "CYAN";
            sprite.sprite = cyan;
            colorStatePlayer++;
        }
        else if (colorStatePlayer == 5)
        {

            GamePlayUIandRuleManagementOption.GetComponent<OptionSetting>().data.colorForPlayer = "MAGENTA";
            sprite.sprite = magenta;
            colorStatePlayer = 0;
        }
    }
}
