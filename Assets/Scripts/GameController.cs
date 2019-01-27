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
    /// <para>The player used to determine loss state</para>
    /// </summary>
    [SerializeField]
    private GameObject player;

    /// <summary>
    /// <para>The objects to show on game over</para>
    /// </summary>
    [SerializeField]
    private GameObject gameOverObject;

    /// <summary>
    /// <para>The canvas that has all of the UI elements</para>
    /// </summary>
    [SerializeField]
    private Canvas canvas;

    /// <summary>
    /// <para>Whether the goal to move on has been met</para>
    /// </summary>
    private bool movingOn;

    /// <summary>
    /// <para>The coroutine keeping track of invisibility</para>
    /// </summary>
    private Coroutine invisibleRoutine;
	#endregion

	#region Properties
    /// <summary>
    /// <para>The instance to reference</para>
    /// </summary>
	public static GameController Instance { get; private set; }

    /// <summary>
    /// <para>Whether the game is paused</para>
    /// </summary>
    public bool Paused { get; private set; }

    /// <summary>
    /// <para>Whether the player is "invisible"</para>
    /// </summary>
    public bool Invisible { get; set; }
    #endregion

    #region Events
    /// <summary>
    /// Awake is called before start
    /// <summary>
    private void Awake() 
	{
        // Set instancing
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        // Initialization
		if (maskImage != null)
        {
            maskImage.color = Color.clear;
        }
        Paused = true;
        TogglePause();
        gameOverObject.SetActive(false);
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

        if (WaveSpawner.instance != null && WaveSpawner.instance.finished && !movingOn)
        {
            movingOn = true;
            RemoveUI();
            Invoke("GoToNextLevel", 5);
        }

        if (player == null && !movingOn)
        {
            movingOn = true;
            RemoveUI();
            gameOverObject.SetActive(true);
            Invoke("QuitToMenu", 5);
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
    /// Turn invisible for a set period of time
    /// </summary>
    /// <param name="time">The time to turn invisible</param>
    public void TurnInvisible(float time)
    {
        if (invisibleRoutine != null)
        {
            StopCoroutine(invisibleRoutine);
        }
        invisibleRoutine = StartCoroutine(GoInvisible(time));
    }

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
    /// Go to the next level
    /// </summary>
    public void GoToNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// Remove all UI from the screen
    /// </summary>
    private void RemoveUI()
    {
        foreach (Transform t in canvas.transform)
        {
            t.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Pause/unpause the game
    /// </summary>
    private void TogglePause()
    {
        Paused = !Paused;
        Time.timeScale = Paused ? 0 : 1;
        pauseMenu.SetActive(Paused);
        Cursor.lockState = Paused ? CursorLockMode.None : CursorLockMode.Locked;
    }
	#endregion
	
	#region Coroutines
    /// <summary>
    /// Go invisible for a set period of time
    /// </summary>
    /// <param name="time">The time to turn invisible</param>
    /// <returns></returns>
    private IEnumerator GoInvisible(float time)
    {
        Invisible = true;
        yield return new WaitForSeconds(time);
        Invisible = false;
    }

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
