using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour {

	public int numUnitsInBase = 5;
	public int unitCapacity = 20;
	public float unitGenerationRate = 1;

	private BaseIcon baseIcon;

	public Player owner;

	public GameObject unit;

	// Use this for initialization
	void Start () {
		// get reference to base icon
		GameObject icon = transform.Find ("base_icon").gameObject;
		baseIcon = icon.GetComponent<BaseIcon> ();

		if (owner != null) {
			baseIcon.setColor(owner.color);
		}

		//continously update number of units in base
		InvokeRepeating ("UpdateUnits", -1, 1.0f/unitGenerationRate);
	}


	void Update () {

		updateIconSize();
	}

	public void transferUnits(Base target){
		int unitDivision = numUnitsInBase / 2;
		numUnitsInBase -= unitDivision;

		for (int i = 0; i<unitDivision; ++i) {
			Vector3 pos = transform.position + new Vector3(0,0,1);
			GameObject go = Instantiate(unit, pos, Quaternion.identity) as GameObject;
			Unit u = go.GetComponent<Unit>();
			u.setOwner(owner);
			u.setRandomVelocity(5);

		}
	}


	public void receiveAttack(){

	}


	private void updateIconSize(){
		float newSize = Mathf.Sqrt(1 + numUnitsInBase/5.0f);
		baseIcon.transform.localScale = new Vector3(newSize, newSize, 1);
	}

	// Increase or decrease units wrt base capacity.
	void UpdateUnits(){
		if (numUnitsInBase < unitCapacity) {
			numUnitsInBase++;
		}
		else if (numUnitsInBase > unitCapacity){
			numUnitsInBase--;
		}
	}
}
