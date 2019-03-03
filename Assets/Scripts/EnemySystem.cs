using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySystem : MonoBehaviour {

	[SerializeField]
	private	float	maxHP;

	[SerializeField]
	private	float	currHP;

	[SerializeField]
	private	Image	healthBar;
	[SerializeField]
	private	float	lerpSpeed;

	[SerializeField]
	private	float	damageRadius;

	[SerializeField]
	private	float	attacCoolDown;
	private	float	attackCoolDownOri;

	[SerializeField]
	private	GameObject player;

	// Use this for initialization
	void Start () {
		currHP = maxHP;
		attackCoolDownOri = attacCoolDown;
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		DamagePlayer();
		healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, currHP / maxHP, lerpSpeed);
		if (currHP <= 0)
			Destroy(this.gameObject);
		if (player.transform.position.y > this.transform.position.y)
			this.GetComponent<SpriteRenderer>().sortingOrder = 3;
		else
			this.GetComponent<SpriteRenderer>().sortingOrder = 1;
	}

	void	DamagePlayer()
	{
		if (attacCoolDown <= 0)
		{
			Collider2D[] inRange = Physics2D.OverlapCircleAll(this.transform.position, damageRadius);
			for (int i = 0; i < inRange.Length; i++)
			{
				if (inRange[i].gameObject.tag == "Player")
					//Debug.Log("Works!!");
				{
					inRange[i].gameObject.GetComponent<PlayerStats>().TakeDamage(5);
				}
			}
			attacCoolDown = attackCoolDownOri;
		}
		else
			attacCoolDown -= Time.deltaTime;
	}

	void OnDrawGizmosSelected()
    {
        // Draw a red sphere at the transform's position just for debug...
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, damageRadius);
    }

	public void	TakeDamage(float damage)
	{
		currHP -= damage;
	}

}
