using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pi1_Cs_projekt
{
    public partial class Form1 : Form
    {
        List<Ziak> ziaci = new List<Ziak>();
        List<Trieda> triedy = new List<Trieda>();
        List<Skrinka> skrinky = new List<Skrinka>();


        public Form1()
        {
            InitializeComponent();
        }

        private void buttonVytvSkr_Click(object sender, EventArgs e)
        {
            try
            {
                skrinky.Add(new Skrinka(int.Parse(textBoxVytvSkrCs.Text), richTextBoxVytvSkrPoz.Text, ziaci[treeViewVytvSkrVl.SelectedNode.Index]));
            }
            catch
            {
                MessageBox.Show("Nespravne zadané vlastnosti");
            }
        }

        private void buttonVytvTr_Click(object sender, EventArgs e)
        {

                
            triedy.Add(new Trieda(textBoxVytvTrNz.Text, textBoxVytvTrOd.Text, textBoxVytvTrTu.Text, int.Parse(textBoxVytvTrRc.Text)));
            comboBoxVytvZiakTr.Items.Add(triedy.Last().Meno);
            treeViewVytvSkrVl.Nodes.Add(triedy.Last().Meno);

        }

        private void buttonVytvZiak_Click(object sender, EventArgs e)
        {

            ziaci.Add(new Ziak(textBoxVytvZiakMP.Text, int.Parse(textBoxVytvZiakPC.Text), comboBoxVytvZiakPoh.SelectedItem.ToString(), int.Parse(textBoxVytvZiakVek.Text), dateTimePickerVytvZiakDN.Value, triedy[comboBoxVytvZiakTr.SelectedIndex]));
            treeViewVytvSkrVl.Nodes[comboBoxVytvZiakTr.SelectedIndex].Nodes.Add(ziaci.Last().MenoPriezvisko);
        }
    }
}
