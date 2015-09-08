using UnityEngine;
using System.Collections;

public class wowc : MonoBehaviour {

	[HideInInspector] public bool facingRight = true;
	[HideInInspector] public bool jump = false;
	public float moveForce = 365f;
	public float maxSpeed = 5f;
	public float jumpForce = 1000f;
	public Transform groundCheck;
	public GameObject character; 

	private bool grounded = false;
	private Animator anim;
	private Rigidbody rb2d;
	
	
	// Use this for initialization
	void Awake () 
	{
		anim = character.GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		grounded = Physics.Linecast (transform.position, groundCheck.position);//, 1 << LayerMask.NameToLayer("Ground"));


		if (Input.GetButtonDown("Jump") && grounded)
		{
			jump = true;
		}
	}
	
	void FixedUpdate()
	{
		float h = Input.GetAxis("Horizontal");

		
		anim.SetFloat("running", Mathf.Abs(h));
		
		if (h * rb2d.velocity.x < maxSpeed)
			rb2d.AddForce(Vector2.right * h * moveForce);
		
		if (Mathf.Abs (rb2d.velocity.x) > maxSpeed)
			rb2d.velocity = new Vector2(Mathf.Sign (rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
		
		if (h > 0 && !facingRight)
			Flip ();
		else if (h < 0 && facingRight)
			Flip ();
		
		if (jump)
		{
			anim.SetTrigger("Jump");
			rb2d.AddForce(new Vector2(0f, jumpForce));
			jump = false;
		}
	}
	
	
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnTriggerEnter (Collider other)
	{

		handlePowerTriggers (other);

	}

	private void handlePowerTriggers(Collider other) 
	{
		switch (other.tag) {
		case "orb_blue" :
			Debug.Log("Blue");
			SkyBoXScript.Instance.ChangeToBlue();
			//adds power script if is not there already
			if (transform.gameObject.GetComponent("BluePowerScript") == null) 
			{
				transform.gameObject.AddComponent<BluePowerScript>();
			}
			
			break;

		case "orb_green" :
			Debug.Log("Green");
			SkyBoXScript.Instance.ChangeToGreen();
			
			//adds power script if is not there already
			if (transform.gameObject.GetComponent("GreenPowerScript") == null) 
			{
				transform.gameObject.AddComponent<GreenPowerScript>();
			}
			
			break;

		case "orb_red" :
			Debug.Log("Red");
			SkyBoXScript.Instance.ChangeToRed();
			
			//adds power script if is not there already
			if (transform.gameObject.GetComponent("RedPowerScript") == null) 
			{
				transform.gameObject.AddComponent<RedPowerScript>();
			}
			else
			{
				//I'm taking Vars cuz .. just like that :D :P Change if you wanna. I dont give a shit.
				var x = transform.GetComponent<RedPowerScript>()as RedPowerScript;
				x.enabled = true;
			}
			break;

		case "orb_yellow" :
			Debug.Log("Yellow");
				SkyBoXScript.Instance.ChangeToYellow();
			
			//adds power script if is not there already
			if (transform.gameObject.GetComponent("YellowPowerScript") == null) 
			{
				transform.gameObject.AddComponent<YellowPowerScript>();
			}
			else
			{
				var x = transform.GetComponent<YellowPowerScript>()as YellowPowerScript;
				x.enabled = true;
			}
			break;

		case "orb_purple" :
			Debug.Log("Purple");
			//	SkyBoXScript.Instance.ChangeToRed();
			
			//adds power script if is not there already
			if (transform.gameObject.GetComponent("PurplePowerScript") == null) 
			{
				transform.gameObject.AddComponent<PurplePowerScript>();
			}
			break;

		case "orb_pink" :
			Debug.Log("Pink");
			//	SkyBoXScript.Instance.ChangeToRed();
			
			//adds power script if is not there already
			if (transform.gameObject.GetComponent("PinkPowerScript") == null) 
			{
				transform.gameObject.AddComponent<PinkPowerScript>();
			}
			break;
			
		}
	}
}
