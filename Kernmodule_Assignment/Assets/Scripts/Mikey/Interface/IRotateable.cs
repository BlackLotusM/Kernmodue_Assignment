using UnityEngine;

/// <summary>
/// Interface for rotating a object
/// </summary>
public interface IRotateable
{
    /// <summary>
    /// Rotate the gameobject
    /// </summary>
    /// <param name="RotateableObject">The GameObject that gets rotated</param>
    void Rotate(GameObject RotateableObject);
}
