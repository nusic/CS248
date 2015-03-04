using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {


	public Color color;
	public float unitSpeed;
	private static int next_player_id = 1;

	void Start(){
		name = "P" + next_player_id++;
	}

}
