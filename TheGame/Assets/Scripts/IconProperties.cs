using UnityEngine;
using System.Collections;


public class IconProperties : MonoBehaviour {

	public SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponents<SpriteRenderer> ()[0];
		if (spriteRenderer == null) {
			throw new System.Exception("Couldn't find SpriteRenderer!");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setColor(Color c){
		spriteRenderer.color = c;
	}
}
