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
    public partial class TransakcijuValdymas : Form
    {
        dbEntities1 context = new dbEntities1();
        public TransakcijuValdymas()
        {
            InitializeComponent();
            updateTable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NaujaTransakcija nt = new NaujaTransakcija();
            nt.ShowDialog();
            if(!nt.cancel)
            {
                Vartotojas n = context.Vartotojas.FirstOrDefault(x => x.VartotojoVardas == nt.vartotojas);
                context.Transakcijos.Add(new Transakcijos() { Vartotojas = n });
                context.SaveChanges();
                updateTable();
            }
            
        }
        private void updateTable()
        {
            listView1.Items.Clear();
            var transactions = context.Set<Transakcijos>();
            foreach (var item in transactions)
            {
                string[] arr = { item.VartotojoVardas };
                listView1.Items.Add(item.transakcijosID.ToString()).SubItems.AddRange(arr);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                Perkama pp = new Perkama(Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text), listView1.SelectedItems[0].SubItems[1].Text);
                pp.ShowDialog();
            }
            else MessageBox.Show("Pasirinkite transakciją, kurią norite redaguoti");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
