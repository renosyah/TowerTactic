using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplaySoundMangement : MonoBehaviour {


    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;
    public AudioClip RecruitSound,failRecruit;
    public AudioClip FightSound1, FightSound2, FightSound3, FightSound4, FightSound5;
    public AudioClip hurt1, hurt2, hurt3;
    public AudioClip Death1, Death2, Death3, Death4, Death5;
    public AudioClip CaptureMine,LostMine;
    public AudioClip fireCannon,cannFireCannon;
    
   public bool enableSound;

    void Awake()
    {
        
  
        source = GetComponent<AudioSource>();

       
       
    }

    private void Start()
    {
        if (!enableSound)
        {
            volLowRange = 0f;
            volHighRange = 0f;
            GameObject.Find("BackgroundMusic").SetActive(false);
            GameObject.Find("BackgroundMusicEasterEgg1").SetActive(false);
            GameObject.Find("BackgroundMusicEasterEgg2").SetActive(false);
        }
    }
    public void PlayFireCannon()
    {
        float vol = Random.Range(volLowRange, volHighRange);
        source.PlayOneShot(fireCannon, vol);
    }

    public void CannotFireCannon()
    {
        float vol = Random.Range(volLowRange, volHighRange);
        source.PlayOneShot(cannFireCannon, vol);
    }

    
    public void playSound()
    {

        float vol = Random.Range(volLowRange, volHighRange);
        source.PlayOneShot(RecruitSound, vol);



    }
    public void FailRecruit()
    {
        float vol = Random.Range(volLowRange, volHighRange);
        source.PlayOneShot(failRecruit, vol);
    }


    public void playFight()
    {
        float vol = Random.Range(volLowRange, volHighRange);
        source.PlayOneShot(Random.Range(1, 5) == 1 ? FightSound1 : Random.Range(1, 5) == 2 ? FightSound2 : Random.Range(1, 5) == 3 ? FightSound3 : Random.Range(1, 5) == 4 ? FightSound4 : FightSound5, vol);
    }

    public void PlayHurt()
    {
        float vol = Random.Range(volLowRange, volHighRange);
        source.PlayOneShot(Random.Range(1, 3) == 1 ? hurt1 : Random.Range(1, 3) == 2 ? hurt2 : Random.Range(1, 3) == 3 ? hurt3 : hurt1, vol);

    }
    public void PlayDead()
    {
        float vol = Random.Range(volLowRange, volHighRange);
        source.PlayOneShot(Random.Range(1, 5) == 1 ? Death1 : Random.Range(1, 5) == 2 ? Death2 : Random.Range(1, 5) == 3 ? Death3 : Random.Range(1, 5) == 4 ? Death4 : Death5, vol);

    }
    public void PlayCaptureMine()
    {
        float vol = Random.Range(volLowRange, volHighRange);
        source.PlayOneShot(CaptureMine, vol);

    }

    public void PlayLostMine()
    {
        float vol = Random.Range(volLowRange, volHighRange);
        source.PlayOneShot(LostMine, vol);
    }
}
