using UnityEngine;

namespace Camera
{
	public class FollowTarget : MonoBehaviour
	{
		[SerializeField] private Transform _target;
		[SerializeField] private Vector3 _offset;
		[SerializeField, Range(0, 1)] private float _speed = 0.1f;
		[SerializeField] private bool _tpAtStart = true;

		// Getters and Setters.
		public Vector3 GetOffset()
		{
			return _offset;
		}
		
		private void Start()
		{
			// At the start of the game, move the camera to the target, if the tpAtStart option is enabled.
			if (_tpAtStart) transform.position = _target.transform.position + _offset;
		}

		private void Update()
		{
			transform.position = Vector3.LerpUnclamped(transform.position, _target.position + _offset, _speed);
		}
	}
}
