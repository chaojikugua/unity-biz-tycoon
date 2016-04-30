using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Store : MonoBehaviour {

	public Text StoreCountText;
	public Text BuyButtonText;
	public Button BuyButton;

	public float storeTimer = 4f;
	public float storeMultiplier;

	public int storeCount;

	public float baseStoreCost;
	public float baseStoreProfit;
	public bool managerUnlocked;
	public bool storeUnlocked;
	public int storeTimerDivisor = 1;

	public float currentTimer = 0f;
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
				GameManager.instance.AddToBalance (baseStoreProfit * storeCount);
			
			}
		}	

		CheckStoreBuy ();
	}

	public void CheckStoreBuy() {

		CanvasGroup cg = this.transform.GetComponent<CanvasGroup> ();

		if (!storeUnlocked && !GameManager.instance.CanBuy(nextStoreCost)) {
			cg.interactable = false;
			cg.alpha = 0; //invisible
		} else {
			cg.interactable = true;
			cg.alpha = 1; //visible
			storeUnlocked = true;
		}

		if (GameManager.instance.CanBuy (nextStoreCost)) {
			BuyButton.interactable = true;
		} else {
			BuyButton.interactable = false;
		}

	}

	public void BuyStore() {
		if (!GameManager.instance.CanBuy(nextStoreCost)) {
			return;
		}

		storeCount++;
		StoreCountText.text = storeCount.ToString();
		UpdateBuyButton ();
		GameManager.instance.AddToBalance (-nextStoreCost);
		nextStoreCost = (baseStoreCost * Mathf.Pow(storeMultiplier, storeCount));

		if (storeCount % storeTimerDivisor == 0) {
			storeTimer = storeTimer / 2;
		}
	}

	public void StoreOnClick(){
		if (!startTimer && storeCount > 0) {
			startTimer = true;	
		}
	}
}
