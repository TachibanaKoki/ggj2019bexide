using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;
using Valve.VR;

public class ViveInput : MonoBehaviour
{
    public static bool GetDownRight1()
    {
        Vector2 position = SteamVR_Input._default.inActions.Move.GetAxis(SteamVR_Input_Sources.RightHand);
        if (position.x <= Mathf.Abs(position.y)) return false;
        if(SteamVR_Input._default.inActions.Teleport.GetState(SteamVR_Input_Sources.RightHand))
        {
            return true;
        }
        return false;
    }
    public static bool GetDownLeft1()
    {
        Vector2 position = SteamVR_Input._default.inActions.Move.GetAxis(SteamVR_Input_Sources.RightHand);
        if (position.x >= -Mathf.Abs(position.y)) return false;
        if (SteamVR_Input._default.inActions.Teleport.GetState(SteamVR_Input_Sources.RightHand))
        {
            return true;
        }
        return false;
    }
    public static bool GetDownUp1()
    {
        Vector2 position = SteamVR_Input._default.inActions.Move.GetAxis(SteamVR_Input_Sources.RightHand);
        if (position.y <= Mathf.Abs(position.x)) return false;
        if (SteamVR_Input._default.inActions.Teleport.GetState(SteamVR_Input_Sources.RightHand))
        {
            return true;
        }
        return false;
    }
    public static bool GetDownDown1()
    {
        Vector2 position = SteamVR_Input._default.inActions.Move.GetAxis(SteamVR_Input_Sources.RightHand);
        if (position.y >= -Mathf.Abs(position.x)) return false;
        if (SteamVR_Input._default.inActions.Teleport.GetState(SteamVR_Input_Sources.RightHand))
        {
            return true;
        }
        return false;
    }
    public static bool GetDownRight2()
    {
        Vector2 position = SteamVR_Input._default.inActions.Move.GetAxis(SteamVR_Input_Sources.LeftHand);
        if (position.x <= Mathf.Abs(position.y)) return false;
        if (SteamVR_Input._default.inActions.Teleport.GetState(SteamVR_Input_Sources.LeftHand))
        {
            return true;
        }
        return false;
    }
    public static bool GetDownLeft2()
    {
        Vector2 position = SteamVR_Input._default.inActions.Move.GetAxis(SteamVR_Input_Sources.LeftHand);
        if (position.x >= -Mathf.Abs(position.y)) return false;
        if (SteamVR_Input._default.inActions.Teleport.GetState(SteamVR_Input_Sources.LeftHand))
        {
            return true;
        }
        return false;
    }
    public static bool GetDownUp2()
    {
        Vector2 position = SteamVR_Input._default.inActions.Move.GetAxis(SteamVR_Input_Sources.LeftHand);
        if (position.y <= Mathf.Abs(position.x)) return false;
        if (SteamVR_Input._default.inActions.Teleport.GetState(SteamVR_Input_Sources.LeftHand))
        {
            return true;
        }
        return false;
    }
    public static bool GetDownDown2()
    {
        Vector2 position = SteamVR_Input._default.inActions.Move.GetAxis(SteamVR_Input_Sources.LeftHand);
        if (position.y >= -Mathf.Abs(position.x)) return false;
        if (SteamVR_Input._default.inActions.Teleport.GetState(SteamVR_Input_Sources.LeftHand))
        {
            return true;
        }
        return false;
    }
}
