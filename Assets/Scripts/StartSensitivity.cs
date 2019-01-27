using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

[RequireComponent(typeof(FirstPersonController))]
public class StartSensitivity : MonoBehaviour 
{
    #region Variables
    /// <summary>
    /// <para>The controller to adjust sensitivity</para>
    /// </summary>
    private FirstPersonController controller;
	#endregion

	#region Properties
	
	#endregion
	
	#region Events
	/// <summary>
	/// Awake is called before start
	/// <summary>
	private void Awake() 
	{
        controller = GetComponent<FirstPersonController>();
	}
	
	/// <summary>
	/// Use this for initialization
	/// <summary>
	private void Start() 
	{
        if (SensitivityController.Instance != null)
        {
            controller.m_MouseLook.XSensitivity = 4.5f * Mathf.Pow(SensitivityController.Instance.Sensitivity, 2) + 0.5f;
            controller.m_MouseLook.YSensitivity = 4.5f * Mathf.Pow(SensitivityController.Instance.Sensitivity, 2) + 0.5f;
        }
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
	
	#endregion
	
	#region Coroutines
	
	#endregion
}
