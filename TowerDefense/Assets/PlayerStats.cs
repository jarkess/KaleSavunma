using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour {

	public static int Money;
	
	public int startMoney;

	public TextMeshProUGUI MoneyText;


	//3 Oyuna başlarken paramızı belirliyor ve ekranda gösteriyor
	void Start ()
	{
		Money = startMoney;
	}

	void Update(){
		MoneyText.text = Money.ToString() + "$";
	}

}
