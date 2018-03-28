using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
public class OptionSetting : MonoBehaviour{

    public string colorForPlayer;
    public string colorForEnemy;
    int SpawnRate,FireRateMin,FireRateMax;
    int PlusHP,CannonBallDamage;
    Text ResourcesMoney;
    int MintMoneyFreq, PlushMoneyFreq,RecourceGive;
    int MineQuantity,MoneyStart;
    public SaveFile data;

   

    public void SaveNow()
    {
        SaveData(data);
        data = LoadData();
    }

    private void Awake()
    {
        data = LoadData();
    }

    private void Start()
    {


        data = LoadData();

        if (data.dificulty == 0)
        {
            SetEasy();

        }else if (data.dificulty ==1)
        {
            SetNormal();
        }
        if (data.dificulty == 2)
        {
            SetHard();
        }
        if (data.dificulty == 3)
        {
            SetCrazy();
        }

        colorForPlayer = data.colorForPlayer;
        colorForEnemy = data.colorForEnemy;

        if (GameObject.Find("PlayerMainTower/Flag/flag_flagger") != null)
        {
            GameObject flagPlayer = GameObject.Find("PlayerMainTower/Flag/flag_flagger");
            SpriteRenderer colorFlagPlayer = flagPlayer.GetComponent<SpriteRenderer>();
            colorFlagPlayer.color = CharacterScript.SetColor(data.colorForPlayer);
        }

        if (GameObject.Find("EnemyMainTower/Flag/flag_flagger") != null)
        {
            GameObject flagEnemy = GameObject.Find("EnemyMainTower/Flag/flag_flagger");
            SpriteRenderer colorFlagEnemy = flagEnemy.GetComponent<SpriteRenderer>();
            colorFlagEnemy.color = CharacterScript.SetColor(data.colorForEnemy);
        }
        
        

        
        

        
        if (GameObject.Find("GameplaySoundManagementGameObject") != null)
        {
            GameObject.Find("GameplaySoundManagementGameObject").GetComponent<GameplaySoundMangement>().enableSound = data.EnableSound;
        }
        

        if (GameObject.Find("ResourcesMoney") != null)
        {
            ResourcesMoney = GameObject.Find("ResourcesMoney").GetComponent<Text>();
            ResourcesMoney.text = MoneyStart + "";
        }
       
    }

    void SendMoney()
    {
    
        if (Random.Range(1,500) == Random.Range(1, 500) && GameObject.Find("ResourcesMoney") != null)
        {

            ResourcesMoney.text = (int.Parse(ResourcesMoney.text) + RecourceGive) + "";
            
        }
    }
    public void SetCustom(int Money,int MineQuantity,int SpawnRate,int FireRateMin,int FireRateMax,int PlusHP,int CannonBallDamage,int RecourceGive)
    {

        this.MineQuantity = MineQuantity;
        this.SpawnRate = SpawnRate;
        this.FireRateMin = FireRateMin;
        this.FireRateMax = FireRateMax;
        this.PlusHP = PlusHP;
        this.CannonBallDamage = CannonBallDamage;
        this.RecourceGive = RecourceGive;
        this.MoneyStart = Money;
    }

    public void SetEasy()
    {
        MineQuantity = Random.Range(2,3);
        SpawnRate = 50;
        FireRateMin = 1;
        FireRateMax = 250;
        PlusHP = 0;
        CannonBallDamage = 5;
        RecourceGive = 10;
        MoneyStart = Random.Range(800, 1000);
    }
    public void SetNormal()
    {
        MineQuantity = Random.Range(1, 3);
        SpawnRate = 45;
        FireRateMin = 1;
        FireRateMax = 200;
        PlusHP = 2;
        CannonBallDamage = 7;
        RecourceGive = 5;
        MoneyStart = Random.Range(500, 900);
    }
    public void SetHard()
    {
        MineQuantity = Random.Range(1, 2);
        SpawnRate = 20;
        FireRateMin = 1;
        FireRateMax = 140;
        PlusHP = 3;
        CannonBallDamage = 8;
        RecourceGive = 0;
        MoneyStart = Random.Range(400, 700);
    }
    public void SetCrazy()
    {
        MineQuantity = 1;
        SpawnRate = 5;
        FireRateMin = 1;
        FireRateMax = 75;
        PlusHP = 4;
        RecourceGive = 0;
        CannonBallDamage = 10;
        MoneyStart = Random.Range(400, 600);
    }
    public int GetSpawnRate()
    {
        return SpawnRate;
    }
    public int GetMineQuantity()
    {
        return MineQuantity;
    }
    public int GetFireRateMin()
    {
        return FireRateMin;
    }
    public int GetFireRateMax()
    {
        return FireRateMax;
    }
    public int GetPlushHP()
    {
        return PlusHP;
    }
    public int GetCannonBallDamage()
    {
        return CannonBallDamage;
    }

    private void Update()
    {
        SendMoney();
    }


    public void SaveData(SaveFile f)
    {
        SaveFile s = new SaveFile();
        s.colorForEnemy = f.colorForEnemy;
        s.colorForPlayer = f.colorForPlayer;
        s.EnableMusic = f.EnableMusic;
        s.EnableSound = f.EnableSound;
        s.dificulty = f.dificulty;

        BinaryFormatter bf = new BinaryFormatter();
       
        FileStream stream = new FileStream(Application.persistentDataPath + "/setting.sv", FileMode.Create);
        bf.Serialize(stream, s);
        stream.Close();
       
    }
    public static void SaveDataStatic(SaveFile f)
    {
        SaveFile s = new SaveFile();
        s.colorForEnemy = f.colorForEnemy;
        s.colorForPlayer = f.colorForPlayer;
        s.EnableMusic = f.EnableMusic;
        s.EnableSound = f.EnableSound;
        s.dificulty = f.dificulty;

        BinaryFormatter bf = new BinaryFormatter();

        FileStream stream = new FileStream(Application.persistentDataPath + "/setting.sv", FileMode.Create);
        bf.Serialize(stream, s);
        stream.Close();
    }
    public static SaveFile LoadDataStatic()
    {
        SaveFile data = new SaveFile();
        if (File.Exists(Application.persistentDataPath + "/setting.sv"))
        {

            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/setting.sv", FileMode.Open);
            data = bf.Deserialize(stream) as SaveFile;
            stream.Close();
        }
        else
        {
            data.colorForEnemy = "RED";
            data.colorForPlayer = "BLUE";
            data.dificulty = 2;
            data.EnableMusic = true;
            data.EnableSound = true;
        }

        return data;
    }
    public SaveFile LoadData()
    {
        SaveFile data = new SaveFile();
        if (File.Exists(Application.persistentDataPath + "/setting.sv"))
        {

            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/setting.sv", FileMode.Open);
            data = bf.Deserialize(stream) as SaveFile;
            stream.Close();
        }
        else
        {
            data.colorForEnemy = "RED";
            data.colorForPlayer = "BLUE";
            data.dificulty = 2;
            data.EnableMusic = true;
            data.EnableSound = true;
        }
       
        return data;
    }

[System.Serializable]
public class SaveFile
    {
        public string colorForPlayer;
        public string colorForEnemy;
        public int dificulty;
        public bool EnableMusic;
        public bool EnableSound;
    }
}
