using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Store : MonoBehaviour {

	public Text StoreCountText;

	public Slider ProgressSlider;
	public GameManager GameManager;
	public float storeTimer = 4f;
	public float storeMultiplier;

	public int storeCount;

	public float baseStoreCost;
	public float baseStoreProfit;
	public bool managerUnlocked;

	float currentTimer = 0f;
	bool startTimer;
	private float nextStoreCost;


	// Use this for initialization
	void Start () {
		startTimer = false;
		StoreCountText.text = storeCount.ToString();
		nextStoreCost = baseStoreCost;

	}
	
	// Update is called once per frame
	void Update () {
		if (startTimer){
			currentTimer += Time.deltaTime;
			if (currentTimer > storeTimer) {
				if (!managerUnlocked)
				startTimer = false;
				currentTimer = 0f;
				GameManager.UpdateBalance (baseStoreProfit * storeCount);
			
			}
		}	
		ProgressSlider.value = currentTimer / storeTimer;
	}

	public void BuyStore() {
		if (!GameManager.CanBuy(nextStoreCost)) {
			return;
		}

		storeCount++;
		StoreCountText.text = storeCount.ToString();
		nextStoreCost = (baseStoreCost * Mathf.Pow(storeMultiplier, storeCount));
		Debug.Log ("nextStoreCost=" + nextStoreCost);
		GameManager.UpdateBalance (-nextStoreCost);

	}

	public void StoreOnClick(){
		Debug.Log ("storeOnClick!");
		if (!startTimer) {
			startTimer = true;	
		}
	}
}
