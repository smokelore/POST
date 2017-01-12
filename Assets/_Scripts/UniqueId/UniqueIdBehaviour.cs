using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class UniqueIdBehaviour : MonoBehaviour
{
    [UniqueIdentifier]
    public string UniqueId;

    void Start()
    {
#if UNITY_EDITOR
        if (String.IsNullOrEmpty(this.UniqueId))
        {
            UniqueId = Guid.NewGuid().ToString();
        }
        UniqueIdRegistry.Register(this.UniqueId, this.GetInstanceID());
        UnityEditor.EditorUtility.SetDirty(this);
#endif
        DontDestroyOnLoad(this);
    }

    void OnDestroy()
    {
#if UNITY_EDITOR
        UniqueIdRegistry.Deregister(this.UniqueId);
#endif
    }

    void Update()
    {
#if UNITY_EDITOR
        if (this.GetInstanceID() != UniqueIdRegistry.GetInstanceId(this.UniqueId))
        {
            UniqueId = Guid.NewGuid().ToString();
            UniqueIdRegistry.Register(this.UniqueId, this.GetInstanceID());
        }
#endif
    }
}