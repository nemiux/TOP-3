using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TOP_3
{
    public partial class NaujaTransakcija : Form
    {
        public bool cancel = true;
        public string vartotojas;
        dbEntities1 context = new dbEntities1();
        public NaujaTransakcija()
        {
            InitializeComponent();
            var names = context.Set<Vartotojas>().Select(x => x.VartotojoVardas);
            foreach (var name in names)
            {
                comboBox1.Items.Add(name);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cancel = false;
            vartotojas = comboBox1.Text;
            Close();
        }
    }
}
