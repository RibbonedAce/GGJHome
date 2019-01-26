using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu2D : MonoBehaviour 
{
    #region Variables
    /// <summary>
    /// <para>The submenus</para>
    /// </summary>
    [SerializeField]
    private GameObject[] menus;
	#endregion

	#region Properties
	
	#endregion
	
	#region Events
	/// <summary>
	/// Awake is called before start
	/// <summary>
	private void Awake() 
	{
        SwitchMenu(0);
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
		
	}
	
	/// <summary>
	/// Use this for physics-related changes
	/// <summary>
	private void FixedUpdate() 
	{
		
	}
	#endregion
	
	#region Methods
    /// <summary>
    /// Switch to a different submenu
    /// </summary>
    /// <param name="menu">The index of the submenu to switch to</param>
	public void SwitchMenu(int menu)
    {
        for (int i = 0; i < menus.Length; ++i)
        {
            menus[i].SetActive(menu == i);
        }
    }
	#endregion
	
	#region Coroutines
	
	#endregion
}
