using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (BoxCollider2D))]
[RequireComponent (typeof (Rigidbody2D))]
public class PlayerMovements : MonoBehaviour {


	[SerializeField]
	private	float speed;

	private	int	dir_x;
	private	int	dir_y;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Move();
	}

	void	Move()
	{
		if (Input.GetAxisRaw("Horizontal") > 0)
			dir_x = 1;
		else if (Input.GetAxisRaw("Horizontal") < 0)
			dir_x = -1;
		else
			dir_x = 0;
		
		if (Input.GetAxisRaw("Vertical") > 0)
			dir_y = 1;
		else if (Input.GetAxisRaw("Vertical") < 0)
			dir_y = -1;
		else
			dir_y = 0;

		//rb.AddForce(new Vector2(dir_x * speed, dir_y * speed));
		rb.velocity = new Vector2(/*rb.velocity.x + */dir_x * speed,/* rb.velocity.y + */dir_y * speed);
	}

}
