using UnityEngine;
using System.Collections;

public class UpdateItem : MonoBehaviour {

	public Texture2D CoinBonus = null;
	public Texture2D Shield = null;
	public Texture2D PointBonus = null;
	public Texture2D CoinMaget = null;
	
	public int CurrentType = 0;
	
	private Texture2D CurrentTexture = null;
	// Use this for initialization
	void Start () {
		CurrentType = Random.Range (0, 4);
		switch (CurrentType)
		{
		case 0:
			CurrentTexture = CoinBonus;
			break;
		case 1:
			CurrentTexture = Shield;
			break;
		case 2:
			CurrentTexture = PointBonus;
			break;
		default:
			CurrentTexture = CoinMaget;
			break;
		}
		renderer.material.mainTexture = CurrentTexture;
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(Vector3.up, 5.0f * Time.deltaTime);
	}
}
