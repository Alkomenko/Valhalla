﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GemPlayer : MonoBehaviour {
	
	static public int gem;

	[SerializeField]
	public Text TextGem;


	void Start(){
		gem = 0;
	}
}
