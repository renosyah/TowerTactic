using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChageDif : MonoBehaviour {

    public string easy, normal, hard, crazy;
    OptionSetting saveData;
    OptionSetting.SaveFile dataBefore;
    public GameObject GamePlayUIandRuleManagementOption;
    OptionSetting option;


    public GameObject GameObjectTarget;
    Text uiText;

    // Use this for initialization
    void Start () {
        
        option = GamePlayUIandRuleManagementOption.GetComponent<OptionSetting>();
        uiText = GameObjectTarget.GetComponent<Text>();

        dataBefore = option.data;

        difSetting = dataBefore.dificulty;
        uiText.text = dataBefore.dificulty == 0 ? easy : dataBefore.dificulty == 1 ? normal : dataBefore.dificulty == 2 ? hard : dataBefore.dificulty == 3 ? crazy : easy;

    }

    private void Update()
    {
 }

    int difSetting = 1;
    public void ChangeDif()
    {
        if (difSetting == 0)
        {
            GamePlayUIandRuleManagementOption.GetComponent<OptionSetting>().data.dificulty = 0;


            uiText.text = easy;
            difSetting++;
        }
        else if (difSetting == 1)
        {
            GamePlayUIandRuleManagementOption.GetComponent<OptionSetting>().data.dificulty = 1;


            uiText.text = normal;
            difSetting++;
        }
        else if (difSetting == 2)
        {
            GamePlayUIandRuleManagementOption.GetComponent<OptionSetting>().data.dificulty = 2;


            uiText.text = hard;
            difSetting++;
        }
        else if (difSetting == 3)
        {
            GamePlayUIandRuleManagementOption.GetComponent<OptionSetting>().data.dificulty = 3;

            uiText.text = crazy;
            difSetting = 0;
        }
       
    }
}
