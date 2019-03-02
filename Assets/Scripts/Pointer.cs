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
	private	float	coolDown;
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

	void	FireBall()
	{
		if (coolDown <= 0)
		{
			if (Input.GetMouseButtonDown(0))
			{
				Instantiate(fireBall, shotPoint.position, transform.rotation);
				coolDown = coolDownOri;
			}
		}
		else
		{
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
