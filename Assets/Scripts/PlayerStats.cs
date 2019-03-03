using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

	[SerializeField]
    private float healAmount;
    [SerializeField]
	private	Image healthBar;

	[SerializeField]
	private	float	lerpSpeed;

	[SerializeField]
	private	float maxHP;
    [SerializeField]
    private float currHP;

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

	public	void	TakeDamage(float damage)
	{
		currHP -= damage;
	}


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Heal")
        {
            if (currHP + healAmount <= maxHP)
            {
                currHP += healAmount;
                Destroy(col.gameObject);
            }
            else {
                currHP = maxHP;
                Destroy(col.gameObject);
            }
        }
    }
}
