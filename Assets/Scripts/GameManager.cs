using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public Text CurrentBalanceText;

	float currentBalance;

	// Use this for initialization
	void Start () {
		currentBalance = 2.0f;
		CurrentBalanceText.text = currentBalance.ToString("C2");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateBalance(float amount) {
		currentBalance += amount;
		CurrentBalanceText.text = currentBalance.ToString("C2");
	}

	public bool CanBuy(float cost) {
		return (cost <= currentBalance);
	}
}
