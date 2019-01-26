using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class MeshColor : MonoBehaviour 
{
    #region Variables
    /// <summary>
    /// <para>The color of the material</para>
    /// </summary>
    [SerializeField]
    private Color color;

    /// <summary>
    /// <para>The Mesh Renderer component attached</para>
    /// </summary>
    private MeshRenderer _meshRenderer;
	#endregion

	#region Properties
	
	#endregion
	
	#region Events
	/// <summary>
	/// Awake is called before start
	/// <summary>
	private void Awake() 
	{
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshRenderer.material.color = color;
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
	
	#endregion
	
	#region Coroutines
	
	#endregion
}
