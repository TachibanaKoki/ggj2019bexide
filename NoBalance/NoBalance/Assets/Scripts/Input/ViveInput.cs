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
        Vector2 position = SteamVR_Input._default.inActions.Move.GetAxis(SteamVR_Input_Sources.RightHand);
        if (position.x <= Mathf.Abs(position.y))
        {
            right1 = false;
            return false;
        }
        if(SteamVR_Input._default.inActions.Teleport.GetState(SteamVR_Input_Sources.RightHand))
        {
            if(!right1)
            {
                right1 = true;
                return true;
            }
            else
            {
                return false;
            }
        }
        right1 = false;
        return false;
    }
    public static bool GetDownLeft1()
    {
        Vector2 position = SteamVR_Input._default.inActions.Move.GetAxis(SteamVR_Input_Sources.RightHand);
        if (position.x >= -Mathf.Abs(position.y))
        {
            left1 = false;
            return false;

        }
        if ( SteamVR_Input._default.inActions.Teleport.GetState(SteamVR_Input_Sources.RightHand))
        {
            if (!left1)
            {
                left1 = true;
                return true;
            }
            else
            {
                return false;
            }
        }
        left1 = false;
        return false;
    }
    public static bool GetDownUp1()
    {
        Vector2 position = SteamVR_Input._default.inActions.Move.GetAxis(SteamVR_Input_Sources.RightHand);
        if (position.y <= Mathf.Abs(position.x))
        {
            up1 = false;
            return false;
        }
        if (SteamVR_Input._default.inActions.Teleport.GetState(SteamVR_Input_Sources.RightHand))
        {
            if (!up1)
            {
                up1 = true;
                return true;
            }
            else
            {
                return false;
            }
        }
        up1 = false;
        return false;
    }
    public static bool GetDownDown1()
    {
        Vector2 position = SteamVR_Input._default.inActions.Move.GetAxis(SteamVR_Input_Sources.RightHand);
        if (position.y >= -Mathf.Abs(position.x))
        {
            down1 = false;
            return false;
        }
        if (SteamVR_Input._default.inActions.Teleport.GetState(SteamVR_Input_Sources.RightHand))
        {
            if (!down1)
            {
                down1 = true;
                return true;
            }
            else
            {
                return false;
            }
        }
        down1 = false;
        return false;
    }
    public static bool GetDownRight2()
    {
        Vector2 position = SteamVR_Input._default.inActions.Move.GetAxis(SteamVR_Input_Sources.LeftHand);
        if (position.x <= Mathf.Abs(position.y))
        {
            right2 = false;
            return false;
        }
        if (SteamVR_Input._default.inActions.Teleport.GetState(SteamVR_Input_Sources.LeftHand))
        {
            if (!right2)
            {
                right2 = true;
                return true;
            }
            else
            {
                return false;
            }
        }
        right2 = false;
        return false;
    }
    public static bool GetDownLeft2()
    {
        Vector2 position = SteamVR_Input._default.inActions.Move.GetAxis(SteamVR_Input_Sources.LeftHand);
        if (position.x >= -Mathf.Abs(position.y))
        {
            left2 = false;
            return false;
        }
        if (SteamVR_Input._default.inActions.Teleport.GetState(SteamVR_Input_Sources.LeftHand))
        {
            if (!left2)
            {
                left2 = true;
                return true;
            }
            else
            {
                return false;
            }
        }
        left2 = false;
        return false;
    }
    public static bool GetDownUp2()
    {
        Vector2 position = SteamVR_Input._default.inActions.Move.GetAxis(SteamVR_Input_Sources.LeftHand);
        if (position.y <= Mathf.Abs(position.x))
        {
            up2 = false;
            return false;
        }
        if (SteamVR_Input._default.inActions.Teleport.GetState(SteamVR_Input_Sources.LeftHand))
        {
            if (!up2)
            {
                up2 = true;
                return true;
            }
            else
            {
                return false;
            }
        }
        up2 = false;
        return false;
    }
    public static bool GetDownDown2()
    {
        Vector2 position = SteamVR_Input._default.inActions.Move.GetAxis(SteamVR_Input_Sources.LeftHand);
        if (position.y >= -Mathf.Abs(position.x))
        {
            down2 = false;
            return false;
        }
        if (SteamVR_Input._default.inActions.Teleport.GetState(SteamVR_Input_Sources.LeftHand))
        {
            if (!down2)
            {
                down2 = true;
                return true;
            }
            else
            {
                return false;
            }
        }
        down2 = false;
        return false;
    }
}
