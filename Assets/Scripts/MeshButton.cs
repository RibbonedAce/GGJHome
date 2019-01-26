using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MeshButton : MonoBehaviour 
{
    #region Variables
    /// <summary>
    /// <para>The method that is called when the button is clicked</para>
    /// </summary>
    [SerializeField]
    private UnityEvent OnClick;
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
		
	}
	
	/// <summary>
	/// Use this for physics-related changes
	/// <summary>
	private void FixedUpdate() 
	{
		
	}

    /// <summary>
    /// This is called when the user has pressed the mouse button while over the GUIElement or Collider
    /// </summary>
    private void OnMouseDown()
    {
        OnClick.Invoke();
    }
    #endregion

    #region Methods

    #endregion

    #region Coroutines

    #endregion
}
