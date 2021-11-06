using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;


public partial class Form1 : Form
{

}

public class 試作RPG : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var form = new Form();
        //formポジション
        form.StartPosition = FormStartPosition.Manual;
        form.Left = 700;
        form.Top = 250;

        //サイズ
        form.Width = 694;
        form.Height = 348;

        form.Show();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
