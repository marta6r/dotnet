using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day24_3
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;

    public class MyCustomComponent : Component
    {
        
        public string Message { get; set; } = "Привет, мир!";

        public void ShowMessage()
        {
            MessageBox.Show(Message);
        }


    }


}
