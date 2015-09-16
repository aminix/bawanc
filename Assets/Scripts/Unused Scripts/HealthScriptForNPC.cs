using UnityEngine;
using System.Collections;

public class HealthScriptForNPC : MonoBehaviour {

	//PUBLIC	
	public float	Health;
	public bool		WillThisRegenHP;

	//PRIVATE
	private float 	health;



	// Use this for initialization
	void Start () 
	{
		health = Health;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(WillThisRegenHP)
		{
			Regen();
		}
		if(Health <=  0)
		{
			Killed();
		}
	}



	void Regen()
	{
	
		if(Health < health)
		{
			Health += Time.deltaTime;
		}

	}

	void Killed()
	{
		Destroy (gameObject);
	}

	public void ElectricDamage(float DamageValue)
	{
		Health -= DamageValue;
	}

	public void FireDamage(float DamageValue)
	{
		Health -= DamageValue;
	}
}
