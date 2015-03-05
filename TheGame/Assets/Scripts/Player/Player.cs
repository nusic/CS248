using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
	
	public Color color;
	public float unitSpeed;

	//Use non-generic Hashtables instead?
	public List<Base> selectedBases = new List<Base>();

	public static Color NullColor = new Color(0.5f, 0.5f, 0.5f);

	void Start(){

	}


}
