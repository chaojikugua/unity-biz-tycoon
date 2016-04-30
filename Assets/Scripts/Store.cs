using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Store : MonoBehaviour {

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
	public float nextStoreCost;

	// Use this for initialization
	void Start () {
		startTimer = false;
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
				GameManager.instance.AddToBalance (baseStoreProfit * storeCount);			
			}
		}				
	}
		
	public void BuyStore() {		
		storeCount++;
		GameManager.instance.AddToBalance (-nextStoreCost);
		nextStoreCost = (baseStoreCost * Mathf.Pow(storeMultiplier, storeCount));
		if (storeCount % storeTimerDivisor == 0) {
			storeTimer = storeTimer / 2;
		}
	}

	public void ProgressTimer(){
		if (!startTimer && storeCount > 0) {
			startTimer = true;	
		}
	}
}