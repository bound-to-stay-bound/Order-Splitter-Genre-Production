namespace PickingCopy_Order_Splitter
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FetchTitles = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CustomerOrderNumber = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.OriginalPickDate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FakePickDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PrintSummary = new System.Windows.Forms.Button();
            this.UpdateOrder = new System.Windows.Forms.Button();
            this.OrderSplitterChoice = new System.Windows.Forms.CheckedListBox();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.FetchTitles);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CustomerOrderNumber);
            this.groupBox1.Location = new System.Drawing.Point(2, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 63);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Order Info";
            // 
            // FetchTitles
            // 
            this.FetchTitles.Location = new System.Drawing.Point(157, 33);
            this.FetchTitles.Name = "FetchTitles";
            this.FetchTitles.Size = new System.Drawing.Size(118, 19);
            this.FetchTitles.TabIndex = 4;
            this.FetchTitles.Text = "Fetch Titles";
            this.FetchTitles.UseVisualStyleBackColor = true;
            this.FetchTitles.Click += new System.EventHandler(this.FetchTitles_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Customer + Order Number";
            // 
            // CustomerOrderNumber
            // 
            this.CustomerOrderNumber.Location = new System.Drawing.Point(6, 32);
            this.CustomerOrderNumber.MaxLength = 13;
            this.CustomerOrderNumber.Name = "CustomerOrderNumber";
            this.CustomerOrderNumber.Size = new System.Drawing.Size(129, 20);
            this.CustomerOrderNumber.TabIndex = 0;
            this.CustomerOrderNumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CustomerOrderNumber_KeyUp);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.OriginalPickDate);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.FakePickDate);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.PrintSummary);
            this.groupBox3.Controls.Add(this.UpdateOrder);
            this.groupBox3.Controls.Add(this.OrderSplitterChoice);
            this.groupBox3.Location = new System.Drawing.Point(2, 79);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(297, 445);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Split Operations";
            // 
            // OriginalPickDate
            // 
            this.OriginalPickDate.AutoSize = true;
            this.OriginalPickDate.Location = new System.Drawing.Point(100, 19);
            this.OriginalPickDate.Name = "OriginalPickDate";
            this.OriginalPickDate.Size = new System.Drawing.Size(13, 13);
            this.OriginalPickDate.TabIndex = 19;
            this.OriginalPickDate.Text = "?";
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.Location = new System.Drawing.Point(3, 295);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(278, 43);
            this.label2.TabIndex = 18;
            this.label2.Text = "Checked dewey classifications will display/print normally.  Unchecked entries wil" +
    "l be removed from the group of Picked titles.";
            // 
            // FakePickDate
            // 
            this.FakePickDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FakePickDate.Location = new System.Drawing.Point(116, 374);
            this.FakePickDate.Name = "FakePickDate";
            this.FakePickDate.Size = new System.Drawing.Size(154, 20);
            this.FakePickDate.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 378);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Update PickDate To";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Current PickDate";
            // 
            // PrintSummary
            // 
            this.PrintSummary.Location = new System.Drawing.Point(6, 341);
            this.PrintSummary.Name = "PrintSummary";
            this.PrintSummary.Size = new System.Drawing.Size(281, 27);
            this.PrintSummary.TabIndex = 13;
            this.PrintSummary.Text = "Print";
            this.PrintSummary.UseVisualStyleBackColor = true;
            this.PrintSummary.Click += new System.EventHandler(this.PrintSummary_Click);
            // 
            // UpdateOrder
            // 
            this.UpdateOrder.Location = new System.Drawing.Point(4, 394);
            this.UpdateOrder.Name = "UpdateOrder";
            this.UpdateOrder.Size = new System.Drawing.Size(282, 26);
            this.UpdateOrder.TabIndex = 9;
            this.UpdateOrder.Text = "Update Order";
            this.UpdateOrder.UseVisualStyleBackColor = true;
            this.UpdateOrder.Click += new System.EventHandler(this.UpdateOrder_Click);
            // 
            // OrderSplitterChoice
            // 
            this.OrderSplitterChoice.FormattingEnabled = true;
            this.OrderSplitterChoice.Location = new System.Drawing.Point(6, 41);
            this.OrderSplitterChoice.Name = "OrderSplitterChoice";
            this.OrderSplitterChoice.Size = new System.Drawing.Size(282, 244);
            this.OrderSplitterChoice.TabIndex = 8;
            // 
            // printDocument1
            // 
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 536);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Genre Order Splitter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button FetchTitles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CustomerOrderNumber;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckedListBox OrderSplitterChoice;
        private System.Windows.Forms.Button UpdateOrder;
        private System.Windows.Forms.DateTimePicker FakePickDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button PrintSummary;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label OriginalPickDate;
    }
}

