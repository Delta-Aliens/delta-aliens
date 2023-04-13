using UnityEngine;

public class BackgroundScoller : MonoBehaviour
{
    [Range(-1f,1f)]
    public float scrollSpeed;
    private float offset;
    private Material mat;
    // reference to the player
    public PlayerController Player;
    private LayerMask raycastMask;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
        // Set the raycast mask to exclude the Ignore Raycast layer
        raycastMask = ~(1 << LayerMask.NameToLayer("Player"));

        scrollSpeed = 0f; // Set the initial scroll speed to 0
    }

    void Update()
    {
        offset += (Time.deltaTime * scrollSpeed) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        
        // Check if the player is grounded and not blocked by an obstacle
        Vector3 rayDirection = Player.horizontalMove > 0 ? Player.transform.right : Player.transform.right * -1;
        float rayLength = Mathf.Max(Player.GetComponent<BoxCollider2D>().bounds.size.y, 1f); // use player's height or 1 if it's smaller
        if (!Physics2D.Raycast(Player.transform.position, rayDirection, rayLength, raycastMask))
        {
            scrollSpeed = Player.horizontalMove * 0.045f;
        }
        else
        {
            // Debug.Log("Blocked");
            scrollSpeed = 0f;
        }
    }
}
