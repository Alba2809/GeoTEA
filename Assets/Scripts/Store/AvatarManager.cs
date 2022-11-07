using UnityEngine;

public class AvatarManager : MonoBehaviour
{
    
    public GameObject[] avatarPrefabs;
    public GameObject contenedor;
    public Vector2 posicion;
    //new Vector2(540, 1140)
    int avatarIndex;

    private void Awake()
    {
        avatarIndex = PlayerPrefs.GetInt("AvatarSeleccionado", 0);
        Instantiate(avatarPrefabs[avatarIndex], posicion, Quaternion.identity, contenedor.transform);
    }
}
