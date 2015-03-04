using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {


	public Color color;
	public float unitSpeed;
	private static int player_id = 0;

	void Start(){
		name = "P" + player_id++;
	}

}
