using UnityEngine;
using System.Collections;
using System;

public class CharacterGenerator : MonoBehaviour
{

    private PlayerCharacter _toon;
    private const int STARTING_POINTS = 350;
    private const int MIN_STARTING_ATTRIBUTE_VALUE = 10;
    private const int STARTINGVALUE = 50;
    private int pointsLeft;


    //buffer between char creation
    private const int OFFSET = 5;

    //how tall the stat lines are
    private const int LINEHEIGHT = 20;

    //how long the boxes in the Char Creation are
    private const int STAT_LABEL_WIDTH = 100;
    private const int BASEVALUE_LABEL_WIDTH = 30; 

    //button dimensions

    private const int BUTTON_WIDTH = 20;
    private const int BUTTON_HEIGHT = 20;

    
    //starting Y position of stats
    private int statStartingPosition = 40;

    //starting x positon of points left
    private int startingStatPosition = 250;





    

    // Use this for initialization
    void Start()
    {
        _toon = new PlayerCharacter();
        _toon.Awake();

        pointsLeft = STARTING_POINTS;

        for (int cnt = 0; cnt < Enum.GetValues(typeof(AttributeName)).Length; cnt++)
        {
            //minimum point is 10, but 50 will start in each
            _toon.GetPrimaryAttribute(cnt).BaseValue = STARTINGVALUE;
            pointsLeft-=(STARTINGVALUE - MIN_STARTING_ATTRIBUTE_VALUE);

        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        DisplayName();
        DisplayPointsLeft();
        DisplayAttributes();
        DisplayVitals();
        DisplaySkills();

    }

    private void DisplayName()
    {
        GUI.Label(new Rect(10, 10, 50, 25), "Name");
        _toon.Name = GUI.TextField(new Rect(65, 10, 100, 25), _toon.Name);

    }

	private void DisplayAttributes()
	{
		for (int cnt = 0; cnt < Enum.GetValues(typeof(AttributeName)).Length; cnt++)
		{
			GUI.Label(new Rect( OFFSET,                                     //x
                                statStartingPosition + (cnt * LINEHEIGHT),  //y
                                STAT_LABEL_WIDTH,                           //width
                                LINEHEIGHT),                                //height 
                                
                                ((AttributeName)cnt).ToString());
			GUI.Label(new Rect(STAT_LABEL_WIDTH + OFFSET, statStartingPosition + (cnt * LINEHEIGHT), BASEVALUE_LABEL_WIDTH, LINEHEIGHT), _toon.GetPrimaryAttribute(cnt).AdjustedBaseValue.ToString());

            if (GUI.Button(new Rect(OFFSET + STAT_LABEL_WIDTH + BASEVALUE_LABEL_WIDTH, 
                statStartingPosition + (cnt * BUTTON_HEIGHT), 
                BUTTON_WIDTH, 
                BUTTON_HEIGHT), 
                "-"))
            {
                if(pointsLeft >0)
                {
                    if(_toon.GetPrimaryAttribute(cnt).BaseValue > MIN_STARTING_ATTRIBUTE_VALUE)
                    {
                        _toon.GetPrimaryAttribute(cnt).BaseValue--;
                        pointsLeft++;
                        _toon.StatUpdate();
                    }


                }
            }
            if (GUI.Button(new Rect(OFFSET + STAT_LABEL_WIDTH + BASEVALUE_LABEL_WIDTH + BUTTON_WIDTH, 
                statStartingPosition + (cnt * BUTTON_HEIGHT), 
                BUTTON_WIDTH, 
                BUTTON_HEIGHT), 
                "+"))
            {
                if (pointsLeft > 0)
                {
                    _toon.GetPrimaryAttribute(cnt).BaseValue++;
                    pointsLeft--;
                    _toon.StatUpdate();
                }
            }
		}
	}

	private void DisplayVitals()
	{
		for (int cnt = 0; cnt < Enum.GetValues(typeof(VitalName)).Length; cnt++)
		{
            GUI.Label(new Rect(OFFSET, 
                statStartingPosition + ((cnt +7) * LINEHEIGHT), 
                STAT_LABEL_WIDTH, 
                LINEHEIGHT), ((VitalName)cnt).ToString());

            GUI.Label(new Rect(OFFSET + STAT_LABEL_WIDTH, 
                statStartingPosition + ((cnt + 7) * LINEHEIGHT), 
                STAT_LABEL_WIDTH, LINEHEIGHT), 
                _toon.GetVital(cnt).AdjustedBaseValue.ToString());
		}
	}

    private void DisplaySkills()
    {
        for (int cnt = 0; cnt < Enum.GetValues(typeof(SkillName)).Length; cnt++)
        {

            GUI.Label(new Rect((OFFSET * 2) + STAT_LABEL_WIDTH + BASEVALUE_LABEL_WIDTH + (BUTTON_WIDTH * 2), 
                statStartingPosition + (cnt * LINEHEIGHT), 
                STAT_LABEL_WIDTH, 
                LINEHEIGHT), 
                ((SkillName)cnt).ToString());

            GUI.Label(new Rect((OFFSET * 2) + STAT_LABEL_WIDTH + BASEVALUE_LABEL_WIDTH + (BUTTON_WIDTH * 2) + STAT_LABEL_WIDTH, 
                statStartingPosition + (cnt * LINEHEIGHT), 
                STAT_LABEL_WIDTH, 
                LINEHEIGHT), 
                _toon.GetSkill(cnt).AdjustedBaseValue.ToString());

        }
    }

    private void DisplayPointsLeft()
    {
        GUI.Label(new Rect((OFFSET * 2) + STAT_LABEL_WIDTH + BASEVALUE_LABEL_WIDTH + (BUTTON_WIDTH * 2), 
            LINEHEIGHT, 
            STAT_LABEL_WIDTH, 
            LINEHEIGHT), 
            "Points Left:" + pointsLeft.ToString());
    }

}
