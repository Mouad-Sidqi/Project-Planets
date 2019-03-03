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
    private Image timeBar;

	[SerializeField]
	private	float	lerpSpeed;

	[SerializeField]
	private	float maxHP;
    [SerializeField]
    private float currHP;

    [SerializeField]
    private float typeCounter;

    [SerializeField]
    private GameObject ice;

    [SerializeField]
    private GameObject fire;

    [SerializeField]
    private float typeTimer;

	// Use this for initialization
	void Start () {
		//currHP = maxHP;
        playerType = GameObject.Find("PlayerMelee");
        maxHP = playerType.GetComponent<PlayerType>().maxHealth;
        currHP = maxHP;
        typeCounter = 0;
        typeTimer = 11;
	}

	
	// Update is called once per frame
	void Update () {
        ManageType();
        HealthManager();
        if (typeCounter < 20)
            typeCounter += Time.deltaTime;
        else if (typeCounter >= 20)
            typeCounter = 0;
        timeBar.fillAmount = typeTimer / 10;
        typeTimer -= Time.deltaTime;
	}

    void    ManageType()
    {
        if (typeCounter >= 0 && typeCounter < 10)
        {
            
            fire.active = true;
            ice.active = false;
            playerType = GameObject.Find("PlayerRange");
            if (typeTimer <= 0)
                typeTimer = 10;
        }
        else if (typeCounter >= 10f && typeCounter < 20)
        {
            
            fire.active = false;
            ice.active = true;
            playerType = GameObject.Find("PlayerMelee");
            if (typeTimer <= 0)
                typeTimer = 10;
        }
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
