using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Store : MonoBehaviour {

	public Text StoreCountText;
	public Text CurrentBalanceText;

	int storeCount;
	float currentBalance;
	float baseStoreCost;
	float baseStoreProfit;
	float storeTimer = 4f;
	float currentTimer = 0f;
	bool startTimer;

	// Use this for initialization
	void Start () {
		storeCount = 1;
		currentBalance = 2.0f;
		baseStoreCost = 1.50f;
		baseStoreProfit = .50f;
		startTimer = false;
		CurrentBalanceText.text = currentBalance.ToString("C2");
	}
	
	// Update is called once per frame
	void Update () {
		if (startTimer){
			currentTimer += Time.deltaTime;
			if (currentTimer > storeTimer) {
				Debug.Log ("timer has ended - resetting!");
				startTimer = false;
				currentTimer = 0f;
				currentBalance += baseStoreProfit * storeCount;
				CurrentBalanceText.text = currentBalance.ToString("C2");
			}
		}		
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
	}

	public void StoreOnClick(){
		Debug.Log ("storeOnClick!");
		if (!startTimer) {
			startTimer = true;	
		}
	}
}
