using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.InputSystem;
public class SpinDetection : TankMemberControlParts
{
    float CheckRadius = 0.5f;
    [SerializeField] Vector2[] SpinCheckPoints;
    [SerializeField] int CheckPointCount;
    [SerializeField] int CurrentCheckPoint;
    public int CheckPointFlowCounter;
    // Start is called before the first frame update
    void Start()
    {
        SetUpCheckPoints();
    }

    void SetUpCheckPoints()
    {
        SpinCheckPoints = new Vector2[CheckPointCount];
        for (int i = 0; i < SpinCheckPoints.Length; i++)
        {
            SpinCheckPoints[i] = GetCirclePosition(new Vector2(), 1f, i * (360 / SpinCheckPoints.Length));
        }
    }

    Vector2 GetCirclePosition(Vector2 OrlPos, float magnitude, float angle)
    {
        angle = 90 - angle;
        angle *= Mathf.Deg2Rad;
        float deltaX = Mathf.Cos(angle) * magnitude;
        float deltaZ = Mathf.Sin(angle) * magnitude;
        return OrlPos + new Vector2(deltaX, deltaZ);
    }

    // Update is called once per frame
    void Update()
    {
        if (!TryGetGamePad())
        {
            return;
        }

        if (IsInputNearCheckPoint())
        {
            if (CurrentCheckPoint == 0)
            {

            }
            CheckPointFlowCounter++;
            Invoke("FlowCounterReset", 0.5f);

            ToNextCheckPoint();
        }
    }

    void FlowCounterReset()
    {
        CheckPointFlowCounter--;
    }

    bool IsInputNearCheckPoint()
    {
        return GetNearDistance() <= CheckRadius;
    }
    float GetNearDistance()
    {
        return Vector2.Distance(GetInputPoint(), SpinCheckPoints[CurrentCheckPoint]);
    }
    Vector2 GetInputPoint()
    {
        return TargetGamePad.leftStick.ReadValue();
    }
    void ToNextCheckPoint()
    {
        CurrentCheckPoint = (int)Mathf.Repeat(CurrentCheckPoint + 1, SpinCheckPoints.Length);
    }

}
