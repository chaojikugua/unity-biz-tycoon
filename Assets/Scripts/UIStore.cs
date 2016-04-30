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
	}
}
