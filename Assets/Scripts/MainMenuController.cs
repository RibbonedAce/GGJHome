using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour 
{
	#region Variables
	
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
    #endregion

    #region Methods
    /// <summary>
    /// Load the given scene
    /// </summary>
    /// <param name="scene">The scene to load</param>
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
	#endregion
	
	#region Coroutines
	
	#endregion
}
