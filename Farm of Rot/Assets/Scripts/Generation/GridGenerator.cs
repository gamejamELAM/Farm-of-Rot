using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Generation
{
	public class GridGenerator : MonoBehaviour
	{
		[SerializeField] private Tilemap[] _tileMaps;
		[SerializeField] private TileBase[] _tiles;

		private void Start()
		{
			GenerateCell(Vector2Int.zero, 7);
		}

		private void GenerateCell(Vector2Int offset, int width)
		{
			var positionArray = new List<Vector3Int>();
			var tileList = new List<TileBase>();

			for (var y = offset.y; y < offset.y + width; y++)
			{
				for (var x = offset.x; x < offset.x + width; x++)
				{
					var tilePosition = new Vector3Int(x, y, 0);
					var isLight = (y * width + x) % 2;

					positionArray.Add(tilePosition);

					tileList.Add(_tiles[isLight == 0 ? 0 : 1]);
				}
			}

			_tileMaps[0].SetTiles(positionArray.ToArray(), tileList.ToArray());
		}
	}
}
