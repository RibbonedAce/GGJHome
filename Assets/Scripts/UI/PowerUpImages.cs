using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpImages : MonoBehaviour 
{
    #region Variables
    /// <summary>
    /// <para>The Powerup List to get info from</para>
    /// </summary>
    [SerializeField]
    private PowerupList list;

    /// <summary>
    /// <para>The images to place the powerup icons in</para>
    /// </summary>
    [SerializeField]
    private Image[] images;
	#endregion

	#region Properties
	
	#endregion
	
	#region Events
	/// <summary>
	/// Awake is called before start
	/// <summary>
	private void Awake() 
	{
		
	}
	
	/// <summary>
	/// Use this for initialization
	/// <summary>
	private void Start() 
	{
		
	}
	
	/// <summary>
	/// Update is called once per frame
	/// <summary>
	private void Update() 
	{
		for (int i = 0; i < list.pList.Count; ++i)
        {
            if (list.pList[i] != null && list.pList[i].icon != null)
            {
                images[i].sprite = list.pList[i].icon;
            }
        }
	}
	
	/// <summary>
	/// Use this for physics-related changes
	/// <summary>
	private void FixedUpdate() 
	{
		
	}
	#endregion
	
	#region Methods
	
	#endregion
	
	#region Coroutines
	
	#endregion
}
