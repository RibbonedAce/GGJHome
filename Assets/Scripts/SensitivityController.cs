using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class SensitivityController : MonoBehaviour 
{
    #region Variables
    /// <summary>
    /// <para>The controller that uses sensitivity</para>
    /// </summary>
    private FirstPersonController _controller;
    #endregion

    #region Properties
    /// <summary>
    /// <para>The instance to reference</para>
    /// </summary>
    public static SensitivityController Instance { get; private set; }

    /// <summary>
    /// <para>The sensitivity of the mouse</para>
    /// </summary>
    public float Sensitivity { get; private set; }
    #endregion

    #region Events
    /// <summary>
    /// Awake is called before start
    /// <summary>
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        _controller = FindObjectOfType<FirstPersonController>();
        SetSensitivity(PlayerPrefs.HasKey("Sound") ? PlayerPrefs.GetFloat("Sound") : 0.5f);
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
    /// Set the sensitivity level
    /// </summary>
    /// <param name="level">The relative level of the sensitivity</param>
    public void SetSensitivity(float level)
    {
        _controller.m_MouseLook.XSensitivity = 4.5f * Mathf.Pow(level, 2) + 0.5f;
        _controller.m_MouseLook.YSensitivity = 4.5f * Mathf.Pow(level, 2) + 0.5f;
    }
	#endregion
	
	#region Coroutines
	
	#endregion
}
