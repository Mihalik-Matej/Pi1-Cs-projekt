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
        List<int> rocniky_pridane = new List<int>();


        public Form1()
        {
            InitializeComponent();
        }

        private void buttonVytvSkr_Click(object sender, EventArgs e)
        {
            try
            {
                skrinky.Add(new Skrinka(int.Parse(textBoxVytvSkrCs.Text), richTextBoxVytvSkrPoz.Text, ziaci[treeViewVytvSkrVl.SelectedNode.Index]));
                treeViewSkrVymz.Nodes.Add(skrinky.Last().Cislo.ToString());
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
            
            bool x = true;
            int index = 0;
            foreach (int j in rocniky_pridane)
            {
                if (j == int.Parse(textBoxVytvTrRc.Text))
                {
                    x = false;
                    break;
                }
                index++;
            }
            if(x)
            {
                treeViewTrdVymz.Nodes.Add(textBoxVytvTrRc.Text);
                rocniky_pridane.Add(int.Parse(textBoxVytvTrRc.Text));
            }
            treeViewTrdVymz.Nodes[index].Nodes.Add(triedy.Last().Meno);
            
            treeViewZiakVymz.Nodes.Add(triedy.Last().Meno);
       
            

        }

        private void buttonVytvZiak_Click(object sender, EventArgs e)
        {

            ziaci.Add(new Ziak(textBoxVytvZiakMP.Text, int.Parse(textBoxVytvZiakPC.Text), comboBoxVytvZiakPoh.SelectedItem.ToString(), int.Parse(textBoxVytvZiakVek.Text), dateTimePickerVytvZiakDN.Value, triedy[comboBoxVytvZiakTr.SelectedIndex]));
            treeViewVytvSkrVl.Nodes[comboBoxVytvZiakTr.SelectedIndex].Nodes.Add(ziaci.Last().MenoPriezvisko);
            treeViewZiakVymz.Nodes[comboBoxVytvZiakTr.SelectedIndex].Nodes.Add(ziaci.Last().MenoPriezvisko);
        }

        private void buttonSkrVymz_Click(object sender, EventArgs e)
        {
            int cislo = 0;
            foreach (TreeNode i in treeViewSkrVymz.Nodes)
            {
                if (i.Text == treeViewSkrVymz.SelectedNode.Text) 
                {
                    cislo = int.Parse(i.Text);
                }
            }  
            foreach (Skrinka i in skrinky)
            {
                if (i.Cislo == cislo) 
                {
                    skrinky.Remove(i);
                    if (skrinky.Count() == 0)
                    {
                        break;
                    }
                }
            }

            treeViewSkrVymz.SelectedNode.Remove();
        }

        private void buttonTrdVymz_Click(object sender, EventArgs e)
        {
            string trieda = "";
            foreach (TreeNode i in treeViewTrdVymz.Nodes)
            {
                foreach (TreeNode j in treeViewTrdVymz.Nodes[i.Index].Nodes)
                {
                    if (j.Text == treeViewTrdVymz.SelectedNode.Text)
                    {
                        trieda = j.Text;
                    }
                }    
            }
            foreach (Trieda i in triedy)
            {
                if (i.Meno == trieda)
                {
                    int indx = 0;
                    foreach (Ziak j in ziaci)
                    {
                        if (j.Trieda == i)
                        {
                            ziaci[indx].Trieda = null;
                        }
                        indx++;
                    }
                    triedy.Remove(i);
                    if (triedy.Count() == 0)
                    {
                        break;
                    }
                }
            }
            foreach (TreeNode i in treeViewTrdVymz.Nodes)
            {
                foreach(TreeNode j in treeViewTrdVymz.Nodes[i.Index].Nodes)
                {
                    if (j.Text == trieda) 
                    {
                        treeViewTrdVymz.Nodes[i.Index].Nodes.Remove(j);
                    }
                }
            }
            foreach (TreeNode i in treeViewVytvSkrVl.Nodes)
            {
                if(i.Text == trieda)
                {
                    foreach(TreeNode j in treeViewVytvSkrVl.Nodes[i.Index].Nodes)
                    {

                    }
                    treeViewVytvSkrVl.Nodes.Remove(i);
                }
            }
            foreach ( String i in comboBoxVytvZiakTr.Items)
            {

                if (i == trieda)
                {
                    comboBoxVytvZiakTr.Items.RemoveAt(comboBoxVytvZiakTr.Items.IndexOf(i));
                }
                if (comboBoxVytvZiakTr.Items.Count == 0)
                {
                    break;
                }
            }

        }

        private void buttonZiakVymz_Click(object sender, EventArgs e)
        {
            string meno ="" ;  

            foreach(TreeNode i in treeViewZiakVymz.Nodes)
            {
                foreach (TreeNode j in treeViewZiakVymz.Nodes[i.Index].Nodes)
                {
                    if (j.Text == treeViewZiakVymz.SelectedNode.Text)
                    {
                        meno = j.Text;
                    }
                }
                
            }      
            foreach(Ziak i in ziaci)
            {
                if(i.MenoPriezvisko == meno)
                {
                    int indx = 0;
                    foreach (Skrinka j in skrinky)
                    {
                        if (j.Vlastnik == i)
                        {
                            skrinky[indx].Vlastnik = null;
                        }
                        indx++;
                    }
                    ziaci.Remove(i);
                    if (ziaci.Count() == 0)
                    {
                        break;
                    }
                }
            }
            foreach (TreeNode i in treeViewVytvSkrVl.Nodes)
            {
                if (i.Text == meno)
                {
                    treeViewVytvSkrVl.Nodes.Remove(i);
                }
            }

            treeViewZiakVymz.SelectedNode.Remove();
        }
    }
}
