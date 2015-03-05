using UnityEngine;
using System.Collections;

public class ShootOnSpace : MonoBehaviour {


	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {

			GameObject[] objs = GameObject.FindGameObjectsWithTag("Base");
			Base b1 = objs[0].GetComponent<Base>();
			Base b2 = objs[1].GetComponent<Base>();

			b1.sendUnits(b2);
			b2.sendUnits(b1);
		}
	}
}
