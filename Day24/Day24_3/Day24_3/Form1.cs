using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Day24_3
{
    public class MyCustomComponent : Component
    {

        public string Message { get; set; } = "Привет, мир!";

        public void ShowMessage()
        {
            MessageBox.Show(Message);
        }
    }
}

