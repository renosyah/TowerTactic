using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplowsiveScript : MonoBehaviour
{

	
    Rigidbody2D rd;
    Animator anim;
    int hp = 5;

    // Use this for initialization
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
          
            Destroy(this.gameObject);


        }
    }
}
