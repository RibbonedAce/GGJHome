using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoUI : MonoBehaviour 
{
    #region Variables
    /// <summary>
    /// <para>The gun script to get ammo info from</para>
    /// </summary>
    [SerializeField]
    private GunScript gun;
    
    /// <summary>
    /// <para>When to change the image to show low ammo</para>
    /// </summary>
    [SerializeField]
    private float lowAmmoThreshold;

    /// <summary>
    /// <para>The Text component on a child</para>
    /// </summary>
    private Text _text;
    
    /// <summary>
    /// <para>The Image component on a child</para>
    /// </summary>
    private Image _image;
	#endregion

	#region Properties
	
	#endregion
	
	#region Events
	/// <summary>
	/// Awake is called before start
	/// <summary>
	private void Awake() 
	{
        _text = GetComponentInChildren<Text>();
        _image = GetComponentInChildren<Image>();
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
        // Ammo text
        _text.text = string.Format("Clip: {0}", gun.m_clipSize);

        // Gun image
        _image.color = (float)gun.m_clipSize / gun.m_maxClipSize <= lowAmmoThreshold ? Color.red : Color.white;
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
