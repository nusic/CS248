using UnityEngine;
using System.Collections;


[RequireComponent(typeof(AudioSource))]
public class PlaySound : MonoBehaviour {
	public AudioClip clip;
	// Use this for initialization
	void Start () {
		//audio.PlayOneShot(clip, 0.9F);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
