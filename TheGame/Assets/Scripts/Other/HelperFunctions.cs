using UnityEngine;
using System.Collections;

public class HelperFunctions : MonoBehaviour {

	public static Vector3 RandomDirectionXY(float radius){
		int a = Random.Range (0, 359);
		return new Vector3(radius*Mathf.Cos(a), radius*Mathf.Sin (a), 0);
	}
}
