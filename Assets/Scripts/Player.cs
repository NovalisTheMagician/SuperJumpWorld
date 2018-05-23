using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private float speed;

	void Start ()
    {
		
	}
	
	void FixedUpdate ()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

		if(Input.GetKey("d"))
        {
            rb.AddForce(Vector2.right * 32);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(Vector2.left * 32);
        }

        
    }

    private void LateUpdate()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (rb.velocity.x >= 12)
        {
            rb.velocity = new Vector2(12, rb.velocity.y);
        }
    }
}
