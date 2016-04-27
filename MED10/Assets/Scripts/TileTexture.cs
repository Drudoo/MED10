using UnityEngine;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class TileTexture : MonoBehaviour {

	public int mapSizeX;
	public int mapSizeY;

	public GameObject tilePrefab;

	private List<Transform> tiles = new List<Transform>();

	#if UNITY_EDITOR
	[DrawGizmo (GizmoType.Selected | GizmoType.Active)]
	void OnDrawGizmos() {
		int i = 0;
		int xIndex = 0;
		int yIndex = 0;
		Gizmos.color = Color.green;
		while (yIndex < mapSizeY) {
			xIndex = 0;
			while (xIndex < mapSizeX) {

				Gizmos.DrawCube(transform.position+new Vector3(xIndex*0.55f, yIndex*0.5f, 0f), new Vector3(1, 1, 1));


				i++;
				xIndex++;
			}
			yIndex++;
		}
	}
	#endif


	void Start() {
		int i = 0;
		int xIndex = 0;
		int yIndex = 0;

		while (yIndex < mapSizeY) {
			xIndex = 0;
			while (xIndex < mapSizeX) {
				GameObject newTile = Instantiate(tilePrefab, new Vector3(xIndex*0.55f, yIndex*0.5f, 0f), Quaternion.identity) as GameObject;
				tiles.Add(newTile.transform);

				newTile.transform.parent = transform;
				newTile.transform.name = "tile_"+i;
				newTile.transform.position = newTile.transform.parent.position+new Vector3(xIndex*0.55f,yIndex*0.55f,0);
				i++;
				xIndex++;
			}
			yIndex++;
		}
	}

}
