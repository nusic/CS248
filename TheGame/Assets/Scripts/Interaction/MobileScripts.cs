using UnityEngine;
using System.Collections;

public class MobileScripts : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		TapCheck ();
		MouseCheck ();
	}

	void TapCheck(){
		foreach(Touch touch in Input.touches){
			if (touch.phase == TouchPhase.Began) {
				ProcessInput (touch.position);
			}
		}
	}

	void MouseCheck(){
		if (Input.GetMouseButton (0)) {
			ProcessInput (Input.mousePosition);
		}
	}

	void ProcessInput(Vector3 pos){
		//Do stuff with mouse/touch position
	}
}
