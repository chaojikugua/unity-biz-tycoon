using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Store : MonoBehaviour {

	public Text StoreCountText;
	public Text BuyButtonText;

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
		UpdateBuyButton ();

	}

	void UpdateBuyButton() {
		BuyButtonText.text = "Buy " + nextStoreCost.ToString ("C2");
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
		UpdateBuyButton ();
		GameManager.UpdateBalance (-nextStoreCost);
		nextStoreCost = (baseStoreCost * Mathf.Pow(storeMultiplier, storeCount));

	}

	public void StoreOnClick(){
		Debug.Log ("storeOnClick!");
		if (!startTimer) {
			startTimer = true;	
		}
	}
}
