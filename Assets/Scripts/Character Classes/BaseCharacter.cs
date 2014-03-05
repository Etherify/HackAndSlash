using UnityEngine;
using System.Collections;
using System;  //added to access enum class


public class BaseCharacter : MonoBehaviour {

    private string _name;
    private int _level;
    private uint _freeExp;

    //Attribute att = new Attribute();


    private Attribute[] _primaryAttribute;
    private Vital[] _vital;
    private Skill[] _skill;


    public void Awake()
    {
        _name = String.Empty;
        _level = 0;
        _freeExp = 0;

        _primaryAttribute = new Attribute[Enum.GetValues(typeof(AttributeName)).Length];
		_vital = new Vital[Enum.GetValues(typeof(VitalName)).Length];
        _skill = new Skill[Enum.GetValues(typeof(SkillName)).Length];

        SetupPrimaryAttributes();
        SetupVitals();
		SetupSkills ();

    }


    public string PlayerName
    {
        get {return _name;}
        set {_name = value;}

    }

    public int level 
    {
        get{ return _level; }
        set{ _level = value; }
    }

    public uint FreeExp
    {
        get{return _freeExp;}
        set{_freeExp = value;}
    }

    private void SetupPrimaryAttributes()
    {
        for (int cnt = 0; cnt < _primaryAttribute.Length; cnt++)
        {
            _primaryAttribute[cnt] = new Attribute();
            _primaryAttribute[cnt].AttName = ((AttributeName)cnt).ToString();
        }
    }

    private void SetupVitals()
    {
        for (int cnt = 0; cnt < _vital.Length; cnt++)
            _vital[cnt] = new Vital();

        SetupVitalModifiers();

    }

    private void SetupSkills()
    {
        for (int cnt = 0; cnt < _skill.Length; cnt++)
            _skill[cnt] = new Skill();

        SetupSkillModifiers();
    }

    //Take Average of players skills and assing that as player level
    public void CalculateLevel()
    {

    }


    public void AddExp(uint exp)
    {
        _freeExp += exp;


        CalculateLevel(); 
    }

    public Attribute GetPrimaryAttribute(int index)
    {
        return _primaryAttribute[index];
    }

    public Vital GetVital(int index)
    {
        return _vital[index];
    }

    public Skill GetSkill(int index)
    {
        return _skill[index];
    }

    private void SetupVitalModifiers()
    {
        ////health
        //ModifyingAttribute health = new ModifyingAttribute();
        //health.attribute = GetPrimaryAttribute((int)AttributeName.Constitution);
        //health.ratio = .5f;

        //GetVital((int)VitalName.Health).AddModifier(health);

        
        ////mana
        //ModifyingAttribute mana = new ModifyingAttribute();
        //mana.attribute = GetPrimaryAttribute((int)AttributeName.Intelligence);
        //mana.ratio = 1f;

        //GetVital((int)VitalName.Mana).AddModifier(mana);
        
        ////energy
        //ModifyingAttribute energy = new ModifyingAttribute();
        //energy.attribute = GetPrimaryAttribute((int)AttributeName.Charisma);
        //energy.ratio = .5f;

        //GetVital((int)VitalName.Energy).AddModifier(energy);


        //not needed code due to adding code into Get:  lines
        //ModifiedStat.ModfiyingAttribute health = new ModifiedStat.ModfiyingAttribute();
        //health.attribute = GetPrimaryAttribute((int)Attribute.AttributeName.Constitution);
        //health.ratio = .5f;


        GetVital((int)VitalName.Health).AddModifier(new ModifyingAttribute (GetPrimaryAttribute((int)AttributeName.Constitution), .5f));
        GetVital((int)VitalName.Mana).AddModifier(new ModifyingAttribute  (GetPrimaryAttribute((int)AttributeName.Willpower), 1f ));
        GetVital((int)VitalName.Energy).AddModifier(new ModifyingAttribute  (GetPrimaryAttribute((int)AttributeName.Nimbleness), 1f ));




    }

	private void SetupSkillModifiers() 
    {

        //Melee Offense
        GetSkill((int)SkillName.Melee_Offense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Might), .33f));
        GetSkill((int)SkillName.Melee_Offense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Nimbleness), .33f));
        //Melee Defense
        GetSkill((int)SkillName.Melee_Defense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Speed), .33f));
        GetSkill((int)SkillName.Melee_Defense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Constitution), .33f));

        //Magic Offense
        GetSkill((int)SkillName.Magic_Offense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Willpower), .33f));
        GetSkill((int)SkillName.Magic_Offense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Concentration), .33f));
        //Magic Defense
        GetSkill((int)SkillName.Magic_Defense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Willpower), .33f));
        GetSkill((int)SkillName.Magic_Defense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Concentration), .33f));
		
        //Ranged Offense
        GetSkill((int)SkillName.Ranged_Offense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Concentration), .33f));
        GetSkill((int)SkillName.Ranged_Offense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Speed), .33f));
        //Ranged Defense
        GetSkill((int)SkillName.Ranged_Defense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Speed), .33f));
        GetSkill((int)SkillName.Ranged_Defense).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Nimbleness), .33f));
		
	}

    public void StatUpdate()
    {
        for (int cnt = 0; cnt < _vital.Length; cnt++)
            _vital[cnt].Update();
        for (int cnt = 0; cnt < _skill.Length; cnt++)
            _skill[cnt].Update();

    }
}
