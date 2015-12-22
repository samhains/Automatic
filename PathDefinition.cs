using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PathDefinition : MonoBehaviour {
	// Use this for initialization
	public Transform[] Points;
	public IEnumerator<Transform> GetPathEnumerator()
	{
		if (Points == null || Points.Length < 2) {
			yield break;
		}
		var direction = 1;
		var index = 0;
		while (true) {

			yield return Points[index];

			if (Points.Length == 1) {
				continue;
			}

			if (index <= 0) {
				direction = 1;
			}
			if (index >= Points.Length - 1) {
				direction = -1;
				
			}
			index = index + direction;
		}
	}
	void OnDrawGizmos()
    {
        if (Points == null || Points.Length < 2)
        {
            return; 
        }

        for (int i = 1; i < Points.Length; i++)      {
            Gizmos.DrawLine(Points[i-1].position, Points[i].position);   
        }
    }
		
}
