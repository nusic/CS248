using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {
	
	public Player owner;
	public SpriteRenderer sr;
	public Base target;
	public float maxSpeed;
	public float minSpeed;
	public float takeOffSpeed;

	// Use this for initialization
	void Start () {

	}

	public void init(Player owner, Base target){
		setOwner(owner);
		this.target = target;

		startAnimation();
	}


	protected void startAnimation(){

		//As an example one can use springs. 
		//Maybe different units should have different animations
		SpringJoint2D spring = GetComponent<SpringJoint2D> ();
		spring.connectedBody = target.gameObject.GetComponent<Rigidbody2D>();

		//Shout out plane in random direction 
		rigidbody2D.velocity = HelperFunctions.RandomDirectionXY (takeOffSpeed);
	}

	private void setOwner(Player p){
		owner = p;
		sr.color = p.color;
	}

	void FixedUpdate(){
		float speed = rigidbody2D.velocity.magnitude;
		if (speed > maxSpeed) {
			rigidbody2D.velocity = maxSpeed * rigidbody2D.velocity.normalized;
		}
		else if (speed < minSpeed){
			rigidbody2D.velocity = minSpeed * rigidbody2D.velocity.normalized;
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
