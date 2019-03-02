using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {

	[SerializeField]
	private	float	speed;

	[SerializeField]
	private float timeToDes;
	private	Vector3 mousePos;
	private	Rigidbody2D	rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		StartCoroutine(TimeToDestroy());
		mousePos = Input.mousePosition;
		mousePos = Camera.main.ScreenToWorldPoint(mousePos);
		rb.AddRelativeForce(Vector2.up * speed);
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Translate(transform.up * speed);
	}

	IEnumerator		TimeToDestroy()
	{
		yield return new WaitForSeconds(timeToDes);
		Destroy(this.gameObject);
	}

	void	OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Enemy")
		{
			coll.gameObject.GetComponent<EnemySystem>().TakeDamage(5f);
			Destroy(this.gameObject);
		}
	}

}
