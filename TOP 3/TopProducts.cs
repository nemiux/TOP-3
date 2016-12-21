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
    public partial class TopProducts : Form
    {
        int length;
        dbEntities1 context = new dbEntities1();
        public TopProducts()
        {
            InitializeComponent();
            length = context.Set<prekiu_perkamumas>().Count();
            for (int i = 0; i < length; i++) comboBox1.Items.Add(i+1);
            updateTable();
        }
        private void updateTable()
        {
            listView1.Items.Clear();
            IEnumerable<prekiu_perkamumas> products = (from x in context.prekiu_perkamumas select x).OrderByDescending(y=>y.PerkamasKiekis);
            if (comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1)
            {
                products = products.Skip(comboBox1.SelectedIndex).Take(comboBox2.SelectedIndex + 1);
                //MessageBox.Show("Skip: " + comboBox1.SelectedIndex.ToString() + ", take: " + comboBox2.SelectedIndex.ToString());
            }
            foreach (var item in products)
            {
                string[] arr = { item.PerkamasKiekis.ToString()};
                listView1.Items.Add(item.Pavadinimas).SubItems.AddRange(arr);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            for (int i = comboBox1.SelectedIndex; i < length; i++)
            {
                comboBox2.Items.Add(i+1);
            }
            comboBox2.SelectedIndex = 0;
            updateTable();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateTable();
        }
    }
}
