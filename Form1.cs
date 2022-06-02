using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;

namespace Pi1_Cs_projekt
{
    public partial class Form1 : Form
    {
        List<Ziak> ziaci = new List<Ziak>();
        List<Trieda> triedy = new List<Trieda>();
        List<Skrinka> skrinky = new List<Skrinka>();
        List<int> rocniky_pridane = new List<int>();

        public readonly string _pathTriedy = @"C:\Users\fsust\Source\Repos\Mihalik-Matej\Pi1-Cs-projekt\Json\TriedyUlozenie.JSON";
        public readonly string _pathZiak = @"C:\Users\fsust\Source\Repos\Mihalik-Matej\Pi1-Cs-projekt\Json\ZiakUlozenie.JSON";
        public readonly string _pathSkrinky = @"C:\Users\fsust\Source\Repos\Mihalik-Matej\Pi1-Cs-projekt\Json\SkrinkaUlozenie.JSON";
        public readonly string _pathRocnik = @"C:\Users\fsust\Source\Repos\Mihalik-Matej\Pi1-Cs-projekt\Json\RocnikUlozenie.JSON";
      
        private void Res_treeviewtrdupr()
        {
            treeViewTrdUpr.Nodes.Clear();
            foreach(int i in rocniky_pridane)
            {
                treeViewTrdUpr.Nodes.Add(i.ToString());
                int index = 0;
                foreach (Trieda j in triedy)
                {
                    if(j.Rocnik == i)
                    {
                        treeViewTrdUpr.Nodes[rocniky_pridane.IndexOf(j.Rocnik)].Nodes.Add(j.Meno);
                        treeViewTrdUpr.Nodes[rocniky_pridane.IndexOf(j.Rocnik)].Nodes[index].Tag = j;
                        treeViewTrdUpr.Nodes[rocniky_pridane.IndexOf(j.Rocnik)].Nodes[index].Nodes.Add(j.Meno);
                        treeViewTrdUpr.Nodes[rocniky_pridane.IndexOf(j.Rocnik)].Nodes[index].Nodes.Add(j.Odbor);
                        treeViewTrdUpr.Nodes[rocniky_pridane.IndexOf(j.Rocnik)].Nodes[index].Nodes.Add(j.Rocnik.ToString());
                        treeViewTrdUpr.Nodes[rocniky_pridane.IndexOf(j.Rocnik)].Nodes[index].Nodes.Add(j.TriednyUcitel);
                        index++;
                    }
                    
                }
            }
           
        }

        private void Res_treeviewtrdvymz()
        {
            treeViewTrdVymz.Nodes.Clear();
            foreach (int i in rocniky_pridane)
            {
                treeViewTrdVymz.Nodes.Add(i.ToString());
                int index = 0;
                foreach (Trieda j in triedy)
                {
                    if (j.Rocnik == i)
                    {
                        treeViewTrdVymz.Nodes[rocniky_pridane.IndexOf(j.Rocnik)].Nodes.Add(j.Meno);
                        treeViewTrdVymz.Nodes[rocniky_pridane.IndexOf(j.Rocnik)].Nodes[index].Tag = j;
                        index++;
                    }

                }
            }

        }

        private void Res_treeviewziakvymz()
        {
            treeViewZiakVymz.Nodes.Clear();
            int indexNT = 0;
            foreach(Trieda i in triedy)
            {
                treeViewZiakVymz.Nodes.Add(i.Meno);
                treeViewZiakVymz.Nodes[indexNT].Tag = i;
                int indexNZ = 0;
                foreach(Ziak j in ziaci)
                {
                    if(j.Trieda == i)
                    {
                        treeViewZiakVymz.Nodes[indexNT].Nodes.Add(j.MenoPriezvisko);
                        treeViewZiakVymz.Nodes[indexNT].Nodes[indexNZ].Tag = j;
                        indexNZ++;
                    }
                }
                indexNT++;
            }

        }

        private void Res_treeviewziakupr()
        {
            treeViewZiakUpr.Nodes.Clear();
            int indexNT = 0;
            foreach (Trieda i in triedy)
            {
                treeViewZiakUpr.Nodes.Add(i.Meno);
                treeViewZiakUpr.Nodes[indexNT].Tag = i;
                int indexNZ = 0;
                foreach (Ziak j in ziaci)
                {
                    if (j.Trieda == i)
                    {
                        treeViewZiakUpr.Nodes[indexNT].Nodes.Add(j.MenoPriezvisko);
                        treeViewZiakUpr.Nodes[indexNT].Nodes[indexNZ].Tag = j;
                        treeViewZiakUpr.Nodes[indexNT].Nodes[indexNZ].Nodes.Add(j.MenoPriezvisko);
                        treeViewZiakUpr.Nodes[indexNT].Nodes[indexNZ].Nodes.Add(j.PoradoveCislo.ToString());
                        treeViewZiakUpr.Nodes[indexNT].Nodes[indexNZ].Nodes.Add(j.Pohlavie);
                        treeViewZiakUpr.Nodes[indexNT].Nodes[indexNZ].Nodes.Add(j.Trieda.Meno);
                        treeViewZiakUpr.Nodes[indexNT].Nodes[indexNZ].Nodes.Add(j.DatumNarodenia.ToString());
                        treeViewZiakUpr.Nodes[indexNT].Nodes[indexNZ].Nodes[3].Tag = i;
                        indexNZ++;
                    }
                }
                indexNT++;
            }

        }

        private void Res_treeviewvytvvymzskrvl( TreeView treeView)
        {
            treeView.Nodes.Clear();
            int indexNT = 0;
            foreach (Trieda i in triedy)
            {
                treeView.Nodes.Add(i.Meno);
                treeView.Nodes[indexNT].Tag = i;
                int indexNZ = 0;
                foreach (Ziak j in ziaci)
                {
                    if (j.Trieda == i)
                    {
                        treeView.Nodes[indexNT].Nodes.Add(j.MenoPriezvisko);
                        treeView.Nodes[indexNT].Nodes[indexNZ].Tag = j;
                        indexNZ++;
                    }
                }
                indexNT++;
            }

        }

        private void Res_treeviewskrvymz()
        {
            treeViewSkrVymz.Nodes.Clear();
            int indexNS = 0;
            foreach (Skrinka i in skrinky)
            {
                treeViewSkrVymz.Nodes.Add(i.Cislo.ToString());
                treeViewSkrVymz.Nodes[indexNS].Tag = i;
                indexNS++;
            }
           

        }
        private void Res_treeviewskrupr()
        {
            treeViewSkrUpr.Nodes.Clear();
            int indexNS = 0;
            foreach (Skrinka i in skrinky)
            {
                treeViewSkrUpr.Nodes.Add(i.Cislo.ToString());
                treeViewSkrUpr.Nodes[indexNS].Tag = i;
                treeViewSkrUpr.Nodes[indexNS].Nodes.Add(i.Cislo.ToString());
                treeViewSkrUpr.Nodes[indexNS].Nodes.Add(i.Poznamka);
                treeViewSkrUpr.Nodes[indexNS].Nodes.Add(i.Vlastnik.MenoPriezvisko);
                treeViewSkrUpr.Nodes[indexNS].Nodes[2].Tag = i.Vlastnik;
                indexNS++;
            }


        }

        private void  Combobox_res(ComboBox combobox)
        {
            combobox.Items.Clear();
            foreach (Trieda i in triedy)
            {
                combobox.Items.Add(i.Meno);
            }
        }

        private void Reset()
        {
            Res_treeviewtrdupr();
            Res_treeviewtrdvymz();

            Res_treeviewziakupr();
            Res_treeviewziakvymz();
            Res_treeviewvytvvymzskrvl(treeViewVytvSkrVl);
            Res_treeviewvytvvymzskrvl(treeViewVymzSkrVl);
            Res_treeviewvytvvymzskrvl(treeViewUprSkrVl);
            Res_treeviewvytvvymzskrvl(treeViewUprSkrVlnv);

            Res_treeviewskrupr();
            Res_treeviewskrvymz();

            Combobox_res(comboBoxVytvZiakTr);
            Combobox_res(comboBoxVytvZiakTrHr);
            Combobox_res(comboBoxVytvZiakTrOdDoHr);
            Combobox_res(comboBoxVytvSkrTrd);
            Combobox_res(comboBoxVymzZiakTr);
            Combobox_res(comboBoxUprZiakTrd);
            Combobox_res(comboBoxUprZiakTrdnv);
        }
            

    public Form1()
        {
            InitializeComponent();

            triedy.Add(new Trieda("Nezaradený", "žiaden", "nikto", 0));
            ziaci.Add(new Ziak("Nikto", 0, "žiadne", new DateTime(1),triedy[0]));
            rocniky_pridane.Add(0);

            string jsonString2zob = File.ReadAllText(_pathTriedy);
            triedy = JsonSerializer.Deserialize<List<Trieda>>(jsonString2zob);

            string jsonString3zob = File.ReadAllText(_pathSkrinky);
            skrinky = JsonSerializer.Deserialize<List<Skrinka>>(jsonString3zob);

            string jsonString4zob = File.ReadAllText(_pathZiak);
            ziaci = JsonSerializer.Deserialize<List<Ziak>>(jsonString4zob);

            foreach(Trieda i in triedy)
            {
                if(!rocniky_pridane.Contains(i.Rocnik))
                {
                    rocniky_pridane.Add(i.Rocnik);
                }
            }

            Reset();

        }

        private void buttonVytvSkr_Click(object sender, EventArgs e)
        {
            try
            {
                Ziak vlastnik = ziaci[0] ;
                foreach(Ziak i in ziaci)
                {
                    if(i == treeViewVytvSkrVl.SelectedNode.Tag)
                    {
                        vlastnik = i;
                    }
                }
                skrinky.Add(new Skrinka(int.Parse(textBoxVytvSkrCs.Text), richTextBoxVytvSkrPoz.Text, vlastnik));
                Reset();
            }
            catch
            {
                MessageBox.Show("Nespravne zadané vlastnosti");
            }
        }

        private void buttonVytvTr_Click(object sender, EventArgs e)
        {


            triedy.Add(new Trieda(textBoxVytvTrNz.Text, textBoxVytvTrOd.Text, textBoxVytvTrTu.Text, int.Parse(textBoxVytvTrRc.Text)));


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
                rocniky_pridane.Add(int.Parse(textBoxVytvTrRc.Text));
            }

            Reset();



        }

        private void buttonVytvZiak_Click(object sender, EventArgs e)
        {

            ziaci.Add(new Ziak(textBoxVytvZiakMP.Text, int.Parse(textBoxVytvZiakPC.Text), comboBoxVytvZiakPoh.SelectedItem.ToString(), dateTimePickerVytvZiakDN.Value, triedy[comboBoxVytvZiakTr.SelectedIndex]));
            Reset();
        }

        private void buttonSkrVymz_Click(object sender, EventArgs e)
        {
            Skrinka skrinka = null;
            foreach (TreeNode i in treeViewSkrVymz.Nodes)
            {
                if (i.Tag == treeViewSkrVymz.SelectedNode.Tag && treeViewSkrVymz.SelectedNode.Tag != ziaci[0] && treeViewSkrVymz.SelectedNode.Tag != triedy[0]) 
                {
                    skrinka = (Skrinka)i.Tag;
                }
            }  
            foreach (Skrinka i in skrinky)
            {
                if (i == skrinka)
                {
                    skrinky.Remove(i);
                    if (skrinky.Count() == 0)
                    {
                        break;
                    }
                    break;
                }
            }
            Reset();
        }

        private void buttonTrdVymz_Click(object sender, EventArgs e)
        {
            Trieda trieda = null;
            foreach (TreeNode i in treeViewTrdVymz.Nodes)
            {
                foreach (TreeNode j in treeViewTrdVymz.Nodes[i.Index].Nodes)
                {
                    if (j.Tag == treeViewTrdVymz.SelectedNode.Tag && treeViewTrdVymz.SelectedNode.Tag != ziaci[0] && treeViewTrdVymz.SelectedNode.Tag != triedy[0])
                    {
                        trieda = (Trieda)j.Tag;
                    }
                }    
            }
            foreach (Trieda i in triedy)
            {
                if (i == trieda)
                {
                    int indx = 0;
                    foreach (Ziak j in ziaci)
                    {
                        if (j.Trieda == i)
                        {
                            ziaci[indx].Trieda = triedy[0];
                            Reset();
                        }
                        indx++;
                    }
                    triedy.Remove(i);
                    break;
                }
            }
            foreach (TreeNode i in treeViewTrdVymz.Nodes)
            {
                foreach(TreeNode j in treeViewTrdVymz.Nodes[i.Index].Nodes)
                {
                    if (j.Tag == trieda) 
                    {
                        treeViewTrdVymz.Nodes[i.Index].Nodes.Remove(j);
                        break;
                    }
                }
            }
            Reset();

        }

        private void buttonZiakVymz_Click(object sender, EventArgs e)
        {
            Ziak ziak = null ;  

            foreach(TreeNode i in treeViewZiakVymz.Nodes)
            {
                foreach (TreeNode j in treeViewZiakVymz.Nodes[i.Index].Nodes)
                {
                    if (j.Tag == treeViewZiakVymz.SelectedNode.Tag && treeViewZiakVymz.SelectedNode.Tag != ziaci[0] && treeViewZiakVymz.SelectedNode.Tag != triedy[0])
                    {
                        ziak = (Ziak)j.Tag;
                    }
                }
                
            }
            foreach (TreeNode i in treeViewZiakUpr.Nodes)
            {
                foreach(TreeNode j in treeViewZiakUpr.Nodes[i.Index].Nodes)
                {
                    if (j.Tag == ziak)
                    {
                        treeViewZiakUpr.Nodes[i.Index].Nodes.Remove(j);
                        break;
                    }
                }
            }

            foreach (Ziak i in ziaci)
            {
                if(i == ziak)
                {
                    int indx = 0;
                    foreach (Skrinka j in skrinky)
                    {
                        if (j.Vlastnik == i)
                        {
                            skrinky[indx].Vlastnik = ziaci[0];
                            Reset();
                        }
                        indx++;
                    }
                    ziaci.Remove(i);  
                    if (ziaci.Count() == 0)
                    {
                        break;
                    }
                    break;
                }
            }

            Reset();

        }
    


        private void treeViewTrdUpr_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (treeViewTrdUpr.SelectedNode.Tag != ziaci[0] && treeViewTrdUpr.SelectedNode.Tag != triedy[0])
                    treeViewTrdUpr.SelectedNode.BeginEdit();
            }

            catch
            {
                MessageBox.Show("Uprava nie je mozna");
            }

        }

        private void treeViewSkrUpr_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if(treeViewSkrUpr.SelectedNode.Tag != triedy[0])
                    treeViewSkrUpr.SelectedNode.BeginEdit();
            }
            catch
            {
                MessageBox.Show("Uprava nie je mozna");
            }
        }

        private void treeViewZiakUpr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if(treeViewZiakUpr.SelectedNode.Tag != ziaci[0] && treeViewZiakUpr.SelectedNode.Tag != triedy[0])
                    treeViewZiakUpr.SelectedNode.BeginEdit();
            }
            catch
            {
                MessageBox.Show("Uprava nie je mozna");
            }
        }



        private void buttonSkrUprPtvZm_Click(object sender, EventArgs e)
        {
            foreach (TreeNode i in treeViewSkrUpr.Nodes) 
            { 
                foreach (Skrinka j in skrinky) 
                {
                    if(j == i.Tag)
                    {
                        foreach(TreeNode k in treeViewSkrUpr.Nodes[i.Index].Nodes)
                        {
                            if (k.Index == 0)
                                skrinky[skrinky.IndexOf(j)].Cislo = int.Parse(treeViewSkrUpr.Nodes[i.Index].Nodes[k.Index].Text);
                            else if (k.Index == 1)
                                skrinky[skrinky.IndexOf(j)].Poznamka = treeViewSkrUpr.Nodes[i.Index].Nodes[k.Index].Text;
                            else if (k.Index == 2)
                                foreach(Ziak z in ziaci)
                                {
                                    if (z.MenoPriezvisko == treeViewSkrUpr.Nodes[i.Index].Nodes[k.Index].Text)
                                    {
                                        skrinky[skrinky.IndexOf(j)].Vlastnik = z;
                                    }
                                }

                            


               
                        }
                    }
                }
            }
            Reset();


        }

        private void buttonTrdUprPtvZm_Click(object sender, EventArgs e)
        {
            foreach(TreeNode i in treeViewTrdUpr.Nodes) 
            {
                foreach(TreeNode j in treeViewTrdUpr.Nodes[i.Index].Nodes) 
                {
                    foreach(Trieda l in triedy)
                    {
                        if (j.Tag == l)
                        {
                            foreach (TreeNode k in treeViewTrdUpr.Nodes[i.Index].Nodes[j.Index].Nodes)
                            {
                                
                                if(k.Index == 0)
                                    triedy[triedy.IndexOf(l)].Meno = treeViewTrdUpr.Nodes[i.Index].Nodes[j.Index].Nodes[k.Index].Text;
                                else if (k.Index == 1)
                                    triedy[triedy.IndexOf(l)].Odbor = treeViewTrdUpr.Nodes[i.Index].Nodes[j.Index].Nodes[k.Index].Text;
                                else if (k.Index == 2)
                                {
                                    triedy[triedy.IndexOf(l)].Rocnik = int.Parse(treeViewTrdUpr.Nodes[i.Index].Nodes[j.Index].Nodes[k.Index].Text);

                                    bool x = true;
                                    int index = 0;
                                    foreach (int r in rocniky_pridane)
                                    {
                                        if (r == int.Parse(treeViewTrdUpr.Nodes[i.Index].Nodes[j.Index].Nodes[k.Index].Text))
                                        {
                                            x = false;
                                            break;
                                        }
                                        index++;
                                    }
                                    if (x)
                                    {
                                        rocniky_pridane.Add(int.Parse(treeViewTrdUpr.Nodes[i.Index].Nodes[j.Index].Nodes[k.Index].Text));
                                    }


                                }
                                    
                                else if (k.Index == 3)
                                    triedy[triedy.IndexOf(l)].TriednyUcitel = treeViewTrdUpr.Nodes[i.Index].Nodes[j.Index].Nodes[k.Index].Text;
                               

                            }
                        }
                    }
                }
            }
            Reset();
            /*
            comboBoxVytvZiakTr.Items.Clear();
            foreach(Trieda i in triedy)
            {
                comboBoxVytvZiakTr.Items.Add(i.Meno);
            }*/
        }

        private void buttonZiakUprPtvZm_Click(object sender, EventArgs e)
        {
            foreach(TreeNode i in treeViewZiakUpr.Nodes)
            {
                foreach(TreeNode j in treeViewZiakUpr.Nodes[i.Index].Nodes) 
                {
                    foreach(Ziak z in ziaci) 
                    {
                        if(j.Tag == z) 
                        {
                            foreach(TreeNode k in treeViewZiakUpr.Nodes[i.Index].Nodes[j.Index].Nodes) 
                            {
                                if (k.Index == 0)
                                    ziaci[ziaci.IndexOf(z)].MenoPriezvisko = treeViewZiakUpr.Nodes[i.Index].Nodes[j.Index].Nodes[k.Index].Text;
                                else if (k.Index == 1)
                                    ziaci[ziaci.IndexOf(z)].PoradoveCislo = int.Parse(treeViewZiakUpr.Nodes[i.Index].Nodes[j.Index].Nodes[k.Index].Text);
                                else if (k.Index == 2)
                                    ziaci[ziaci.IndexOf(z)].Pohlavie = treeViewZiakUpr.Nodes[i.Index].Nodes[j.Index].Nodes[k.Index].Text;
                                else if (k.Index == 3)
                                    foreach (Trieda l in triedy)
                                    {
                                        if (l.Meno == treeViewZiakUpr.Nodes[i.Index].Nodes[j.Index].Nodes[k.Index].Text)
                                        {
                                            ziaci[ziaci.IndexOf(z)].Trieda = l;
                                        }
                                    }
                               
                                else if (k.Index == 4)
                                    ziaci[ziaci.IndexOf(z)].DatumNarodenia = DateTime.Parse(treeViewZiakUpr.Nodes[i.Index].Nodes[j.Index].Nodes[k.Index].Text);

                            }
                        }
                    }
                }
            }
            Reset();
        }

        private void buttonSkrUprRsZm_Click(object sender, EventArgs e)
        {
            Res_treeviewskrupr();
        }

        private void buttonTrdUprRsZm_Click(object sender, EventArgs e)
        {
            Res_treeviewtrdupr();
        }

        private void buttonZiakUprRsZm_Click(object sender, EventArgs e)
        {
            Res_treeviewziakupr();
        }




        private void buttonVytvTrHr_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < int.Parse(textBoxVytvTrPocHr.Text);i++)
            {
                triedy.Add(new Trieda(textBoxVytvTrNzHr.Text, textBoxVytvTrOdHr.Text, textBoxVytvTrTuHr.Text, int.Parse(textBoxVytvTrRcHr.Text)));
            }

            bool x = true;
            int index = 0;
            foreach (int j in rocniky_pridane)
            {
                if (j == int.Parse(textBoxVytvTrRcHr.Text))
                {
                    x = false;
                    break;
                }
                index++;
            }
            if (x)
            {
                rocniky_pridane.Add(int.Parse(textBoxVytvTrRcHr.Text));
            }

            Reset();
        }

        private void buttonVytvTrHrOdDo_Click(object sender, EventArgs e)
        {
            for (int i = int.Parse(textBoxVytvTrRcHrOd.Text); i <= int.Parse(textBoxVytvTrRcHrDo.Text); i++)
            {
                triedy.Add(new Trieda(i.ToString() + "." + textBoxVytvTrOdbHrOdDo.Text, textBoxVytvTrOdbHrOdDo.Text, " " , i));
                bool x = true;
                int index = 0;
                foreach (int j in rocniky_pridane)
                {
                    if (j == i)
                    {
                        x = false;
                        break;
                    }
                    index++;
                }
                if (x)
                {
                    rocniky_pridane.Add(i);
                }
            }


            Reset();
        }



        private void buttonVytvZiakHr_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < int.Parse(textBoxVytvZiakPocHr.Text); i++)
            {
                ziaci.Add(new Ziak(textBoxVytvZiakMPHr.Text,int.Parse(textBoxVytvZiakPCHr.Text),comboBoxVytvZiakPohHr.SelectedItem.ToString(),dateTimePickerVytvZiakDNHr.Value, triedy[comboBoxVytvZiakTrHr.SelectedIndex]));
            }

            Reset();
        }

        private void buttonVytvZiakHrTr_Click(object sender, EventArgs e)
        {
            for (int i = int.Parse(textBoxVytvZiakPCOdHr.Text); i <= int.Parse(textBoxVytvZiakPCDoHr.Text); i++)
            {
                ziaci.Add(new Ziak("", i,"", new DateTime(1), triedy[comboBoxVytvZiakTrOdDoHr.SelectedIndex])) ;
            }

            Reset();
        }




        private void buttonVytvSkrHr_Click(object sender, EventArgs e)
        {
            for (int i = int.Parse(textBoxVytvSkrCsOd.Text); i < int.Parse(textBoxVytvSkrCsDo.Text); i++)
            {
                skrinky.Add(new Skrinka(i,richTextBoxVytvSkrPozHr.Text,ziaci[0]));
            }
            Reset();
        }

        private void buttonVytvSkrHrTr_Click(object sender, EventArgs e)
        {
            int cislo = 1;
            foreach (Ziak i in ziaci)
            {
                if(i.Trieda == triedy[comboBoxVytvZiakTrOdDoHr.SelectedIndex])
                {
                    skrinky.Add(new Skrinka(cislo,"",i));
                    cislo++;
                }
            }
            Reset();
        }


        private void buttonTrdVymzHr_Click(object sender, EventArgs e)
        {

            List<Trieda> triedy_vymazanie = new List<Trieda>();
            
            foreach (Trieda i in triedy)
            {
                if (checkBoxVymzTrNz.Checked && checkBoxVymzTrOd.Checked && checkBoxVymzTrRc.Checked && checkBoxVymzTrTu.Checked)
                {
                    if (i.Meno == textBoxVymzTrNz.Text && i.Odbor == textBoxVymzTrOd.Text && i.Rocnik == int.Parse(textBoxVymzTrRc.Text) && i.TriednyUcitel == textBoxVymzTrTu.Text)
                    {
                        triedy_vymazanie.Add(i);
                    }
                }
                else if(checkBoxVymzTrNz.Checked && checkBoxVymzTrOd.Checked && checkBoxVymzTrRc.Checked && !checkBoxVymzTrTu.Checked)
                {
                    if (i.Meno == textBoxVymzTrNz.Text && i.Odbor == textBoxVymzTrOd.Text && i.Rocnik == int.Parse(textBoxVymzTrRc.Text))
                    {
                        triedy_vymazanie.Add(i);
                    }
                }
                else if(checkBoxVymzTrNz.Checked && checkBoxVymzTrOd.Checked && !checkBoxVymzTrRc.Checked && checkBoxVymzTrTu.Checked)
                {
                    if (i.Meno == textBoxVymzTrNz.Text && i.Odbor == textBoxVymzTrOd.Text && i.TriednyUcitel == textBoxVymzTrTu.Text)
                    {
                        triedy_vymazanie.Add(i);
                    }
                }
                else if(checkBoxVymzTrNz.Checked && !checkBoxVymzTrOd.Checked && checkBoxVymzTrRc.Checked && checkBoxVymzTrTu.Checked)
                {
                    if (i.Meno == textBoxVymzTrNz.Text &&  i.Rocnik == int.Parse(textBoxVymzTrRc.Text) && i.TriednyUcitel == textBoxVymzTrTu.Text)
                    {
                        triedy_vymazanie.Add(i);
                    }
                }
                else if(!checkBoxVymzTrNz.Checked && checkBoxVymzTrOd.Checked && checkBoxVymzTrRc.Checked && checkBoxVymzTrTu.Checked)
                {
                    if (i.Rocnik == int.Parse(textBoxVymzTrRc.Text) && i.TriednyUcitel == textBoxVymzTrTu.Text && i.TriednyUcitel == textBoxVymzTrTu.Text)
                    {
                        triedy_vymazanie.Add(i);
                    }
                }
                else if(checkBoxVymzTrNz.Checked && checkBoxVymzTrOd.Checked && !checkBoxVymzTrRc.Checked && !checkBoxVymzTrTu.Checked)
                {
                    if (i.Meno == textBoxVymzTrNz.Text && i.Odbor == textBoxVymzTrOd.Text)
                    {
                        triedy_vymazanie.Add(i);
                    }
                }
                else if(checkBoxVymzTrNz.Checked && !checkBoxVymzTrOd.Checked && checkBoxVymzTrRc.Checked && !checkBoxVymzTrTu.Checked)
                {
                    if (i.Meno == textBoxVymzTrNz.Text && i.Rocnik == int.Parse(textBoxVymzTrRc.Text) )
                    {
                        triedy_vymazanie.Add(i);
                    }
                }
                else if(!checkBoxVymzTrNz.Checked && checkBoxVymzTrOd.Checked && checkBoxVymzTrRc.Checked && !checkBoxVymzTrTu.Checked)
                {
                    if (i.Odbor == textBoxVymzTrOd.Text && i.Rocnik == int.Parse(textBoxVymzTrRc.Text))
                    {
                        triedy_vymazanie.Add(i);
                    }
                }
                else if(checkBoxVymzTrNz.Checked && !checkBoxVymzTrOd.Checked && !checkBoxVymzTrRc.Checked && checkBoxVymzTrTu.Checked)
                {
                    if (i.Meno == textBoxVymzTrNz.Text && i.TriednyUcitel == textBoxVymzTrTu.Text)
                    {
                        triedy_vymazanie.Add(i);
                    }
                }
                else if(!checkBoxVymzTrNz.Checked && checkBoxVymzTrOd.Checked && !checkBoxVymzTrRc.Checked && checkBoxVymzTrTu.Checked)
                {
                    if (i.Odbor == textBoxVymzTrOd.Text && i.TriednyUcitel == textBoxVymzTrTu.Text)
                    {
                        triedy_vymazanie.Add(i);
                    }
                }
                else if(!checkBoxVymzTrNz.Checked && !checkBoxVymzTrOd.Checked && checkBoxVymzTrRc.Checked && checkBoxVymzTrTu.Checked)
                {
                    if (i.Rocnik == int.Parse(textBoxVymzTrRc.Text) && i.TriednyUcitel == textBoxVymzTrTu.Text)
                    {
                        triedy_vymazanie.Add(i);
                    }
                }
                else if(checkBoxVymzTrNz.Checked && !checkBoxVymzTrOd.Checked && !checkBoxVymzTrRc.Checked && !checkBoxVymzTrTu.Checked)
                {
                    if (i.Meno == textBoxVymzTrNz.Text)
                    {
                        triedy_vymazanie.Add(i);
                    }
                }
                else if(!checkBoxVymzTrNz.Checked && checkBoxVymzTrOd.Checked && !checkBoxVymzTrRc.Checked && !checkBoxVymzTrTu.Checked)
                {
                    if (i.Odbor == textBoxVymzTrOd.Text)
                    {
                        triedy_vymazanie.Add(i);
                    }
                }
                else if(!checkBoxVymzTrNz.Checked && !checkBoxVymzTrOd.Checked && checkBoxVymzTrRc.Checked && !checkBoxVymzTrTu.Checked)
                {
                    if (i.Rocnik == int.Parse(textBoxVymzTrRc.Text))
                    {
                        triedy_vymazanie.Add(i);
                    }
                }
                else if(!checkBoxVymzTrNz.Checked && !checkBoxVymzTrOd.Checked && !checkBoxVymzTrRc.Checked && checkBoxVymzTrTu.Checked)
                {
                    if (i.TriednyUcitel == textBoxVymzTrTu.Text)
                    {
                        triedy_vymazanie.Add(i);
                    }
                }
            }
            
            foreach (Trieda i in triedy_vymazanie)
            {
                triedy.Remove(i);
                int indx = 0;
                foreach (Ziak j in ziaci)
                {
                    if(j.Trieda == i)
                    {
                        ziaci[indx].Trieda = triedy[0];
                    }
                    indx++;
                }
            }

            Reset();

        }


        private void buttonZiakVymzHr_Click(object sender, EventArgs e)
        {
            List<Ziak> ziaci_vymazanie = new List<Ziak>();

            foreach (Ziak i in ziaci)
            {
                if (checkBoxVymzZiakMP.Checked && checkBoxVymzZiakPC.Checked && checkBoxVymzZiakDN.Checked && checkBoxVymzZiakPoh.Checked && checkBoxVymzZiakTr.Checked)
                {
                    if (i.MenoPriezvisko == textBoxVymzZiakMP.Text && i.PoradoveCislo == int.Parse(textBoxVymzZiakPC.Text) && i.DatumNarodenia == dateTimePickerVymzZiakDN.Value && i.Pohlavie == comboBoxVymzZiakPoh.SelectedItem.ToString() && i.Trieda == triedy[comboBoxVymzZiakTr.SelectedIndex])
                    {
                        ziaci_vymazanie.Add(i);
                    }
                }
                else if(checkBoxVymzZiakMP.Checked && checkBoxVymzZiakPC.Checked && checkBoxVymzZiakDN.Checked && checkBoxVymzZiakPoh.Checked && !checkBoxVymzZiakTr.Checked)
                {
                    if (i.MenoPriezvisko == textBoxVymzZiakMP.Text && i.PoradoveCislo == int.Parse(textBoxVymzZiakPC.Text) && i.DatumNarodenia == dateTimePickerVymzZiakDN.Value && i.Pohlavie == comboBoxVymzZiakPoh.SelectedItem.ToString())
                    {
                        ziaci_vymazanie.Add(i);
                    }

                }
                else if(checkBoxVymzZiakMP.Checked && checkBoxVymzZiakPC.Checked && checkBoxVymzZiakDN.Checked && !checkBoxVymzZiakPoh.Checked && checkBoxVymzZiakTr.Checked)
                {
                    if (i.MenoPriezvisko == textBoxVymzZiakMP.Text && i.PoradoveCislo == int.Parse(textBoxVymzZiakPC.Text) && i.DatumNarodenia == dateTimePickerVymzZiakDN.Value && i.Trieda == triedy[comboBoxVymzZiakTr.SelectedIndex])
                    {
                        ziaci_vymazanie.Add(i);
                    }

                }
                else if(checkBoxVymzZiakMP.Checked && checkBoxVymzZiakPC.Checked && !checkBoxVymzZiakDN.Checked && checkBoxVymzZiakPoh.Checked && checkBoxVymzZiakTr.Checked)
                {
                    if (i.MenoPriezvisko == textBoxVymzZiakMP.Text && i.PoradoveCislo == int.Parse(textBoxVymzZiakPC.Text) && i.Pohlavie == comboBoxVymzZiakPoh.SelectedItem.ToString() && i.Trieda == triedy[comboBoxVymzZiakTr.SelectedIndex])
                    {
                        ziaci_vymazanie.Add(i);
                    }

                }
                else if(checkBoxVymzZiakMP.Checked && !checkBoxVymzZiakPC.Checked && checkBoxVymzZiakDN.Checked && checkBoxVymzZiakPoh.Checked && checkBoxVymzZiakTr.Checked)
                {
                    if (i.MenoPriezvisko == textBoxVymzZiakMP.Text && i.DatumNarodenia == dateTimePickerVymzZiakDN.Value && i.Pohlavie == comboBoxVymzZiakPoh.SelectedItem.ToString() && i.Trieda == triedy[comboBoxVymzZiakTr.SelectedIndex])
                    {
                        ziaci_vymazanie.Add(i);
                    }

                }
                else if(!checkBoxVymzZiakMP.Checked && checkBoxVymzZiakPC.Checked && checkBoxVymzZiakDN.Checked && checkBoxVymzZiakPoh.Checked && checkBoxVymzZiakTr.Checked)
                {
                    if (i.PoradoveCislo == int.Parse(textBoxVymzZiakPC.Text) && i.DatumNarodenia == dateTimePickerVymzZiakDN.Value && i.Pohlavie == comboBoxVymzZiakPoh.SelectedItem.ToString() && i.Trieda == triedy[comboBoxVymzZiakTr.SelectedIndex])
                    {
                        ziaci_vymazanie.Add(i);
                    }

                }
                else if(checkBoxVymzZiakMP.Checked && checkBoxVymzZiakPC.Checked && checkBoxVymzZiakDN.Checked && !checkBoxVymzZiakPoh.Checked && !checkBoxVymzZiakTr.Checked)
                {
                    if (i.MenoPriezvisko == textBoxVymzZiakMP.Text && i.PoradoveCislo == int.Parse(textBoxVymzZiakPC.Text) && i.DatumNarodenia == dateTimePickerVymzZiakDN.Value)
                    {
                        ziaci_vymazanie.Add(i);
                    }

                }
                else if(checkBoxVymzZiakMP.Checked && checkBoxVymzZiakPC.Checked && !checkBoxVymzZiakDN.Checked && checkBoxVymzZiakPoh.Checked && !checkBoxVymzZiakTr.Checked)
                {
                    if (i.MenoPriezvisko == textBoxVymzZiakMP.Text && i.PoradoveCislo == int.Parse(textBoxVymzZiakPC.Text) && i.Pohlavie == comboBoxVymzZiakPoh.SelectedItem.ToString())
                    {
                        ziaci_vymazanie.Add(i);
                    }

                }
                else if(checkBoxVymzZiakMP.Checked && !checkBoxVymzZiakPC.Checked && checkBoxVymzZiakDN.Checked && checkBoxVymzZiakPoh.Checked && !checkBoxVymzZiakTr.Checked)
                {
                    if (i.MenoPriezvisko == textBoxVymzZiakMP.Text  && i.DatumNarodenia == dateTimePickerVymzZiakDN.Value && i.Pohlavie == comboBoxVymzZiakPoh.SelectedItem.ToString())
                    {
                        ziaci_vymazanie.Add(i);
                    }

                }
                else if(!checkBoxVymzZiakMP.Checked && checkBoxVymzZiakPC.Checked && checkBoxVymzZiakDN.Checked && checkBoxVymzZiakPoh.Checked && !checkBoxVymzZiakTr.Checked)
                {
                    if (i.PoradoveCislo == int.Parse(textBoxVymzZiakPC.Text) && i.DatumNarodenia == dateTimePickerVymzZiakDN.Value && i.Pohlavie == comboBoxVymzZiakPoh.SelectedItem.ToString())
                    {
                        ziaci_vymazanie.Add(i);
                    }

                }
                else if(checkBoxVymzZiakMP.Checked && checkBoxVymzZiakPC.Checked && !checkBoxVymzZiakDN.Checked && !checkBoxVymzZiakPoh.Checked && checkBoxVymzZiakTr.Checked)
                {
                    if (i.MenoPriezvisko == textBoxVymzZiakMP.Text && i.PoradoveCislo == int.Parse(textBoxVymzZiakPC.Text) &&  i.Trieda == triedy[comboBoxVymzZiakTr.SelectedIndex])
                    {
                        ziaci_vymazanie.Add(i);
                    }

                }
                else if(checkBoxVymzZiakMP.Checked && !checkBoxVymzZiakPC.Checked && checkBoxVymzZiakDN.Checked && !checkBoxVymzZiakPoh.Checked && checkBoxVymzZiakTr.Checked)
                {
                    if (i.MenoPriezvisko == textBoxVymzZiakMP.Text && i.DatumNarodenia == dateTimePickerVymzZiakDN.Value && i.Trieda == triedy[comboBoxVymzZiakTr.SelectedIndex])
                    {
                        ziaci_vymazanie.Add(i);
                    }

                }
                else if(!checkBoxVymzZiakMP.Checked && checkBoxVymzZiakPC.Checked && checkBoxVymzZiakDN.Checked && !checkBoxVymzZiakPoh.Checked && checkBoxVymzZiakTr.Checked)
                {
                    if (i.PoradoveCislo == int.Parse(textBoxVymzZiakPC.Text) && i.DatumNarodenia == dateTimePickerVymzZiakDN.Value && i.Trieda == triedy[comboBoxVymzZiakTr.SelectedIndex])
                    {
                        ziaci_vymazanie.Add(i);
                    }

                }
                else if(checkBoxVymzZiakMP.Checked && !checkBoxVymzZiakPC.Checked && !checkBoxVymzZiakDN.Checked && checkBoxVymzZiakPoh.Checked && checkBoxVymzZiakTr.Checked)
                {
                    if (i.MenoPriezvisko == textBoxVymzZiakMP.Text && i.Pohlavie == comboBoxVymzZiakPoh.SelectedItem.ToString() && i.Trieda == triedy[comboBoxVymzZiakTr.SelectedIndex])
                    {
                        ziaci_vymazanie.Add(i);
                    }

                }
                else if(!checkBoxVymzZiakMP.Checked && checkBoxVymzZiakPC.Checked && !checkBoxVymzZiakDN.Checked && checkBoxVymzZiakPoh.Checked && checkBoxVymzZiakTr.Checked)
                {
                    if (i.PoradoveCislo == int.Parse(textBoxVymzZiakPC.Text) && i.Pohlavie == comboBoxVymzZiakPoh.SelectedItem.ToString() && i.Trieda == triedy[comboBoxVymzZiakTr.SelectedIndex])
                    {
                        ziaci_vymazanie.Add(i);
                    }

                }
                else if(!checkBoxVymzZiakMP.Checked && !checkBoxVymzZiakPC.Checked && checkBoxVymzZiakDN.Checked && checkBoxVymzZiakPoh.Checked && checkBoxVymzZiakTr.Checked)
                {
                    if (i.DatumNarodenia == dateTimePickerVymzZiakDN.Value && i.Pohlavie == comboBoxVymzZiakPoh.SelectedItem.ToString() && i.Trieda == triedy[comboBoxVymzZiakTr.SelectedIndex])
                    {
                        ziaci_vymazanie.Add(i);
                    }

                }
                else if(checkBoxVymzZiakMP.Checked && checkBoxVymzZiakPC.Checked && !checkBoxVymzZiakDN.Checked && !checkBoxVymzZiakPoh.Checked && !checkBoxVymzZiakTr.Checked)
                {
                    if (i.MenoPriezvisko == textBoxVymzZiakMP.Text && i.PoradoveCislo == int.Parse(textBoxVymzZiakPC.Text))
                    {
                        ziaci_vymazanie.Add(i);
                    }

                }
                else if(checkBoxVymzZiakMP.Checked && !checkBoxVymzZiakPC.Checked && checkBoxVymzZiakDN.Checked && !checkBoxVymzZiakPoh.Checked && !checkBoxVymzZiakTr.Checked)
                {
                    if (i.MenoPriezvisko == textBoxVymzZiakMP.Text && i.DatumNarodenia == dateTimePickerVymzZiakDN.Value)
                    {
                        ziaci_vymazanie.Add(i);
                    }

                }
                else if(!checkBoxVymzZiakMP.Checked && checkBoxVymzZiakPC.Checked && checkBoxVymzZiakDN.Checked && !checkBoxVymzZiakPoh.Checked && !checkBoxVymzZiakTr.Checked)
                {
                    if (i.PoradoveCislo == int.Parse(textBoxVymzZiakPC.Text) && i.DatumNarodenia == dateTimePickerVymzZiakDN.Value)
                    {
                        ziaci_vymazanie.Add(i);
                    }

                }
                else if(checkBoxVymzZiakMP.Checked && !checkBoxVymzZiakPC.Checked && !checkBoxVymzZiakDN.Checked && checkBoxVymzZiakPoh.Checked && !checkBoxVymzZiakTr.Checked)
                {
                    if (i.MenoPriezvisko == textBoxVymzZiakMP.Text && i.Pohlavie == comboBoxVymzZiakPoh.SelectedItem.ToString())
                    {
                        ziaci_vymazanie.Add(i);
                    }

                }
                else if(!checkBoxVymzZiakMP.Checked && checkBoxVymzZiakPC.Checked && !checkBoxVymzZiakDN.Checked && checkBoxVymzZiakPoh.Checked && !checkBoxVymzZiakTr.Checked)
                {
                    if (i.PoradoveCislo == int.Parse(textBoxVymzZiakPC.Text) && i.Pohlavie == comboBoxVymzZiakPoh.SelectedItem.ToString())
                    {
                        ziaci_vymazanie.Add(i);
                    }

                }
                else if(!checkBoxVymzZiakMP.Checked && !checkBoxVymzZiakPC.Checked && checkBoxVymzZiakDN.Checked && checkBoxVymzZiakPoh.Checked && !checkBoxVymzZiakTr.Checked)
                {
                    if (i.DatumNarodenia == dateTimePickerVymzZiakDN.Value && i.Pohlavie == comboBoxVymzZiakPoh.SelectedItem.ToString())
                    {
                        ziaci_vymazanie.Add(i);
                    }

                }
                else if(checkBoxVymzZiakMP.Checked && !checkBoxVymzZiakPC.Checked && !checkBoxVymzZiakDN.Checked && !checkBoxVymzZiakPoh.Checked && checkBoxVymzZiakTr.Checked)
                {
                    if (i.MenoPriezvisko == textBoxVymzZiakMP.Text && i.Trieda == triedy[comboBoxVymzZiakTr.SelectedIndex])
                    {
                        ziaci_vymazanie.Add(i);
                    }

                }
                else if(!checkBoxVymzZiakMP.Checked && checkBoxVymzZiakPC.Checked && !checkBoxVymzZiakDN.Checked && !checkBoxVymzZiakPoh.Checked && checkBoxVymzZiakTr.Checked)
                {
                    if (i.PoradoveCislo == int.Parse(textBoxVymzZiakPC.Text) && i.Trieda == triedy[comboBoxVymzZiakTr.SelectedIndex])
                    {
                        ziaci_vymazanie.Add(i);
                    }

                }
                else if(!checkBoxVymzZiakMP.Checked && !checkBoxVymzZiakPC.Checked && checkBoxVymzZiakDN.Checked && !checkBoxVymzZiakPoh.Checked && checkBoxVymzZiakTr.Checked)
                {
                    if (i.DatumNarodenia == dateTimePickerVymzZiakDN.Value  && i.Trieda == triedy[comboBoxVymzZiakTr.SelectedIndex])
                    {
                        ziaci_vymazanie.Add(i);
                    }

                }
                else if(!checkBoxVymzZiakMP.Checked && !checkBoxVymzZiakPC.Checked && !checkBoxVymzZiakDN.Checked && checkBoxVymzZiakPoh.Checked && checkBoxVymzZiakTr.Checked)
                {
                    if (i.Pohlavie == comboBoxVymzZiakPoh.SelectedItem.ToString() && i.Trieda == triedy[comboBoxVymzZiakTr.SelectedIndex])
                    {
                        ziaci_vymazanie.Add(i);
                    }

                }
                else if(checkBoxVymzZiakMP.Checked && !checkBoxVymzZiakPC.Checked && !checkBoxVymzZiakDN.Checked && !checkBoxVymzZiakPoh.Checked && !checkBoxVymzZiakTr.Checked)
                {
                    if (i.MenoPriezvisko == textBoxVymzZiakMP.Text)
                    {
                        ziaci_vymazanie.Add(i);
                    }

                }
                else if(!checkBoxVymzZiakMP.Checked && checkBoxVymzZiakPC.Checked && !checkBoxVymzZiakDN.Checked && !checkBoxVymzZiakPoh.Checked && !checkBoxVymzZiakTr.Checked)
                {
                    if (i.PoradoveCislo == int.Parse(textBoxVymzZiakPC.Text) )
                    {
                        ziaci_vymazanie.Add(i);
                    }

                }
                else if(!checkBoxVymzZiakMP.Checked && !checkBoxVymzZiakPC.Checked && checkBoxVymzZiakDN.Checked && !checkBoxVymzZiakPoh.Checked && !checkBoxVymzZiakTr.Checked)
                {
                    if (i.DatumNarodenia == dateTimePickerVymzZiakDN.Value )
                    {
                        ziaci_vymazanie.Add(i);
                    }

                }
                else if(!checkBoxVymzZiakMP.Checked && !checkBoxVymzZiakPC.Checked && !checkBoxVymzZiakDN.Checked && checkBoxVymzZiakPoh.Checked && !checkBoxVymzZiakTr.Checked)
                {
                    if (i.Pohlavie == comboBoxVymzZiakPoh.SelectedItem.ToString())
                    {
                        ziaci_vymazanie.Add(i);
                    }

                }
                else if(!checkBoxVymzZiakMP.Checked && !checkBoxVymzZiakPC.Checked && !checkBoxVymzZiakDN.Checked && !checkBoxVymzZiakPoh.Checked && checkBoxVymzZiakTr.Checked)
                {
                    if (i.Trieda == triedy[comboBoxVymzZiakTr.SelectedIndex])
                    {
                        ziaci_vymazanie.Add(i);
                    }

                }

            }

            foreach (Ziak i in ziaci_vymazanie)
            {
                ziaci.Remove(i);
                int indx = 0;
                foreach (Skrinka j in skrinky)
                {
                    
                    if (j.Vlastnik == i)
                    {
                        skrinky[indx].Vlastnik = ziaci[0];
                    }
                    indx++;
                }
            }

            Reset();
        }


 
        private void buttonSkrVymzHr_Click(object sender, EventArgs e)
        {
            List <Skrinka> skrinky_vymazanie = new List<Skrinka>();

            foreach (Skrinka i in skrinky)
            {
                if (checkBoxVymzSkrCs.Checked && checkBoxVymzSkrPoz.Checked && checkBoxVymzSkrVl.Checked)
                {

                    if(i.Cislo == int.Parse(textBoxVymzSkrCs.Text) && i.Poznamka == richTextBoxVymzSkrPoz.Text && i.Vlastnik == treeViewVymzSkrVl.SelectedNode.Tag)
                    {
                        skrinky_vymazanie.Add(i);
                    }
                }
                else if (checkBoxVymzSkrCs.Checked && checkBoxVymzSkrPoz.Checked && !checkBoxVymzSkrVl.Checked)
                {
                    if (i.Cislo == int.Parse(textBoxVymzSkrCs.Text) && i.Poznamka == richTextBoxVymzSkrPoz.Text)
                    {
                        skrinky_vymazanie.Add(i);
                    }
                }
                else if (checkBoxVymzSkrCs.Checked && !checkBoxVymzSkrPoz.Checked && checkBoxVymzSkrVl.Checked)
                {
                    if (i.Cislo == int.Parse(textBoxVymzSkrCs.Text) && i.Vlastnik == treeViewVymzSkrVl.SelectedNode.Tag)
                    {
                        skrinky_vymazanie.Add(i);
                    }
                }
                else if (!checkBoxVymzSkrCs.Checked && checkBoxVymzSkrPoz.Checked && checkBoxVymzSkrVl.Checked)
                {
                    if (i.Poznamka == richTextBoxVymzSkrPoz.Text && i.Vlastnik == treeViewVymzSkrVl.SelectedNode.Tag)
                        continue;
                    skrinky_vymazanie.Add(i);

                }
                else if (checkBoxVymzSkrCs.Checked && !checkBoxVymzSkrPoz.Checked && !checkBoxVymzSkrVl.Checked)
                {
                    if (i.Cislo == int.Parse(textBoxVymzSkrCs.Text))
                    {
                        skrinky_vymazanie.Add(i);
                    }
                }
                else if (!checkBoxVymzSkrCs.Checked && checkBoxVymzSkrPoz.Checked && !checkBoxVymzSkrVl.Checked)
                {
                    if (i.Poznamka == richTextBoxVymzSkrPoz.Text)
                    {
                        skrinky_vymazanie.Add(i);
                    }
                }
                else if (!checkBoxVymzSkrCs.Checked && !checkBoxVymzSkrPoz.Checked && checkBoxVymzSkrVl.Checked)
                {
                    if (i.Vlastnik == treeViewVymzSkrVl.SelectedNode.Tag)
                    {
                        skrinky_vymazanie.Add(i);
                    }
                }
            }
            foreach(Skrinka i in skrinky_vymazanie)
            {
                skrinky.Remove(i);
            }

            Reset();
        }

        private void rocnikyuprhr()
        {
            bool x = true;
            int index = 0;
            foreach (int r in rocniky_pridane)
            {
                if (r == int.Parse(textBoxUprTrRcnv.Text))
                {
                    x = false;
                    break;
                }
                index++;
            }
            if (x)
            {
                rocniky_pridane.Add(int.Parse(textBoxUprTrRcnv.Text));
            }
        }

        private void buttonUprTrdHr_Click(object sender, EventArgs e)
        {
            foreach (Trieda i in triedy)
            {
                if (checkBoxUprTrNz.Checked && checkBoxUprTrOd.Checked && checkBoxUprTrRc.Checked && checkBoxUprTrTu.Checked)
                {
                    if (i.Meno == textBoxUprTrNz.Text && i.Odbor == textBoxUprTrOd.Text && i.Rocnik == int.Parse(textBoxUprTrRc.Text) && i.TriednyUcitel == textBoxUrpTrTu.Text)
                    {
                        triedy[triedy.IndexOf(i)].Meno = textBoxUprTrNznv.Text;
                        triedy[triedy.IndexOf(i)].Odbor = textBoxUprTrOdnv.Text;
                        triedy[triedy.IndexOf(i)].Rocnik = int.Parse(textBoxUprTrRcnv.Text);
                        rocnikyuprhr();
                        triedy[triedy.IndexOf(i)].TriednyUcitel = textBoxUprTrTunv.Text;
                    }
                }
                else if(checkBoxUprTrNz.Checked && checkBoxUprTrOd.Checked && checkBoxUprTrRc.Checked && !checkBoxUprTrTu.Checked)
                {
                    if (i.Meno == textBoxUprTrNz.Text && i.Odbor == textBoxUprTrOd.Text && i.Rocnik == int.Parse(textBoxUprTrRc.Text))
                    {
                        triedy[triedy.IndexOf(i)].Meno = textBoxUprTrNznv.Text;
                        triedy[triedy.IndexOf(i)].Odbor = textBoxUprTrOdnv.Text;
                        triedy[triedy.IndexOf(i)].Rocnik = int.Parse(textBoxUprTrRcnv.Text);
                        rocnikyuprhr();
                    }
                }
                else if(checkBoxUprTrNz.Checked && checkBoxUprTrOd.Checked && !checkBoxUprTrRc.Checked && checkBoxUprTrTu.Checked)
                {
                    if (i.Meno == textBoxUprTrNz.Text && i.Odbor == textBoxUprTrOd.Text && i.TriednyUcitel == textBoxUrpTrTu.Text)
                    {
                        triedy[triedy.IndexOf(i)].Meno = textBoxUprTrNznv.Text;
                        triedy[triedy.IndexOf(i)].Odbor = textBoxUprTrOdnv.Text;
                        triedy[triedy.IndexOf(i)].TriednyUcitel = textBoxUprTrTunv.Text;
                    }
                }
                else if(checkBoxUprTrNz.Checked && !checkBoxUprTrOd.Checked && checkBoxUprTrRc.Checked && checkBoxUprTrTu.Checked)
                {
                    if (i.Meno == textBoxUprTrNz.Text && i.Rocnik == int.Parse(textBoxUprTrRc.Text) && i.TriednyUcitel == textBoxUrpTrTu.Text)
                    {
                        triedy[triedy.IndexOf(i)].Meno = textBoxUprTrNznv.Text;
                        triedy[triedy.IndexOf(i)].Rocnik = int.Parse(textBoxUprTrRcnv.Text);
                        rocnikyuprhr();
                        triedy[triedy.IndexOf(i)].TriednyUcitel = textBoxUprTrTunv.Text;
                    }
                }
                else if(!checkBoxUprTrNz.Checked && checkBoxUprTrOd.Checked && checkBoxUprTrRc.Checked && checkBoxUprTrTu.Checked)
                {
                    if (i.Meno == textBoxUprTrNz.Text && i.Rocnik == int.Parse(textBoxUprTrRc.Text) && i.TriednyUcitel == textBoxUrpTrTu.Text)
                    {
                        triedy[triedy.IndexOf(i)].Rocnik = int.Parse(textBoxUprTrRcnv.Text);
                        rocnikyuprhr();
                        triedy[triedy.IndexOf(i)].Odbor = textBoxUprTrOdnv.Text;
                        triedy[triedy.IndexOf(i)].TriednyUcitel = textBoxUprTrTunv.Text;
                    }
                }
                else if(checkBoxUprTrNz.Checked && checkBoxUprTrOd.Checked && !checkBoxUprTrRc.Checked && !checkBoxUprTrTu.Checked)
                {
                    if (i.Meno == textBoxUprTrNz.Text && i.Odbor == textBoxUprTrOd.Text)
                    {
                        triedy[triedy.IndexOf(i)].Meno = textBoxUprTrNznv.Text;
                        triedy[triedy.IndexOf(i)].Odbor = textBoxUprTrOdnv.Text;
                    }
                }
                else if(checkBoxUprTrNz.Checked && !checkBoxUprTrOd.Checked && checkBoxUprTrRc.Checked && !checkBoxUprTrTu.Checked)
                {
                    if (i.Meno == textBoxUprTrNz.Text && i.Rocnik == int.Parse(textBoxUprTrRc.Text))
                    {
                        triedy[triedy.IndexOf(i)].Meno = textBoxUprTrNznv.Text;
                        triedy[triedy.IndexOf(i)].Rocnik = int.Parse(textBoxUprTrRcnv.Text);
                        rocnikyuprhr();
                    }
                }
                else if(!checkBoxUprTrNz.Checked && checkBoxUprTrOd.Checked && checkBoxUprTrRc.Checked && !checkBoxUprTrTu.Checked)
                {
                    if (i.Odbor == textBoxUprTrOd.Text && i.Rocnik == int.Parse(textBoxUprTrRc.Text))
                    {
                        triedy[triedy.IndexOf(i)].Odbor = textBoxUprTrOdnv.Text;
                        triedy[triedy.IndexOf(i)].Rocnik = int.Parse(textBoxUprTrRcnv.Text);
                        rocnikyuprhr();
                    }
                }
                else if(checkBoxUprTrNz.Checked && !checkBoxUprTrOd.Checked && !checkBoxUprTrRc.Checked && checkBoxUprTrTu.Checked)
                {
                    if (i.Meno == textBoxUprTrNz.Text && i.TriednyUcitel == textBoxUrpTrTu.Text)
                    {
                        triedy[triedy.IndexOf(i)].Meno = textBoxUprTrNznv.Text;
                        triedy[triedy.IndexOf(i)].TriednyUcitel = textBoxUprTrTunv.Text;
                    }
                }
                else if(!checkBoxUprTrNz.Checked && checkBoxUprTrOd.Checked && !checkBoxUprTrRc.Checked && checkBoxUprTrTu.Checked)
                {
                    if (i.Odbor == textBoxUprTrOd.Text && i.TriednyUcitel == textBoxUrpTrTu.Text)
                    {
                        triedy[triedy.IndexOf(i)].Odbor = textBoxUprTrOdnv.Text;
                        triedy[triedy.IndexOf(i)].TriednyUcitel = textBoxUprTrTunv.Text;
                    }
                }
                else if(!checkBoxUprTrNz.Checked && !checkBoxUprTrOd.Checked && checkBoxUprTrRc.Checked && checkBoxUprTrTu.Checked)
                {
                    if (i.Rocnik == int.Parse(textBoxUprTrRc.Text) && i.TriednyUcitel == textBoxUrpTrTu.Text)
                    {
                        triedy[triedy.IndexOf(i)].Rocnik = int.Parse(textBoxUprTrRcnv.Text);
                        rocnikyuprhr();
                        triedy[triedy.IndexOf(i)].TriednyUcitel = textBoxUprTrTunv.Text;
                    }
                }
                else if(checkBoxUprTrNz.Checked && !checkBoxUprTrOd.Checked && !checkBoxUprTrRc.Checked && !checkBoxUprTrTu.Checked)
                {
                    if (i.Meno == textBoxUprTrNz.Text)
                    {
                        triedy[triedy.IndexOf(i)].Meno = textBoxUprTrNznv.Text;
                    }
                }
                else if(!checkBoxUprTrNz.Checked && checkBoxUprTrOd.Checked && !checkBoxUprTrRc.Checked && !checkBoxUprTrTu.Checked)
                {
                    if (i.Odbor == textBoxUprTrOd.Text)
                    {
                        triedy[triedy.IndexOf(i)].Odbor = textBoxUprTrOdnv.Text;
                    }
                }
                else if(!checkBoxUprTrNz.Checked && !checkBoxUprTrOd.Checked && checkBoxUprTrRc.Checked && !checkBoxUprTrTu.Checked)
                {
                    if (i.Rocnik == int.Parse(textBoxUprTrRc.Text))
                    {
                        triedy[triedy.IndexOf(i)].Rocnik = int.Parse(textBoxUprTrRcnv.Text);
                        rocnikyuprhr();
                    }
                }
                else if(!checkBoxUprTrNz.Checked && !checkBoxUprTrOd.Checked && !checkBoxUprTrRc.Checked && checkBoxUprTrTu.Checked)
                {
                    if (i.TriednyUcitel == textBoxUrpTrTu.Text)
                    {
                        triedy[triedy.IndexOf(i)].TriednyUcitel = textBoxUprTrTunv.Text;
                    }
                }
            }

            Reset();
        }

        private void buttonZiakUprPtvZmHr_Click(object sender, EventArgs e)
        {
            foreach (Ziak i in ziaci)
            {
                if(checkBoxUprZiakMP.Checked && checkBoxUprZiakPC.Checked && checkBoxUprZiakDN.Checked && checkBoxUprZiakPoh.Checked && checkBoxUprZiakTr.Checked)
                {
                    if (i.MenoPriezvisko == textBoxUprZiakMP.Text && i.PoradoveCislo == int.Parse(textBoxUprZiakPc.Text) && i.DatumNarodenia == dateTimePickerUprZiakDN.Value && i.Pohlavie == comboBoxUprZiakPoh.SelectedItem.ToString() && i.Trieda == triedy[comboBoxUprZiakTrd.SelectedIndex])
                    {
                        ziaci[ziaci.IndexOf(i)].MenoPriezvisko = textBoxUprZiakMPnv.Text;
                        ziaci[ziaci.IndexOf(i)].PoradoveCislo = int.Parse(textBoxUprZiakPcnv.Text);
                        ziaci[ziaci.IndexOf(i)].DatumNarodenia = dateTimePickerUprZiakDNnv.Value;
                        ziaci[ziaci.IndexOf(i)].Pohlavie = comboBoxUprZiakPohnv.SelectedItem.ToString();
                        ziaci[ziaci.IndexOf(i)].Trieda = triedy[comboBoxUprZiakTrdnv.SelectedIndex];
                    }
                }
                else if(checkBoxUprZiakMP.Checked && checkBoxUprZiakPC.Checked && checkBoxUprZiakDN.Checked && checkBoxUprZiakPoh.Checked && !checkBoxUprZiakTr.Checked)
                {
                    if (i.MenoPriezvisko == textBoxUprZiakMP.Text && i.PoradoveCislo == int.Parse(textBoxUprZiakPc.Text) && i.DatumNarodenia == dateTimePickerUprZiakDN.Value && i.Pohlavie == comboBoxUprZiakPoh.SelectedItem.ToString())
                    {
                        ziaci[ziaci.IndexOf(i)].MenoPriezvisko = textBoxUprZiakMPnv.Text;
                        ziaci[ziaci.IndexOf(i)].PoradoveCislo = int.Parse(textBoxUprZiakPcnv.Text);
                        ziaci[ziaci.IndexOf(i)].DatumNarodenia = dateTimePickerUprZiakDNnv.Value;
                        ziaci[ziaci.IndexOf(i)].Pohlavie = comboBoxUprZiakPohnv.SelectedItem.ToString();
                    }

                }
                else if(checkBoxUprZiakMP.Checked && checkBoxUprZiakPC.Checked && checkBoxUprZiakDN.Checked && !checkBoxUprZiakPoh.Checked && checkBoxUprZiakTr.Checked)
                {
                    if (i.MenoPriezvisko == textBoxUprZiakMP.Text && i.PoradoveCislo == int.Parse(textBoxUprZiakPc.Text) && i.DatumNarodenia == dateTimePickerUprZiakDN.Value && i.Trieda == triedy[comboBoxUprZiakTrd.SelectedIndex])
                    {
                        ziaci[ziaci.IndexOf(i)].MenoPriezvisko = textBoxUprZiakMPnv.Text;
                        ziaci[ziaci.IndexOf(i)].PoradoveCislo = int.Parse(textBoxUprZiakPcnv.Text);
                        ziaci[ziaci.IndexOf(i)].DatumNarodenia = dateTimePickerUprZiakDNnv.Value;
                        ziaci[ziaci.IndexOf(i)].Trieda = triedy[comboBoxUprZiakTrdnv.SelectedIndex];
                    }

                }
                else if(checkBoxUprZiakMP.Checked && checkBoxUprZiakPC.Checked && !checkBoxUprZiakDN.Checked && checkBoxUprZiakPoh.Checked && checkBoxUprZiakTr.Checked)
                {
                    if (i.MenoPriezvisko == textBoxUprZiakMP.Text && i.PoradoveCislo == int.Parse(textBoxUprZiakPc.Text) && i.Pohlavie == comboBoxUprZiakPoh.SelectedItem.ToString() && i.Trieda == triedy[comboBoxUprZiakTrd.SelectedIndex])
                    {
                        ziaci[ziaci.IndexOf(i)].MenoPriezvisko = textBoxUprZiakMPnv.Text;
                        ziaci[ziaci.IndexOf(i)].PoradoveCislo = int.Parse(textBoxUprZiakPcnv.Text);
                        ziaci[ziaci.IndexOf(i)].Pohlavie = comboBoxUprZiakPohnv.SelectedItem.ToString();
                        ziaci[ziaci.IndexOf(i)].Trieda = triedy[comboBoxUprZiakTrdnv.SelectedIndex];
                    }

                }
                else if(checkBoxUprZiakMP.Checked && !checkBoxUprZiakPC.Checked && checkBoxUprZiakDN.Checked && checkBoxUprZiakPoh.Checked && checkBoxUprZiakTr.Checked)
                {
                    if (i.MenoPriezvisko == textBoxUprZiakMP.Text && i.DatumNarodenia == dateTimePickerUprZiakDN.Value && i.Pohlavie == comboBoxUprZiakPoh.SelectedItem.ToString() && i.Trieda == triedy[comboBoxUprZiakTrd.SelectedIndex])
                    {
                        ziaci[ziaci.IndexOf(i)].MenoPriezvisko = textBoxUprZiakMPnv.Text;
                        ziaci[ziaci.IndexOf(i)].DatumNarodenia = dateTimePickerUprZiakDNnv.Value;
                        ziaci[ziaci.IndexOf(i)].Pohlavie = comboBoxUprZiakPohnv.SelectedItem.ToString();
                        ziaci[ziaci.IndexOf(i)].Trieda = triedy[comboBoxUprZiakTrdnv.SelectedIndex];

                    }

                }
                else if(!checkBoxUprZiakMP.Checked && checkBoxUprZiakPC.Checked && checkBoxUprZiakDN.Checked && checkBoxUprZiakPoh.Checked && checkBoxUprZiakTr.Checked)
                {
                    if (i.PoradoveCislo == int.Parse(textBoxUprZiakPc.Text) && i.DatumNarodenia == dateTimePickerUprZiakDN.Value && i.Pohlavie == comboBoxUprZiakPoh.SelectedItem.ToString() && i.Trieda == triedy[comboBoxUprZiakTrd.SelectedIndex])
                    {
                        ziaci[ziaci.IndexOf(i)].PoradoveCislo = int.Parse(textBoxUprZiakPcnv.Text);
                        ziaci[ziaci.IndexOf(i)].DatumNarodenia = dateTimePickerUprZiakDNnv.Value;
                        ziaci[ziaci.IndexOf(i)].Pohlavie = comboBoxUprZiakPohnv.SelectedItem.ToString();
                        ziaci[ziaci.IndexOf(i)].Trieda = triedy[comboBoxUprZiakTrdnv.SelectedIndex];
                    }

                }
                else if(checkBoxUprZiakMP.Checked && checkBoxUprZiakPC.Checked && checkBoxUprZiakDN.Checked && !checkBoxUprZiakPoh.Checked && !checkBoxUprZiakTr.Checked)
                {
                    if (i.MenoPriezvisko == textBoxUprZiakMP.Text && i.PoradoveCislo == int.Parse(textBoxUprZiakPc.Text) && i.DatumNarodenia == dateTimePickerUprZiakDN.Value)
                    {
                        ziaci[ziaci.IndexOf(i)].MenoPriezvisko = textBoxUprZiakMPnv.Text;
                        ziaci[ziaci.IndexOf(i)].PoradoveCislo = int.Parse(textBoxUprZiakPcnv.Text);
                        ziaci[ziaci.IndexOf(i)].DatumNarodenia = dateTimePickerUprZiakDNnv.Value;
                    }

                }
                else if(checkBoxUprZiakMP.Checked && checkBoxUprZiakPC.Checked && !checkBoxUprZiakDN.Checked && checkBoxUprZiakPoh.Checked && !checkBoxUprZiakTr.Checked)
                {
                    if (i.MenoPriezvisko == textBoxUprZiakMP.Text && i.PoradoveCislo == int.Parse(textBoxUprZiakPc.Text) && i.Pohlavie == comboBoxUprZiakPoh.SelectedItem.ToString())
                    {
                        ziaci[ziaci.IndexOf(i)].MenoPriezvisko = textBoxUprZiakMPnv.Text;
                        ziaci[ziaci.IndexOf(i)].PoradoveCislo = int.Parse(textBoxUprZiakPcnv.Text);
                        ziaci[ziaci.IndexOf(i)].Pohlavie = comboBoxUprZiakPohnv.SelectedItem.ToString();
                    }

                }
                else if(checkBoxUprZiakMP.Checked && !checkBoxUprZiakPC.Checked && checkBoxUprZiakDN.Checked && checkBoxUprZiakPoh.Checked && !checkBoxUprZiakTr.Checked)
                {
                    if (i.MenoPriezvisko == textBoxUprZiakMP.Text && i.DatumNarodenia == dateTimePickerUprZiakDN.Value && i.Pohlavie == comboBoxUprZiakPoh.SelectedItem.ToString())
                    {
                        ziaci[ziaci.IndexOf(i)].MenoPriezvisko = textBoxUprZiakMPnv.Text;
                        ziaci[ziaci.IndexOf(i)].DatumNarodenia = dateTimePickerUprZiakDNnv.Value;
                        ziaci[ziaci.IndexOf(i)].Pohlavie = comboBoxUprZiakPohnv.SelectedItem.ToString();
                    }

                }
                else if(!checkBoxUprZiakMP.Checked && checkBoxUprZiakPC.Checked && checkBoxUprZiakDN.Checked && checkBoxUprZiakPoh.Checked && !checkBoxUprZiakTr.Checked)
                {
                    if (i.PoradoveCislo == int.Parse(textBoxUprZiakPc.Text) && i.DatumNarodenia == dateTimePickerUprZiakDN.Value && i.Pohlavie == comboBoxUprZiakPoh.SelectedItem.ToString())
                    {
                        ziaci[ziaci.IndexOf(i)].PoradoveCislo = int.Parse(textBoxUprZiakPcnv.Text);
                        ziaci[ziaci.IndexOf(i)].DatumNarodenia = dateTimePickerUprZiakDNnv.Value;
                        ziaci[ziaci.IndexOf(i)].Pohlavie = comboBoxUprZiakPohnv.SelectedItem.ToString();
                    }

                }
                else if(checkBoxUprZiakMP.Checked && checkBoxUprZiakPC.Checked && !checkBoxUprZiakDN.Checked && !checkBoxUprZiakPoh.Checked && checkBoxUprZiakTr.Checked)
                {
                    if (i.MenoPriezvisko == textBoxUprZiakMP.Text && i.PoradoveCislo == int.Parse(textBoxUprZiakPc.Text) && i.Trieda == triedy[comboBoxUprZiakTrd.SelectedIndex])
                    {
                        ziaci[ziaci.IndexOf(i)].MenoPriezvisko = textBoxUprZiakMPnv.Text;
                        ziaci[ziaci.IndexOf(i)].PoradoveCislo = int.Parse(textBoxUprZiakPcnv.Text);
                        ziaci[ziaci.IndexOf(i)].Trieda = triedy[comboBoxUprZiakTrdnv.SelectedIndex];
                    }

                }
                else if(checkBoxUprZiakMP.Checked && !checkBoxUprZiakPC.Checked && checkBoxUprZiakDN.Checked && !checkBoxUprZiakPoh.Checked && checkBoxUprZiakTr.Checked)
                {
                    if (i.MenoPriezvisko == textBoxUprZiakMP.Text && i.DatumNarodenia == dateTimePickerUprZiakDN.Value && i.Trieda == triedy[comboBoxUprZiakTrd.SelectedIndex])
                    {
                        ziaci[ziaci.IndexOf(i)].MenoPriezvisko = textBoxUprZiakMPnv.Text;
                        ziaci[ziaci.IndexOf(i)].DatumNarodenia = dateTimePickerUprZiakDNnv.Value;
                        ziaci[ziaci.IndexOf(i)].Trieda = triedy[comboBoxUprZiakTrdnv.SelectedIndex];
                    }

                }
                else if(!checkBoxUprZiakMP.Checked && checkBoxUprZiakPC.Checked && checkBoxUprZiakDN.Checked && !checkBoxUprZiakPoh.Checked && checkBoxUprZiakTr.Checked)
                {
                    if (i.PoradoveCislo == int.Parse(textBoxUprZiakPc.Text) && i.DatumNarodenia == dateTimePickerUprZiakDN.Value && i.Trieda == triedy[comboBoxUprZiakTrd.SelectedIndex])
                    {
                        ziaci[ziaci.IndexOf(i)].PoradoveCislo = int.Parse(textBoxUprZiakPcnv.Text);
                        ziaci[ziaci.IndexOf(i)].DatumNarodenia = dateTimePickerUprZiakDNnv.Value;
                        ziaci[ziaci.IndexOf(i)].Trieda = triedy[comboBoxUprZiakTrdnv.SelectedIndex];
                    }

                }
                else if(checkBoxUprZiakMP.Checked && !checkBoxUprZiakPC.Checked && !checkBoxUprZiakDN.Checked && checkBoxUprZiakPoh.Checked && checkBoxUprZiakTr.Checked)
                {
                    if (i.MenoPriezvisko == textBoxUprZiakMP.Text && i.Pohlavie == comboBoxUprZiakPoh.SelectedItem.ToString() && i.Trieda == triedy[comboBoxUprZiakTrd.SelectedIndex])
                    {
                        ziaci[ziaci.IndexOf(i)].MenoPriezvisko = textBoxUprZiakMPnv.Text;
                        ziaci[ziaci.IndexOf(i)].Pohlavie = comboBoxUprZiakPohnv.SelectedItem.ToString();
                        ziaci[ziaci.IndexOf(i)].Trieda = triedy[comboBoxUprZiakTrdnv.SelectedIndex];
                    }

                }
                else if(!checkBoxUprZiakMP.Checked && checkBoxUprZiakPC.Checked && !checkBoxUprZiakDN.Checked && checkBoxUprZiakPoh.Checked && checkBoxUprZiakTr.Checked)
                {
                    if (i.PoradoveCislo == int.Parse(textBoxUprZiakPc.Text) && i.Pohlavie == comboBoxUprZiakPoh.SelectedItem.ToString() && i.Trieda == triedy[comboBoxUprZiakTrd.SelectedIndex])
                    {
                        ziaci[ziaci.IndexOf(i)].PoradoveCislo = int.Parse(textBoxUprZiakPcnv.Text);
                        ziaci[ziaci.IndexOf(i)].Pohlavie = comboBoxUprZiakPohnv.SelectedItem.ToString();
                        ziaci[ziaci.IndexOf(i)].Trieda = triedy[comboBoxUprZiakTrdnv.SelectedIndex];
                    }

                }
                else if(!checkBoxUprZiakMP.Checked && !checkBoxUprZiakPC.Checked && checkBoxUprZiakDN.Checked && checkBoxUprZiakPoh.Checked && checkBoxUprZiakTr.Checked)
                {
                    if (i.DatumNarodenia == dateTimePickerUprZiakDN.Value && i.Pohlavie == comboBoxUprZiakPoh.SelectedItem.ToString() && i.Trieda == triedy[comboBoxUprZiakTrd.SelectedIndex])
                    {
                        ziaci[ziaci.IndexOf(i)].DatumNarodenia = dateTimePickerUprZiakDNnv.Value;
                        ziaci[ziaci.IndexOf(i)].Pohlavie = comboBoxUprZiakPohnv.SelectedItem.ToString();
                        ziaci[ziaci.IndexOf(i)].Trieda = triedy[comboBoxUprZiakTrdnv.SelectedIndex];
                    }

                }
                else if(checkBoxUprZiakMP.Checked && checkBoxUprZiakPC.Checked && !checkBoxUprZiakDN.Checked && !checkBoxUprZiakPoh.Checked && !checkBoxUprZiakTr.Checked)
                {
                    if (i.MenoPriezvisko == textBoxUprZiakMP.Text && i.PoradoveCislo == int.Parse(textBoxUprZiakPc.Text))
                    {
                        ziaci[ziaci.IndexOf(i)].MenoPriezvisko = textBoxUprZiakMPnv.Text;
                        ziaci[ziaci.IndexOf(i)].PoradoveCislo = int.Parse(textBoxUprZiakPcnv.Text);
                    }

                }
                else if(checkBoxUprZiakMP.Checked && !checkBoxUprZiakPC.Checked && checkBoxUprZiakDN.Checked && !checkBoxUprZiakPoh.Checked && !checkBoxUprZiakTr.Checked)
                {
                    if (i.MenoPriezvisko == textBoxUprZiakMP.Text && i.DatumNarodenia == dateTimePickerUprZiakDN.Value)
                    {
                        ziaci[ziaci.IndexOf(i)].MenoPriezvisko = textBoxUprZiakMPnv.Text;
                        ziaci[ziaci.IndexOf(i)].DatumNarodenia = dateTimePickerUprZiakDNnv.Value;
                    }

                }
                else if(!checkBoxUprZiakMP.Checked && checkBoxUprZiakPC.Checked && checkBoxUprZiakDN.Checked && !checkBoxUprZiakPoh.Checked && !checkBoxUprZiakTr.Checked)
                {
                    if (i.PoradoveCislo == int.Parse(textBoxUprZiakPc.Text) && i.DatumNarodenia == dateTimePickerUprZiakDN.Value)
                    {
                        ziaci[ziaci.IndexOf(i)].PoradoveCislo = int.Parse(textBoxUprZiakPcnv.Text);
                        ziaci[ziaci.IndexOf(i)].DatumNarodenia = dateTimePickerUprZiakDNnv.Value;

                    }

                }
                else if(checkBoxUprZiakMP.Checked && !checkBoxUprZiakPC.Checked && !checkBoxUprZiakDN.Checked && checkBoxUprZiakPoh.Checked && !checkBoxUprZiakTr.Checked)
                {
                    if (i.MenoPriezvisko == textBoxUprZiakMP.Text && i.Pohlavie == comboBoxUprZiakPoh.SelectedItem.ToString())
                    {
                        ziaci[ziaci.IndexOf(i)].MenoPriezvisko = textBoxUprZiakMPnv.Text;
                        ziaci[ziaci.IndexOf(i)].Pohlavie = comboBoxUprZiakPohnv.SelectedItem.ToString();

                    }

                }
                else if(!checkBoxUprZiakMP.Checked && checkBoxUprZiakPC.Checked && !checkBoxUprZiakDN.Checked && checkBoxUprZiakPoh.Checked && !checkBoxUprZiakTr.Checked)
                {
                    if (i.PoradoveCislo == int.Parse(textBoxUprZiakPc.Text) && i.Pohlavie == comboBoxUprZiakPoh.SelectedItem.ToString())

                    {
                        ziaci[ziaci.IndexOf(i)].PoradoveCislo = int.Parse(textBoxUprZiakPcnv.Text);
                        ziaci[ziaci.IndexOf(i)].Pohlavie = comboBoxUprZiakPohnv.SelectedItem.ToString();
                    }

                }
                else if(!checkBoxUprZiakMP.Checked && !checkBoxUprZiakPC.Checked && checkBoxUprZiakDN.Checked && checkBoxUprZiakPoh.Checked && !checkBoxUprZiakTr.Checked)
                {
                    if (i.DatumNarodenia == dateTimePickerUprZiakDN.Value && i.Pohlavie == comboBoxUprZiakPoh.SelectedItem.ToString())
                    {
                        ziaci[ziaci.IndexOf(i)].DatumNarodenia = dateTimePickerUprZiakDNnv.Value;
                        ziaci[ziaci.IndexOf(i)].Pohlavie = comboBoxUprZiakPohnv.SelectedItem.ToString();
                    }

                }
                else if(checkBoxUprZiakMP.Checked && !checkBoxUprZiakPC.Checked && !checkBoxUprZiakDN.Checked && !checkBoxUprZiakPoh.Checked && checkBoxUprZiakTr.Checked)
                {
                    if (i.MenoPriezvisko == textBoxUprZiakMP.Text && i.Trieda == triedy[comboBoxUprZiakTrd.SelectedIndex])
                    {
                        ziaci[ziaci.IndexOf(i)].MenoPriezvisko = textBoxUprZiakMPnv.Text;
                        ziaci[ziaci.IndexOf(i)].Trieda = triedy[comboBoxUprZiakTrdnv.SelectedIndex];
                    }

                }
                else if(!checkBoxUprZiakMP.Checked && checkBoxUprZiakPC.Checked && !checkBoxUprZiakDN.Checked && !checkBoxUprZiakPoh.Checked && checkBoxUprZiakTr.Checked)
                {
                    if (i.PoradoveCislo == int.Parse(textBoxUprZiakPc.Text) && i.Trieda == triedy[comboBoxUprZiakTrd.SelectedIndex])
                    {
                        ziaci[ziaci.IndexOf(i)].PoradoveCislo = int.Parse(textBoxUprZiakPcnv.Text);
                        ziaci[ziaci.IndexOf(i)].Trieda = triedy[comboBoxUprZiakTrdnv.SelectedIndex];
                    }

                }
                else if(!checkBoxUprZiakMP.Checked && !checkBoxUprZiakPC.Checked && checkBoxUprZiakDN.Checked && !checkBoxUprZiakPoh.Checked && checkBoxUprZiakTr.Checked)
                {
                    if (i.DatumNarodenia == dateTimePickerUprZiakDN.Value && i.Trieda == triedy[comboBoxUprZiakTrd.SelectedIndex])
                    {
                        ziaci[ziaci.IndexOf(i)].DatumNarodenia = dateTimePickerUprZiakDNnv.Value;
                        ziaci[ziaci.IndexOf(i)].Trieda = triedy[comboBoxUprZiakTrdnv.SelectedIndex];
                    }

                }
                else if(!checkBoxUprZiakMP.Checked && !checkBoxUprZiakPC.Checked && !checkBoxUprZiakDN.Checked && checkBoxUprZiakPoh.Checked && checkBoxUprZiakTr.Checked)
                {
                    if (i.Pohlavie == comboBoxUprZiakPoh.SelectedItem.ToString() && i.Trieda == triedy[comboBoxUprZiakTrd.SelectedIndex])
                    {
                        ziaci[ziaci.IndexOf(i)].Pohlavie = comboBoxUprZiakPohnv.SelectedItem.ToString();
                        ziaci[ziaci.IndexOf(i)].Trieda = triedy[comboBoxUprZiakTrdnv.SelectedIndex];
                    }

                }
                else if(checkBoxUprZiakMP.Checked && !checkBoxUprZiakPC.Checked && !checkBoxUprZiakDN.Checked && !checkBoxUprZiakPoh.Checked && !checkBoxUprZiakTr.Checked)
                {
                    if (i.MenoPriezvisko == textBoxUprZiakMP.Text)
                    {
                        ziaci[ziaci.IndexOf(i)].MenoPriezvisko = textBoxUprZiakMPnv.Text;
                    }

                }
                else if(!checkBoxUprZiakMP.Checked && checkBoxUprZiakPC.Checked && !checkBoxUprZiakDN.Checked && !checkBoxUprZiakPoh.Checked && !checkBoxUprZiakTr.Checked)
                {
                    if (i.PoradoveCislo == int.Parse(textBoxUprZiakPc.Text))
                    {
                        ziaci[ziaci.IndexOf(i)].PoradoveCislo = int.Parse(textBoxUprZiakPcnv.Text);
                    }

                }
                else if(!checkBoxUprZiakMP.Checked && !checkBoxUprZiakPC.Checked && checkBoxUprZiakDN.Checked && !checkBoxUprZiakPoh.Checked && !checkBoxUprZiakTr.Checked)
                {
                    if (i.DatumNarodenia == dateTimePickerUprZiakDN.Value)
                    {
                        ziaci[ziaci.IndexOf(i)].DatumNarodenia = dateTimePickerUprZiakDNnv.Value;
                    }

                }
                else if(!checkBoxUprZiakMP.Checked && !checkBoxUprZiakPC.Checked && !checkBoxUprZiakDN.Checked && checkBoxUprZiakPoh.Checked && !checkBoxUprZiakTr.Checked)
                {
                    if (i.Pohlavie == comboBoxUprZiakPoh.SelectedItem.ToString())
                    {
                        ziaci[ziaci.IndexOf(i)].Pohlavie = comboBoxUprZiakPohnv.SelectedItem.ToString();
                    }

                }
                else if (!checkBoxUprZiakMP.Checked && !checkBoxUprZiakPC.Checked && !checkBoxUprZiakDN.Checked && !checkBoxUprZiakPoh.Checked && checkBoxUprZiakTr.Checked)
                {
                    if (i.Trieda == triedy[comboBoxUprZiakTrd.SelectedIndex])
                    {
                        ziaci[ziaci.IndexOf(i)].Trieda = triedy[comboBoxUprZiakTrdnv.SelectedIndex];
                    }

                }             
            }
            Reset();
        }

        private void buttonSkrUprHr_Click(object sender, EventArgs e)
        {
            foreach(Skrinka i in skrinky)
            {
                if (checkBoxUprSkrCs.Checked && checkBoxUprSkrPoz.Checked && checkBoxUprSkrVl.Checked)
                {

                    if (i.Cislo == int.Parse(textBoxUprSkrCs.Text) && i.Poznamka == richTextBoxUprSkrPoz.Text && i.Vlastnik == treeViewUprSkrVl.SelectedNode.Tag)
                    {
                        skrinky[skrinky.IndexOf(i)].Cislo = int.Parse(textBoxUprSkrCsnv.Text);
                        skrinky[skrinky.IndexOf(i)].Poznamka = richTextBoxUprSkrPoznv.Text;

                        Ziak vlastnik = ziaci[0];
                        foreach (Ziak j in ziaci)
                        {
                            if (j == treeViewVytvSkrVl.SelectedNode.Tag)
                            {
                                vlastnik = j;
                            }
                        }
                        skrinky[skrinky.IndexOf(i)].Vlastnik = vlastnik;
                    }
                }
                else if (checkBoxUprSkrCs.Checked && checkBoxUprSkrPoz.Checked && !checkBoxUprSkrVl.Checked)
                {
                    if (i.Cislo == int.Parse(textBoxUprSkrCs.Text) && i.Poznamka == richTextBoxUprSkrPoz.Text)
                    {
                        skrinky[skrinky.IndexOf(i)].Cislo = int.Parse(textBoxUprSkrCsnv.Text);
                        skrinky[skrinky.IndexOf(i)].Poznamka = richTextBoxUprSkrPoznv.Text;
                    }
                }
                else if (checkBoxUprSkrCs.Checked && !checkBoxUprSkrPoz.Checked && checkBoxUprSkrVl.Checked)
                {
                    if (i.Cislo == int.Parse(textBoxUprSkrCs.Text) && i.Vlastnik == treeViewUprSkrVl.SelectedNode.Tag)
                    {
                        skrinky[skrinky.IndexOf(i)].Cislo = int.Parse(textBoxUprSkrCsnv.Text);

                        Ziak vlastnik = ziaci[0];
                        foreach (Ziak j in ziaci)
                        {
                            if (j == treeViewVytvSkrVl.SelectedNode.Tag)
                            {
                                vlastnik = j;
                            }
                        }
                        skrinky[skrinky.IndexOf(i)].Vlastnik = vlastnik;
                    }
                }
                else if (!checkBoxUprSkrCs.Checked && checkBoxUprSkrPoz.Checked && checkBoxUprSkrVl.Checked)
                {
                    if (i.Poznamka == richTextBoxUprSkrPoz.Text && i.Vlastnik == treeViewUprSkrVl.SelectedNode.Tag)
                    {;
                        skrinky[skrinky.IndexOf(i)].Poznamka = richTextBoxUprSkrPoznv.Text;

                        Ziak vlastnik = ziaci[0];
                        foreach (Ziak j in ziaci)
                        {
                            if (j == treeViewVytvSkrVl.SelectedNode.Tag)
                            {
                                vlastnik = j;
                            }
                        }
                        skrinky[skrinky.IndexOf(i)].Vlastnik = vlastnik;
                    }

                }
                else if (checkBoxUprSkrCs.Checked && !checkBoxUprSkrPoz.Checked && !checkBoxUprSkrVl.Checked)
                {
                    if (i.Cislo == int.Parse(textBoxUprSkrCs.Text))
                    {
                        skrinky[skrinky.IndexOf(i)].Cislo = int.Parse(textBoxUprSkrCsnv.Text);
                    }
                }
                else if (!checkBoxUprSkrCs.Checked && checkBoxUprSkrPoz.Checked && !checkBoxUprSkrVl.Checked)
                {
                    if (i.Poznamka == richTextBoxUprSkrPoz.Text)
                    { 
                        skrinky[skrinky.IndexOf(i)].Poznamka = richTextBoxUprSkrPoznv.Text;

                    }
                }
                else if (!checkBoxUprSkrCs.Checked && !checkBoxUprSkrPoz.Checked && checkBoxUprSkrVl.Checked)
                {
                    if (i.Vlastnik == treeViewUprSkrVl.SelectedNode.Tag)
                    {
                        Ziak vlastnik = ziaci[0];
                        foreach (Ziak j in ziaci)
                        {
                            if (j == treeViewVytvSkrVl.SelectedNode.Tag)
                            {
                                vlastnik = j;
                            }
                        }
                        skrinky[skrinky.IndexOf(i)].Vlastnik = vlastnik;
                    }
                }
            }
            Reset();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var opt = new JsonSerializerOptions() { WriteIndented=true };
            string JsonString = JsonSerializer.Serialize<List<Trieda>>(triedy, opt);

            using (var writer = new StreamWriter(_pathTriedy))
            {
                writer.Write(JsonString);
            }

            var opt2 = new JsonSerializerOptions() { WriteIndented=true };
            string JsonString2 = JsonSerializer.Serialize<List<Skrinka>>(skrinky, opt2);

            using (var writer = new StreamWriter(_pathSkrinky))
            {
                writer.Write(JsonString2);
            }

            var opt3 = new JsonSerializerOptions() { WriteIndented=true };
            string jsonString3 = JsonSerializer.Serialize<List<Ziak>>(ziaci, opt3);

            using (var writer = new StreamWriter(_pathZiak))
            {
                writer.Write(jsonString3);
            }

        }
    }
}

