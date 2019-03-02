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

	// Use this for initialization
	void Start () {
		currHP = maxHP;
	}
	
	// Update is called once per frame
	void Update () {
		healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, currHP / maxHP, lerpSpeed);
		if (currHP <= 0)
			Destroy(this.gameObject);
	}

	public void	TakeDamage(float damage)
	{
		currHP -= damage;
	}

}
