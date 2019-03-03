using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour {

	[SerializeField]
	private float	offset;

	[SerializeField]
	private	GameObject	fireBall;
	[SerializeField]
	private	Transform	shotPoint;

	[SerializeField]
	private GameObject fireParticales;

	[SerializeField]
	private	float	coolDown;
    [SerializeField]
	private	float	coolDownOri;

	void	Start()
	{
		coolDownOri = coolDown;
	}

	void	FixedUpdate()
	{
		MoveAround();
		FireBall();
	}

	IEnumerator	FireParts()
	{
		yield return new WaitForSeconds(0.05f);
		GameObject parts = Instantiate(fireParticales, shotPoint.position, transform.rotation);
		Destroy(parts, 0.2f);
	}

	void	FireBall()
	{
		if (Input.GetMouseButton(0))
		{
			if (coolDown <= 0)
			{
				Instantiate(fireBall, shotPoint.position, transform.rotation);
				coolDown = coolDownOri;
				StartCoroutine(FireParts());
			}
			else
				coolDown -= Time.deltaTime;
		}

	}

	void	MoveAround()
	{
		Vector3 mousePos = Input.mousePosition;
		mousePos = Camera.main.ScreenToWorldPoint(mousePos) - transform.position;
		float rotZ = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);  
	}

}
