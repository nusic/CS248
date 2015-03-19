using UnityEngine;
using System.Collections;

public class SimpleAI : Player {

	public float slowness;

	// Use this for initialization
	void Start () {
		sounds = new PlayerSounds();
		InvokeRepeating("takeAction", slowness, slowness);
	}
	

	protected void takeAction(){
		Base weakest = findWeakestEnemyBase();
		if (weakest != null) {
			attackWithAllBases (weakest);
		}
	}

	protected Base findWeakestEnemyBase(){
		GameObject[] gos = GameObject.FindGameObjectsWithTag ("Base");

		Base weakest = null;
		foreach (GameObject go in gos){
			Base b = go.GetComponent<Base>();
			if (b.owner != this){
				if(weakest == null || b.numUnitsInBase < weakest.numUnitsInBase){
					weakest = b;
				}
			}
		}
		return weakest;
	}

	public void attackWithAllBases(Base target){
		GameObject[] gos = GameObject.FindGameObjectsWithTag ("Base");

		foreach (GameObject go in gos){
			Base b = go.GetComponent<Base>();
			if (b.owner == this){
				b.sendUnits(target);
			}
		}
	}
}
