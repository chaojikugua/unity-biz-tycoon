using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIStore : MonoBehaviour {

	public Text StoreCountText;
	public Slider ProgressSlider;
	public Text BuyButtonText;
	public Button BuyButton;

	public Store Store;

	void Awake() {
		Store = transform.GetComponent<Store>();
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		ProgressSlider.value = Store.currentTimer / Store.storeTimer;
		UpdateUI ();
	}

	public void UpdateUI() {
		CanvasGroup cg = this.transform.GetComponent<CanvasGroup> ();
		if (!Store.storeUnlocked && !GameManager.instance.CanBuy(Store.nextStoreCost)) {
			cg.interactable = false;
			cg.alpha = 0; //invisible
		} else {
			cg.interactable = true;
			cg.alpha = 1; //visible
			Store.storeUnlocked = true;
		}
		if (GameManager.instance.CanBuy (Store.nextStoreCost)) {
			BuyButton.interactable = true;
		} else {
			BuyButton.interactable = false;
		}


	}

	public void BuyStoreOnClick(){
		if (!GameManager.instance.CanBuy(Store.nextStoreCost)) {
			return;
		}
		Store.BuyStore ();
		StoreCountText.text = Store.storeCount.ToString();
		BuyButtonText.text = "Buy " + Store.nextStoreCost.ToString ("C2");
	}

	public void ProgressTimerOnClick() {
		Store.ProgressTimer ();
	}
}
