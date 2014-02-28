using System.Collections.Generic;

public class ModifiedStat : BaseStat
{

    private List<ModfiyingAttribute> _mods;  // list of attributes that modify this stat
    private int _modValue;                   // amount added to the baseValue from the modifiers



    public ModifiedStat()
    {

        _mods = new List<ModfiyingAttribute>();
        _modValue = 0;

    }

    public void AddModifier(ModfiyingAttribute mod)
    {
        _mods.Add(mod);
    }

    private void CalculateModValue()
    {
        _modValue = 0;

        if (_mods.Count > 0)
            foreach (ModfiyingAttribute att in _mods)
                _modValue += (int)(att.attribute.AdjustedBaseValue * att.ratio);
    }

    
    public new int AdjustedBaseValue
    {
        get { return BaseValue + BuffValue + _modValue; }
    }

    public void Update()
    {
        CalculateModValue();
    }

    
    
    public struct ModfiyingAttribute
    {
        public Attribute attribute;
        public float ratio;
    }



}
