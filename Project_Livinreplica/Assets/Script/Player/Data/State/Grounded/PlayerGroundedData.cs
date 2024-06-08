using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerGroundedData
{
    [field: SerializeField] public float BaseSpeed { get; private set; } = 5f;

    [field: SerializeField] public PlayerWalkData WalkData { get; private set; }

    [field: SerializeField] public PlayerRunData RunData { get; private set; }

    [field: SerializeField][field: Range(0f, 5f)] public float GroundToFallRayDistance { get; private set; } = 1f;

    [field: SerializeField] public PlayerSprintData SprintData { get; private set; }
}
