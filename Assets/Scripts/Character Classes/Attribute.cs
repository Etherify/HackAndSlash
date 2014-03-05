public class Attribute : BaseStat
{
    private string _attname;


	public Attribute()
	{
		ExpToLevel = 50;
		LevelModifier = 1.05f;
        _attname = "";
	}

    public string AttName
    {
        get { return _attname; }
        set { _attname = value; }
    }

}

public enum AttributeName 
{
	Might,
	Constitution,
	Nimbleness,
	Speed,
	Concentration,
	Willpower,
    Charisma
	
}