using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveText : MonoBehaviour 
{
    #region Variables
    /// <summary>
    /// <para>The wave spawner to get info from</para>
    /// </summary>
    [SerializeField]
    private WaveSpawner waveSpawner;

    /// <summary>
    /// <para>How long the text says a new wave is approaching</para>
    /// </summary>
    [SerializeField]
    private float displayTime;

    /// <summary>
    /// <para>The cached wave value</para>
    /// </summary>
    private int currentWave;

    /// <summary>
    /// <para>The Text component attached</para>
    /// </summary>
    private Text _text;

    /// <summary>
    /// <para>Whether a new wave has spawned</para>
    /// </summary>
    private bool newWave;
	#endregion

	#region Properties
	
	#endregion
	
	#region Events
	/// <summary>
	/// Awake is called before start
	/// <summary>
	private void Awake() 
	{
        _text = GetComponent<Text>();
        newWave = false;
        currentWave = -1;
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
        // Display finish message
        if (waveSpawner.finished)
        {
            _text.text = "Level complete!";
        }

        // Announce new wave
        else if (newWave)
        {
            _text.text = string.Format("Wave {0}", currentWave);
        }

        // Show remaining enemies
        else
        {
            _text.text = string.Format("{0} enemies remaining", waveSpawner.enemiesRemaining);
        }

        // Display new wave if one spawns
        if (currentWave != waveSpawner.currentWave)
        {
            currentWave = waveSpawner.currentWave;
            StartCoroutine(StartNewWave());
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
    /// Start a new wave
    /// </summary>
    /// <returns>The time the text says the wave is spawning</returns>
	private IEnumerator StartNewWave()
    {
        newWave = true;
        yield return new WaitForSeconds(displayTime);
        newWave = false;
    }
	#endregion
}
