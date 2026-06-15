using UnityEngine;
using System.Collections.Generic;

public class EventBus : MonoBehaviour
{
    public static EventBus Instance { get; private set; }
    
    private Dictionary<string, System.Action<object>> eventHandlers = new Dictionary<string, System.Action<object>>();
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void Subscribe(string eventName, System.Action<object> handler)
    {
        if (!eventHandlers.ContainsKey(eventName))
        {
            eventHandlers[eventName] = null;
        }
        
        eventHandlers[eventName] += handler;
    }
    
    public void Unsubscribe(string eventName, System.Action<object> handler)
    {
        if (eventHandlers.ContainsKey(eventName))
        {
            eventHandlers[eventName] -= handler;
        }
    }
    
    public void Publish(string eventName, object data = null)
    {
        if (eventHandlers.TryGetValue(eventName, out var handler))
        {
            handler?.Invoke(data);
        }
    }
}