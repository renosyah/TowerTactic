using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonBallSpawner : MonoBehaviour {

    public GameObject CannonItself;
    Animator animCannonItself;

    public string Side;
    public GameObject CannonShell;
    GameObject Projectile;
    public float projectileVelocityMin = 100;
    public float projectileVelocityMax = 200;
    public int MinFireFrequenty = 1;
    public int MaxFireFrequenty = 100;
    public bool AutoShoot = true;
    Text ResourcesMoney, MoneyText;

    // Use this for initialization
    void Start () {
        ResourcesMoney = GameObject.Find("ResourcesMoney").GetComponent<Text>();
        MoneyText = GameObject.Find("MoneyText").GetComponent<Text>();

        animCannonItself = CannonItself.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
       
        if (Random.Range(MinFireFrequenty, MaxFireFrequenty) == Random.Range(MinFireFrequenty, MaxFireFrequenty) && AutoShoot)
        {
            ShotCannonBall();

        }
    }
    int Oneshot  = 1;
    public void ShotCannonBall()
    {
        if (Oneshot == 1 && 10 > (int.Parse(ResourcesMoney.text)))
        {
            ResourcesMoney.color = Color.red;
            MoneyText.color = Color.red;
        }
        if (!AutoShoot && Oneshot == 1 && 10 <= (int.Parse(ResourcesMoney.text)))
        {
            animCannonItself.SetBool("Shot", true);
            
            ResourcesMoney.color = Color.white;
            MoneyText.color = Color.white;
            Projectile = (GameObject)Instantiate(CannonShell, transform.position, Quaternion.identity);
            Rigidbody2D rd_Shell = Projectile.GetComponent<Rigidbody2D>();
            rd_Shell.velocity = new Vector3(Side == "Player" ? Random.Range(projectileVelocityMin, projectileVelocityMax) : Side == "Enemy" ? -Random.Range(projectileVelocityMin, projectileVelocityMax) : 0, rd_Shell.velocity.y, 0);
            ResourcesMoney.text = (int.Parse(ResourcesMoney.text) - 10) + "";
        
        }else if (AutoShoot)
        {
            animCannonItself.SetBool("Shot", true);
            
            Projectile = (GameObject)Instantiate(CannonShell, transform.position, Quaternion.identity);
            Rigidbody2D rd_Shell = Projectile.GetComponent<Rigidbody2D>();
            rd_Shell.velocity = new Vector3(Side == "Player" ? Random.Range(projectileVelocityMin, projectileVelocityMax) : Side == "Enemy" ? -Random.Range(projectileVelocityMin, projectileVelocityMax) : 0, rd_Shell.velocity.y, 0);
            StartCoroutine(Example());
             
        }
        Oneshot = 0;
    }

    IEnumerator Example()
    {
        
        yield return new WaitForSeconds(0.1f);
        Reload();
    }
    public void Reload()
    {
        Oneshot = 1;
        animCannonItself.SetBool("Shot", false);
    }

    
}
