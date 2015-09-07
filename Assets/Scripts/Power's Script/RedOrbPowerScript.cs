using UnityEngine;
using System.Collections;

public class RedOrbPowerScript : MonoBehaviour {

	//PROJECTILE SCRIPT


	//Public
	public GameObject 	Explosion;
	public float		DamageValue;

	// Update is called once per frame
	void OnTriggerEnter (Collider coll) 
	{
		//Add other Tags to ignore HERE
		if(coll.tag == "Player" || coll.tag == "orb_green" || coll.tag == "orb_blue" ||
		   coll.tag == "orb_red" || coll.tag == "orb_pink" || coll.tag == "orb_violet" ||
		   coll.tag == "orb_black")// || "MoreTags"
		{
			return;
		}

		if(gameObject.activeSelf)
		{
			//Creating Some explosion for effect
			GameObject x =	Instantiate(Explosion,transform.position,Quaternion.identity) as GameObject;
			Destroy(x,1.5f);
			//Sending Damage value to the collided object to decrease from Their HP
			coll.SendMessage("FireDamage", DamageValue);
		}
		//Deactivating to reuse same. To save Game Memory
		gameObject.SetActive(false);
	}
}
