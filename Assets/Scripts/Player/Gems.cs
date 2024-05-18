using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gems : MonoBehaviour {
	public int Cost; 


	void OnTriggerEnter2D(Collider2D col) { 
		GemPlayer.gem += Cost; 
		GameObject.FindGameObjectWithTag ("Player").GetComponent<GemPlayer> ().TextGem.text = GemPlayer.gem.ToString(); 
		Destroy (gameObject); 
		}
}

