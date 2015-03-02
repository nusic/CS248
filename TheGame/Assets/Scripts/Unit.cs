using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {
	
	public Player owner;
	public SpriteRenderer sr;
	public Base target;

	public Vector3 vel;

	// Use this for initialization
	void Start () {
		sr = transform.GetComponent<SpriteRenderer> ();

	}

	public void init(Player owner, Base target){
		setOwner(owner);
		
		//Just sending out Units in random direction now
		// Here it should start an animation, moving towards
		setRandomVelocity(5);
	}

	public void setOwner(Player p){
		owner = p;
		sr.color = p.color;
	}

	public void setVel(float vx, float vy){
		vel = new Vector3 (vx, vy, 0);
	}

	public void setRandomVelocity(float magnitude){
		int a = Random.Range (0, 359);
		setVel(magnitude*Mathf.Cos(a), magnitude*Mathf.Sin (a));
	}

	// Update is called once per frame
	void Update () {
		transform.position += vel * Time.deltaTime;
	}
}
