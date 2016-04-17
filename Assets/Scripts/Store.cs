using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Store : MonoBehaviour {

	public Text StoreCountText;

	public Slider ProgressSlider;
	public GameManager GameManager;
	public float storeTimer = 4f;

	public int storeCount;

	public float baseStoreCost;
	public float baseStoreProfit;

	float currentTimer = 0f;
	bool startTimer;

	// Use this for initialization
	void Start () {
		startTimer = false;
		StoreCountText.text = storeCount.ToString();

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
		if (!GameManager.CanBuy(baseStoreCost)) {
			return;
		}

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
