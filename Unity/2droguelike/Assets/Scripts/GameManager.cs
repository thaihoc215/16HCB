using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public BoarManager boarScript;
    
    private int level = 3;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        boarScript = GetComponent<BoarManager>();
        InitGame();
    }

    //init game with the level define in boarmanager
    void InitGame()
    {
        boarScript.SetupScene(level);
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
