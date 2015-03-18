using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class BaseSounds{
	public AudioClip explosion1;
	public AudioClip explosion2;
	public AudioClip onTransfer;

}

[RequireComponent(typeof(AudioSource))]
public class Base : MonoBehaviour {

	public int numUnitsInBase = 5;
	public int unitCapacity = 20;
	public float unitGenerationRate = 1;
	
	public BaseIcon baseIcon;
	public Player owner;
	public Unit unitPrefab;
	public Text label;
	
	public float takeOffTime;

	public BaseSounds sounds;


	// Use this for initialization
	void Start () {
		setOwner(owner);
		OnUnitUpdate();

		//continously update number of units in base
		InvokeRepeating ("GenerateUnits", 2, 1.0f/unitGenerationRate);
	}

	public void sendUnits(Base target){
		if (target == this) {
			return;
		}

		int unitDivision = numUnitsInBase / 2;
		numUnitsInBase -= unitDivision;

		StartCoroutine(sendUnitsRoutine(target, unitDivision));
	}

	protected IEnumerator sendUnitsRoutine(Base target, int numUnits){
		for (int i = 0; i<numUnits; ++i) {
			Vector3 pos = transform.position;
			Unit u = Instantiate(unitPrefab, pos, Quaternion.identity) as Unit;
			u.init(owner, target);
			OnUnitUpdate();
			yield return new WaitForSeconds(takeOffTime);
		}
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
			playUnitTransferSound();
			numUnitsInBase++;
		} else {
			Instantiate(unit.explosionPrefab, unit.transform.position, unit.transform.rotation);
			playExplosionSound();
			if(--numUnitsInBase <= 0) {
				setOwner(unit.owner);
			}
		}
		OnUnitUpdate();
		Destroy (unit.gameObject);
	}


	private void setOwner(Player newOwner){
		this.owner = newOwner;

		if (this.owner == null) {
			baseIcon.setColor(Player.NullColor);
			label.color = Player.NullColor;
			return;
		}

		baseIcon.setColor(this.owner.color);
		label.color = 2.0f*this.owner.color;

	}


	// Increase or decrease units wrt base capacity.
	private void GenerateUnits(){
		//Don't generate units if no uwner
		if (!owner) {
			return;
		}
		if (numUnitsInBase < unitCapacity) {
			numUnitsInBase++;
		}
		else if (numUnitsInBase > unitCapacity){
			numUnitsInBase--;
		}
		OnUnitUpdate ();
	}

	private void OnUnitUpdate(){
		label.text = numUnitsInBase.ToString();
		updateIconSize();
	}

	// Should be called when ever numUnitsInBase is changed
	private void updateIconSize(){
		float newSize = Mathf.Sqrt(1 + numUnitsInBase/5.0f);
		baseIcon.transform.localScale = new Vector3(newSize, newSize, 1);
	}

	private void playUnitTransferSound(){
		float f = (1.0f) / 36 * (numUnitsInBase-12);
		audio.pitch = Mathf.Pow (2, f);
		audio.PlayOneShot (sounds.onTransfer, 0.2f);
	}

	private void playExplosionSound(){
		audio.pitch = Random.Range(0.7f,1.0f);
		if (Random.Range (0, 2) > 0.3) {
			audio.PlayOneShot (sounds.explosion1, 0.6F);
		}
		else{
			audio.PlayOneShot (sounds.explosion2, 0.6F);
		}
	}
}
