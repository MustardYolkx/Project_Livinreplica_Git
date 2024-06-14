using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyDetectedData 
{
    [field:SerializeField] public float LedgeDetectDistance { get;private set; }
    [field:SerializeField] public float GroundDetectDistance { get; private set; }

    [field: SerializeField] public float PlayerDetectDistance { get; private set; }

    [field: SerializeField] public float CheckPlayerRadius { get; private set; }
}
