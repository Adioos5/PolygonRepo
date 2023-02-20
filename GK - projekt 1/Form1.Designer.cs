namespace GK___projekt_1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Canvas = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.EditionRadioButton = new System.Windows.Forms.RadioButton();
            this.MovementRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.VertexInsertionCheckBox = new System.Windows.Forms.CheckBox();
            this.ParallelismCheckBox = new System.Windows.Forms.CheckBox();
            this.LengthCheckBox = new System.Windows.Forms.CheckBox();
            this.Algorithm = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.LibraryRadioButton = new System.Windows.Forms.RadioButton();
            this.BresenhamRadioButton = new System.Windows.Forms.RadioButton();
            this.AppLogo = new System.Windows.Forms.PictureBox();
            this.XiaolinWuRadioButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.Algorithm.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AppLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Canvas.Location = new System.Drawing.Point(3, 3);
            this.Canvas.MaximumSize = new System.Drawing.Size(3000, 3000);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(1021, 855);
            this.Canvas.TabIndex = 0;
            this.Canvas.TabStop = false;
            this.Canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseDown);
            this.Canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseMove);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.Canvas, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1284, 861);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.Algorithm, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.AppLogo, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1030, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(251, 855);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tableLayoutPanel3);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(3, 216);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 207);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mode";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.EditionRadioButton, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.MovementRadioButton, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 30);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(239, 174);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // EditionRadioButton
            // 
            this.EditionRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.EditionRadioButton.AutoSize = true;
            this.EditionRadioButton.Location = new System.Drawing.Point(40, 3);
            this.EditionRadioButton.Margin = new System.Windows.Forms.Padding(40, 3, 3, 3);
            this.EditionRadioButton.Name = "EditionRadioButton";
            this.EditionRadioButton.Size = new System.Drawing.Size(92, 81);
            this.EditionRadioButton.TabIndex = 0;
            this.EditionRadioButton.TabStop = true;
            this.EditionRadioButton.Text = "Edition";
            this.EditionRadioButton.UseVisualStyleBackColor = true;
            this.EditionRadioButton.CheckedChanged += new System.EventHandler(this.EditionRadioButton_CheckedChanged);
            // 
            // MovementRadioButton
            // 
            this.MovementRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.MovementRadioButton.AutoSize = true;
            this.MovementRadioButton.Location = new System.Drawing.Point(40, 90);
            this.MovementRadioButton.Margin = new System.Windows.Forms.Padding(40, 3, 3, 3);
            this.MovementRadioButton.Name = "MovementRadioButton";
            this.MovementRadioButton.Size = new System.Drawing.Size(125, 81);
            this.MovementRadioButton.TabIndex = 1;
            this.MovementRadioButton.TabStop = true;
            this.MovementRadioButton.Text = "Movement";
            this.MovementRadioButton.UseVisualStyleBackColor = true;
            this.MovementRadioButton.CheckedChanged += new System.EventHandler(this.MovementRadioButton_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(3, 429);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(245, 207);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Edition Tools";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.VertexInsertionCheckBox, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.ParallelismCheckBox, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.LengthCheckBox, 0, 2);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 30);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(239, 174);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // VertexInsertionCheckBox
            // 
            this.VertexInsertionCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.VertexInsertionCheckBox.AutoSize = true;
            this.VertexInsertionCheckBox.Location = new System.Drawing.Point(40, 3);
            this.VertexInsertionCheckBox.Margin = new System.Windows.Forms.Padding(40, 3, 3, 3);
            this.VertexInsertionCheckBox.Name = "VertexInsertionCheckBox";
            this.VertexInsertionCheckBox.Size = new System.Drawing.Size(166, 52);
            this.VertexInsertionCheckBox.TabIndex = 0;
            this.VertexInsertionCheckBox.Text = "Vertex Insertion";
            this.VertexInsertionCheckBox.UseVisualStyleBackColor = true;
            this.VertexInsertionCheckBox.CheckedChanged += new System.EventHandler(this.VertexInsertionCheckBox_CheckedChanged);
            // 
            // ParallelismCheckBox
            // 
            this.ParallelismCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ParallelismCheckBox.AutoSize = true;
            this.ParallelismCheckBox.Location = new System.Drawing.Point(40, 61);
            this.ParallelismCheckBox.Margin = new System.Windows.Forms.Padding(40, 3, 3, 3);
            this.ParallelismCheckBox.Name = "ParallelismCheckBox";
            this.ParallelismCheckBox.Size = new System.Drawing.Size(123, 52);
            this.ParallelismCheckBox.TabIndex = 1;
            this.ParallelismCheckBox.Text = "Parallelism";
            this.ParallelismCheckBox.UseVisualStyleBackColor = true;
            this.ParallelismCheckBox.CheckedChanged += new System.EventHandler(this.ParallelismCheckBox_CheckedChanged);
            // 
            // LengthCheckBox
            // 
            this.LengthCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LengthCheckBox.AutoSize = true;
            this.LengthCheckBox.Location = new System.Drawing.Point(40, 119);
            this.LengthCheckBox.Margin = new System.Windows.Forms.Padding(40, 3, 3, 3);
            this.LengthCheckBox.Name = "LengthCheckBox";
            this.LengthCheckBox.Size = new System.Drawing.Size(91, 52);
            this.LengthCheckBox.TabIndex = 2;
            this.LengthCheckBox.Text = "Length";
            this.LengthCheckBox.UseVisualStyleBackColor = true;
            this.LengthCheckBox.CheckedChanged += new System.EventHandler(this.LengthCheckBox_CheckedChanged);
            // 
            // Algorithm
            // 
            this.Algorithm.Controls.Add(this.tableLayoutPanel5);
            this.Algorithm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Algorithm.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Algorithm.Location = new System.Drawing.Point(3, 642);
            this.Algorithm.Name = "Algorithm";
            this.Algorithm.Size = new System.Drawing.Size(245, 210);
            this.Algorithm.TabIndex = 3;
            this.Algorithm.TabStop = false;
            this.Algorithm.Text = "Algorithm";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.LibraryRadioButton, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.BresenhamRadioButton, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.XiaolinWuRadioButton, 0, 2);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 30);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(239, 177);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // LibraryRadioButton
            // 
            this.LibraryRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LibraryRadioButton.AutoSize = true;
            this.LibraryRadioButton.Checked = true;
            this.LibraryRadioButton.Location = new System.Drawing.Point(40, 3);
            this.LibraryRadioButton.Margin = new System.Windows.Forms.Padding(40, 3, 3, 3);
            this.LibraryRadioButton.Name = "LibraryRadioButton";
            this.LibraryRadioButton.Size = new System.Drawing.Size(90, 53);
            this.LibraryRadioButton.TabIndex = 0;
            this.LibraryRadioButton.TabStop = true;
            this.LibraryRadioButton.Text = "Library";
            this.LibraryRadioButton.UseVisualStyleBackColor = true;
            this.LibraryRadioButton.CheckedChanged += new System.EventHandler(this.LibraryRadioButton_CheckedChanged);
            // 
            // BresenhamRadioButton
            // 
            this.BresenhamRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.BresenhamRadioButton.AutoSize = true;
            this.BresenhamRadioButton.Location = new System.Drawing.Point(40, 62);
            this.BresenhamRadioButton.Margin = new System.Windows.Forms.Padding(40, 3, 3, 3);
            this.BresenhamRadioButton.Name = "BresenhamRadioButton";
            this.BresenhamRadioButton.Size = new System.Drawing.Size(125, 53);
            this.BresenhamRadioButton.TabIndex = 1;
            this.BresenhamRadioButton.Text = "Bresenham";
            this.BresenhamRadioButton.UseVisualStyleBackColor = true;
            this.BresenhamRadioButton.CheckedChanged += new System.EventHandler(this.BresenhamRadioButton_CheckedChanged);
            // 
            // AppLogo
            // 
            this.AppLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AppLogo.ErrorImage = ((System.Drawing.Image)(resources.GetObject("AppLogo.ErrorImage")));
            this.AppLogo.ImageLocation = "0,0";
            this.AppLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("AppLogo.InitialImage")));
            this.AppLogo.Location = new System.Drawing.Point(3, 3);
            this.AppLogo.Name = "AppLogo";
            this.AppLogo.Size = new System.Drawing.Size(245, 207);
            this.AppLogo.TabIndex = 4;
            this.AppLogo.TabStop = false;
            // 
            // XiaolinWuRadioButton
            // 
            this.XiaolinWuRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.XiaolinWuRadioButton.AutoSize = true;
            this.XiaolinWuRadioButton.Location = new System.Drawing.Point(40, 121);
            this.XiaolinWuRadioButton.Margin = new System.Windows.Forms.Padding(40, 3, 3, 3);
            this.XiaolinWuRadioButton.Name = "XiaolinWuRadioButton";
            this.XiaolinWuRadioButton.Size = new System.Drawing.Size(125, 53);
            this.XiaolinWuRadioButton.TabIndex = 2;
            this.XiaolinWuRadioButton.TabStop = true;
            this.XiaolinWuRadioButton.Text = "Xiaolin Wu";
            this.XiaolinWuRadioButton.UseVisualStyleBackColor = true;
            this.XiaolinWuRadioButton.CheckedChanged += new System.EventHandler(this.XiaolinWuRadioButton_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1284, 861);
            this.Controls.Add(this.tableLayoutPanel1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Polygon";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.Algorithm.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AppLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox Canvas;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel3;
        private GroupBox groupBox2;
        private TableLayoutPanel tableLayoutPanel4;
        private RadioButton EditionRadioButton;
        private RadioButton MovementRadioButton;
        private GroupBox Algorithm;
        private TableLayoutPanel tableLayoutPanel5;
        private RadioButton LibraryRadioButton;
        private RadioButton BresenhamRadioButton;
        private CheckBox VertexInsertionCheckBox;
        private CheckBox ParallelismCheckBox;
        private CheckBox LengthCheckBox;
        private PictureBox AppLogo;
        private RadioButton XiaolinWuRadioButton;
    }
}