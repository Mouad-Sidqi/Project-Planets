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
    [SerializeField]
    CameraShake cameraShake;
    GameObject objectWithScript;


	void	Start()
	{
        //cameraShake = GameObject.FindGameObjectWithTag("Pointer").GetComponent<CameraShake>();
        //cameraShake = objectWithScript.GetComponent<CameraShake>();
        //cameraShake = GetComponent<CameraShake>();
            
		coolDownOri = coolDown;
	}

	void	Update()
	{
		
		FireBall();
	}
	void FixedUpdate()
	{
        MoveAround();
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
            if (coolDown <= 0 || Input.GetMouseButtonDown(0))
			{
               // cameraShake.gameObject.  
             //   BeginShake(0.1f, 0.2f);
				Instantiate(fireBall, shotPoint.position, transform.rotation);
				coolDown = coolDownOri;
				StartCoroutine(FireParts());
			}
            else
				coolDown -= Time.deltaTime;
		}
        else 
            coolDown = coolDownOri;

	}

	void	MoveAround()
	{
		Vector3 mousePos = Input.mousePosition;
		mousePos = Camera.main.ScreenToWorldPoint(mousePos) - transform.position;
		float rotZ = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);  
	}

}
