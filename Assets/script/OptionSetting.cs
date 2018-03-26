using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionSetting : MonoBehaviour{

    public GameObject ColorSpawner;
    public GameObject TowerFlagEnemy;
    public GameObject TowerFlagPlayer;

    public GameObject PlayerFlagger;
    public GameObject PlayerSwordMan;
    public GameObject PlayerPikeMan;
    public GameObject PlayerShieldMan;
    public GameObject PlayerMaceMan;

    public GameObject MineSpawner;

    private void Start()
    {
        /*
        ColorSpawner.GetComponent<Spawner>().ColorForEnemy = "YELLOW";
        ColorSpawner.GetComponent<Spawner>().colorForPlayer = "RED";

        

        TowerFlagEnemy.GetComponent<TowerScript>().ColorForEnemy = "YELLOW";
        TowerFlagEnemy.GetComponent<TowerScript>().colorForPlayer = "RED";

        TowerFlagPlayer.GetComponent<TowerScript>().ColorForEnemy = "YELLOW";
        TowerFlagPlayer.GetComponent<TowerScript>().colorForPlayer = "RED";


        PlayerFlagger.GetComponent<Spawner>().colorForPlayer="RED";
        PlayerFlagger.GetComponent<Spawner>().ColorForEnemy="YELLOW";

        PlayerSwordMan.GetComponent<Spawner>().colorForPlayer="RED";
        PlayerSwordMan.GetComponent<Spawner>().ColorForEnemy="YELLOW";

        PlayerPikeMan.GetComponent<Spawner>().colorForPlayer="RED";
        PlayerPikeMan.GetComponent<Spawner>().ColorForEnemy="YELLOW";

        PlayerShieldMan.GetComponent<Spawner>().colorForPlayer="RED";
        PlayerShieldMan.GetComponent<Spawner>().ColorForEnemy="YELLOW";

        PlayerMaceMan.GetComponent<Spawner>().colorForPlayer="RED";
        PlayerMaceMan.GetComponent<Spawner>().ColorForEnemy="YELLOW";

        MineSpawner.GetComponent<MineSpawner>().colorForPlayer = "RED";
        MineSpawner.GetComponent<MineSpawner>().ColorForEnemy = "YELLOW";
        */
    }

    private void Update()
    {
    }


    public void SaveData()
    {

    }


    public void LoadData()
    {

    }

[System.Serializable]
class SaveFile
    {

    }
}
