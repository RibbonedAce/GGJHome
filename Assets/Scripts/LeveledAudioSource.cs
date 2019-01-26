using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeveledAudioSource : MonoBehaviour 
{
    #region Variables
    /// <summary>
    /// <para>The Audio Source component attached</para>
    /// </summary>
    private AudioSource _audioSource;
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
        if (SoundController.Instance != null)
        {
            _audioSource.volume = SoundController.Instance.SoundLevel;
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
