using UnityEngine;
using System.Collections;

public class SwitchScript : MonoBehaviour {


	public GameObject	EffectedBySwitch;
	public bool 		Pressed 										= false;

	public bool			MoveUp,MoveDown,MoveRight,MoveLeft;
	public bool			ShouldTheObjectMovedReturnToOriginalPosition;

	public float		TargetPosition;
	public float		MoveSpeed;

	//PRIVATE
	private Vector3		previousPosition;
	private bool		ReturnToNormal 									= false;


	// Use this for initialization
	void Start ()
	{
		previousPosition = EffectedBySwitch.transform.position;
	}


	void Update()
	{
		if(Pressed)
		{
			ILikeToMoveItMoveIt();
		}

		if(ShouldTheObjectMovedReturnToOriginalPosition && ReturnToNormal)
		{
			SetItBack();
		}


	}



	// Update is called once per frame
	void OnTriggerEnter (Collider coll)
	{
		Debug.Log (coll.tag);
		if(coll.tag =="Electricity")
		{
			if(!Pressed)
			{
				transform.localScale = new Vector3(transform.localScale.x,0.05f,transform.localScale.z);
				ILikeToMoveItMoveIt();
				Pressed = true;
			}
			else
			{
				transform.localScale = new Vector3(transform.localScale.x,0.2f,transform.localScale.z);
				ILikeToMoveItMoveIt();
				Pressed = false;
			}
		}


	}


	void ILikeToMoveItMoveIt()
	{

		if(MoveUp)
		{
			float y = EffectedBySwitch.transform.position.y;
			y += Time.deltaTime;
			EffectedBySwitch.transform.position = new Vector3(EffectedBySwitch.transform.position.x,
			                                                  y,EffectedBySwitch.transform.position.z );
			
			if(EffectedBySwitch.transform.position.y >= TargetPosition)
			{
				transform.localScale = new Vector3(transform.localScale.x,0.2f,transform.localScale.z);

				Pressed = false;
				ReturnToNormal = true;
			}
		}

		if(MoveDown)
		{
			float y = EffectedBySwitch.transform.position.y;
			y -= Time.deltaTime;
			EffectedBySwitch.transform.position = new Vector3(EffectedBySwitch.transform.position.x,
			                                                  y,EffectedBySwitch.transform.position.z );
			
			if(EffectedBySwitch.transform.position.y <= TargetPosition)
			{
				transform.localScale = new Vector3(transform.localScale.x,0.2f,transform.localScale.z);

				Pressed = false;
				ReturnToNormal = true;
			}
		}

		if(MoveRight)
		{
			float x = EffectedBySwitch.transform.position.x;
			x += Time.deltaTime;
			EffectedBySwitch.transform.position = new Vector3(x,
			                                                  EffectedBySwitch.transform.position.y,EffectedBySwitch.transform.position.z );
			
			if(EffectedBySwitch.transform.position.x >= TargetPosition)
			{
				transform.localScale = new Vector3(transform.localScale.x,0.2f,transform.localScale.z);

				Pressed = false;
				ReturnToNormal = true;
			}
		}

		if(MoveLeft)
		{
			float x = EffectedBySwitch.transform.position.x;
			x -= Time.deltaTime;
			EffectedBySwitch.transform.position = new Vector3(x,
			                                                  EffectedBySwitch.transform.position.y,EffectedBySwitch.transform.position.z );
			
			if(EffectedBySwitch.transform.position.x <= TargetPosition)
			{
				transform.localScale = new Vector3(transform.localScale.x,0.2f,transform.localScale.z);

				Pressed = false;
				ReturnToNormal = true;
			}
		}




	}


	void SetItBack()
	{
		if(MoveDown)
		{
			float y = EffectedBySwitch.transform.position.y;
			y += Time.deltaTime;
			EffectedBySwitch.transform.position = new Vector3(EffectedBySwitch.transform.position.x,
			                                                  y,EffectedBySwitch.transform.position.z );
			
			if(EffectedBySwitch.transform.position.y >= previousPosition.y)
			{

				Pressed = false;
				ReturnToNormal = false;
			}
		}
		
		if(MoveUp)
		{
		
			float y = EffectedBySwitch.transform.position.y;
			y -= Time.deltaTime;
			EffectedBySwitch.transform.position = new Vector3(EffectedBySwitch.transform.position.x,
			                                                  y,EffectedBySwitch.transform.position.z );
			
			if(EffectedBySwitch.transform.position.y <= previousPosition.y)
			{

				Pressed = false;
				ReturnToNormal = false;
			}
		}
		
		if(MoveLeft)
		{
			float x = EffectedBySwitch.transform.position.x;
			x += Time.deltaTime;
			EffectedBySwitch.transform.position = new Vector3(x,
			                                                  EffectedBySwitch.transform.position.y,EffectedBySwitch.transform.position.z );
			
			if(EffectedBySwitch.transform.position.x >= previousPosition.x)
			{

				Pressed = false;
				ReturnToNormal = false;
			}
		}
		
		if(MoveRight)
		{
			float x = EffectedBySwitch.transform.position.x;
			x -= Time.deltaTime;
			EffectedBySwitch.transform.position = new Vector3(x,
			                                                  EffectedBySwitch.transform.position.y,EffectedBySwitch.transform.position.z );
			
			if(EffectedBySwitch.transform.position.x <= previousPosition.x)
			{

				Pressed = false;
				ReturnToNormal = false;
			}
		}
	}








}
