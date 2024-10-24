/*
using System.Collections.Generic;
using UnityEngine;
using SpatialSys.UnitySDK;

public class NetworkingManager : MonoBehaviour
{
    private INetworkingService networkingService;

    private void Awake()
    {
        // Initialize the networking service using SpatialBridge
        networkingService = SpatialBridge.NetworkingService;
    }

    private void Start()
    {
        // Create server instances for groups
        CreateServerInstance("Group 1");
        CreateServerInstance("Group 2");
        CreateServerInstance("Group 3");
        CreateServerInstance("Group 4");
    }

    private void CreateServerInstance(string groupName)
    {
        var serverInstanceOptions = new ServerInstanceOptions
        {
            SceneName = "IntroTutorial", // Replace with your scene name
            Properties = new Dictionary<string, object>
            {
                { "GroupName", groupName }
            }
        };

        networkingService.CreateServerInstance(serverInstanceOptions, OnServerInstanceCreated);
    }

    private void OnServerInstanceCreated(IServerInstance instance) // Assuming IServerInstance is the correct type
    {
        Debug.Log($"Server instance created: {instance.InstanceId}");
    }

    public void JoinServer(string groupName)
    {
        var servers = networkingService.ServerInstances;
        foreach (var server in servers)
        {
            if (server.Properties.TryGetValue("GroupName", out object name) && name.Equals(groupName))
            {
                networkingService.JoinServer(server.InstanceId, OnServerJoined);
                return;
            }
        }

        Debug.LogWarning($"No server found for group: {groupName}");
    }

    private void OnServerJoined(bool success)
    {
        if (success)
        {
            Debug.Log("Successfully joined the server.");
        }
        else
        {
            Debug.LogError("Failed to join the server.");
        }
    }
}
*/