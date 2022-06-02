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
            foreach (int i in rocniky_pridane)
            {
                treeViewTrdUpr.Nodes.Add(i.ToString());
                int index = 0;
                foreach (Trieda j in triedy)
                {
                    if (j.Rocnik == i)
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
            foreach (Trieda i in triedy)
            {
                treeViewZiakVymz.Nodes.Add(i.Meno);
                treeViewZiakVymz.Nodes[indexNT].Tag = i;
                int indexNZ = 0;
                foreach (Ziak j in ziaci)
                {
                    if (j.Trieda == i)
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

        private void Res_treeviewvytvskrvl()
        {
            treeViewVytvSkrVl.Nodes.Clear();
            int indexNT = 0;
            foreach (Trieda i in triedy)
            {
                treeViewVytvSkrVl.Nodes.Add(i.Meno);
                treeViewVytvSkrVl.Nodes[indexNT].Tag = i;
                int indexNZ = 0;
                foreach (Ziak j in ziaci)
                {
                    if (j.Trieda == i)
                    {
                        treeViewVytvSkrVl.Nodes[indexNT].Nodes.Add(j.MenoPriezvisko);
                        treeViewVytvSkrVl.Nodes[indexNT].Nodes[indexNZ].Tag = j;
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

        private void Combobox_res(ComboBox combobox)
        {
            combobox.Items.Clear();
            foreach (Trieda i in triedy)
            {
                combobox.Items.Add(i.Meno);
            }
        }


        public Form1()
        {
            InitializeComponent();

            triedy.Add(new Trieda("Nezaradený", "žiaden", "nikto", 0));
            ziaci.Add(new Ziak("Nikto", 0, "žiadne", new DateTime(1), triedy[0]));
            rocniky_pridane.Add(0);

            string jsonString2zob = File.ReadAllText(_pathTriedy);
            triedy = JsonSerializer.Deserialize<List<Trieda>>(jsonString2zob);

            string jsonString3zob = File.ReadAllText(_pathSkrinky);
            skrinky = JsonSerializer.Deserialize<List<Skrinka>>(jsonString3zob);

            string jsonString4zob = File.ReadAllText(_pathZiak);
            ziaci = JsonSerializer.Deserialize<List<Ziak>>(jsonString4zob);

            foreach (Trieda i in triedy)
            {
                if (!rocniky_pridane.Contains(i.Rocnik))
                {
                    rocniky_pridane.Add(i.Rocnik);
                }
            }

            //string jsonString5zob = File.ReadAllText(_pathRocnik);
            //rocniky_pridane = JsonSerializer.Deserialize<List<int>>(jsonString5zob);

            /*string jsonString2zob = File.ReadAllText(_pathTriedy);
            triedy = JsonSerializer.Deserialize<List<Trieda>>(jsonString2zob);

            string jsonString3zob = File.ReadAllText(_pathSkrinky);
            skrinky = JsonSerializer.Deserialize<List<Skrinka>>(jsonString3zob);

            string jsonString4zob = File.ReadAllText(_pathZiak);
            ziaci = JsonSerializer.Deserialize<List<Ziak>>(jsonString4zob);*/

            //string jsonString5 = File.ReadAllLines(_pathRocnik);
            //rocniky_pridane = JsonSerializer.Deserialize(jsonString5);



            Res_treeviewtrdupr();
            Res_treeviewtrdvymz();

            Res_treeviewziakupr();
            Res_treeviewziakvymz();
            Res_treeviewvytvskrvl();

            Res_treeviewskrupr();
            Res_treeviewskrvymz();

            Combobox_res(comboBoxVytvZiakTr);
            Combobox_res(comboBoxVytvZiakTrHr);
            Combobox_res(comboBoxVytvZiakTrOdDoHr);
            Combobox_res(comboBoxVytvSkrTrd);
        }

        private void buttonVytvSkr_Click(object sender, EventArgs e)
        {
            try
            {
                skrinky.Add(new Skrinka(int.Parse(textBoxVytvSkrCs.Text), richTextBoxVytvSkrPoz.Text, ziaci[treeViewVytvSkrVl.SelectedNode.Index]));
                /*treeViewSkrVymz.Nodes.Add(skrinky.Last().Cislo.ToString());
                treeViewSkrVymz.Nodes[treeViewSkrVymz.Nodes.Count - 1].Tag = skrinky.Last();
                treeViewSkrUpr.Nodes.Add(skrinky.Last().Cislo.ToString());
                treeViewSkrUpr.Nodes[treeViewSkrUpr.Nodes.Count - 1].Tag = skrinky.Last();
                treeViewSkrUpr.Nodes[skrinky.IndexOf(skrinky.Last())].Nodes.Add(skrinky.Last().Cislo.ToString());
                treeViewSkrUpr.Nodes[skrinky.IndexOf(skrinky.Last())].Nodes.Add(skrinky.Last().Poznamka);
                treeViewSkrUpr.Nodes[skrinky.IndexOf(skrinky.Last())].Nodes.Add(skrinky.Last().Vlastnik.MenoPriezvisko);
                treeViewSkrUpr.Nodes[treeViewSkrUpr.Nodes.Count - 1].Nodes[2].Tag = skrinky.Last().Vlastnik;*/
                Res_treeviewskrupr();
                Res_treeviewskrvymz();
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
            comboBoxVytvZiakTrHr.Items.Add(triedy.Last().Meno);
            comboBoxVytvZiakTrOdDoHr.Items.Add(triedy.Last().Meno);
            comboBoxVytvSkrTrd.Items.Add(triedy.Last().Meno);
                       

            /* treeViewVytvSkrVl.Nodes.Add(triedy.Last().Meno);
             treeViewVytvSkrVl.Nodes[triedy.IndexOf(triedy.Last())].Tag = triedy.Last();*/

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
            if (x)
            {
                /* treeViewTrdUpr.Nodes.Add(textBoxVytvTrRc.Text);
                 treeViewTrdVymz.Nodes.Add(textBoxVytvTrRc.Text);*/
                rocniky_pridane.Add(int.Parse(textBoxVytvTrRc.Text));
            }
            /*treeViewTrdUpr.Nodes[index].Nodes.Add(triedy.Last().Meno);
            treeViewTrdUpr.Nodes[index].Nodes[triedy.IndexOf(triedy.Last())].Tag = triedy.Last();
            treeViewTrdUpr.Nodes[index].Nodes[triedy.IndexOf(triedy.Last())].Nodes.Add(triedy.Last().Meno);
            treeViewTrdUpr.Nodes[index].Nodes[triedy.IndexOf(triedy.Last())].Nodes.Add(triedy.Last().Odbor);
            treeViewTrdUpr.Nodes[index].Nodes[triedy.IndexOf(triedy.Last())].Nodes.Add(triedy.Last().Rocnik.ToString());
            treeViewTrdUpr.Nodes[index].Nodes[triedy.IndexOf(triedy.Last())].Nodes.Add(triedy.Last().TriednyUcitel);*/

            Res_treeviewtrdupr();
            Res_treeviewtrdvymz();

            /* treeViewTrdVymz.Nodes[index].Nodes.Add(triedy.Last().Meno);
             treeViewTrdVymz.Nodes[index].Nodes[triedy.IndexOf(triedy.Last())].Tag = triedy.Last();


             treeViewZiakUpr.Nodes.Add(triedy.Last().Meno);
             treeViewZiakUpr.Nodes[triedy.IndexOf(triedy.Last())].Tag = triedy.Last();

             treeViewZiakVymz.Nodes.Add(triedy.Last().Meno);
             treeViewZiakVymz.Nodes[triedy.IndexOf(triedy.Last())].Tag = triedy.Last();*/




        }

        private void buttonVytvZiak_Click(object sender, EventArgs e)
        {

            ziaci.Add(new Ziak(textBoxVytvZiakMP.Text, int.Parse(textBoxVytvZiakPC.Text), comboBoxVytvZiakPoh.SelectedItem.ToString(), dateTimePickerVytvZiakDN.Value, triedy[comboBoxVytvZiakTr.SelectedIndex]));
            /*treeViewVytvSkrVl.Nodes[comboBoxVytvZiakTr.SelectedIndex].Nodes.Add(ziaci.Last().MenoPriezvisko);
            treeViewVytvSkrVl.Nodes[comboBoxVytvZiakTr.SelectedIndex].Nodes[ziaci.IndexOf(ziaci.Last())].Tag = ziaci.Last();
            treeViewZiakVymz.Nodes[comboBoxVytvZiakTr.SelectedIndex].Nodes.Add(ziaci.Last().MenoPriezvisko);
            treeViewZiakVymz.Nodes[comboBoxVytvZiakTr.SelectedIndex].Nodes[ziaci.IndexOf(ziaci.Last())].Tag = ziaci.Last();
            treeViewZiakUpr.Nodes[comboBoxVytvZiakTr.SelectedIndex].Nodes.Add(ziaci.Last().MenoPriezvisko);
            treeViewZiakUpr.Nodes[comboBoxVytvZiakTr.SelectedIndex].Nodes[ziaci.IndexOf(ziaci.Last())].Tag = ziaci.Last();
            treeViewZiakUpr.Nodes[comboBoxVytvZiakTr.SelectedIndex].Nodes[ziaci.IndexOf(ziaci.Last())].Nodes.Add(ziaci.Last().MenoPriezvisko);
            treeViewZiakUpr.Nodes[comboBoxVytvZiakTr.SelectedIndex].Nodes[ziaci.IndexOf(ziaci.Last())].Nodes.Add(ziaci.Last().PoradoveCislo.ToString());
            treeViewZiakUpr.Nodes[comboBoxVytvZiakTr.SelectedIndex].Nodes[ziaci.IndexOf(ziaci.Last())].Nodes.Add(ziaci.Last().Pohlavie);
            treeViewZiakUpr.Nodes[comboBoxVytvZiakTr.SelectedIndex].Nodes[ziaci.IndexOf(ziaci.Last())].Nodes.Add(ziaci.Last().Trieda.Meno);
            treeViewZiakUpr.Nodes[comboBoxVytvZiakTr.SelectedIndex].Nodes[ziaci.IndexOf(ziaci.Last())].Nodes.Add(ziaci.Last().DatumNarodenia.ToString());
            treeViewZiakUpr.Nodes[comboBoxVytvZiakTr.SelectedIndex].Nodes[ziaci.IndexOf(ziaci.Last())].Nodes[3].Tag = ziaci.Last().Trieda;*/

            Res_treeviewziakupr();
            Res_treeviewziakvymz();
            Res_treeviewvytvskrvl();
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
            foreach (TreeNode i in treeViewSkrUpr.Nodes)
            {
                if (i.Tag == skrinka)
                {
                    treeViewSkrUpr.Nodes[i.Index].Remove();
                    break;
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

            treeViewSkrVymz.SelectedNode.Remove();
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
                            Res_treeviewziakupr();
                            Res_treeviewziakvymz();
                            Res_treeviewvytvskrvl();
                        }
                        indx++;
                    }
                    triedy.Remove(i);
                    break;
                    if (triedy.Count() == 0)
                    {
                        break;
                    }
                }
            }
            foreach (TreeNode i in treeViewTrdVymz.Nodes)
            {
                foreach (TreeNode j in treeViewTrdVymz.Nodes[i.Index].Nodes)
                {
                    if (j.Tag == trieda)
                    {
                        treeViewTrdVymz.Nodes[i.Index].Nodes.Remove(j);
                        break;
                    }
                }
            }
            foreach (TreeNode i in treeViewTrdUpr.Nodes)
            {
                foreach (TreeNode j in treeViewTrdUpr.Nodes[i.Index].Nodes)
                {
                    if (j.Tag == trieda)
                    {
                        treeViewTrdUpr.Nodes[i.Index].Nodes.Remove(j);
                        break;
                    }
                }
            }
            foreach (TreeNode i in treeViewVytvSkrVl.Nodes)
            {
                if (i.Tag == trieda)
                {
                    foreach (TreeNode j in treeViewVytvSkrVl.Nodes[i.Index].Nodes)
                    {

                    }
                    treeViewVytvSkrVl.Nodes.Remove(i);
                    break;
                }
            }
            foreach (TreeNode i in treeViewZiakUpr.Nodes)
            {
                if (i.Tag == trieda)
                {
                    foreach (TreeNode j in treeViewZiakUpr.Nodes[i.Index].Nodes)
                    {

                    }
                    treeViewZiakUpr.Nodes.Remove(i);
                    break;
                }
            }
            foreach (TreeNode i in treeViewZiakVymz.Nodes)
            {
                if (i.Tag == trieda)
                {
                    foreach (TreeNode j in treeViewZiakVymz.Nodes[i.Index].Nodes)
                    {

                    }
                    treeViewZiakVymz.Nodes.Remove(i);
                    break;
                }
            }
            foreach (String i in comboBoxVytvZiakTr.Items)
            {
                if (trieda != null)
                {
                    if (i == trieda.Meno)
                    {
                        comboBoxVytvZiakTr.Items.RemoveAt(comboBoxVytvZiakTr.Items.IndexOf(i));
                        break;
                    }
                    if (comboBoxVytvZiakTr.Items.Count == 0)
                    {
                        break;
                    }
                }
            }
            Combobox_res(comboBoxVytvZiakTr);
            Combobox_res(comboBoxVytvZiakTrHr);
            Combobox_res(comboBoxVytvZiakTrOdDoHr);
            Combobox_res(comboBoxVytvSkrTrd);

        }

        private void buttonZiakVymz_Click(object sender, EventArgs e)
        {
            Ziak ziak = null;

            foreach (TreeNode i in treeViewZiakVymz.Nodes)
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
                foreach (TreeNode j in treeViewZiakUpr.Nodes[i.Index].Nodes)
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
                if (i == ziak)
                {
                    int indx = 0;
                    foreach (Skrinka j in skrinky)
                    {
                        if (j.Vlastnik == i)
                        {
                            skrinky[indx].Vlastnik = ziaci[0];
                            Res_treeviewskrupr();
                            Res_treeviewskrvymz();
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
            foreach (TreeNode i in treeViewVytvSkrVl.Nodes)
            {
                foreach (TreeNode j in treeViewVytvSkrVl.Nodes[i.Index].Nodes)
                {
                    if (j.Tag == ziak)
                    {
                        treeViewVytvSkrVl.Nodes[i.Index].Nodes.Remove(j);
                        break;
                    }
                }

            }

            treeViewZiakVymz.SelectedNode.Remove();

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
                MessageBox.Show("!");
            }

        }

        private void treeViewSkrUpr_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (treeViewSkrUpr.SelectedNode.Tag != triedy[0])
                    treeViewSkrUpr.SelectedNode.BeginEdit();
            }
            catch
            {
                MessageBox.Show("!");
            }
        }

        private void treeViewZiakUpr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (treeViewZiakUpr.SelectedNode.Tag != ziaci[0] && treeViewZiakUpr.SelectedNode.Tag != triedy[0])
                    treeViewZiakUpr.SelectedNode.BeginEdit();
            }
            catch
            {
                MessageBox.Show("!");
            }
        }



        private void buttonSkrUprPtvZm_Click(object sender, EventArgs e)
        {
            foreach (TreeNode i in treeViewSkrUpr.Nodes)
            {
                foreach (Skrinka j in skrinky)
                {
                    if (j == i.Tag)
                    {
                        foreach (TreeNode k in treeViewSkrUpr.Nodes[i.Index].Nodes)
                        {
                            if (k.Index == 0)
                                skrinky[skrinky.IndexOf(j)].Cislo = int.Parse(treeViewSkrUpr.Nodes[i.Index].Nodes[k.Index].Text);
                            else if (k.Index == 1)
                                skrinky[skrinky.IndexOf(j)].Poznamka = treeViewSkrUpr.Nodes[i.Index].Nodes[k.Index].Text;
                            else if (k.Index == 2)
                                foreach (Ziak z in ziaci)
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
            Res_treeviewskrupr();
            Res_treeviewskrvymz();


        }

        private void buttonTrdUprPtvZm_Click(object sender, EventArgs e)
        {
            foreach (TreeNode i in treeViewTrdUpr.Nodes)
            {
                foreach (TreeNode j in treeViewTrdUpr.Nodes[i.Index].Nodes)
                {
                    foreach (Trieda l in triedy)
                    {
                        if (j.Tag == l)
                        {
                            foreach (TreeNode k in treeViewTrdUpr.Nodes[i.Index].Nodes[j.Index].Nodes)
                            {

                                if (k.Index == 0)
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
            Res_treeviewtrdupr();
            Res_treeviewtrdvymz();
            Combobox_res(comboBoxVytvZiakTr);
            Combobox_res(comboBoxVytvZiakTrHr);
            Combobox_res(comboBoxVytvZiakTrOdDoHr);
            Combobox_res(comboBoxVytvSkrTrd);
            /*
            comboBoxVytvZiakTr.Items.Clear();
            foreach(Trieda i in triedy)
            {
                comboBoxVytvZiakTr.Items.Add(i.Meno);
            }*/
        }

        private void buttonZiakUprPtvZm_Click(object sender, EventArgs e)
        {
            foreach (TreeNode i in treeViewZiakUpr.Nodes)
            {
                foreach (TreeNode j in treeViewZiakUpr.Nodes[i.Index].Nodes)
                {
                    foreach (Ziak z in ziaci)
                    {
                        if (j.Tag == z)
                        {
                            foreach (TreeNode k in treeViewZiakUpr.Nodes[i.Index].Nodes[j.Index].Nodes)
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
            Res_treeviewziakupr();
            Res_treeviewziakvymz();
            Res_treeviewvytvskrvl();
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
            for (int i = 0; i < int.Parse(textBoxVytvTrPocHr.Text); i++)
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

            Res_treeviewtrdupr();
            Res_treeviewtrdvymz();

            Combobox_res(comboBoxVytvZiakTr);
            Combobox_res(comboBoxVytvZiakTrHr);
            Combobox_res(comboBoxVytvZiakTrOdDoHr);
            Combobox_res(comboBoxVytvSkrTrd);
        }

        private void buttonVytvTrHrOdDo_Click(object sender, EventArgs e)
        {
            for (int i = int.Parse(textBoxVytvTrRcHrOd.Text); i <= int.Parse(textBoxVytvTrRcHrDo.Text); i++)
            {
                triedy.Add(new Trieda(i.ToString() + "." + textBoxVytvTrOdbHrOdDo.Text, textBoxVytvTrOdbHrOdDo.Text, " ", i));
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


            Res_treeviewtrdupr();
            Res_treeviewtrdvymz();

            Combobox_res(comboBoxVytvZiakTr);
            Combobox_res(comboBoxVytvZiakTrHr);
            Combobox_res(comboBoxVytvZiakTrOdDoHr);
            Combobox_res(comboBoxVytvSkrTrd);
        }



        private void buttonVytvZiakHr_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < int.Parse(textBoxVytvZiakPocHr.Text); i++)
            {
                ziaci.Add(new Ziak(textBoxVytvZiakMPHr.Text, int.Parse(textBoxVytvZiakPCHr.Text), comboBoxVytvZiakPohHr.SelectedItem.ToString(), dateTimePickerVytvZiakDNHr.Value, triedy[comboBoxVytvZiakTrHr.SelectedIndex]));
            }

            Res_treeviewziakupr();
            Res_treeviewziakvymz();
            Res_treeviewvytvskrvl();
        }

        private void buttonVytvZiakHrTr_Click(object sender, EventArgs e)
        {
            for (int i = int.Parse(textBoxVytvZiakPCOdHr.Text); i <= int.Parse(textBoxVytvZiakPCDoHr.Text); i++)
            {
                ziaci.Add(new Ziak("", i, "", new DateTime(1), triedy[comboBoxVytvZiakTrOdDoHr.SelectedIndex]));
            }

            Res_treeviewziakupr();
            Res_treeviewziakvymz();
            Res_treeviewvytvskrvl();
        }




        private void buttonVytvSkrHr_Click(object sender, EventArgs e)
        {
            for (int i = int.Parse(textBoxVytvSkrCsOd.Text); i < int.Parse(textBoxVytvSkrCsDo.Text); i++)
            {
                skrinky.Add(new Skrinka(i, richTextBoxVytvSkrPozHr.Text, ziaci[0]));
            }
            Res_treeviewskrupr();
            Res_treeviewskrvymz();
        }

        private void buttonVytvSkrHrTr_Click(object sender, EventArgs e)
        {
            int cislo = 1;
            foreach (Ziak i in ziaci)
            {
                if (i.Trieda == triedy[comboBoxVytvZiakTrOdDoHr.SelectedIndex])
                {
                    skrinky.Add(new Skrinka(cislo, "", i));
                    cislo++;
                }
            }
            Res_treeviewskrupr();
            Res_treeviewskrvymz();
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

            /*if (rocniky_pridane.Count != 0)
            {
                var opt4 = new JsonSerializerOptions() { WriteIndented=true };
                int jsonString4 = JsonSerializer.Serialize(rocniky_pridane.ToString(), opt4);

                using (var writer = new StreamWriter(_pathRocnik))
                {
                    writer.Write(jsonString4);
                }
            }*/

            /*string[] the_array = rocniky_pridane.Select(i => i.ToString()).ToArray();
            var opt5 = new JsonSerializerOptions() { WriteIndented=true };
            string jsonString5 = JsonSerializer.Serialize(the_array, opt5);

            using (var writer = new StreamWriter(_pathRocnik))
            {
                writer.Write(jsonString5);
            }
            */
        }
    }   
}

