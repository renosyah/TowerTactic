using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeSound : MonoBehaviour {

    public string soundEnable, soundDisable;
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
        soundSetting = dataBefore.EnableSound ? 0 : 1;
        uiText.text = dataBefore.EnableSound ? soundEnable : soundDisable;
   
    }

    private void Update()
    {
 }

    int soundSetting = 1;
    public void Change()
    {
        if (soundSetting == 0)
        {
            GamePlayUIandRuleManagementOption.GetComponent<OptionSetting>().data.EnableSound = true;
            uiText.text = soundEnable;
            soundSetting++;
        }

        else if (soundSetting == 1)
        {
            GamePlayUIandRuleManagementOption.GetComponent<OptionSetting>().data.EnableSound = false;
  
            uiText.text = soundDisable;
            soundSetting = 0;
        }

    }
}
