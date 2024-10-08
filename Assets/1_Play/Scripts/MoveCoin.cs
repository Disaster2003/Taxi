using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCoin : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Ÿ‚ÌŒiF‚Ö
        if (GetComponent<SpriteRenderer>().color == Color.clear)
        {
            Destroy(gameObject);
        }

        // ã‚ÖˆÚ“®
        transform.position += new Vector3(0, 2 * Time.deltaTime);

        // ·•ª‚ğ™X‚É‰ÁZ‚·‚é
        GetComponent<SpriteRenderer>().color = Color.Lerp(GetComponent<SpriteRenderer>().color, Color.clear, 0.5f * Time.deltaTime);
    }
}
