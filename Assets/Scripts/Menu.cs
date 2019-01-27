using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour 
{
    #region Variables
    /// <summary>
    /// <para>The locations of the camera in different menus</para>
    /// </summary>
    [SerializeField]
    private Vector3[] cameraPositions;

    /// <summary>
    /// <para>The eulers for the rotation of the camera in different menus</para>
    /// </summary>
    [SerializeField]
    private Vector3[] cameraAngles;

    /// <summary>
    /// <para>The objects to click on for transitions</para>
    /// </summary>
    [SerializeField]
    private Transform[] clickObjects;

    /// <summary>
    /// <para>The speed at which the camera moves when transitioning between menus</para>
    /// </summary>
    [SerializeField]
    private float cameraSpeed;

    /// <summary>
    /// <para>The current menu open</para>
    /// </summary>
    private int menuIndex;

    /// <summary>
    /// <para>Whether the menu is currently transitioning</para>
    /// </summary>
    private bool transitioning;

    /// <summary>
    /// <para>The transition Coroutine going on</para>
    /// </summary>
    private Coroutine transitionRoutine;
	#endregion

	#region Properties
	
	#endregion
	
	#region Events
	/// <summary>
	/// Awake is called before start
	/// <summary>
	private void Awake() 
	{
        // Set camera and object click to first menu
        menuIndex = 1;
        Camera.main.transform.position = cameraPositions[menuIndex];
        Camera.main.transform.rotation = Quaternion.Euler(cameraAngles[menuIndex]);

        // Set first set of clickable objects
        for (int i = 0; i < clickObjects.Length; ++i)
        {
            foreach (Transform t in clickObjects[i])
            {
                Collider c = t.GetComponent<Collider>();
                if (c != null)
                {
                    c.enabled = i == menuIndex;
                }
            }
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
    /// Go to another menu
    /// </summary>
    /// <param name="menu">The menu to go to</param>
	public void ChangeMenu(int menu)
    {
        // Change only if not in same menu and if not currently transitioning
        if (menu != menuIndex && !transitioning)
        {
            menuIndex = menu;
            transitionRoutine = StartCoroutine(TransitionMenu());
        }
    }
	#endregion
	
	#region Coroutines
    /// <summary>
    /// Transition between submenus
    /// </summary>
    /// <returns>The time it takes to transition twice</returns>
    private IEnumerator TransitionMenu()
    {
        yield return StartCoroutine(MoveCamera(cameraPositions[0], Quaternion.Euler(cameraAngles[0])));
        yield return StartCoroutine(MoveCamera(cameraPositions[menuIndex], Quaternion.Euler(cameraAngles[menuIndex])));
    }

    /// <summary>
    /// Move the camera to a new position over time
    /// </summary>
    /// <param name="newPos">The new position to move the camera to</param>
    /// <param name="newRot">The new rotation to move the camera to</param>
    /// <returns>The time it takes to transition</returns>
	private IEnumerator MoveCamera(Vector3 newPos, Quaternion newRot)
    {
        // Set up
        transitioning = true;
        Transform camTransform = Camera.main.transform;
        Vector3 oldPos = camTransform.position;
        Quaternion oldRot = camTransform.rotation;
        for (int i = 0; i < clickObjects.Length; ++i)
        {
            foreach (Transform t in clickObjects[i])
            {
                Collider c = t.GetComponent<Collider>();
                if (c != null)
                {
                    c.enabled = false;
                }
            }
        }
        
        // Do progressive movement
        for (float t = 0f; t < 1f / cameraSpeed; t += Time.deltaTime)
        {
            float current = Utils.SineCurve(t * cameraSpeed);
            camTransform.position = Vector3.Lerp(oldPos, newPos, current);
            camTransform.rotation = Quaternion.Slerp(oldRot, newRot, current);
            yield return null;
        }

        // Finish
        foreach (Transform t in clickObjects[menuIndex])
        {
            Collider c = t.GetComponent<Collider>();
            if (c != null)
            {
                c.enabled = true;
            }
        }
        camTransform.position = newPos;
        camTransform.rotation = newRot;
        transitioning = false;
    }
	#endregion
}
