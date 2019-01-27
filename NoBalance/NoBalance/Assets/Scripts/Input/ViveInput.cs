using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;
using Valve.VR;

public class ViveInput : MonoBehaviour
{
    static bool right1 = false;
    static bool right2 = false;
    static bool up1 = false;
    static bool up2 = false;
    static bool down1 = false;
    static bool down2 = false;
    static bool left1 = false;
    static bool left2 = false;

    public static bool GetDownRight1()
    {
        try
        {
            Vector2 p = SteamVR_Input._default.inActions.Move.GetAxis(SteamVR_Input_Sources.RightHand);
        }
        catch
        {
            return false;
        }
        Vector2 position = SteamVR_Input._default.inActions.Move.GetAxis(SteamVR_Input_Sources.RightHand);

        if(SteamVR_Input._default.inActions.Teleport.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            if (position.x <= Mathf.Abs(position.y))
            {
                return false;
            }
            return true;
        }
        return false;
    }
    public static bool GetDownLeft1()
    {
        try
        {
            Vector2 p = SteamVR_Input._default.inActions.Move.GetAxis(SteamVR_Input_Sources.RightHand);
        }
        catch
        {
            return false;
        }
        Vector2 position = SteamVR_Input._default.inActions.Move.GetAxis(SteamVR_Input_Sources.RightHand);

        if ( SteamVR_Input._default.inActions.Teleport.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            if (position.x >= -Mathf.Abs(position.y))
            {
                return false;

            }
            return true;
        }
        return false;
    }
    public static bool GetDownUp1()
    {
        try
        {
            Vector2 p = SteamVR_Input._default.inActions.Move.GetAxis(SteamVR_Input_Sources.RightHand);
        }
        catch
        {
            return false;
        }
        Vector2 position = SteamVR_Input._default.inActions.Move.GetAxis(SteamVR_Input_Sources.RightHand);

        if (SteamVR_Input._default.inActions.Teleport.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            if (position.y <= Mathf.Abs(position.x))
            {
                return false;
            }
            return true;
        }
        return false;
    }
    public static bool GetDownDown1()
    {
        try
        {
            Vector2 p = SteamVR_Input._default.inActions.Move.GetAxis(SteamVR_Input_Sources.RightHand);
        }
        catch
        {
            return false;
        }
        Vector2 position = SteamVR_Input._default.inActions.Move.GetAxis(SteamVR_Input_Sources.RightHand);

        if (SteamVR_Input._default.inActions.Teleport.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            if (position.y >= -Mathf.Abs(position.x))
            {
                return false;
            }
                return true;
        }
        return false;
    }
    public static bool GetDownRight2()
    {
        try
        {
            Vector2 p = SteamVR_Input._default.inActions.Move.GetAxis(SteamVR_Input_Sources.RightHand);
        }
        catch
        {
            return false;
        }
        Vector2 position = SteamVR_Input._default.inActions.Move.GetAxis(SteamVR_Input_Sources.LeftHand);

        if (SteamVR_Input._default.inActions.Teleport.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            if (position.x <= Mathf.Abs(position.y))
            {
                return false;
            }
                return true;
        }
        return false;
    }
    public static bool GetDownLeft2()
    {
        try
        {
            Vector2 p = SteamVR_Input._default.inActions.Move.GetAxis(SteamVR_Input_Sources.RightHand);
        }
        catch
        {
            return false;
        }
        Vector2 position = SteamVR_Input._default.inActions.Move.GetAxis(SteamVR_Input_Sources.LeftHand);

        if (SteamVR_Input._default.inActions.Teleport.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            if (position.x >= -Mathf.Abs(position.y))
            {
                return false;
            }
                return true;
        }
        return false;
    }
    public static bool GetDownUp2()
    {
        try
        {
            Vector2 p = SteamVR_Input._default.inActions.Move.GetAxis(SteamVR_Input_Sources.RightHand);
        }
        catch
        {
            return false;
        }
        Vector2 position = SteamVR_Input._default.inActions.Move.GetAxis(SteamVR_Input_Sources.LeftHand);

        if (SteamVR_Input._default.inActions.Teleport.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            if (position.y <= Mathf.Abs(position.x))
            {
                return false;
            }
                return true;
        }
        return false;
    }
    public static bool GetDownDown2()
    {
        try
        {
            Vector2 p = SteamVR_Input._default.inActions.Move.GetAxis(SteamVR_Input_Sources.RightHand);
        }
        catch
        {
            return false;
        }
        Vector2 position = SteamVR_Input._default.inActions.Move.GetAxis(SteamVR_Input_Sources.LeftHand);

        if (SteamVR_Input._default.inActions.Teleport.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            if (position.y >= -Mathf.Abs(position.x))
            {
                return false;
            }
                return true;
        }
        return false;
    }
}
