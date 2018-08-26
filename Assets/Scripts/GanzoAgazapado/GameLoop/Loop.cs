using System;
using System.Collections;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static GanzoAgazapado.CoroutineUtils;

namespace GanzoAgazapado.GameLoop
{
	public class Loop : MonoBehaviour
	{
		public TextMeshProUGUI screenText;
		public TextMeshProUGUI scoreText;
		public Image initialDimmer;
		public Image redDimmer;
		public AudioSource music;
		public AudioSource loseSound;

		public event Action OnReady = delegate {};
		public event Action OnStop = delegate {};

		int score = 0;
		bool finished;

		public void StartGame() => StartCoroutine(StartRoutine());
		
		public void Lose()
		{
			if (finished)
				return;

			finished = true;
			ShowDimmer(redDimmer, "Ded Ganz!\n\nScore: " + score);
			OnStop();
			StartCoroutine(FadeMusic(0.25f));
		}

		IEnumerator FadeMusic(float time)
		{
			var t = 0f;

			loseSound.Play();
			
			while (t < time) {
				music.volume = 1f - t / time;
				loseSound.volume = t / time;
				t += Time.deltaTime;

				yield return 0;
			}

			music.volume = 0;
		}

		public void AddScore()
		{
			score++;
			scoreText.text = score.ToString();
		}

		void Start() => StartGame();

		IEnumerator StartRoutine() => Do(() => ShowText("3"))
			.Then(Wait(1))
			.Then(Do(() => ShowText("2")))
			.Then(Wait(1))
			.Then(Do(() => ShowText("1")))
			.Then(Wait(1))
			.Then(Do(() => ShowText("Agazapated Ganz!")))
			.Then(Do(() => music.Play()))
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
