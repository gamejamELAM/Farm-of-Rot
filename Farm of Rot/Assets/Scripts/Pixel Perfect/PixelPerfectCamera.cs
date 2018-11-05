using UnityEngine;

namespace Pixel_Perfect
{
	[RequireComponent(typeof(UnityEngine.Camera))]
	public class PixelPerfectCamera : MonoBehaviour
	{
		// Fields.
		[SerializeField, Tooltip("The target resolution you want to get.")]
		private Vector2Int _resolution = new Vector2Int(16,9);
		
		[SerializeField, Tooltip("The PPU of the assets.")] private int _pixelsPerUnit = 100;
		[SerializeField, Tooltip("The width of each pixel.")] private int _pixelWidth = 2;

		private UnityEngine.Camera _targetCamera;

		// Unity Methods.
		private void Start()
		{
			_targetCamera = GetComponent<UnityEngine.Camera>();
		}
		
		private void Update()
		{
			// Work out the largest amount of units that could fit in the window.
			int widthUnits = Mathf.FloorToInt((float)Screen.width / (_resolution.x * _pixelWidth));
			int heightUnits = Mathf.FloorToInt((float)Screen.height / (_resolution.y * _pixelWidth));
			
			// Make both units even.
			widthUnits = widthUnits % 2 == 0 ? widthUnits : widthUnits - 1;
			heightUnits = heightUnits % 2 == 0 ? heightUnits : heightUnits - 1;
			
			// Picks the smaller unit to make sure the other one also fits.
			if (heightUnits < widthUnits) widthUnits = heightUnits;
			else heightUnits = widthUnits;
			
			// Scale them both back up to pixels.
			widthUnits *= _resolution.x * _pixelWidth;
			heightUnits *= _resolution.y * _pixelWidth;

			// Work out the camera size.
			_targetCamera.orthographicSize = (float)heightUnits / _pixelWidth / (2 * _pixelsPerUnit);

			// Make the camera fit the desired resolution.
			var rectangle = _targetCamera.rect;
			rectangle.width = (float)widthUnits / Screen.width;
			rectangle.height = (float)heightUnits / Screen.height;
			rectangle.x = Mathf.Round(( 1 - rectangle.width) / 2 * 100) / 100;
			rectangle.y = Mathf.Round(( 1 - rectangle.height) / 2 * 100) / 100;
			_targetCamera.rect = rectangle;
		}
	}
}