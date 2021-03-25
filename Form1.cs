using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TubesStima2
{
    public partial class Form1 : Form
    {
        Graph g;
        Microsoft.Msagl.Drawing.Graph graph;

        public Form1()
        {
            InitializeComponent();
            BFSRadio.Checked = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                String filename = openFileDialog1.FileName;
                FileInput.Text = filename;
            }
        }


        private void SearchButton_Click(object sender, EventArgs e)
        {
            System.Text.RegularExpressions.Regex Input2 = new System.Text.RegularExpressions.Regex(@"[A-Z]");

            //idk this is not working yet
            Dictionary<int, String> ordinal = new Dictionary<int, String>()
            {
                { 1, "st" },
                { 2, "nd" },
                { 3, "rd" }
            };

            //case no account input
            if (!Input2.IsMatch(AccountBox.GetItemText(AccountBox.SelectedItem)))
            {
                ResultBox.Text = "Invalid Input 2.";
                return;
            }

            ResultBox.Clear();

            //Explore Friend
            if ((BFSRadio.Checked || DFSRadio.Checked) && Input2.IsMatch(ExploreBox.GetItemText(ExploreBox.SelectedItem)))
            {
                List<String> pathToExplore;
                if (BFSRadio.Checked)
                {
                    pathToExplore = g.ExploreBFS(AccountBox.GetItemText(AccountBox.SelectedItem), ExploreBox.GetItemText(ExploreBox.SelectedItem));
                } else
                {
                    pathToExplore = g.ExploreDFS(AccountBox.GetItemText(AccountBox.SelectedItem), ExploreBox.GetItemText(ExploreBox.SelectedItem));
                }

                ResultBox.AppendText("Explore Path From " + AccountBox.GetItemText(AccountBox.SelectedItem) + " To " + ExploreBox.GetItemText(ExploreBox.SelectedItem) + "\n");

                if (pathToExplore[0] == "-1")
                {
                    ResultBox.AppendText("Tidak ada jalur koneksi yang tersedia.\n Anda harus memulai koneksi baru itu sendiri.\n");
                }
                else
                {
                    foreach (String path in pathToExplore)
                    {
                        if (path == pathToExplore.Last())
                        {
                            ResultBox.AppendText(path + "\n");
                        }
                        else
                        {
                            ResultBox.AppendText(path + " -> ");
                        }
                    }
                    ResultBox.AppendText((pathToExplore.Count() - 2) + " Degree\n");
                }

                ResultBox.AppendText("\n");
            }

            //Friend Recommendation
            List<List<String>> firstDegreeFriend = g.FriendRecBFS(AccountBox.GetItemText(AccountBox.SelectedItem));

            ResultBox.AppendText("Friend Recommendation For " + AccountBox.GetItemText(AccountBox.SelectedItem) + " :\n");
            foreach (List<String> list in firstDegreeFriend)
            {
                foreach (String v in list)
                {
                    if (v == list.First())
                    {
                        ResultBox.AppendText(v + "\n" + (list.Count() - 2) + " Mutual Friend : ");
                    }
                    else
                    {
                        ResultBox.AppendText(v + " ");
                    }
                }
                ResultBox.AppendText("\n");
            }

            //ResultBox.Text = "Success";

        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            String filename = FileInput.Text;
            g = new Graph();
            graph = new Microsoft.Msagl.Drawing.Graph("graph");
            System.IO.StreamReader file;

            //case no input
            if (filename == "")
            {
                ResultBox.Text = "Invalid input.";
                return;
            }

            //read file
            try
            {
                file = new System.IO.StreamReader(filename);
            }
            catch (System.IO.IOException)
            {
                ResultBox.Text = "IO Error.";
                return;
            }

            //create graph
            int numOfEdges = Int32.Parse(file.ReadLine());
            for (int i = 0; i < numOfEdges; i++)
            {
                String line = file.ReadLine();
                String[] subs = line.Split(' ');
                g.AddEdge(subs[0], subs[1]);
                graph.AddEdge(subs[0], subs[1]).Attr.ArrowheadAtTarget = Microsoft.Msagl.Drawing.ArrowStyle.None;
            }

            //show graph
            gViewer1.Graph = graph;

            AccountBox.Items.Clear();
            ExploreBox.Items.Clear();
            foreach (String v in g.vertices)
            {
                AccountBox.Items.Add(v);
                ExploreBox.Items.Add(v);
            }

        }
    }
}
