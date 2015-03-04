using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour {

	public int numUnitsInBase = 5;
	public int unitCapacity = 20;
	public float unitGenerationRate = 1;

	public BaseIcon baseIcon;
	public Player owner;
	public Unit unitPrefab;

	// Use this for initialization
	void Start () {

		if (owner != null) {
			baseIcon.setColor(owner.color);
		}

		//continously update number of units in base
		InvokeRepeating ("UpdateUnits", -1, 1.0f/unitGenerationRate);
	}

	public void sendUnits(Base target){
		int unitDivision = numUnitsInBase / 2;
		numUnitsInBase -= unitDivision;

		for (int i = 0; i<unitDivision; ++i) {
			Vector3 pos = transform.position + HelperFunctions.RandomDirectionXY(10);

			Unit u = Instantiate(unitPrefab, pos, Quaternion.identity) as Unit;
			u.init(owner, target);
		}
		updateIconSize();
	}


	//Invoked when unit collides into base 
	void OnTriggerStay2D(Collider2D unitCollider) {
		receiveUnit (unitCollider.gameObject.GetComponent<Unit>());
	}

	//Receive a unit to the base. If the unit is friendly, increment 
	//number of units in base, otherwise decrement (ie base is attacked)
	private void receiveUnit(Unit unit){
		if (this != unit.target) {
			return;
		}

		if (unit.owner == owner) {
			numUnitsInBase++;
		} else {
			if(--numUnitsInBase < 0){
				setOwner(unit.owner);
			}
		}
		updateIconSize();
		Destroy (unit.gameObject);
	}


	private void setOwner(Player owner){
		this.owner = owner;
		baseIcon.setColor (this.owner.color);
	}

	// Should be called when ever numUnitsInBase is changed
	private void updateIconSize(){
		float newSize = Mathf.Sqrt(1 + numUnitsInBase/5.0f);
		transform.localScale = new Vector3(newSize, newSize, 1);
	}

	// Increase or decrease units wrt base capacity.
	private void UpdateUnits(){
		if (numUnitsInBase < unitCapacity) {
			numUnitsInBase++;
		}
		else if (numUnitsInBase > unitCapacity){
			numUnitsInBase--;
		}
		updateIconSize();
	}
}
