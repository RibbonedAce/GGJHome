using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : Slider 
{
	#region Variables
	
	#endregion

	#region Properties
	
	#endregion
	
	#region Events
	/// <summary>
	/// Awake is called before start
	/// <summary>
	protected override void Awake() 
	{
        base.Awake();
	}

    /// <summary>
    /// Use this for initialization
    /// <summary>
    protected override void Start() 
	{
        base.Start();

        // Set given level
        if (SoundController.Instance != null)
        {
            Debug.Log(SoundController.Instance.SoundLevel);
            value = SoundController.Instance.SoundLevel;
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
