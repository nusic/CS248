using UnityEngine;
using System.Collections;

public class BomberBase : Base {

	public float bomberPrepareTime = 5;
	public BomberUnit bomber = null;

	private bool hasBomber;
	private IEnumerator timer;
	private float timeLeft;
	
	public void Start(){
		setOwner(owner);
		OnUnitUpdate();
	}

	protected override void setOwner(Player owner){
		Debug.Log ("this.owner:" + this.owner);
		Debug.Log ("owner:" + owner);
		if (this.owner != owner) {
			setBomberReady (false);
		}
		base.setOwner (owner);
	}

	void Update(){
		if (owner != null) {
			timeLeft -= Time.deltaTime;
			if (timeLeft <= 0) {
				setBomberReady (true);
			}
			else{
				//Debug.Log (timeLeft);
			}
		}
	}

	public override void sendUnits(Base target){
		if (target != this && hasBomber) {
			BomberUnit bu = Instantiate(bomber, transform.position, transform.rotation) as BomberUnit;
			bu.damage = 20;
			bu.init(owner, target);
			setBomberReady(false);
		}
		else{
			base.sendUnits(target);
		}

	}

	private void setBomberReady(bool ready){

		if(ready && ready == hasBomber){
			return;
		}

		SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer> ();
		srs[0].enabled = ready;
		hasBomber = ready;
		if(!ready){
			timeLeft = bomberPrepareTime;
		}

	}
}
