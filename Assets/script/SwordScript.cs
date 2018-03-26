using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour {
    Rigidbody2D rd;

	// Use this for initialization
	void Start () {
        rd = GetComponent<Rigidbody2D>();
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "CannonBall")
        {
            Destroy(this.gameObject);
        }
    }
}
