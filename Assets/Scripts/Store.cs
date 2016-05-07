using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Store : MonoBehaviour {

	public float storeTimer;
	public float storeMultiplier;
	int storeCount;
	public float baseStoreCost;
	public float baseStoreProfit;
	public bool managerUnlocked;
	public bool storeUnlocked;
	public int storeTimerDivisor;
	float currentTimer = 0f;
	bool startTimer;
	float nextStoreCost;

	// Use this for initialization
	void Start () {
		startTimer = false;
		nextStoreCost = baseStoreCost;
		storeCount = 0;
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
	}
		
	public void BuyStore() {		
		GameManager.instance.AddToBalance (-nextStoreCost);
		nextStoreCost = (baseStoreCost * Mathf.Pow(storeMultiplier, storeCount));
		if (storeCount % storeTimerDivisor == 0) {
			storeTimer = storeTimer / 2;
		}
		storeCount++;
	}

	public void ProgressTimer(){
		if (!startTimer && storeCount > 0) {
			startTimer = true;	
		}
	}

	public float getCurrentTimer(){
		return currentTimer;
	}

	public float getStoreTimer() {
		return storeTimer;
	}

	public float getNextStoreCost() {
		return nextStoreCost;
	}

	public int getStoreCount() {
		return storeCount;
	}
}
