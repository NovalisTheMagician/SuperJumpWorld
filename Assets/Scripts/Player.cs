using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    [SerializeField]
    private float speed = 2;

    [SerializeField]
    private Transform groundCheck;

    private bool isOnGround;

	void Start ()
    {
		
	}
	
    void Update()
    {
        RaycastHit2D[] hit = new RaycastHit2D[1];
        ContactFilter2D filter = new ContactFilter2D();
        filter.SetLayerMask(LayerMask.NameToLayer("Platform"));
        int hits = Physics2D.Linecast(transform.position, groundCheck.position, filter, hit);
        isOnGround = hits > 0;

        if(this.transform.position.y < -10)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

	void FixedUpdate ()
    {
        Debug.Log(isOnGround);

        Rigidbody2D rb = GetComponent<Rigidbody2D>();

		if(Input.GetKey("d"))
        {
            rb.AddForce(Vector2.right * 32);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(Vector2.left * 32);
        }

        if (Input.GetKey(KeyCode.Space) && isOnGround)
        {
            rb.AddForce(Vector2.up * 64);
        }
    }

    private void LateUpdate()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (rb.velocity.x >= speed)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }

        else if (rb.velocity.x <= -speed)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Collectable"))
        {
            Destroy(other.gameObject);
        }
    }
}
