using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoEHealing : AoEBase
{
    [SerializeField] private int healing;
    [SerializeField] private List<GameObject> playersHealed;
    [SerializeField] private List<GameObject> playerVFX;
    [SerializeField] private GameObject healVFXPrefab;

    private void Awake()
    {
        playersHealed = new List<GameObject>();
    }

    protected override void OnTriggerEffect(GameObject other)
    {
        // Added check for player tag to prevent healing shields
        if (other.gameObject.CompareTag("Player") && other.GetComponent<Health>() != null && other.GetComponent<Health>().isPlayer)
        {
            other.GetComponent<Health>().takeDamage(-1 * healing);
            UpdatePlayersHealed(other);
        }

        if (other.gameObject.CompareTag("Player") && other.GetComponentInChildren<Health>() != null && other.GetComponentInChildren<Health>().isPlayer)
        {
            other.GetComponentInChildren<Health>().takeDamage(-1 * healing);
            UpdatePlayersHealed(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("FAK");
            var index = GetPlayerHealed(other.gameObject);
            if (index < 0)
                return;
            Destroy(playerVFX[GetPlayerHealed(other.gameObject)]);
            playersHealed.RemoveAt(index);
            playerVFX.RemoveAt(index);
        }
    }

    private void UpdatePlayersHealed(GameObject other)
    {
        if (PlayerIsHealed(other))
            return;

        playersHealed.Add(other);
        AddHealVFX(other);
    }

    private bool PlayerIsHealed(GameObject other)
    {
        for (int i = 0; i < playersHealed.Count; i++)
        {
            if (playersHealed[i] == other)
                return true;
        }
        return false;
    }

    private int GetPlayerHealed(GameObject other)
    {
        for (int i = 0; i < playersHealed.Count; i++)
        {
            if (playersHealed[i] == other)
                return i;
        }
        return -1;
    }

    private void OnDestroy()
    {
        for (int i = 0; i < playerVFX.Count; i++)
        {
            Destroy(playerVFX[i]);
        }
    }

    private void AddHealVFX(GameObject other)
    {
        var vfx = Instantiate(healVFXPrefab, other.transform);
        playerVFX.Add(vfx);
    }
}
