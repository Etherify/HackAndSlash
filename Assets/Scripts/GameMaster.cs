using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

    public GameObject playerCharacter;
    public Camera mainCamera;
    public GameObject gameSettings; 

    //will remove once camera script is enabled
    public float zOffset;
    public float yOffset;
    public float xRotOffset;
    //end delete


    private PlayerCharacter _pcScript;



    private GameObject _pc;

    
	// Use this for initialization
	void Start () 
    {
        _pc = Instantiate(playerCharacter, Vector3.zero, Quaternion.identity) as GameObject;


        _pcScript = _pc.GetComponent<PlayerCharacter>();




        zOffset = -2.5f;
        yOffset = 2.5f;
        xRotOffset = 22.5f;

        mainCamera.transform.position = _pc.transform.position;

        mainCamera.transform.position = new Vector3(_pc.transform.position.x, _pc.transform.position.y + yOffset, _pc.transform.position.z + zOffset);
        mainCamera.transform.Rotate(xRotOffset, 0, 0);


	}

    public void LoadCharacter()
    {
        GameObject gs = GameObject.Find("__GameSettings");

        if (gs == null)
        {
            Instantiate(gameSettings, Vector3.zero, Quaternion.identity);
        }

        GameSettings gsScript = GameObject.Find("__Game Settings").GetComponent<GameSettings>();

        //chage the cur value of the vital to the max modified value of that vital

        gsScript.LoadCharacterData();


    }

}
