using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class DefaultColliderData 
{
    
        [field: Tooltip("The height is known through the Model Mesh Renderer \"bounds.size\" variable.")]
        [field: SerializeField] public float Height { get; private set; } = 3f;
        [field: SerializeField] public float CenterY { get; private set; } = -0.5f;
        [field: SerializeField] public float Width { get; private set; } = 1f;
}

