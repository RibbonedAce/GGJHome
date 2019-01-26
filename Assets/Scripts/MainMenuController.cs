using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour 
{
    #region Variables
    /// <summary>
    /// <para>The image used to fade the screen</para>
    /// </summary>
    [SerializeField]
    private Image maskImage;
	#endregion

	#region Properties
	
	#endregion
	
	#region Events
	/// <summary>
	/// Awake is called before start
	/// <summary>
	private void Awake() 
	{
		if (maskImage != null)
        {
            maskImage.color = Color.clear;
        }
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
        StartCoroutine(TransitionScene(scene));
    }
    #endregion

    #region Coroutines
    /// <summary>
    /// Do things then load the given scene
    /// </summary>
    /// <param name="scene">The scene to load</param>
    /// <returns>The time to do things</returns>
    private IEnumerator TransitionScene(string scene)
    {
        // Fade to black if mask given
        if (maskImage != null)
        {
            for (float t = 0; t < 1; t += Time.deltaTime)
            {
                maskImage.color = new Color(0, 0, 0, t);
                yield return null;
            }
        }

        SceneManager.LoadScene(scene);
    }
	#endregion
}
