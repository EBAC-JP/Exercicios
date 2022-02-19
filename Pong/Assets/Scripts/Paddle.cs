using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Paddle : MonoBehaviour {

    [SerializeField] private float speed;
    [SerializeField] private TMP_InputField playerNameInput;
    [Header("Key Setup")]
    [SerializeField] private KeyCode upKey;
    [SerializeField] private KeyCode downKey;
    [Header("Points")]
    [SerializeField] public TextMeshProUGUI score;
    public int currentPoint;
    [Header("Winner")]
    [SerializeField] private TextMeshProUGUI wonText;
    [Header("Color")]
    [SerializeField] private List<Color> colors;
    [SerializeField] private GameObject upArrow;
    [SerializeField] private GameObject downArrow;

    private Rigidbody2D myRigidbody;
    private Vector3 _defaultPositon;
    private bool _canMove, _typing;
    private int index;
    private string playerName;

    void Awake() {
        myRigidbody = gameObject.GetComponent<Rigidbody2D>();
        index = 0;
        _canMove = false;
        _typing = false;
        playerName = gameObject.name;
        _defaultPositon = transform.position;
        wonText.gameObject.SetActive(false);
    }

    void Update() {
        if (_canMove) {
            if (Input.GetKey(upKey)) {
                myRigidbody.MovePosition(transform.position + transform.up * speed * Time.deltaTime);
            } else if (Input.GetKey(downKey)) {
                myRigidbody.MovePosition(transform.position + transform.up * -speed * Time.deltaTime);
            }
        } else if(!_typing) {
            CheckIndex();
            ChangeColor(colors[index]);
            if (Input.GetKeyDown(upKey) && index > 0) {
                index--;
            } else if (Input.GetKeyDown(downKey) && index < colors.Count - 1) {
                index++;
            }
        }
    }

    void ResetPoints() {
        currentPoint = 0;
        score.text = currentPoint.ToString();
    }

    void ChangeColor(Color newColor) {
        GetComponent<SpriteRenderer>().color = newColor;
    }

    void CheckIndex() {
        if (index == 0) upArrow.SetActive(false);
        else if(index == colors.Count - 1) downArrow.SetActive(false);
        else {
            upArrow.SetActive(true);
            downArrow.SetActive(true);
        }
    }

    public void AddPoint() {
        currentPoint++;
        score.text = currentPoint.ToString();
    }

    public void StartPaddle() {
        upArrow.SetActive(false);
        downArrow.SetActive(false);
        wonText.gameObject.SetActive(false);
        ResetPoints();
        _canMove = true;
    }

    public void ActiveWonText() {
        wonText.text = playerName + "\n WON";
        wonText.gameObject.SetActive(true);
    }

    public void EndGame() {
        _canMove = false;
        transform.position = _defaultPositon;
        index = 0;
        upArrow.SetActive(true);
        downArrow.SetActive(true);
    }

    public void IsTyping() {
        _typing = true;
    }

    public void NotTyping() {
        _typing = false;
        playerName = playerNameInput.text;
        Debug.Log("Player name: " + playerName);
    }
}
