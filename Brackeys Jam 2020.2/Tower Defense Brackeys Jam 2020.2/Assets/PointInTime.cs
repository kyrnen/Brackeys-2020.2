
using UnityEngine;
public class PointInTime
{
	public Vector3 Poition;
	public Quaternion rotation;

	public PointInTime (Vector3 _position, Quaternion _rotation)
	{
		Poition = _position;
		rotation = _rotation;
	}
}
