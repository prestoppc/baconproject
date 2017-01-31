using UnityEngine;
using System.Collections;

public enum AXIS_XY { X, Y };
public enum BUTTON { A, B, X, Y, BUMPL ,BUMPR, START, SELECT, LSTICK, RSTICK };
public enum STICKS { LEFT, RIGHT, DPAD };
public enum TRIGGER_LR { LEFT, RIGHT };
public enum UPDOWN { UP, DOWN };


public static class scr_InputManager
{
    public static float GetStickorDpad(STICKS joyStick, AXIS_XY axis)
    {
        float ret = 0.0f;

        string inputChecker = "";

        switch (joyStick)
        {
            case STICKS.LEFT:
                inputChecker += "LeftStick_";
                break;
            case STICKS.RIGHT:
                inputChecker += "RightStick_";
                break;
            case STICKS.DPAD:
                inputChecker += "DPad_";
                break;
            default:
                break;
        }

        switch (axis)
        {
            case AXIS_XY.X:
                inputChecker += "X";
                break;
            case AXIS_XY.Y:
                inputChecker += "Y";
                break;
            default:
                return 0.0f;
        }
       
        ret = Input.GetAxis(inputChecker);

        return ret;
    }

    public static float TriggerAxis(TRIGGER_LR trig)
    {
        float ret = 0.0f;

        string inputChecker = "Trigger_";

        switch (trig)
        {
            case TRIGGER_LR.LEFT:
                inputChecker += "L";
                break;
            case TRIGGER_LR.RIGHT:
                inputChecker += "R";
                break;
            default:
                break;
        }

        ret = Input.GetAxis(inputChecker);

        return ret;
    }

    public static bool GetButt(BUTTON butt, UPDOWN pos)
    {
        bool ret = false;

        string inputChecker = "";

        switch (butt)
        {
            case BUTTON.A:
                inputChecker += "Button_A";
                break;
            case BUTTON.B:
                inputChecker += "Button_B";
                break;
            case BUTTON.X:
                inputChecker += "Button_X";
                break;
            case BUTTON.Y:
                inputChecker += "Button_Y";
                break;
            case BUTTON.BUMPL:
                inputChecker += "Bumper_L";
                break;
            case BUTTON.BUMPR:
                inputChecker += "Bumper_R";
                break;
            case BUTTON.START:
                inputChecker += "Start";
                break;
            case BUTTON.SELECT:
                inputChecker += "Back";
                break;
            case BUTTON.LSTICK:
                inputChecker += "LeftStick_Click";
                break;
            case BUTTON.RSTICK:
                inputChecker += "RightStick_Click";
                break;
            default:
                break;
        }

        if (pos == UPDOWN.DOWN)
        {
            ret = Input.GetButtonDown(inputChecker);
        }
        else if (pos == UPDOWN.UP)
        {
            ret = Input.GetButtonUp(inputChecker);
        }

        return ret;
    }
}
//How to use this script in code
//scr_InputManager.GetStickorDpad(which stick/dpad, x or y axis)
//
//scr_InputManager.TriggerAxis(Left or right trigger)
//
//scr_InputManager.GetButt(which button, up or down)