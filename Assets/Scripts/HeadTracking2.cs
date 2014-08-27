using UnityEngine;
using System;
using System.Collections;

public class HeadTracking2 : MonoBehaviour
{
	int i = 3;
	private Vector3 initialPosition;
	private Quaternion initialRotation;
	public Vector3 offset = Vector3.zero;
	
	public Vector3 correction = Vector3.one;
	
	void Start()
	{
		initialPosition = transform.position;
		initialRotation = transform.rotation;
	}
	
	
	void Update()
	{
		if (Kinect2Manager.Instance.HasTrackedBody ()) 
		{
			// Debug.Log("ID trackedBody : " + Kinect2Manager.Instance.TrackedBodyId);
			Vector3 posJoint = new Vector3(Kinect2Manager.Instance.bodyData.JointData[i].PositionX ,
			                               //Kinect2Manager.Instance.bodyData.JointData[i].PositionY*0.01F,
			                               transform.localPosition.y,
			                               -Kinect2Manager.Instance.bodyData.JointData[i].PositionZ );
			
			//Quaternion rotJoint = KinectManager.Instance.GetJointOrientation(playerID, joint, !MirroredMovement);
			Quaternion rotJoint = new Quaternion(Kinect2Manager.Instance.bodyData.JointData[i].QuaternionX,
			                                     Kinect2Manager.Instance.bodyData.JointData[i].QuaternionY,
			                                     Kinect2Manager.Instance.bodyData.JointData[i].QuaternionZ,
			                                     Kinect2Manager.Instance.bodyData.JointData[i].QuaternionW);			

			
			transform.localPosition = posJoint  + offset;
			transform.localPosition = new Vector3(transform.localPosition.x * correction.x,
			                                      transform.localPosition.y * correction.y,
			                                      transform.localPosition.z * correction.z);    
			//transform.localRotation = rotJoint;
			transform.localRotation = rotJoint;		
		}
		
	}
	
}
