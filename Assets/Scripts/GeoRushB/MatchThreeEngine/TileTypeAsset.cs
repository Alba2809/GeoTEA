using UnityEngine;

namespace MatchThreeEngine
{
	[CreateAssetMenu(menuName = "GeoRush/Tile Type Asset")]
	public sealed class TileTypeAsset : ScriptableObject
	{
		public int id;

		public int value;

		public Sprite sprite;
	}
}
