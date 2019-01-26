using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils 
{
	#region Methods
    /// <summary>
    /// Convert a number to its respective sine curve y position 
    /// </summary>
    /// <param name="f">x position</param>
    /// <returns>(1 - cos(f*pi)) / 2</returns>
	public static float SineCurve(float f)
    {
        return (1 - Mathf.Cos(f * Mathf.PI)) / 2;
    }
	#endregion
	
	#region Coroutines
	
	#endregion
}
