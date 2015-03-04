using UnityEngine;
using System.Collections;

/// <summary>
/// Using a separate class for BaseIcon so that the icon can be scaled 
/// independently from the actual base. Ie, set the general scale in
/// in the Base, and let the dynamic rescaling wrt the number of units in the
/// base happens here.
/// 
/// </summary>
public class BaseIcon : MonoBehaviour {

	public SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		//spriteRenderer = GetComponents<SpriteRenderer> ()[0];
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
