using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Store : MonoBehaviour {

	public Text StoreCountText;

	int storeCount;

	// Use this for initialization
	void Start () {
		storeCount = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void BuyStore() {
		storeCount++;
		StoreCountText.text = storeCount.ToString();
	}
}
