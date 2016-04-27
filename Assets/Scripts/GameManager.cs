using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	float currentBalance;

	// Use this for initialization
	void Start () {
		currentBalance = 2.0f;
		UIManager.instance.UpdateUI ();

	
	}

	void Awake() {
		if (instance == null)
			instance = this;
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateBalance(float amount) {
		currentBalance += amount;
		UIManager.instance.UpdateUI ();
	}

	public bool CanBuy(float cost) {
		return (cost <= currentBalance);
	}

	public float GetCurrentBalance() {
		return currentBalance;
	}
}
