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
    public partial class VartotojuValdymas : Form
    {
        dbEntities1 context;
        public VartotojuValdymas()
        {
            InitializeComponent();
            context = new dbEntities1();
            updateTable();
            
        }
        private void updateTable()
        {
            listView1.Items.Clear();
            var users = context.Set<Vartotojas>();
            foreach (var item in users)
            {
                string[] arr = { item.Slaptazodis, item.Miestas, item.Gatve, item.Namas, item.Butas };
                listView1.Items.Add(item.VartotojoVardas).SubItems.AddRange(arr);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NaujasVartotojas nv = new NaujasVartotojas();
            nv.ShowDialog();
            if (!nv.cancel)
            {
                context.Vartotojas.Add(new Vartotojas()
                {
                    VartotojoVardas = nv.vardas,
                    Slaptazodis = nv.slaptazodis,
                    Miestas = nv.miestas,
                    Gatve = nv.gatve,
                    Namas = nv.namas,
                    Butas = nv.butas
                });
                context.SaveChanges();
                updateTable();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                NaujasVartotojas rv = new NaujasVartotojas(listView1.SelectedItems[0]);
                rv.ShowDialog();
                if (!rv.cancel)
                {
                    Vartotojas keiciamas = (from x in context.Vartotojas where x.VartotojoVardas == rv.vardas select x).FirstOrDefault();
                    keiciamas.Slaptazodis = rv.slaptazodis;
                    keiciamas.Miestas = rv.miestas;
                    keiciamas.Gatve = rv.gatve;
                    keiciamas.Namas = rv.namas;
                    keiciamas.Butas = rv.butas;
                    context.SaveChanges();
                    updateTable();
                }
            }
            else MessageBox.Show("Pasirinkite vartotoją, kurį norite redaguoti");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                string trint = listView1.SelectedItems[0].SubItems[0].Text;
                Vartotojas trinamas = (from x in context.Vartotojas where x.VartotojoVardas.Equals(trint) select x).First();
                context.Vartotojas.Remove(trinamas);
                context.SaveChanges();
                updateTable();
            }
            else MessageBox.Show("Pasirinkite vartotoją, kurį norite ištrinti");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
