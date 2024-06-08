using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dialogue_Method 
{
    private static Dialogue_Method instance;

    public static Dialogue_Method GetInstance()
    {
        if (instance == null)
        {
            instance = new Dialogue_Method();

        }
        return instance;
    }

    
}
