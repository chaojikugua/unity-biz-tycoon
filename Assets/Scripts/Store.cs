using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Store : MonoBehaviour {

	public Text StoreCountText;

	public Slider ProgressSlider;
	public GameManager GameManager;

	int storeCount;

	float baseStoreCost;
	float baseStoreProfit;
	float storeTimer = 4f;
	float currentTimer = 0f;
	bool startTimer;

	// Use this for initialization
	void Start () {
		storeCount = 1;

		baseStoreCost = 1.50f;
		baseStoreProfit = .50f;
		startTimer = false;

	}
	
	// Update is called once per frame
	void Update () {
		if (startTimer){
			currentTimer += Time.deltaTime;
			if (currentTimer > storeTimer) {
				Debug.Log ("timer has ended - resetting!");
				startTimer = false;
				currentTimer = 0f;
				GameManager.UpdateBalance (baseStoreProfit * storeCount);
			
			}
		}	
		ProgressSlider.value = currentTimer / storeTimer;
	}

	public void BuyStore() {
		//if (baseStoreCost > currentBalance) {
		//	Debug.Log ("Not enough money!");
		//	return;
		//}

		storeCount++;
		StoreCountText.text = storeCount.ToString();

		GameManager.UpdateBalance (-baseStoreCost);

	}

	public void StoreOnClick(){
		Debug.Log ("storeOnClick!");
		if (!startTimer) {
			startTimer = true;	
		}
	}
}
