using UnityEngine;
using FishNet;
using PlayFab;
using PlayFab.ClientModels;

public class Bootstrap : MonoBehaviour
{
    [Header("Components")]
    public NetworkManager networkManager;
    public PlayFabManager playFabManager;
    
    [Header("Game Objects")]
    public GameObject playerPrefab;
    public Transform spawnPoint;
    
    private void Awake()
    {
        // Initialize PlayFab
        if (playFabManager == null)
        {
            Debug.LogError("PlayFab Manager is not assigned in Bootstrap!");
            return;
        }
        
        playFabManager.Initialize();
        
        // Initialize FishNet
        if (networkManager == null)
        {
            Debug.LogError("Network Manager is not assigned in Bootstrap!");
            return;
        }
        
        networkManager.StartConnection();
    }
    
    public void OnPlayFabAuthenticated(PlayFabResult<LoginResult> result)
    {
        Debug.Log("PlayFab authenticated successfully.");
        
        // Spawn player after authentication
        if (playerPrefab != null && spawnPoint != null)
        {
            // This will be handled by PlayerSpawner or NetworkManager
            Debug.Log("Player spawning logic should go here.");
        }
    }
}