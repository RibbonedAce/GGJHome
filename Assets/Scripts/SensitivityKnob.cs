using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensitivityKnob : MonoBehaviour 
{
    #region Variables
    /// <summary>
    /// <para>The offset of rotation</para>
    /// </summary>
    [SerializeField]
    private float offset;

    /// <summary>
    /// <para>The rotation of the knob</para>
    /// </summary>
    private float zRotation;
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
        // Set given level
        if (SensitivityController.Instance != null)
        {
            Debug.Log(SensitivityController.Instance.Sensitivity);
            zRotation = SensitivityController.Instance.Sensitivity * 180 + offset;
            transform.localRotation = Quaternion.Euler(0, 0, zRotation);
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

    /// <summary>
    /// This is called when the user has clicked on a GUIElement or Collider and is still holding down the mouse
    /// </summary>
    private void OnMouseDrag()
    {
        zRotation = Mathf.Clamp(zRotation + Input.GetAxis("Mouse X") + Input.GetAxis("Mouse Y"), offset, offset + 180);
        Debug.Log(zRotation);
        transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y, zRotation);
        if (SensitivityController.Instance != null)
        {
            SensitivityController.Instance.SetSensitivity((zRotation - offset) / 180);
        }
    }
    #endregion

    #region Methods

    #endregion

    #region Coroutines

    #endregion
}
