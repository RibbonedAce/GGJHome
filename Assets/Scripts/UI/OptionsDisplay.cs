using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshPro))]
public class OptionsDisplay : MonoBehaviour 
{
    #region Variables
    /// <summary>
    /// <para>The cached volume</para>
    /// </summary>
    private float storedVolume;

    /// <summary>
    /// <para>The cached sensitivity</para>
    /// </summary>
    private float storedSensitivity;

    /// <summary>
    /// <para>The Text Mesh Pro component attached</para>
    /// </summary>
    private TextMeshPro _textMeshPro;

    /// <summary>
    /// <para>The coroutine for displaying the info</para>
    /// </summary>
    private Coroutine displayRoutine;
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
        _textMeshPro = GetComponent<TextMeshPro>();
        _textMeshPro.text = "";

        if (SoundController.Instance != null)
        {
            storedVolume = SoundController.Instance.SoundLevel;
        }

        if (SensitivityController.Instance != null)
        {
            storedSensitivity = SensitivityController.Instance.Sensitivity;
        }
	}
	
	/// <summary>
	/// Update is called once per frame
	/// <summary>
	private void Update() 
	{
		if (SoundController.Instance != null && storedVolume != SoundController.Instance.SoundLevel)
        {
            storedVolume = SoundController.Instance.SoundLevel;
            if (displayRoutine != null)
            {
                StopCoroutine(displayRoutine);
            }
            displayRoutine = StartCoroutine(DisplayText(string.Format("Volume: {0:000.}%", storedVolume * 100)));
        }

        if (SensitivityController.Instance != null && storedSensitivity != SensitivityController.Instance.Sensitivity)
        {
            storedSensitivity = SensitivityController.Instance.Sensitivity;
            if (displayRoutine != null)
            {
                StopCoroutine(displayRoutine);
            }
            displayRoutine = StartCoroutine(DisplayText(string.Format("Sensitivity: {0:000.}%", storedSensitivity * 100)));
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
    /// <summary>
    /// Show text on a menu for a time
    /// </summary>
    /// <param name="text">The text to display</param>
    /// <returns>How long the text is displayed in seconds</returns>
	private IEnumerator DisplayText(string text)
    {
        _textMeshPro.text = text;
        yield return new WaitForSeconds(3);
        _textMeshPro.text = "";
    }
	#endregion
}
