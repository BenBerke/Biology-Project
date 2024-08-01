using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMover : MonoBehaviour
{
    bool moving;
    Vector3 pos;
    float speed;
    public void Move(Vector2 pos, float speed)
    {
        GetComponent<Animator>().Play("cardTurn");
        moving = true;
        this.pos = pos;
        this.speed = speed;

        CloseText();
    }

    void CloseText()
    {
        GameObject text = transform.GetChild(0).transform.GetChild(0).gameObject;
        text.SetActive(false);
    }

    private void Update()
    {
        if (moving) transform.position = Vector2.MoveTowards(transform.position, pos, speed * Time.deltaTime);
        if (transform.position == pos) moving = false;
    }
}
