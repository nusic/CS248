using UnityEngine;
using System.Collections;

public class SimpleAI : Player {

	public float slowness;
	public float randomness;

	// Use this for initialization
	void Start () {
		sounds = new PlayerSounds();
		StartCoroutine("takeAction");
	}

	private float waitTime(){
		return slowness + Random.Range (-randomness/2, randomness/2);
	}

	IEnumerator takeAction(){
		yield return new WaitForSeconds(slowness);
		while(true){
			Base weakest = findWeakestEnemyBase();
			if (weakest != null) {
				attackWithAllBases (weakest);
			}
			yield return new WaitForSeconds (slowness);
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
