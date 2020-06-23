using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;

public class Fix : MonoBehaviour {
    private List<TMP_Text> list;

    private void Awake() {
        var manager = TMP_UpdateManager.instance;
        this.list = (List<TMP_Text>) manager.GetType()
            .GetField("m_InternalUpdateQueue", BindingFlags.Instance | BindingFlags.NonPublic)
            .GetValue(manager);
    }

    private void Update() {
        this.list.Clear();
    }
}