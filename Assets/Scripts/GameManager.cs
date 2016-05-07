using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public delegate void UpdateBalance ();
	public static event UpdateBalance OnUpdateBalance;

	public static GameManager instance;
	float currentBalance = 0f;
	public string CompanyName;

	// Use this for initialization
	void Start () {
		if (OnUpdateBalance != null)
			OnUpdateBalance();		
	}

	void Awake() {
		if (instance == null)
			instance = this;
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void AddToBalance(float amount) {
		currentBalance += amount;
		if (OnUpdateBalance != null)
			OnUpdateBalance();		
	}

	public bool CanBuy(float cost) {
		return (cost <= currentBalance);
	}

	public float GetCurrentBalance() {
		return currentBalance;
	}
}
