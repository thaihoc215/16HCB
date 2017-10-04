using UnityEngine;
using System.Collections;

public class Upgrade : MonoBehaviour {

	public Texture2D CoinBonus = null;
	public Texture2D Shield = null;
	public Texture2D PointBonus = null;
	public Texture2D CoinMaget = null;
	public float costCoinBonus;
	public float costShield;
	public float costPointBonus;
	public float costCoinMaget;
	public float totalcoin;
	// Use this for initialization
	void Start () {
		costCoinBonus = Mathf.Max (10.0f, PlayerPrefs.GetFloat ("costcoinbonus"));
		costShield = Mathf.Max (10.0f, PlayerPrefs.GetFloat ("costshield"));
		costPointBonus = Mathf.Max (10.0f, PlayerPrefs.GetFloat ("costpointbonus"));
		costCoinMaget = Mathf.Max (10.0f, PlayerPrefs.GetFloat ("costcoinmaget"));
		totalcoin = PlayerPrefs.GetFloat ("totalcoin");
		PlayerPrefs.SetFloat ("coinbonus", Mathf.Max (5.0f, PlayerPrefs.GetFloat ("coinbonus")));
		PlayerPrefs.SetFloat ("coinmaget", Mathf.Max (2.0f, PlayerPrefs.GetFloat ("coinmaget")));
		PlayerPrefs.SetFloat ("pointbonus", Mathf.Max (5.0f, PlayerPrefs.GetFloat ("pointbonus")));
		PlayerPrefs.SetFloat ("shield", Mathf.Max (2.0f, PlayerPrefs.GetFloat ("shield")));
	}
	
	void OnGUI()
	{
		GUI.DrawTexture (new Rect(10,10, 100,100), CoinBonus);
		GUI.Label (new Rect(120, 10, 200 , 100), "Coin bonus");
		if (GUI.Button (new Rect(320, 10, 100,100), costCoinBonus + "$"))
		{
			if (PlayerPrefs.GetFloat ("totalcoin") >= costCoinBonus)
			{
				PlayerPrefs.SetFloat ("coinbonus", PlayerPrefs.GetFloat ("coinbonus") * 2);
				totalcoin -= costCoinBonus;
				costCoinBonus = costCoinBonus * 4;
				PlayerPrefs.SetFloat ("costcoinbonus", costCoinBonus);
				PlayerPrefs.SetFloat ("totalcoin", totalcoin);
			}
		}
		GUI.DrawTexture (new Rect(10,120, 100,100), Shield);
		GUI.Label (new Rect(120, 110, 200 , 100), "Shied");
		if (GUI.Button (new Rect(320, 120, 100,100), costShield + "$"))
		{
			if (PlayerPrefs.GetFloat ("totalcoin") >= costShield)
			{
				PlayerPrefs.SetFloat ("shield", PlayerPrefs.GetFloat ("shield") * 2);
				totalcoin -= costShield;
				costShield *= 4;
				PlayerPrefs.SetFloat ("costshield", costShield);
				PlayerPrefs.SetFloat ("totalcoin", totalcoin);
			}
		}
		
		GUI.DrawTexture (new Rect(10,230, 100,100), PointBonus);
		GUI.Label (new Rect(120, 230, 200 , 100), "Point bonus");
		if (GUI.Button (new Rect(320, 230, 100,100), costPointBonus + "$"))
		{
			if (PlayerPrefs.GetFloat ("totalcoin") >= costPointBonus)
			{
				PlayerPrefs.SetFloat ("pointbonus", PlayerPrefs.GetFloat ("pointbonus") * 2);
				totalcoin -= costPointBonus;
				costPointBonus *= 4;
				PlayerPrefs.SetFloat ("costpointbonus", costPointBonus);
				PlayerPrefs.SetFloat ("totalcoin", totalcoin);
			}
		}
		
		GUI.DrawTexture (new Rect(10,340, 100,100), CoinMaget);
		GUI.Label (new Rect(120, 340, 200 , 100), "Coin maget");
		if (GUI.Button (new Rect(320, 340, 100,100), costCoinMaget + "$"))
		{
			if (PlayerPrefs.GetFloat ("totalcoin") >= costCoinMaget)
			{
				PlayerPrefs.SetFloat ("coinmaget", PlayerPrefs.GetFloat ("coinmaget") * 2);
				totalcoin -= costCoinMaget;
				costCoinMaget *= 4;
				PlayerPrefs.SetFloat ("costcoinmaget", costCoinMaget);
				PlayerPrefs.SetFloat ("totalcoin", totalcoin);
			}
		}
		
		GUI.Label (new Rect (110, 500, 300, 100), "Coin: " + totalcoin.ToString () + "$");
		if (GUI.Button (new Rect(0, Screen.height - 30, 50, 30), "Back"))
		{
			Application.LoadLevel ("game");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
