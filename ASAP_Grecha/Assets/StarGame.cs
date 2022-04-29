using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StarGame : MonoBehaviour
{
    public int index;
    private void OnMouseDown()
    {
        SceneManager.LoadScene(index);
    }
}
