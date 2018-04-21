//======= Copyright (c) Valve Corporation, All rights reserved. ===============
//
// Purpose: For controlling in-game objects with tracked devices.
//
//=============================================================================

using UnityEngine;
using Valve.VR;

public class SteamVR_TrackedObject : MonoBehaviour
{

    private const int kMaxDevicesToSearch = 10;
    private const string GreenTrackerSerial = "LHR-1EA69A06";
    private const string BlueTrackerSerial = "LHR-1890594A";

    public enum EPhysioRole
    {
        None = 0,
        Knee = 1,   // green
        Ankle = 2,      // blue
    };

    public EPhysioRole physio_role;

    /* generic/hmd
     * LHR-A3EAE6FE
     * 
     * base station/lh_basestation_vive
     * LHB-37F5B858
     * LHB-988FEE1A
     * 
     * trackers htc}vr_tracker_vive_1_0
     * LHR-1EA69A06
     * LHR-1890594A
     * 
     * vive controllers vr_controller_vive_1_5
     *  LHR-FFDB3D40
     *  LHR-F7CFB44
     */


    public enum EIndex
{
    None = -1,
    Hmd = (int)OpenVR.k_unTrackedDeviceIndex_Hmd,
    Device1,
    Device2,
    Device3,
    Device4,
    Device5,
    Device6,
    Device7,
    Device8,
    Device9,
    Device10,
    Device11,
    Device12,
    Device13,
    Device14,
    Device15
}

public EIndex index;

[Tooltip("If not set, relative to parent")]
public Transform origin;

    private EIndex getIndexForSerialNumber(string serial_to_find)
    {
        for (uint i = 0; i < kMaxDevicesToSearch; i++)
        {
            string serial_number = SteamVR.instance.GetStringProperty(ETrackedDeviceProperty.Prop_SerialNumber_String, i);
            if (serial_number == serial_to_find)
            {
                return (EIndex)i;
            }
        }
        return 0; 
    }

    // I want deterministic behaviour for the controllers - eg green maps to the knee.
    public void Awake()
    {
        dumpDeviceProperties();
        if (physio_role == EPhysioRole.Knee)
        {
            index = getIndexForSerialNumber(GreenTrackerSerial);
            // assign the index for the Knee
        }
        else if (physio_role == EPhysioRole.Ankle)
        {
            index = getIndexForSerialNumber(BlueTrackerSerial);
        }
    }

    public bool isValid { get; private set; }

private void dumpDeviceProperties()
{
    for (uint i = 0; i < kMaxDevicesToSearch; i++)
    {
        string serial_number = SteamVR.instance.GetStringProperty(ETrackedDeviceProperty.Prop_SerialNumber_String, i);
        string render_model_name = SteamVR.instance.GetStringProperty(ETrackedDeviceProperty.Prop_RenderModelName_String, i);
        Debug.Log(i + " SerialNumber: " + serial_number + " RenderModel: " + render_model_name);
    }
}

private void OnNewPoses(TrackedDevicePose_t[] poses)
{
    if (index == EIndex.None)
        return;

    var i = (int)index;

    //dumpDeviceProperties();
    isValid = false;
    if (poses.Length <= i)
        return;

    if (!poses[i].bDeviceIsConnected)
        return;

    if (!poses[i].bPoseIsValid)
        return;

    isValid = true;

    var pose = new SteamVR_Utils.RigidTransform(poses[i].mDeviceToAbsoluteTracking);

    if (origin != null)
    {
        transform.position = origin.transform.TransformPoint(pose.pos);
        transform.rotation = origin.rotation * pose.rot;
    }
    else
    {
        transform.localPosition = pose.pos;
        transform.localRotation = pose.rot;
    }
}

SteamVR_Events.Action newPosesAction;

SteamVR_TrackedObject()
{
    newPosesAction = SteamVR_Events.NewPosesAction(OnNewPoses);
    }

    void OnEnable()
{
    var render = SteamVR_Render.instance;
    if (render == null)
    {
        enabled = false;
        return;
    }

    newPosesAction.enabled = true;
}

void OnDisable()
{
    newPosesAction.enabled = false;
    isValid = false;
}

public void SetDeviceIndex(int index)
{
    if (System.Enum.IsDefined(typeof(EIndex), index))
        this.index = (EIndex)index;
}
}

