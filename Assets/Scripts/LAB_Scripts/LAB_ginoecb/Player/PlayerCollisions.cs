using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerState))]
public class PlayerCollisions : MonoBehaviour
{
    #region Variables

    [Header("Required")]
    [SerializeField] private PlayerState state;
    [SerializeField] private Collider collider;
    [SerializeField] private LayerMask mask;

    [Header("Raycasting")]
    private RaycastInfo rayInfo = new RaycastInfo();
    public Collisions collisions = new Collisions();

    [Header("Testing")]
    [SerializeField] private int rayCount = 10;

    #endregion Variables

    #region Initialization

    private void Awake()
    {
        state = this.GetComponent<PlayerState>();
        collider = this.GetComponentInChildren<Collider>();
        UpdateRaycastInfo();
    }

    // Get distance between raycasts along x and y axes
    private void GetRaySpacings()
    {
        rayInfo.spacing = GetRaySpacing(collider.bounds.max.y, collider.bounds.min.y, rayInfo.count);
    }

    // Get length of raycasts along x and y axes
    private void GetRayDistances()
    {
        rayInfo.distance = GetRayDistance(collider.bounds.center.x, collider.bounds.min.x);
    }

    #endregion Initialization

    // Update count, spacing, and distance for all raycast info
    private void UpdateRaycastInfo()
    {
        rayInfo.count = rayCount - 1;
        GetRaySpacings();
        GetRayDistances();
    }

    #region Check Collisions

    // Get all collisions
    public void CheckCollisions()
    {
        collisions.Reset();
        CheckCollisionsHorizontal();
    }

    // Get horizontal collisions
    public void CheckCollisionsHorizontal()
    {
        Vector3 origin = new Vector3(collider.bounds.center.x, collider.bounds.min.y + rayInfo.spacing / 2, 0);
        //collisions.left = CheckRaycast(origin, Vector3.left, rayInfo);
    }

    // Performs multiple raycasts in specified direction
    private bool CheckRaycast(Vector3 origin, Vector3 direction, RaycastInfo info)
    {
        // Determine direction for offset to be applied between raycasts
        Vector3 offset = Vector3.zero;
        // Vertical collisions
        if (direction == Vector3.up || direction == Vector3.down)
        {
            offset = Vector3.right;
        }
        // Horizontal collisions
        else if (direction == Vector3.left || direction == Vector3.right)
        {
            offset = Vector3.up;
        }
        // Error checking
        if (offset == Vector3.zero)
        {
            Debug.LogError("Invalid raycast direction specified in call to CheckRaycast()");
        }

        // Multiple raycasts in specified direction
        for (int i = 0; i < info.count; i++)
        {
            if (Physics.Raycast(origin + offset * info.spacing * i, direction, info.distance, mask))
            {
                return true;
            }
            Debug.DrawRay(origin + offset * info.spacing * i, direction * info.distance, Color.yellow);
        }
        // If no raycast hits, return false
        return false;
    }

    #endregion Check Collisions


    #region Helpers

    // Get distance between raycasts along specified axis
    private float GetRaySpacing(float max, float min, int rayCount)
    {
        return Mathf.Abs(max - min) / rayCount;
    }

    // Get ray length along specified axis
    private float GetRayDistance(float max, float min)
    {
        return Mathf.Abs(max - min) + 0.01f;
    }

    // Helper class for managing raycast control data
    public class RaycastInfo
    {
        public int count;
        public float distance;
        public float spacing;
    }

    // Helper class for managing collision data
    public class Collisions
    {
        public bool horizontal;
        public bool down;

        // Constructor
        public Collisions()
        {
            horizontal = false;
            down = false;
        }

        // Reset collision data
        public void Reset()
        {
            horizontal = false;
            down = false;
        }
    }

    #endregion Helpers
}
