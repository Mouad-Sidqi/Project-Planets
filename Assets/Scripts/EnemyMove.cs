using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
    [SerializeField]
    private bool isAgro;
    [SerializeField]
    private int direction;
    private Rigidbody2D rb;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float agroSpeed;
    private Transform player;
    [SerializeField]
    private float stopingDistance;
    [SerializeField]
    private float agroDistance;







	void Start () {
        isAgro = false;
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();       


        //direction = Random.Range(1, 8);
	}
	
	// Update is called once per frame
	void Update () {
        float Distance = Vector2.Distance(transform.position, player.position);

        if (isAgro == true || (Distance <= agroDistance && Distance > stopingDistance))
        {
            isAgro = true;
            rb.velocity = Vector2.zero;
            transform.position = Vector2.MoveTowards(transform.position, player.position, agroSpeed);
        }
        else if (isAgro == false)
        {





            if (direction == 1)
                rb.velocity = new Vector2(speed, 0);
            if (direction == 2)
                rb.velocity = new Vector2(0, speed);
            if (direction == 3)
                rb.velocity = new Vector2(speed, speed);
            if (direction == 4)
                rb.velocity = new Vector2(-speed, -speed);
            if (direction == 5)
                rb.velocity = new Vector2(-speed, speed);
            if (direction == 6)
                rb.velocity = new Vector2(speed, -speed);
            if (direction == 7)
                rb.velocity = new Vector2(-speed, 0);
            if (direction == 8)
                rb.velocity = new Vector2(0, -speed);
        }
        else
            isAgro = false;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.gameObject.tag == "Borders")
        {
            speed = -speed;                                             //reverse directions if it hit walls
            //direction = Random.Range(1, 8);
        }
	}
}
