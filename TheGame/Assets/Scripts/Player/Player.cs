using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class PlayerSounds {
	public AudioClip jet;
	public AudioClip attack;
	public AudioClip transfer;
	public AudioClip aimEnemy;
	public AudioClip select;
}

[RequireComponent(typeof(AudioSource))]
public class Player : MonoBehaviour {

	public Color color;
	public float unitSpeed;

	public GameObject selectedPrefab;
	public GameObject attackPrefab;
	public GameObject transferPrefab;

	public PlayerSounds sounds;

	//Use non-generic Hashtables instead?
	private List<Base> selectedBases = new List<Base>();
	private List<GameObject> selectedSprites = new List<GameObject>();
	private GameObject aim;
	private Base currentTarget;

	public static Color NullColor = new Color(0.5f, 0.5f, 0.5f);

	void Start(){

	}

	public bool hasSelected(Base b){
		return selectedBases.Contains (b);
	}

	public int selectCount(){
		return selectedBases.Count;
	}

	public void addToSelection(Base b){
		selectedBases.Add(b);

		Vector3 pos = b.transform.position;
		GameObject sel = (GameObject)Instantiate(selectedPrefab, pos, Quaternion.identity);
		selectedSprites.Add(sel);
	}

	public void aimAt(Base target){
		if (target == currentTarget) {
			return;
		}

		currentTarget = target;

		if(aim){
			Destroy(aim);
		}
		if (target) {
			Vector3 pos = target.transform.position;
			if (target.owner == this){
				audio.PlayOneShot(sounds.select, 0.2f);
				aim = (GameObject)Instantiate(transferPrefab, pos, Quaternion.identity);	
			}
			else{
				audio.PlayOneShot(sounds.aimEnemy, 0.2f);
				aim = (GameObject)Instantiate(attackPrefab, pos, Quaternion.identity);
			}
		} 
	}


	public void selectionSendTo(Base target){
		foreach (Base b in selectedBases){
			b.sendUnits(target);
		}
		clearSelection();
		audio.PlayOneShot (sounds.jet);

		if (target.owner == this) {
			audio.PlayOneShot(sounds.transfer, 0.5f);
		}
		else{
			audio.PlayOneShot(sounds.attack, 0.5f);
		}

	}
	
	public void clearSelection(){
		selectedBases.Clear();
		foreach (GameObject go in selectedSprites) {
			Destroy(go);
		}
		selectedSprites.Clear();
		Destroy (aim);
	}
}
