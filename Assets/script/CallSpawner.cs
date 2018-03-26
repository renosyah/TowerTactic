using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallSpawner : MonoBehaviour {
    public GameObject SpawnerObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnFlagger()
    {
        SpawnerObject.GetComponent<Spawner>().SpawnNow();
    }
    public void SpawnSwordMan()
    {

    }
    public void SpawnPikeman()
    {

    }
    public void SpawnShieldMan()
    {

    }
    public void SpawnMaceman()
    {

    }
}
