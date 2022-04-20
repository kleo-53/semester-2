namespace Calculator;

partial class CalculatorForm
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
        this.button1 = new System.Windows.Forms.Button();
        this.button2 = new System.Windows.Forms.Button();
        this.button3 = new System.Windows.Forms.Button();
        this.button4 = new System.Windows.Forms.Button();
        this.button5 = new System.Windows.Forms.Button();
        this.button6 = new System.Windows.Forms.Button();
        this.button7 = new System.Windows.Forms.Button();
        this.button8 = new System.Windows.Forms.Button();
        this.button9 = new System.Windows.Forms.Button();
        this.button0 = new System.Windows.Forms.Button();
        this.tableButtons = new System.Windows.Forms.TableLayoutPanel();
        this.buttonDivision = new System.Windows.Forms.Button();
        this.buttonMultiply = new System.Windows.Forms.Button();
        this.buttonSubtract = new System.Windows.Forms.Button();
        this.buttonAddition = new System.Windows.Forms.Button();
        this.buttonBackspace = new System.Windows.Forms.Button();
        this.buttonClearAll = new System.Windows.Forms.Button();
        this.buttonEqual = new System.Windows.Forms.Button();
        this.buttonDecimalDot = new System.Windows.Forms.Button();
        this.tableCalculatorBody = new System.Windows.Forms.TableLayoutPanel();
        this.textNumbers = new System.Windows.Forms.Label();
        this.tableButtons.SuspendLayout();
        this.tableCalculatorBody.SuspendLayout();
        this.SuspendLayout();
        // 
        // button1
        // 
        this.button1.Location = new System.Drawing.Point(3, 115);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(52, 50);
        this.button1.TabIndex = 0;
        this.button1.Text = "1";
        this.button1.UseVisualStyleBackColor = true;
        this.button1.Click += new System.EventHandler(this.buttonDigital_Click);
        // 
        // button2
        // 
        this.button2.Location = new System.Drawing.Point(61, 115);
        this.button2.Name = "button2";
        this.button2.Size = new System.Drawing.Size(52, 50);
        this.button2.TabIndex = 1;
        this.button2.Text = "2";
        this.button2.UseVisualStyleBackColor = true;
        this.button2.Click += new System.EventHandler(this.buttonDigital_Click);
        // 
        // button3
        // 
        this.button3.Location = new System.Drawing.Point(119, 115);
        this.button3.Name = "button3";
        this.button3.Size = new System.Drawing.Size(52, 50);
        this.button3.TabIndex = 2;
        this.button3.Text = "3";
        this.button3.UseVisualStyleBackColor = true;
        this.button3.Click += new System.EventHandler(this.buttonDigital_Click);
        // 
        // button4
        // 
        this.button4.Location = new System.Drawing.Point(3, 59);
        this.button4.Name = "button4";
        this.button4.Size = new System.Drawing.Size(52, 50);
        this.button4.TabIndex = 3;
        this.button4.Text = "4";
        this.button4.UseVisualStyleBackColor = true;
        this.button4.Click += new System.EventHandler(this.buttonDigital_Click);
        // 
        // button5
        // 
        this.button5.Location = new System.Drawing.Point(61, 59);
        this.button5.Name = "button5";
        this.button5.Size = new System.Drawing.Size(52, 50);
        this.button5.TabIndex = 4;
        this.button5.Text = "5";
        this.button5.UseVisualStyleBackColor = true;
        this.button5.Click += new System.EventHandler(this.buttonDigital_Click);
        // 
        // button6
        // 
        this.button6.Location = new System.Drawing.Point(119, 59);
        this.button6.Name = "button6";
        this.button6.Size = new System.Drawing.Size(52, 50);
        this.button6.TabIndex = 5;
        this.button6.Text = "6";
        this.button6.UseVisualStyleBackColor = true;
        this.button6.Click += new System.EventHandler(this.buttonDigital_Click);
        // 
        // button7
        // 
        this.button7.Location = new System.Drawing.Point(3, 3);
        this.button7.Name = "button7";
        this.button7.Size = new System.Drawing.Size(52, 50);
        this.button7.TabIndex = 6;
        this.button7.Text = "7";
        this.button7.UseVisualStyleBackColor = true;
        this.button7.Click += new System.EventHandler(this.buttonDigital_Click);
        // 
        // button8
        // 
        this.button8.Location = new System.Drawing.Point(61, 3);
        this.button8.Name = "button8";
        this.button8.Size = new System.Drawing.Size(52, 50);
        this.button8.TabIndex = 7;
        this.button8.Text = "8";
        this.button8.UseVisualStyleBackColor = true;
        this.button8.Click += new System.EventHandler(this.buttonDigital_Click);
        // 
        // button9
        // 
        this.button9.Location = new System.Drawing.Point(119, 3);
        this.button9.Name = "button9";
        this.button9.Size = new System.Drawing.Size(52, 50);
        this.button9.TabIndex = 8;
        this.button9.Text = "9";
        this.button9.UseVisualStyleBackColor = true;
        this.button9.Click += new System.EventHandler(this.buttonDigital_Click);
        // 
        // button0
        // 
        this.button0.Location = new System.Drawing.Point(3, 171);
        this.button0.Name = "button0";
        this.button0.Size = new System.Drawing.Size(52, 50);
        this.button0.TabIndex = 9;
        this.button0.Text = "0";
        this.button0.UseVisualStyleBackColor = true;
        this.button0.Click += new System.EventHandler(this.buttonDigital_Click);
        // 
        // tableButtons
        // 
        this.tableButtons.ColumnCount = 5;
        this.tableButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
        this.tableButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
        this.tableButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
        this.tableButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
        this.tableButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
        this.tableButtons.Controls.Add(this.button4, 0, 1);
        this.tableButtons.Controls.Add(this.button8, 1, 0);
        this.tableButtons.Controls.Add(this.button1, 0, 2);
        this.tableButtons.Controls.Add(this.button5, 1, 1);
        this.tableButtons.Controls.Add(this.button6, 2, 1);
        this.tableButtons.Controls.Add(this.button7, 0, 0);
        this.tableButtons.Controls.Add(this.button2, 1, 2);
        this.tableButtons.Controls.Add(this.button3, 2, 2);
        this.tableButtons.Controls.Add(this.buttonDivision, 3, 0);
        this.tableButtons.Controls.Add(this.buttonMultiply, 3, 1);
        this.tableButtons.Controls.Add(this.buttonSubtract, 3, 2);
        this.tableButtons.Controls.Add(this.buttonAddition, 3, 3);
        this.tableButtons.Controls.Add(this.buttonBackspace, 4, 0);
        this.tableButtons.Controls.Add(this.buttonClearAll, 4, 1);
        this.tableButtons.Controls.Add(this.buttonEqual, 4, 3);
        this.tableButtons.Controls.Add(this.button0, 0, 3);
        this.tableButtons.Controls.Add(this.buttonDecimalDot, 1, 3);
        this.tableButtons.Controls.Add(this.button9, 2, 0);
        this.tableButtons.Location = new System.Drawing.Point(3, 54);
        this.tableButtons.Name = "tableButtons";
        this.tableButtons.RowCount = 4;
        this.tableButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
        this.tableButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
        this.tableButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
        this.tableButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
        this.tableButtons.Size = new System.Drawing.Size(292, 224);
        this.tableButtons.TabIndex = 10;
        // 
        // buttonDivision
        // 
        this.buttonDivision.Location = new System.Drawing.Point(177, 3);
        this.buttonDivision.Name = "buttonDivision";
        this.buttonDivision.Size = new System.Drawing.Size(52, 50);
        this.buttonDivision.TabIndex = 10;
        this.buttonDivision.Text = "/";
        this.buttonDivision.UseVisualStyleBackColor = true;
        this.buttonDivision.Click += new System.EventHandler(this.buttonOperation_Click);
        // 
        // buttonMultiply
        // 
        this.buttonMultiply.Location = new System.Drawing.Point(177, 59);
        this.buttonMultiply.Name = "buttonMultiply";
        this.buttonMultiply.Size = new System.Drawing.Size(52, 50);
        this.buttonMultiply.TabIndex = 11;
        this.buttonMultiply.Text = "*";
        this.buttonMultiply.UseVisualStyleBackColor = true;
        this.buttonMultiply.Click += new System.EventHandler(this.buttonOperation_Click);
        // 
        // buttonSubtract
        // 
        this.buttonSubtract.Location = new System.Drawing.Point(177, 115);
        this.buttonSubtract.Name = "buttonSubtract";
        this.buttonSubtract.Size = new System.Drawing.Size(52, 50);
        this.buttonSubtract.TabIndex = 12;
        this.buttonSubtract.Text = "-";
        this.buttonSubtract.UseVisualStyleBackColor = true;
        this.buttonSubtract.Click += new System.EventHandler(this.buttonOperation_Click);
        // 
        // buttonAddition
        // 
        this.buttonAddition.Location = new System.Drawing.Point(177, 171);
        this.buttonAddition.Name = "buttonAddition";
        this.buttonAddition.Size = new System.Drawing.Size(52, 50);
        this.buttonAddition.TabIndex = 13;
        this.buttonAddition.Text = "+";
        this.buttonAddition.UseVisualStyleBackColor = true;
        this.buttonAddition.Click += new System.EventHandler(this.buttonOperation_Click);
        // 
        // buttonBackspace
        // 
        this.buttonBackspace.Location = new System.Drawing.Point(235, 3);
        this.buttonBackspace.Name = "buttonBackspace";
        this.buttonBackspace.Size = new System.Drawing.Size(54, 50);
        this.buttonBackspace.TabIndex = 14;
        this.buttonBackspace.Text = "←";
        this.buttonBackspace.UseVisualStyleBackColor = true;
        this.buttonBackspace.Click += new System.EventHandler(this.buttonBackspace_Click);
        // 
        // buttonClearAll
        // 
        this.buttonClearAll.Location = new System.Drawing.Point(235, 59);
        this.buttonClearAll.Name = "buttonClearAll";
        this.buttonClearAll.Size = new System.Drawing.Size(54, 50);
        this.buttonClearAll.TabIndex = 15;
        this.buttonClearAll.Text = "C";
        this.buttonClearAll.UseVisualStyleBackColor = true;
        this.buttonClearAll.Click += new System.EventHandler(this.buttonClearAll_Click);
        // 
        // buttonEqual
        // 
        this.buttonEqual.Location = new System.Drawing.Point(235, 171);
        this.buttonEqual.Name = "buttonEqual";
        this.buttonEqual.Size = new System.Drawing.Size(54, 50);
        this.buttonEqual.TabIndex = 16;
        this.buttonEqual.Text = "=";
        this.buttonEqual.UseVisualStyleBackColor = true;
        this.buttonEqual.Click += new System.EventHandler(this.buttonEqual_Click);
        // 
        // buttonDecimalDot
        // 
        this.buttonDecimalDot.Location = new System.Drawing.Point(61, 171);
        this.buttonDecimalDot.Name = "buttonDecimalDot";
        this.buttonDecimalDot.Size = new System.Drawing.Size(52, 50);
        this.buttonDecimalDot.TabIndex = 17;
        this.buttonDecimalDot.Text = ",";
        this.buttonDecimalDot.UseVisualStyleBackColor = true;
        this.buttonDecimalDot.Click += new System.EventHandler(this.buttonDecimalDot_Click);
        // 
        // tableCalculatorBody
        // 
        this.tableCalculatorBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.tableCalculatorBody.ColumnCount = 1;
        this.tableCalculatorBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.tableCalculatorBody.Controls.Add(this.tableButtons, 0, 1);
        this.tableCalculatorBody.Controls.Add(this.textNumbers, 0, 0);
        this.tableCalculatorBody.Location = new System.Drawing.Point(30, 96);
        this.tableCalculatorBody.Name = "tableCalculatorBody";
        this.tableCalculatorBody.RowCount = 2;
        this.tableCalculatorBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.14947F));
        this.tableCalculatorBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.85053F));
        this.tableCalculatorBody.Size = new System.Drawing.Size(298, 281);
        this.tableCalculatorBody.TabIndex = 11; 
        // 
        // textNumbers
        // 
        this.textNumbers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.textNumbers.AutoSize = true;
        this.textNumbers.Location = new System.Drawing.Point(275, 11);
        this.textNumbers.MaximumSize = new System.Drawing.Size(290, 40);
        this.textNumbers.MinimumSize = new System.Drawing.Size(20, 40);
        this.textNumbers.Name = "textNumbers";
        this.textNumbers.Size = new System.Drawing.Size(20, 40);
        this.textNumbers.TabIndex = 11;
        // 
        // CalculatorForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(352, 403);
        this.Controls.Add(this.tableCalculatorBody);
        this.MinimumSize = new System.Drawing.Size(370, 450);
        this.Name = "CalculatorForm";
        this.Text = "Calculator";
        this.tableButtons.ResumeLayout(false);
        this.tableCalculatorBody.ResumeLayout(false);
        this.tableCalculatorBody.PerformLayout();
        this.ResumeLayout(false);

    }

    #endregion

    private Button button1;
    private Button button2;
    private Button button3;
    private Button button4;
    private Button button5;
    private Button button6;
    private Button button7;
    private Button button8;
    private Button button9;
    private TableLayoutPanel tableButtons;
    private Button button0;
    private Button buttonDivision;
    private Button buttonMultiply;
    private Button buttonSubtract;
    private Button buttonAddition;
    private Button buttonBackspace;
    private Button buttonClearAll;
    private Button buttonEqual;
    private Button buttonDecimalDot;
    private TableLayoutPanel tableCalculatorBody;
    private Label textNumbers;
}
