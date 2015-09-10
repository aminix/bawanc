using UnityEngine;
using System.Collections;

public class GreenPowerScript : MonoBehaviour {
	GameObject anchor;
	public GameObject anchor_prefab;
	private int i;
	private bool grounded;
	private bool w8ing;
	private bool w8ing2;
	public GameObject line_holder;
	GameObject liner;
	public LineRenderer line;
	private Rigidbody rb;
	float y;
	float x;
	public Vector2 pointer;
	RaycastHit hit;
	public Transform rock;
	public float launch_power;
	public float pointer_speed;
	public float rope_width;
	int timer;
	void Awake () {
		anchor = Instantiate(anchor_prefab, hit.point, Quaternion.identity) as GameObject;
		liner = Instantiate (line_holder, transform.position, Quaternion.identity) as GameObject;
		line = liner.GetComponent<LineRenderer>();
		//transform.gameObject.AddComponent (line);
		rb = GetComponent<Rigidbody> ();
		//Destroy (liner);
		liner.GetComponent<LineRenderer>().enabled = false;
		w8ing = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		
		/*if (!w8ing) {
			line.SetPosition (0, transform.position);
			line.SetPosition (1, anchor.transform.position);
		}*/
		grounded = Physics.Linecast (transform.position, gameObject.GetComponent<wowc> ().groundCheck.position);
		
		if (grounded && !w8ing && timer <= 0) {
			w8ing2 = false;
			transform.GetComponent<wowc> ().enabled = true;
			line.enabled = false;
			
		}
		
		
		
		if (Input.GetKeyDown("c")) {
			line.enabled = true;
			transform.GetComponent<wowc>().enabled = false;
			i = 1;
			w8ing = true;
			pointer = transform.position;
			y = pointer.y;
			x = pointer.x;
			//Invoke(boing, 0);
			//print (3);
			
		}
		
		if (w8ing) {
			rock.GetComponent<ParticleSystem> ().maxParticles = 100;
			//w8ing2 = true;
			x += Input.GetAxis("Horizontal") * pointer_speed;
			y += Input.GetAxis("Vertical") * pointer_speed;
			pointer = new Vector2(x, y);
			line.SetPosition (0, transform.position);
			line.SetPosition (1, pointer);
			rock.position = pointer;
			Debug.DrawRay (transform.position, (pointer - new Vector2(transform.position.x, transform.position.y)), Color.magenta, 3);
			if(Physics.Raycast(transform.position, (pointer - new Vector2(transform.position.x, transform.position.y)), out hit)){
				anchor.transform.position = hit.point;
				
			}
			
			if(Input.GetKeyDown("x")) {
				boing();
				w8ing = false;
				w8ing2 = true;
				rock.GetComponent<ParticleSystem> ().maxParticles = 0;
				timer = 4;
			}
			
		}
		
		if (w8ing2) {
			line.SetPosition (0, transform.position);
			line.SetPosition (1, hit.point);
			line.SetWidth((1 / Vector2.Distance(transform.position, hit.point)) * rope_width, (1 / Vector2.Distance(transform.position, hit.point)) * rope_width);
		}
		
		/*if(transform.position == anchor.transform.position)
			rb.useGravity = true;
			*/
		if (i <= 0) {rb.useGravity = true;} else {
			rb.useGravity = false;
			//boing();
			i--;
		}
		//Debug.DrawLine (transform.position, anchor.position, Color.green);
		timer --;
	}
	
	void boing() {
		//rb.velocity = (anchor.position - transform.position);//Vector2.MoveTowards (anchor.position, transform.position, 2);
		//transform.position = Vector2.MoveTowards (transform.position, anchor.position, 2);
		//rb.useGravity = false;
		rb.AddForce ((anchor.transform.position - transform.position) * launch_power);//(Vector2.MoveTowards(transform.position, anchor.position, 100));//new Vector2((anchor.position.x - transform.position.x) * 100, (anchor.position.y - transform.position.y) * 100));
		
	}
}
