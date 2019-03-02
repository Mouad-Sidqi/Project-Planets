using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour {


	[SerializeField]
	private float	offset;

	[SerializeField]
	private	float attackRadius;
	[SerializeField]
	private	Transform	shotPoint;

	[SerializeField]
	private	float	coolDown;
	private	float	coolDownOri;

	void	Start()
	{
		coolDownOri = coolDown;
	}

	void	FixedUpdate()
	{
		MoveAround();
		SwordAttacking();
	}

	void	SwordAttacking()
	{
		Collider2D[] enemiesToAttack;
		if (Input.GetMouseButtonDown(0))
		{
			//Create a circle and attack all enemies in it
			enemiesToAttack = Physics2D.OverlapCircleAll(shotPoint.position, attackRadius);
			for (int i = 0; i < enemiesToAttack.Length; i++)
			{
				//Checking if the collider in the circle is an enemy
				if (enemiesToAttack[i].gameObject.tag == "Enemy")
					enemiesToAttack[i].gameObject.GetComponent<EnemySystem>().TakeDamage(5f);
			}
		}
	}

	void OnDrawGizmosSelected()
    {
        // Draw a red sphere at the transform's position just for debug...
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(shotPoint.position, attackRadius);
    }

	void	MoveAround()
	{
		Vector3 mousePos = Input.mousePosition;
		mousePos = Camera.main.ScreenToWorldPoint(mousePos) - transform.position;
		float rotZ = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);  
	}
}
