using UnityEngine;
using System.Collections;

public class MobileScripts : MonoBehaviour {


	public Player player;
	

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
			if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved) {
				ProcessOnDown (touch.position);
			}
			else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Ended) {
				ProcessOnRelease (touch.position);
			}
		}
	}

	void MouseCheck(){
		if (Input.GetMouseButton(0)) {
			ProcessOnDown (Input.mousePosition);
		} else if (Input.GetMouseButtonUp (0)) {
			ProcessOnRelease (Input.mousePosition);
		}
	}

	void ProcessOnDown(Vector3 pos){
		//Do stuff with mouse/touch position
		/*
		foreach (GameObject go in GameObject.FindGameObjectsWithTag("Base")) {
			Base b = go.GetComponent<Base>();
			Vector3 posWorld = Camera.main.ScreenToWorldPoint(pos);
			if(b.collider2D.OverlapPoint(new Vector2(posWorld.x, posWorld.y))){
				ProcessDownOnBase(b);
			}
		}
		*/
		ProcessDownOnBase (baseAtPosition (pos));
	}

	Base baseAtPosition(Vector3 pos){
		foreach (GameObject go in GameObject.FindGameObjectsWithTag("Base")) {
			Base b = go.GetComponent<Base>();
			Vector3 posWorld = Camera.main.ScreenToWorldPoint(pos);
			if(b.collider2D.OverlapPoint(new Vector2(posWorld.x, posWorld.y))){
				return b;
			}
		}
		return null;
	}

	void ProcessDownOnBase(Base b){
		if (b == null) {
			player.aimAt(null);
			return;
		}
		if (b.owner == player) {
			if (!player.hasSelected(b)) {
				player.addToSelection (b);
			}
		} 
		if (player.selectCount() > 0) {
			player.aimAt(b);
		}
	}

	void ProcessOnRelease(Vector3 posScreen){
		Base target = baseAtPosition(posScreen);
		if (target) {
			player.selectionSendTo(target);
		}
		player.clearSelection();
	}
}
