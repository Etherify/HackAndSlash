using UnityEngine;
using System.Collections;

public class GameSettings : MonoBehaviour {


    void Awake()
    {
        DontDestroyOnLoad(this);
    }
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void SaveCharacterData()
    {
        GameObject pc = GameObject.Find("pc");

        PlayerPrefs.DeleteAll();

        PlayerCharacter pcClass = pc.GetComponent<PlayerCharacter>();
        PlayerPrefs.SetString("Player Name",pcClass.PlayerName.ToString());



        for (int cnt = 0; cnt < System.Enum.GetValues(typeof(AttributeName)).Length; cnt++)
        {
            PlayerPrefs.SetInt(((AttributeName)cnt).ToString() + ":  Base Value", pcClass.GetPrimaryAttribute(cnt).BaseValue);
            PlayerPrefs.SetInt(((AttributeName)cnt).ToString()+":  Exp To Level", pcClass.GetPrimaryAttribute(cnt).ExpToLevel);
        }

        for (int cnt = 0; cnt < System.Enum.GetValues(typeof(VitalName)).Length; cnt++)
        {
            PlayerPrefs.SetInt(((VitalName)cnt).ToString() + ":  Base Value", pcClass.GetVital(cnt).BaseValue);
            PlayerPrefs.SetInt(((VitalName)cnt).ToString() + ":  Exp To Level", pcClass.GetVital(cnt).ExpToLevel);
            PlayerPrefs.SetInt(((VitalName)cnt).ToString() + ":  Current Value", pcClass.GetVital(cnt).CurValue);

            PlayerPrefs.SetString(((VitalName)cnt).ToString() + ":  Modifying Attributes", pcClass.GetVital(cnt).GetModifyingAttributesString());

            pcClass.GetVital(cnt).GetModifyingAttributesString();

        }


        for (int cnt = 0; cnt < System.Enum.GetValues(typeof(SkillName)).Length; cnt++)
        {
            PlayerPrefs.SetInt(((SkillName)cnt).ToString() + ":  Base Value", pcClass.GetSkill(cnt).BaseValue);
            PlayerPrefs.SetInt(((SkillName)cnt).ToString() + ":  Exp To Level", pcClass.GetSkill(cnt).ExpToLevel);

            PlayerPrefs.SetString(((SkillName)cnt).ToString() + ":  Modifying Attributes", pcClass.GetSkill(cnt).GetModifyingAttributesString());

            pcClass.GetSkill(cnt).GetModifyingAttributesString();

        }

        
    }

    public void LoadCharacterData()
    {

    }


}
