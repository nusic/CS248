using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {
	
	public Player owner;
	public SpriteRenderer sr;
	public Base target;

	// Use this for initialization
	void Start () {

	}

	public void init(Player owner, Base target){
		setOwner(owner);
		this.target = target;

		//Vector2 directionToTarget = (target.transform.position - transform.position).normalized;
		//rigidbody2D.velocity = owner.unitSpeed * directionToTarget;

		SpringJoint2D spring = GetComponent<SpringJoint2D> ();
		spring.connectedBody = target.gameObject.GetComponent<Rigidbody2D>();
	}

	public void setOwner(Player p){
		owner = p;
		sr.color = p.color;
		tag = p.name;
	}


	// Update is called once per frame
	void Update () {

	}
}
