using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    [SerializeField]
    private GameObject playerType;

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
		//currHP = maxHP;
        playerType = GameObject.Find("PlayerRange");
        maxHP = playerType.GetComponent<PlayerType>().maxHealth;
        currHP = maxHP;
	}
	
	// Update is called once per frame
	void Update () {
        HealthManager();
	}

    void    HealthManager()
    {
        maxHP = playerType.GetComponent<PlayerType>().maxHealth;
		healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, currHP / maxHP, lerpSpeed);
        if (currHP <= 0)
            Destroy(this.gameObject);
        if (currHP > maxHP)
            currHP = maxHP;
    }

	public	void	TakeDamage(float damage)
	{
		currHP -= damage;
	}

    public  void    Heal(float heal)
    {
        currHP += heal;
    }

}
