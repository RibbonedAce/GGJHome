using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour 
{
    #region Variables
    /// <summary>
    /// <para>The image to use for screen mask</para>
    /// </summary>
    [SerializeField]
    private Image maskImage;

    /// <summary>
    /// <para>The menu to open on pause</para>
    /// </summary>
    [SerializeField]
    private GameObject pauseMenu;

    /// <summary>
    /// <para>Whether the game is paused</para>
    /// </summary>
    private bool paused;
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
        paused = false;
        pauseMenu.SetActive(false);
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
		if (Input.GetButtonDown("Pause"))
        {
            TogglePause();
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
    /// <summary>
    /// Quit to the main menu
    /// </summary>
	public void QuitToMenu()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        StartCoroutine(PerformQuit());
    }

    /// <summary>
    /// Pause/unpause the game
    /// </summary>
    private void TogglePause()
    {
        paused = !paused;
        Time.timeScale = paused ? 0 : 1;
        pauseMenu.SetActive(paused);
    }
	#endregion
	
	#region Coroutines
    /// <summary>
    /// Do things then quit
    /// </summary>
    /// <returns>The time it takes to do things</returns>
	private IEnumerator PerformQuit()
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
        
        SceneManager.LoadScene("MainMenu");
    }
	#endregion
}
