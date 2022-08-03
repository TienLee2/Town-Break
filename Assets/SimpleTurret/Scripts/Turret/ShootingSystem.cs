using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ShootingSystem : MonoBehaviour
{

	//Main turret controller Component
	TurretController controller;
	
	//Random Variables
	bool reloading = false;
	float time = 0;
	int i,j;
	public int counter = 0;
	[Tooltip("Target to be attacked by turret")]
	public Transform target;
	
	private List<Transform> findTargets = new List<Transform>();

	public List<Transform> near = new List<Transform>();

	public Button button;
	public Image hair;
	public Transform rest;

	[Header("Effects")]
	[Tooltip("Bullet Fire effect")]
	public ParticleSystem fireMuzzle;
	[Tooltip("Effect initialized at point where bullet hits")]
	public GameObject bulletHitEffect;

	[Header("Attack")]
	[Tooltip("Time after which next shot will be fired")]
	public float fireDelay = 0.1f;
	[Tooltip("Range of the Turret")]
	public float range = 20;


	[Header("Ammo")]
	[Tooltip("Current available ammo of the gun")]
	public int ammo;
	[Tooltip("Magzine size of the Gun")]
	public int magzineSize = 50;
	[Tooltip("Totale Ammo available for the GUN")]
	public int totalAmmo = 500;
	[Tooltip("Time taken to reload the Gun")]
	public float reloadTime = 2f;
	[Tooltip("Damage done by the bullet")]
	public float ammoDamage = 1;

	void Awake()
	{
		ammoDamage = ammoDamage + Upgrade.GetCrit();
	}

	//Get the component
	void Start()
	{
		
		//InvokeRepeating("FindingTr", 1f, 0.5f);
		controller = this.GetComponent<TurretController>();
		button.onClick.AddListener(OnClick);
	}
	
	public void FindingTr()
	{
		findTargets.Clear();
		near.Clear();
		foreach (GameObject go in GameObject.FindGameObjectsWithTag("Enemy"))
		{
			findTargets.Add(go.GetComponent<Transform>());
		}

		for (i = 0; i < findTargets.Count; i++)
		{
			float dis = Vector3.Distance(findTargets[i].position, transform.position);
			//Debug.Log(i);
			if (dis <= range)
			{
				near.Add(findTargets[i]);
				
			}
		}
		

		for (j = 0; j < near.Count; j++)
		{
			
			target = near[j+counter].transform;
			break;
		}
		

	}

	void Update()
	{
		
		//check FireDelay after fire
		if (time <= fireDelay)
			time += Time.deltaTime;

		if (counter >= near.Count)
		{
			counter = 0;
		}

		FindingTr();
		X();
	}
	
	void X()
    {
		if (target != null)
		{
			Vector3 wantedPos = Camera.main.WorldToScreenPoint(target.position);
			hair.transform.position = wantedPos;
		}
        else
        {
			Vector3 restPos = Camera.main.WorldToScreenPoint(rest.position);
			hair.transform.position = restPos;
		}
	}

	public void OnClick()
    {
		counter = counter + 1;
	}

	public void Fire(){ //without Hit Effect

		if (ammo > 0 && time > fireDelay) {
		
			ammo--;

			fireMuzzle.Stop ();		
			fireMuzzle.Play ();
			time = 0;
			controller._Audio.Play_Fire ();
		} else {
			controller._Audio.Play_OutOfAmmo ();
		}
	}

	public void Fire(Vector3 hitPoint, GameObject hitObject){ //with hit effect

		if (reloading)
			return;

		if (ammo > 0) {

			if (time > fireDelay) {

				ammo--;

				fireMuzzle.Stop ();		
				fireMuzzle.Play ();

				hitObject.SendMessage ("ApplyDamage", ammoDamage, SendMessageOptions.DontRequireReceiver);
				Instantiate (bulletHitEffect, hitPoint, Quaternion.identity);

				time = 0;
				controller._Audio.Play_Fire ();
			}

		} else {
			controller._Audio.Play_OutOfAmmo ();

			Reload ();
		}
	}

	//Reload Turret 
	public void Reload(){

		reloading = true;
		controller._Audio.Play_Reload ();
		StartCoroutine (ReloadAfterDelay ());

	}

	//Reload Turret after the delay
	IEnumerator ReloadAfterDelay (){

		yield return new WaitForSeconds (reloadTime);

		if (totalAmmo - magzineSize > 0) {
		
			totalAmmo -= magzineSize;
			ammo = magzineSize;

		} else {		
			ammo = totalAmmo;
			totalAmmo = 0;
		}

		reloading = false;
	}
}
