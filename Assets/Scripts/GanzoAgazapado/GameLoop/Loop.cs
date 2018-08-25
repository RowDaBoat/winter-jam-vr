using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static GanzoAgazapado.CoroutineUtils;

namespace GanzoAgazapado.GameLoop
{
	public class Loop : MonoBehaviour
	{
		public TextMeshProUGUI screenText;
		public Image initialDimmer;
		public Image redDimmer;

		public event Action OnReady = delegate {};
		public event Action OnStop = delegate {};

		int score = 0;

		public void StartGame() => StartCoroutine(StartRoutine());
		
		public void Lose()
		{
			ShowDimmer(redDimmer, "Ded Ganz!\n\nScore: " + score);
			OnStop();
		}

		public void AddScore() => score++;

		void Start() => StartGame();

		IEnumerator StartRoutine() => Do(() => ShowText("3"))
			.Then(Wait(1))
			.Then(Do(() => ShowText("2")))
			.Then(Wait(1))
			.Then(Do(() => ShowText("1")))
			.Then(Wait(1))
			.Then(Do(() => ShowText("Agazapated Ganz!")))
			.Then(Wait(1))
			.Then(Do(() => HideDimmer(initialDimmer)))
			.Then(Do(() => OnReady()));

		void ShowDimmer(Image image, string text = "")
		{
			image.enabled = true;
			screenText.enabled = true;
			ShowText(text);
		}

		void HideDimmer(Image image)
		{
			image.enabled = false;
			screenText.enabled = false;
		} 

		void ShowText(string text)
		{
			screenText.text = text;
		}
	}
}
