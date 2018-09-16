using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JL
{

	public class ConnectionView : MonoBehaviour
	{

		public ParameterView Source;

		public ParameterView Target;

		public static ConnectionView Create(ParameterView source, ParameterView target)
		{
			return Instantiate(Resources.Load<GameObject>("Prefab/Connection")).GetComponent<ConnectionView>();
		}

	}

}