using UnityEngine;
using System.Collections;

public class TestInteraction : MonoBehaviour {


	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			GameObject.Find("Base").GetComponent<Base>().sendUnits(null);
		}
	}
}
