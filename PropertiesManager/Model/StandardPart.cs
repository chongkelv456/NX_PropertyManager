using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesManager.Model
{
    public class StandardPart
    {
        List<string> lists = new List<string>();

        const string ADJUST_PIN = "ADJUST PIN";        
        const string BLANK_PUNCH = "BLANK PUNCH";
        const string BLOCK_PUNCH = "BLOCK PUNCH";
        const string BURRING_PUNCH = "BURRING PUNCH";
        const string BUTTON_DIE = "BUTTON DIE";
        const string CAP_SCREW = "CAP SCREW";
        const string COIL_SPRING = "COIL SPRING";
        const string DOWEL_PIN = "DOWEL PIN";
        const string EJECTOR_PIN = "EJECTOR PIN";
        const string EXTENSION_SPRING = "EXTENSION SPRING";
        const string FLAT_HEAD_CAP_SCREW = "FLAT HEAD CAP SCREW";
        const string GUIDE_BUSH = "GUIDE BUSH";
        const string GUIDE_LIFTER = "GUIDE LIFTER";
        const string GUIDE_LIFTER_SETS = "GUIDE LIFTER SETS";
        const string GUIDE_PIN = "GUIDE PIN";
        const string GUIDE_POST_SETS = "GUIDE POST SETS";
        const string HEX_NUT = "HEX NUT";
        const string HOOK = "HOOK";
        const string KEY = "KEY";
        const string KNOCKOUT_PINS = "KNOCKOUT PINS";
        const string LIFTER_PIN = "LIFTER PIN";
        const string LIFTER_PIN_SETS = "LIFTER PIN SETS";
        const string MISFEED_SENSOR = "MISFEED SENSOR";
        const string PILOT = "PILOT";
        const string POSITIONING_SWITCHES = "POSITIONING SWITCHES";        
        const string PUSHING_PINS = "PUSHING PINS";
        const string SENSOR_COVER = "SENSOR COVER";
        const string SET_SCREW = "SET SCREW";
        const string SHOULDER_PUNCH = "SHOULDER PUNCH";
        const string SPACER = "SPACER";
        const string SPRING_PLUNGER = "SPRING PLUNGER";
        const string STEPPED_DOWEL_PIN = "STEPPED DOWEL PIN";
        const string STOPPER = "STOPPER";
        const string STRAIGHT_PUNCHES = "STRAIGHT PUNCHES";
        const string STRIPPER_BOLT = "STRIPPER BOLT";
        const string STROKE_END_BLOCK = "STROKE END BLOCK";
        const string WASHER = "WASHER";
        const string WIRE_SPRING = "WIRE SPRING";

        public StandardPart()
        {
            lists.Add(ADJUST_PIN);
            lists.Add(BLANK_PUNCH);
            lists.Add(BLOCK_PUNCH);
            lists.Add(BURRING_PUNCH);
            lists.Add(BUTTON_DIE);
            lists.Add(CAP_SCREW);
            lists.Add(COIL_SPRING);
            lists.Add(DOWEL_PIN);
            lists.Add(EJECTOR_PIN);
            lists.Add(EXTENSION_SPRING);
            lists.Add(FLAT_HEAD_CAP_SCREW);
            lists.Add(GUIDE_BUSH);
            lists.Add(GUIDE_LIFTER);
            lists.Add(GUIDE_LIFTER_SETS);
            lists.Add(GUIDE_PIN);
            lists.Add(GUIDE_POST_SETS);
            lists.Add(HEX_NUT);
            lists.Add(HOOK);
            lists.Add(KEY);
            lists.Add(KNOCKOUT_PINS);
            lists.Add(LIFTER_PIN);
            lists.Add(LIFTER_PIN_SETS);
            lists.Add(MISFEED_SENSOR);
            lists.Add(PILOT);
            lists.Add(POSITIONING_SWITCHES);
            lists.Add(PUSHING_PINS);
            lists.Add(SENSOR_COVER);
            lists.Add(SET_SCREW);
            lists.Add(SHOULDER_PUNCH);
            lists.Add(SPACER);
            lists.Add(SPRING_PLUNGER);
            lists.Add(STEPPED_DOWEL_PIN);
            lists.Add(STOPPER);
            lists.Add(STRAIGHT_PUNCHES);
            lists.Add(STRIPPER_BOLT);
            lists.Add(STROKE_END_BLOCK);
            lists.Add(WASHER);
            lists.Add(WIRE_SPRING);
        }

        public List<string> Get { get => lists; }
    }
}
