using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerAirborneData 
{
    [field: SerializeField] public Vector2 JumpForceStay { get; private set; }
    [field: SerializeField] public float JumpStaySpeedModifier { get; private set; } = 0.2f;
    [field: SerializeField] public Vector2 JumpForceNormal { get; private set; }
    [field: SerializeField] public float JumpNormalSpeedModifier { get; private set; } = 0.2f;
    [field: SerializeField] public Vector2 JumpForceRun { get; private set; }

    [field: SerializeField] public float JumpRunSpeedModifier { get; private set; } = 0.8f;

    [field: SerializeField] public float JumpForceAdd { get; private set; } = 0.2f;
}
