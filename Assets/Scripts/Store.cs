using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Store : MonoBehaviour {

	public Text StoreCountText;
	public Text CurrentBalanceText;

	int storeCount;
	float currentBalance;
	float baseStoreCost;

	// Use this for initialization
	void Start () {
		storeCount = 1;
		currentBalance = 2.0f;
		baseStoreCost = 1.50f;
		CurrentBalanceText.text = currentBalance.ToString("C2");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void BuyStore() {
		if (baseStoreCost > currentBalance) {
			Debug.Log ("Not enough money!");
			return;
		}

		storeCount++;
		StoreCountText.text = storeCount.ToString();
		currentBalance = currentBalance - baseStoreCost;
		CurrentBalanceText.text = currentBalance.ToString("C2");
		Debug.Log ("currentBalance=" + currentBalance);
	}
}
