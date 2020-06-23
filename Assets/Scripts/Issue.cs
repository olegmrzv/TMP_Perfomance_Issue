using System.Globalization;
using TMPro;
using UnityEngine;

//Update any UI element to force canvas rebuild, it can be any element: text, image, slider, etc.
//It will trigger TMP_UpdateManager.OnCameraPreCull -> TMP_UpdateManager.DoRebuilds -> TextMeshProUGUI.InternalUpdate().
//A very expensive operation will be called for each text, even if it has not changed -> Transform.get_lossyScale().
//On low-end devices this kills any performance.
//In the example, 4000 instances of text to show a lag on a PC, but on real mobile projects 20-100 instances are enough.
//
//In Fix.cs is fix which we have to use in production.
//Just enable it on the Issue object in the SampleScene to see the difference.
public class Issue : MonoBehaviour {
    public TextMeshProUGUI text;
    
    private void Update() {
        this.text.text = Time.time.ToString(CultureInfo.InvariantCulture);
    }
}
