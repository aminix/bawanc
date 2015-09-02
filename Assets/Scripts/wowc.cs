using UnityEngine;
using System.Collections;

public class wowc : MonoBehaviour {

	public Transform head;
	[HideInInspector] public bool facingRight = true;
	[HideInInspector] public bool jump = false;
	public float moveForce = 365f;
	public float maxSpeed = 5f;
	public float jumpForce = 1000f;
	public Transform groundCheck;
	
	
	private bool grounded = false;
	//private Animator anim;
	private Rigidbody rb2d;
	
	
	// Use this for initialization
	void Awake () 
	{
		//anim = GetComponent<Animator>();
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

		
		//anim.SetFloat("Speed", Mathf.Abs(h));
		
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
			//anim.SetTrigger("Jump");
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
		//print (other.name);
		switch (other.tag) {
		case "orb_blue" :
			head.gameObject.GetComponent<Renderer>().material.color = Color.blue;// other.gameObject.GetComponent<Renderer>().material.color;
			SkyBoXScript.Instance.ChangeToBlue();
			Debug.Log("Blue");
			break;
		case "orb_green" :
			head.gameObject.GetComponent<Renderer>().material.color = Color.green;// other.gameObject.GetComponent<Renderer>().material.color;
			SkyBoXScript.Instance.ChangeToGreen();
			Debug.Log("Green");
			break;
		case "orb_red" :
			head.gameObject.GetComponent<Renderer>().material.color = Color.red;// other.gameObject.GetComponent<Renderer>().material.color;
			SkyBoXScript.Instance.ChangeToRed();
			Debug.Log("Red");
			break;

		}
	}
}
