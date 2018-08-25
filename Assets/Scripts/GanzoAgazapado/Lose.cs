using UnityEngine;

namespace GanzoAgazapado
{
	public class Lose : MonoBehaviour
	{
		public GameObject dimmer;

		void Start() {
			dimmer.SetActive(false);
		}

		public void Do()
		{
			dimmer.SetActive(true);
		}
	}
}
