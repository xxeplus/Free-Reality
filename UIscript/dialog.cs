
using UnityEngine;

public class dialog : MonoBehaviour
{
    public GameObject enterdialog;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "player")
        {
            enterdialog.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            enterdialog.SetActive(false);
        }
    }
}
