using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class SwipeRecognize : MonoBehaviour {

	public Text pop;                                                                                                                                                                                                                                                                                                                         

	public enum SwipeDir {
		UP,
		DOWN,
		LEFT,
		RIGHT
	}

	public static event Action<SwipeDir> swipe;
	private float startTime;
	private Vector2 startPos;

	private bool swiping;
	private float minSwipeDist;
	private float maxSwipeTime;

	void Start () {
		startTime = 0.0f;
		startPos = Vector2.zero;
		swiping = false;

		minSwipeDist = 50.0f;
		maxSwipeTime = 0.5f;
	}

	void Update () {
		if (Input.touchCount > 0) {
			
			Touch touch = Input.GetTouch (0);
			if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) {
				Vector2 touchPos = Camera.main.ScreenToWorldPoint (
					                   new Vector3 (touch.position.x,
						                   touch.position.y,
						                   10));
				transform.position = touchPos;
			}

			foreach (Touch t in  Input.touches) {
				switch (t.phase) {
				case TouchPhase.Began:
					swiping = true;
					startTime = Time.time;
					startPos = t.position;
					break;

				case TouchPhase.Canceled:
					swiping = false;
					break;

				case TouchPhase.Ended:
					float gestureTime = Time.time - startTime;
					float gestureDist = (t.position - startPos).magnitude;

					if (swiping && gestureTime < maxSwipeTime && gestureDist > minSwipeDist) {
						Vector2 dir = t.position - startPos;
						Vector2 swipeType = Vector2.zero;

						if (Mathf.Abs (dir.x) > Mathf.Abs (dir.y))
							swipeType = Vector2.right * Mathf.Sign (dir.x);
						else
							swipeType = Vector2.up * Mathf.Sign (dir.y);

						if(swipeType.x != 0.0f) {
							if (swipeType.x > 0.0f) {
								//swipe (SwipeDir.RIGHT);
								//pop.text = "RGITH";
								GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Main>().Atk("Right");
							} else {
								//swipe (SwipeDir.LEFT);
								//pop.text = "Left";
								GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Main>().Atk("Left");
							}
						}

						if(swipeType.y != 0.0f) {
							if (swipeType.y > 0.0f) {
								//swipe (SwipeDir.UP);
								//pop.text = "UP";
								GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Main>().Atk("Up");
							} else {
								//swipe (SwipeDir.DOWN);
								//pop.text = "DOWN";
								GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Main>().Atk("Down");
							}
						}	
					}
				break;
				}
			}
		}
	}
}
