using UnityEngine;
using System.Collections;

public class BaseProperties : MonoBehaviour {

	// All public for easy debugging in Unity
	public int numUnits = 5;
	public int unitCapacity = 20;
	public float unitGenerationRate = 2;


	public GameObject icon;

	// Use this for initialization
	void Start () {
		icon = transform.Find ("base_icon").gameObject;

		//Update number of units in Base every "unitGenerationRate" second
		InvokeRepeating ("UpdateUnits", -1, 1.0f/unitGenerationRate);
	}
	
	
	void Update () {
		float newSize = Mathf.Sqrt(1 + numUnits/5.0f);
		icon.transform.localScale = new Vector3(newSize, newSize, 1);
	}

	// Increase or decrease units wrt base capacity.
	void UpdateUnits(){
		if (numUnits < unitCapacity) {
			numUnits++;
			icon.GetComponent<IconProperties>().setColor(Color.blue);
		}
		else if (numUnits > unitCapacity){
			numUnits--;
			icon.GetComponent<IconProperties>().setColor(Color.red);
		}
	}
}
