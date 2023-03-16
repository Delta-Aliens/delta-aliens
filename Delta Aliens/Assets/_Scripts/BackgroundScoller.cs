using UnityEngine;

public class BackgroundScoller : MonoBehaviour
{
    [Range(-1f,1f)]
    public float scrollSpeed;
    private float offset;
    private Material mat;
    // reference to the player
    public PlayerController Player;


    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        offset += (Time.deltaTime * scrollSpeed) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        scrollSpeed = Player.horizontalMove * 0.065f;
    }
}
