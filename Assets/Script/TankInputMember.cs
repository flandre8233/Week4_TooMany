using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.InputSystem;
using UnityEngine;

public enum TankMember
{
    Loader,
    Driver,
    Gunner,
    Commander
}

public class TankInputMember : SingletonMonoBehavior<TankInputMember>
{
    Dictionary<TankMember, Gamepad> OneMemberDict;
    Dictionary<TankMember, Gamepad> TwoMemberDict;
    void ReSetID()
    {
        OneMemberDict = new Dictionary<TankMember, Gamepad>();
        OneMemberDict.Add(TankMember.Driver, Gamepad.all.Count > 0 ? Gamepad.all[0] : null);
        OneMemberDict.Add(TankMember.Gunner, Gamepad.all.Count > 1 ? Gamepad.all[1] : null);
        OneMemberDict.Add(TankMember.Loader, Gamepad.all.Count > 2 ? Gamepad.all[2] : null);
        OneMemberDict.Add(TankMember.Commander, Gamepad.all.Count > 3 ? Gamepad.all[3] : null);
        /*
        TwoMemberDict = new Dictionary<TankMember, Gamepad>();
        TwoMemberDict.Add(TankMember.Driver, Gamepad.all.Count > 3 ? Gamepad.all[3] : null);
        TwoMemberDict.Add(TankMember.Gunner, Gamepad.all.Count > 4 ? Gamepad.all[4] : null);
        TwoMemberDict.Add(TankMember.Loader, Gamepad.all.Count > 5 ? Gamepad.all[5] : null);
        */

        /*
                OneMemberDict = new Dictionary<TankMember, Gamepad>();
                OneMemberDict.Add(TankMember.Driver, Gamepad.all.Count > 0 ? Gamepad.all[0] : null);
                OneMemberDict.Add(TankMember.Gunner, null);
                OneMemberDict.Add(TankMember.Loader, Gamepad.all.Count > 2 ? Gamepad.all[2] : null);
                TwoMemberDict = new Dictionary<TankMember, Gamepad>();
                TwoMemberDict.Add(TankMember.Driver, Gamepad.all.Count > 1 ? Gamepad.all[1] : null);
                TwoMemberDict.Add(TankMember.Gunner, null);
                TwoMemberDict.Add(TankMember.Loader, null);
                */
    }

    public void OnPlayerJoined()
    {
        ReSetID();
    }

    public void OnPlayerLeft()
    {
        ReSetID();
    }

    public Gamepad GetGamepad(TankMember Member, bool isOne)
    {
        Dictionary<TankMember, Gamepad> MemberDict = isOne ? OneMemberDict : TwoMemberDict;
        if (MemberDict == null)
        {
            return null;
        }
        return MemberDict[Member];
    }
}
