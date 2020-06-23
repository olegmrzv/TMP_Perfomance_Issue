# TextMeshPro Performance Issue  
## How To Reproduce  
* Clone Repo (don't use zip - there are Git LFS files)
* Open Scenes/SampleScene.scene  
* Open Profiler Window  
* Enable Deep Profile
* Press Play Button
* Expand `Camera.Render/Culling/Camera.FireOnPreCull/`
* You will see the following picture
![profiler.png](Assets/Images/profiler.png)  
* Enjoy

## Explanation  
This is a confirmed issue on any revisions of Unity 2019.3.* , 2019.4.*
  
Update any UI element to force canvas rebuild, it can be any element: text, image, slider, etc.  
It will trigger `TMP_UpdateManager.OnCameraPreCull` -> `TMP_UpdateManager.DoRebuilds` -> `TextMeshProUGUI.InternalUpdate()`.  
A very expensive operation will be called for **each** TMP text, even if it has **not changed** -> `Transform.get_lossyScale()`.  
On low-end devices this kills any performance.  
In the example, 4000 instances of text to show a lag on a PC, but on real mobile projects 20-100 instances of text are enough.  
  
In `Fix.cs` is fix which we have to use in production.  
We just clear every frame *TMP_Text* collection which can be updated.  
Just enable it on the Issue object in the SampleScene to see the difference.  