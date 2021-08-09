using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ManagerBase : MonoBehaviour
{
    private SceneLoader sceneLoader;

    internal SceneLoader SceneLoader {
			get {
				if (sceneLoader == null) {
					sceneLoader = GameObject.FindGameObjectWithTag("SceneLoader").GetComponent<SceneLoader>();
				}
				return sceneLoader;
			}
		}
}
