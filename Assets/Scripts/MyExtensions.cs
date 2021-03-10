using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MyExtensions
{
    // returns a random color
    public static Color Random(this Color color)
    {
        return new Color( UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
    }
}
