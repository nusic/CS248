using UnityEngine;
using System.Collections;

public class OwnershipController : MonoBehaviour {

	private int[] baseOwnership;
	
	// Use this for initialization
	void Start () {
		GameObject[] objs = GameObject.FindGameObjectsWithTag ("Base");
		baseOwnership = new int[objs.Length];
		for (int i = 0; i<baseOwnership.Length; ++i) {
			baseOwnership[i] = -1;
		}
	}

	void setOwner(int b, int owner){

	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
