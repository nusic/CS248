using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour {

	public int numUnitsInBase = 5;
	public int unitCapacity = 20;
	public float unitGenerationRate = 1;

	public BaseIcon baseIcon;
	public Player owner;
	public Unit unit;

	// Use this for initialization
	void Start () {

		if (owner != null) {
			baseIcon.setColor(owner.color);
		}

		//continously update number of units in base
		InvokeRepeating ("UpdateUnits", -1, 1.0f/unitGenerationRate);
	}


	void Update () {

	}

	//Using vague name "transfer" since the logic for attacking enemy
	//and moving units withing your own bases is almost the same. 
	public void sendUnits(Base target){
		int unitDivision = numUnitsInBase / 2;
		numUnitsInBase -= unitDivision;

		for (int i = 0; i<unitDivision; ++i) {
			Vector3 pos = transform.position + HelperFunctions.RandomDirectionXY(20);

			Unit u = Instantiate(unit, pos, Quaternion.identity) as Unit;
			u.init(owner, target);
		}
		updateIconSize();
	}

	void OnTriggerEnter2D(Collider2D coll) {
		receiveUnit (coll.gameObject.GetComponent<Unit>());
	}

	public void receiveUnit(Unit unit){
		if (this != unit.target) {
			return;
		}

		if (unit.owner == owner) {
			numUnitsInBase++;
		} else {
			if(--numUnitsInBase <= 0){
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
		updateIconSize();
	}
}
