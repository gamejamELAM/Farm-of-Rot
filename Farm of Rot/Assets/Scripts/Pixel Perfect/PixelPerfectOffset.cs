using UnityEngine;

namespace Pixel_Perfect
{
	public class PixelPerfectOffset : MonoBehaviour
	{
		[SerializeField] private Vector3 _offset = Vector3.zero;
		[SerializeField] private int _pixelsPerUnit = 10;
		[SerializeField, Range(0, 1)] private float _speed = .5f;

		public void SetOffset(Vector3 offset)
		{
			_offset = offset;
		}
		
		private void LateUpdate()
		{
			// Get the current position.
			var parentsPosition = transform.parent.position;
			// Get the closest pixel perfect position.
			var pixelPerfectX = Mathf.Round(parentsPosition.x * _pixelsPerUnit) / _pixelsPerUnit;
			var pixelPerfectY = Mathf.Round(parentsPosition.y * _pixelsPerUnit) / _pixelsPerUnit;
			
			var pixelPerfectPosition = new Vector3(pixelPerfectX, pixelPerfectY, transform.parent.position.z);

			var differencePosition = pixelPerfectPosition - parentsPosition;
			var newPosition = Vector3.Lerp(transform.localPosition, differencePosition, _speed);
			transform.localPosition = newPosition + _offset;
		}
	}
}
