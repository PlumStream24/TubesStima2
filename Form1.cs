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
        // attributes
        Graph g;
        Microsoft.Msagl.Drawing.Graph graph;

        // init
        public Form1()
        {
            InitializeComponent();
            BFSRadio.Checked = true;
        }

        // get file path
        private void BrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                String filename = openFileDialog1.FileName;
                FileInput.Text = filename;
            }
            AccountBox.Items.Clear();
            ExploreBox.Items.Clear();
        }

        // main function
        private void SearchButton_Click(object sender, EventArgs e)
        {
            // init variables
            int start, finish;
            String AccountInput = AccountBox.GetItemText(AccountBox.SelectedItem);
            String ExploreInput = ExploreBox.GetItemText(ExploreBox.SelectedItem);
            System.Text.RegularExpressions.Regex Input2 = new System.Text.RegularExpressions.Regex(@"[A-Z]");
            
            // scuffed ordinal dictionary
            Dictionary<int, String> ordinal = new Dictionary<int, String>()
            {
                { 0, "th" }, { 1, "st" }, { 2, "nd" }, { 3, "rd" }, { 4, "th" },
                { 5, "th" }, { 6, "th" }, { 7, "th" }, { 8, "th" }, { 9, "th" },
                { 10, "th" }, { 11, "th" }, { 12, "th" }, { 13, "th" }, { 14, "th" },
                { 15, "th" }, { 16, "th" }, { 17, "th" }, { 18, "th" }, { 19, "th" },
                { 20, "th" }, { 21, "th" }, { 22, "th" }, { 23, "th" }, { 24, "th" }
            };

            //Reset Graph Color
            foreach (String v in g.vertices)
            {
                graph.FindNode(v).Attr.FillColor = Microsoft.Msagl.Drawing.Color.White;
            }

            //case no account input
            if (!Input2.IsMatch(AccountInput))
            {
                ResultBox.Text = "Invalid Input 2 . . .";
                return;
            }

            ResultBox.Clear();

            //case same input
            if (AccountInput == ExploreInput)
            {
                ResultBox.AppendText("Please input a different node . . .\n");
            }

            //Explore Friend
            if ((BFSRadio.Checked || DFSRadio.Checked) && Input2.IsMatch(ExploreInput) && AccountInput != ExploreInput)
            {
                // get path from BFS or DFS Algo
                List<String> pathToExplore;
                if (BFSRadio.Checked)
                {
                    pathToExplore = g.ExploreBFS(AccountInput, ExploreInput);
                } else
                {
                    pathToExplore = g.ExploreDFS(AccountInput, ExploreInput);
                }

                //Bold first line, it's stupid i know
                start = ResultBox.Text.Length;
                ResultBox.AppendText("Explore Path From " + AccountInput + " To " + ExploreInput + (BFSRadio.Checked ? " (BFS) " : " (DFS) ") + "\n");
                finish = ResultBox.Text.Length - start;
                ResultBox.Select(start, finish);
                ResultBox.SelectionFont = new Font(ResultBox.Font, FontStyle.Bold);

                //case not found
                if (pathToExplore[0] == "-1")
                {
                    ResultBox.AppendText("Tidak ada jalur koneksi yang tersedia.\nAnda harus memulai koneksi baru itu sendiri.\n");
                }
                //case found
                else
                {
                    //print each node and color it
                    foreach (String path in pathToExplore)
                    {
                        if (path == pathToExplore.Last())
                        {
                            ResultBox.AppendText(path + "\n");
                            graph.FindNode(path).Attr.FillColor = Microsoft.Msagl.Drawing.Color.LightPink;
                        }
                        else
                        {
                            ResultBox.AppendText(path + " -> ");
                            graph.FindNode(path).Attr.FillColor = Microsoft.Msagl.Drawing.Color.MistyRose;
                        }
                        
                    }
                    //print degree
                    ResultBox.AppendText((pathToExplore.Count() - 2) + ordinal[pathToExplore.Count() - 2] + " Degree Connection\n");
                }

                ResultBox.AppendText("\n");
            }

            //Friend Recommendation
            List<List<String>> firstDegreeFriend = g.FriendRecBFS(AccountInput);

            //Bold first line, again, it's stupid
            start = ResultBox.Text.Length;
            ResultBox.AppendText("Friend Recommendation For " + AccountInput + " :\n");
            finish = ResultBox.Text.Length - start;
            ResultBox.Select(start, finish);
            ResultBox.SelectionFont = new Font(ResultBox.Font, FontStyle.Bold);
            ResultBox.Select(ResultBox.Text.Length, 0);

            //Print
            foreach (List<String> list in firstDegreeFriend)
            {
                foreach (String v in list)
                {
                    if (v == list.First())
                    {
                        ResultBox.SelectionBullet = true;
                        ResultBox.AppendText("Friend " + v + "\n");
                        ResultBox.SelectionBullet = false;
                        ResultBox.AppendText((list.Count() - 1) + " Mutual Friend : ");
                    }
                    else
                    {
                        ResultBox.AppendText(v + " ");
                    }
                }
                ResultBox.AppendText("\n");
            }

            //Color First Node
            graph.FindNode(AccountInput).Attr.FillColor = Microsoft.Msagl.Drawing.Color.LightCyan;

            //Update Graph
            gViewer1.Graph = graph;


        }

        //Load graph from file and add selection
        private void LoadButton_Click(object sender, EventArgs e)
        {
            //init attributes
            String filename = FileInput.Text;
            g = new Graph();
            graph = new Microsoft.Msagl.Drawing.Graph("graph");
            System.IO.StreamReader file;
            System.Text.RegularExpressions.Regex filenameRegex = new System.Text.RegularExpressions.Regex(@".*\.txt");

            ResultBox.Clear();

            //case no input
            if (filename == "" || !filenameRegex.IsMatch(filename))
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

            //Add selection to boxes
            AccountBox.Items.Clear();
            ExploreBox.Items.Clear();
            foreach (String v in g.vertices)
            {
                AccountBox.Items.Add(v);
                ExploreBox.Items.Add(v);
            }

            //show graph
            gViewer1.Graph = graph;

        }
    }
}
