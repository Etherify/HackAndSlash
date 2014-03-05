using System.Collections.Generic;

public class ModifiedStat : BaseStat
{
	private List<ModifyingAttribute> _mods;
	private int _modValue;
	
	public ModifiedStat()
    {
		_mods = new List<ModifyingAttribute>();
		_modValue = 0;
	}
	
	public void AddModifier(ModifyingAttribute mod)
    {
		_mods.Add(mod);
	}
	
	public void CalculateModValue(){
		_modValue = 0;
		if(_mods.Count > 0){
			foreach(ModifyingAttribute mod in _mods)
			{
				_modValue +=  (int)(mod.attribute.AdjustedBaseValue * mod.ratio);
			}
		}
	}
	
	public new int AdjustedBaseValue
	{
		get	{return BaseValue + BuffValue + _modValue;}
	}
	
	public void Update(){
		CalculateModValue();
	}

    public string GetModifyingAttributesString()
    {
        string tempString ="";

//        UnityEngine.Debug.Log(_mods.Count);

        for(int cnt=0; cnt < _mods.Count;cnt ++)
        {
            //UnityEngine.Debug.Log(_mods[cnt].attribute.AttName);
            //UnityEngine.Debug.Log(_mods[cnt].ratio);

            tempString += _mods[cnt].attribute.AttName;
            tempString+="_";
            tempString+= _mods[cnt].ratio;


            if (cnt < _mods.Count - 1)
                tempString += "|";            
            
        }
        UnityEngine.Debug.Log(tempString);

        return tempString;
    }

}




public struct ModifyingAttribute 
{
	public Attribute attribute;			//the attribute to be used as a modifier
	public float ratio;					//the percent of the attributes AdjustedBaseValue that will be applied to the ModifiedStat
	
	/// <summary>
	/// Initializes a new instance of the <see cref="ModifyingAttribute"/> struct.
	/// </summary>
	/// <param name='att'>
	/// Att. the attribute to be used
	/// </param>
	/// <param name='rat'>
	/// Rat. the ratio to use
	/// </param>
    /// 

    public ModifyingAttribute(Attribute att, float rat)
    {
        //		UnityEngine.Debug.Log("Modifying Attribute Created");
        attribute = att;
        ratio = rat;
    }

	
}


