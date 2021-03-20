
namespace TubesStima2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gViewer1 = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.FileInput = new System.Windows.Forms.MaskedTextBox();
            this.FileInputLabel = new System.Windows.Forms.Label();
            this.AlgorithmSelectLabel = new System.Windows.Forms.Label();
            this.BFSRadio = new System.Windows.Forms.RadioButton();
            this.DFSRadio = new System.Windows.Forms.RadioButton();
            this.AccountLabel = new System.Windows.Forms.Label();
            this.AccountInput = new System.Windows.Forms.MaskedTextBox();
            this.ExploreLabel = new System.Windows.Forms.Label();
            this.ExploreInput = new System.Windows.Forms.MaskedTextBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.ResultBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // gViewer1
            // 
            this.gViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gViewer1.ArrowheadLength = 10D;
            this.gViewer1.AsyncLayout = false;
            this.gViewer1.AutoScroll = true;
            this.gViewer1.BackwardEnabled = false;
            this.gViewer1.BuildHitTree = true;
            this.gViewer1.CurrentLayoutMethod = Microsoft.Msagl.GraphViewerGdi.LayoutMethod.UseSettingsOfTheGraph;
            this.gViewer1.EdgeInsertButtonVisible = true;
            this.gViewer1.FileName = "";
            this.gViewer1.ForwardEnabled = false;
            this.gViewer1.Graph = null;
            this.gViewer1.InsertingEdge = false;
            this.gViewer1.LayoutAlgorithmSettingsButtonVisible = true;
            this.gViewer1.LayoutEditingEnabled = true;
            this.gViewer1.Location = new System.Drawing.Point(12, 90);
            this.gViewer1.LooseOffsetForRouting = 0.25D;
            this.gViewer1.MouseHitDistance = 0.05D;
            this.gViewer1.Name = "gViewer1";
            this.gViewer1.NavigationVisible = true;
            this.gViewer1.NeedToCalculateLayout = true;
            this.gViewer1.OffsetForRelaxingInRouting = 0.6D;
            this.gViewer1.PaddingForEdgeRouting = 8D;
            this.gViewer1.PanButtonPressed = false;
            this.gViewer1.SaveAsImageEnabled = true;
            this.gViewer1.SaveAsMsaglEnabled = true;
            this.gViewer1.SaveButtonVisible = true;
            this.gViewer1.SaveGraphButtonVisible = true;
            this.gViewer1.SaveInVectorFormatEnabled = true;
            this.gViewer1.Size = new System.Drawing.Size(510, 304);
            this.gViewer1.TabIndex = 0;
            this.gViewer1.TightOffsetForRouting = 0.125D;
            this.gViewer1.ToolBarIsVisible = true;
            this.gViewer1.Transform = ((Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation)(resources.GetObject("gViewer1.Transform")));
            this.gViewer1.UndoRedoButtonsVisible = true;
            this.gViewer1.WindowZoomButtonPressed = false;
            this.gViewer1.ZoomF = 1D;
            this.gViewer1.ZoomWindowThreshold = 0.05D;
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(389, 22);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseButton.TabIndex = 1;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // FileInput
            // 
            this.FileInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileInput.Location = new System.Drawing.Point(88, 24);
            this.FileInput.Name = "FileInput";
            this.FileInput.Size = new System.Drawing.Size(259, 20);
            this.FileInput.TabIndex = 2;
            // 
            // FileInputLabel
            // 
            this.FileInputLabel.AutoSize = true;
            this.FileInputLabel.Location = new System.Drawing.Point(30, 27);
            this.FileInputLabel.Name = "FileInputLabel";
            this.FileInputLabel.Size = new System.Drawing.Size(56, 13);
            this.FileInputLabel.TabIndex = 3;
            this.FileInputLabel.Text = "File Input :";
            // 
            // AlgorithmSelectLabel
            // 
            this.AlgorithmSelectLabel.AutoSize = true;
            this.AlgorithmSelectLabel.Location = new System.Drawing.Point(30, 60);
            this.AlgorithmSelectLabel.Name = "AlgorithmSelectLabel";
            this.AlgorithmSelectLabel.Size = new System.Drawing.Size(56, 13);
            this.AlgorithmSelectLabel.TabIndex = 4;
            this.AlgorithmSelectLabel.Text = "Algorithm :";
            // 
            // BFSRadio
            // 
            this.BFSRadio.AutoSize = true;
            this.BFSRadio.Location = new System.Drawing.Point(92, 60);
            this.BFSRadio.Name = "BFSRadio";
            this.BFSRadio.Size = new System.Drawing.Size(45, 17);
            this.BFSRadio.TabIndex = 5;
            this.BFSRadio.TabStop = true;
            this.BFSRadio.Text = "BFS";
            this.BFSRadio.UseVisualStyleBackColor = true;
            this.BFSRadio.CheckedChanged += new System.EventHandler(this.BFSRadio_CheckedChanged);
            // 
            // DFSRadio
            // 
            this.DFSRadio.AutoSize = true;
            this.DFSRadio.Location = new System.Drawing.Point(143, 60);
            this.DFSRadio.Name = "DFSRadio";
            this.DFSRadio.Size = new System.Drawing.Size(46, 17);
            this.DFSRadio.TabIndex = 6;
            this.DFSRadio.TabStop = true;
            this.DFSRadio.Text = "DFS";
            this.DFSRadio.UseVisualStyleBackColor = true;
            this.DFSRadio.CheckedChanged += new System.EventHandler(this.DFSRadio_CheckedChanged);
            // 
            // AccountLabel
            // 
            this.AccountLabel.AutoSize = true;
            this.AccountLabel.Location = new System.Drawing.Point(30, 414);
            this.AccountLabel.Name = "AccountLabel";
            this.AccountLabel.Size = new System.Drawing.Size(53, 13);
            this.AccountLabel.TabIndex = 8;
            this.AccountLabel.Text = "Account :";
            // 
            // AccountInput
            // 
            this.AccountInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AccountInput.Location = new System.Drawing.Point(88, 411);
            this.AccountInput.Name = "AccountInput";
            this.AccountInput.Size = new System.Drawing.Size(79, 20);
            this.AccountInput.TabIndex = 7;
            // 
            // ExploreLabel
            // 
            this.ExploreLabel.AutoSize = true;
            this.ExploreLabel.Location = new System.Drawing.Point(30, 440);
            this.ExploreLabel.Name = "ExploreLabel";
            this.ExploreLabel.Size = new System.Drawing.Size(48, 13);
            this.ExploreLabel.TabIndex = 10;
            this.ExploreLabel.Text = "Explore :";
            // 
            // ExploreInput
            // 
            this.ExploreInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExploreInput.Location = new System.Drawing.Point(88, 437);
            this.ExploreInput.Name = "ExploreInput";
            this.ExploreInput.Size = new System.Drawing.Size(79, 20);
            this.ExploreInput.TabIndex = 9;
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(33, 472);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(75, 23);
            this.SearchButton.TabIndex = 11;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // ResultBox
            // 
            this.ResultBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultBox.Location = new System.Drawing.Point(12, 501);
            this.ResultBox.Name = "ResultBox";
            this.ResultBox.ReadOnly = true;
            this.ResultBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.ResultBox.Size = new System.Drawing.Size(510, 69);
            this.ResultBox.TabIndex = 12;
            this.ResultBox.Text = "";
            // 
            // Form1
            // 
            this.AcceptButton = this.SearchButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 582);
            this.Controls.Add(this.ResultBox);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.ExploreLabel);
            this.Controls.Add(this.ExploreInput);
            this.Controls.Add(this.AccountLabel);
            this.Controls.Add(this.AccountInput);
            this.Controls.Add(this.DFSRadio);
            this.Controls.Add(this.BFSRadio);
            this.Controls.Add(this.AlgorithmSelectLabel);
            this.Controls.Add(this.FileInputLabel);
            this.Controls.Add(this.FileInput);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.gViewer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Msagl.GraphViewerGdi.GViewer gViewer1;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.MaskedTextBox FileInput;
        private System.Windows.Forms.Label FileInputLabel;
        private System.Windows.Forms.Label AlgorithmSelectLabel;
        private System.Windows.Forms.RadioButton BFSRadio;
        private System.Windows.Forms.RadioButton DFSRadio;
        private System.Windows.Forms.Label AccountLabel;
        private System.Windows.Forms.MaskedTextBox AccountInput;
        private System.Windows.Forms.Label ExploreLabel;
        private System.Windows.Forms.MaskedTextBox ExploreInput;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.RichTextBox ResultBox;
    }
}

