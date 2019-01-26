using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour 
{
    #region Variables

	#endregion

	#region Properties
    /// <summary>
    /// <para>The instance to reference</para>
    /// </summary>
	public static SoundController Instance { get; private set; }

    /// <summary>
    /// <para>The sound level</para>
    /// </summary>
    public float SoundLevel { get; private set; }
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

        SetSound(PlayerPrefs.HasKey("Sound") ? PlayerPrefs.GetFloat("Sound") : 0.5f);
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
    /// <para>Set the sound level</para>
    /// </summary>
    /// <param name="level">The level to set the sound at</param>
	public void SetSound(float level)
    {
        PlayerPrefs.SetFloat("Sound", level);
        SoundLevel = level;

        // Set each audio level
        foreach (AudioSource a in FindObjectsOfType<AudioSource>())
        {
            a.volume = level;
        }
    }
	#endregion
	
	#region Coroutines
	
	#endregion
}
