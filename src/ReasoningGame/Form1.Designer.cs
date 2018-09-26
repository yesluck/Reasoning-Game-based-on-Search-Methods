namespace ReasoningGame
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timeBox = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.questionLabel = new System.Windows.Forms.Label();
            this.dialogLabelA = new System.Windows.Forms.Label();
            this.dialogLabelB = new System.Windows.Forms.Label();
            this.dialogLabelC = new System.Windows.Forms.Label();
            this.identityBoxA = new System.Windows.Forms.ComboBox();
            this.identityBoxB = new System.Windows.Forms.ComboBox();
            this.identityBoxC = new System.Windows.Forms.ComboBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.machineMode = new System.Windows.Forms.RadioButton();
            this.humanMode = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.typeA = new System.Windows.Forms.RadioButton();
            this.typeB = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.defaultQuestion = new System.Windows.Forms.RadioButton();
            this.randomQuestion = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.testHardBackground = new System.Windows.Forms.RadioButton();
            this.coffeeBackground = new System.Windows.Forms.RadioButton();
            this.testBackground = new System.Windows.Forms.RadioButton();
            this.metalBackground = new System.Windows.Forms.RadioButton();
            this.courseBackground = new System.Windows.Forms.RadioButton();
            this.quizButton = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.identityBoxD = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.amOnlyStyle = new System.Windows.Forms.RadioButton();
            this.amNotStyle = new System.Windows.Forms.RadioButton();
            this.dialogLabelD = new System.Windows.Forms.Label();
            this.identityLabelA = new System.Windows.Forms.Label();
            this.identityLabelD = new System.Windows.Forms.Label();
            this.identityLabelB = new System.Windows.Forms.Label();
            this.identityLabelC = new System.Windows.Forms.Label();
            this.dialogBox3 = new System.Windows.Forms.PictureBox();
            this.dialogBox4 = new System.Windows.Forms.PictureBox();
            this.dialogBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dialogBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.LinZikun = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.timeBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dialogBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dialogBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dialogBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dialogBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("方正等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(155, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "剩余时间";
            // 
            // timeLabel
            // 
            this.timeLabel.BackColor = System.Drawing.Color.Transparent;
            this.timeLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.timeLabel.Font = new System.Drawing.Font("方正等线", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.timeLabel.ForeColor = System.Drawing.Color.Red;
            this.timeLabel.Location = new System.Drawing.Point(226, 30);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(134, 32);
            this.timeLabel.TabIndex = 1;
            this.timeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("方正等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(424, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "设定时间";
            // 
            // timeBox
            // 
            this.timeBox.Enabled = false;
            this.timeBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.timeBox.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.timeBox.Location = new System.Drawing.Point(492, 36);
            this.timeBox.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.timeBox.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.timeBox.Name = "timeBox";
            this.timeBox.Size = new System.Drawing.Size(45, 23);
            this.timeBox.TabIndex = 3;
            this.timeBox.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("方正等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(543, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "秒";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(43, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "问题";
            // 
            // questionLabel
            // 
            this.questionLabel.BackColor = System.Drawing.Color.Transparent;
            this.questionLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.questionLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.questionLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.questionLabel.Location = new System.Drawing.Point(47, 111);
            this.questionLabel.Name = "questionLabel";
            this.questionLabel.Size = new System.Drawing.Size(659, 103);
            this.questionLabel.TabIndex = 6;
            this.questionLabel.Text = "请在右侧选择问题属性，并点击“出题”获取问题。";
            // 
            // dialogLabelA
            // 
            this.dialogLabelA.BackColor = System.Drawing.Color.Transparent;
            this.dialogLabelA.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dialogLabelA.Location = new System.Drawing.Point(30, 242);
            this.dialogLabelA.Name = "dialogLabelA";
            this.dialogLabelA.Size = new System.Drawing.Size(113, 40);
            this.dialogLabelA.TabIndex = 7;
            this.dialogLabelA.Text = "甲说的话";
            this.dialogLabelA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dialogLabelB
            // 
            this.dialogLabelB.BackColor = System.Drawing.Color.Transparent;
            this.dialogLabelB.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dialogLabelB.Location = new System.Drawing.Point(210, 242);
            this.dialogLabelB.Name = "dialogLabelB";
            this.dialogLabelB.Size = new System.Drawing.Size(113, 40);
            this.dialogLabelB.TabIndex = 8;
            this.dialogLabelB.Text = "乙说的话";
            this.dialogLabelB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dialogLabelC
            // 
            this.dialogLabelC.BackColor = System.Drawing.Color.Transparent;
            this.dialogLabelC.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dialogLabelC.Location = new System.Drawing.Point(593, 238);
            this.dialogLabelC.Name = "dialogLabelC";
            this.dialogLabelC.Size = new System.Drawing.Size(113, 40);
            this.dialogLabelC.TabIndex = 9;
            this.dialogLabelC.Text = "丙说的话";
            this.dialogLabelC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // identityBoxA
            // 
            this.identityBoxA.Enabled = false;
            this.identityBoxA.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.identityBoxA.FormattingEnabled = true;
            this.identityBoxA.Items.AddRange(new object[] {
            "牧师",
            "赌棍",
            "骗子"});
            this.identityBoxA.Location = new System.Drawing.Point(12, 616);
            this.identityBoxA.MaxDropDownItems = 4;
            this.identityBoxA.Name = "identityBoxA";
            this.identityBoxA.Size = new System.Drawing.Size(155, 25);
            this.identityBoxA.TabIndex = 15;
            this.identityBoxA.Text = "请选择他的身份";
            // 
            // identityBoxB
            // 
            this.identityBoxB.Enabled = false;
            this.identityBoxB.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.identityBoxB.FormattingEnabled = true;
            this.identityBoxB.Items.AddRange(new object[] {
            "牧师",
            "赌棍",
            "骗子"});
            this.identityBoxB.Location = new System.Drawing.Point(197, 616);
            this.identityBoxB.Name = "identityBoxB";
            this.identityBoxB.Size = new System.Drawing.Size(155, 25);
            this.identityBoxB.TabIndex = 16;
            this.identityBoxB.Text = "请选择他的身份";
            // 
            // identityBoxC
            // 
            this.identityBoxC.Enabled = false;
            this.identityBoxC.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.identityBoxC.FormattingEnabled = true;
            this.identityBoxC.Items.AddRange(new object[] {
            "牧师",
            "赌棍",
            "骗子"});
            this.identityBoxC.Location = new System.Drawing.Point(567, 616);
            this.identityBoxC.Name = "identityBoxC";
            this.identityBoxC.Size = new System.Drawing.Size(155, 25);
            this.identityBoxC.TabIndex = 17;
            this.identityBoxC.Text = "请选择他的身份";
            // 
            // submitButton
            // 
            this.submitButton.Enabled = false;
            this.submitButton.Location = new System.Drawing.Point(777, 599);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 23);
            this.submitButton.TabIndex = 21;
            this.submitButton.Text = "计算答案";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // machineMode
            // 
            this.machineMode.AutoSize = true;
            this.machineMode.Checked = true;
            this.machineMode.Location = new System.Drawing.Point(19, 20);
            this.machineMode.Name = "machineMode";
            this.machineMode.Size = new System.Drawing.Size(83, 16);
            this.machineMode.TabIndex = 23;
            this.machineMode.TabStop = true;
            this.machineMode.Text = "计算机解题";
            this.machineMode.UseVisualStyleBackColor = true;
            this.machineMode.CheckedChanged += new System.EventHandler(this.machineMode_CheckedChanged);
            // 
            // humanMode
            // 
            this.humanMode.AutoSize = true;
            this.humanMode.Location = new System.Drawing.Point(19, 42);
            this.humanMode.Name = "humanMode";
            this.humanMode.Size = new System.Drawing.Size(71, 16);
            this.humanMode.TabIndex = 24;
            this.humanMode.Text = "人工解题";
            this.humanMode.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.machineMode);
            this.groupBox1.Controls.Add(this.humanMode);
            this.groupBox1.Location = new System.Drawing.Point(750, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(135, 67);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "模式";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.typeA);
            this.groupBox2.Controls.Add(this.typeB);
            this.groupBox2.Location = new System.Drawing.Point(750, 130);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(135, 67);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "问题类型";
            // 
            // typeA
            // 
            this.typeA.AutoSize = true;
            this.typeA.Checked = true;
            this.typeA.Location = new System.Drawing.Point(19, 20);
            this.typeA.Name = "typeA";
            this.typeA.Size = new System.Drawing.Size(107, 16);
            this.typeA.TabIndex = 23;
            this.typeA.TabStop = true;
            this.typeA.Text = "牧师/骗子/赌棍";
            this.typeA.UseVisualStyleBackColor = true;
            this.typeA.CheckedChanged += new System.EventHandler(this.typeA_CheckedChanged);
            // 
            // typeB
            // 
            this.typeB.AutoSize = true;
            this.typeB.Location = new System.Drawing.Point(19, 42);
            this.typeB.Name = "typeB";
            this.typeB.Size = new System.Drawing.Size(107, 16);
            this.typeB.TabIndex = 24;
            this.typeB.Text = "正确/错误/部分";
            this.typeB.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.defaultQuestion);
            this.groupBox3.Controls.Add(this.randomQuestion);
            this.groupBox3.Location = new System.Drawing.Point(750, 220);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(135, 67);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "出题方式";
            // 
            // defaultQuestion
            // 
            this.defaultQuestion.AutoSize = true;
            this.defaultQuestion.Checked = true;
            this.defaultQuestion.Location = new System.Drawing.Point(19, 20);
            this.defaultQuestion.Name = "defaultQuestion";
            this.defaultQuestion.Size = new System.Drawing.Size(71, 16);
            this.defaultQuestion.TabIndex = 23;
            this.defaultQuestion.TabStop = true;
            this.defaultQuestion.Text = "默认题目";
            this.defaultQuestion.UseVisualStyleBackColor = true;
            this.defaultQuestion.CheckedChanged += new System.EventHandler(this.defaultQuestion_CheckedChanged);
            // 
            // randomQuestion
            // 
            this.randomQuestion.AutoSize = true;
            this.randomQuestion.Location = new System.Drawing.Point(19, 42);
            this.randomQuestion.Name = "randomQuestion";
            this.randomQuestion.Size = new System.Drawing.Size(71, 16);
            this.randomQuestion.TabIndex = 24;
            this.randomQuestion.Text = "随机出题";
            this.randomQuestion.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.testHardBackground);
            this.groupBox5.Controls.Add(this.coffeeBackground);
            this.groupBox5.Controls.Add(this.testBackground);
            this.groupBox5.Controls.Add(this.metalBackground);
            this.groupBox5.Controls.Add(this.courseBackground);
            this.groupBox5.Location = new System.Drawing.Point(750, 400);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(135, 134);
            this.groupBox5.TabIndex = 28;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "题目背景(类型2)";
            // 
            // testHardBackground
            // 
            this.testHardBackground.AutoSize = true;
            this.testHardBackground.Enabled = false;
            this.testHardBackground.Location = new System.Drawing.Point(19, 108);
            this.testHardBackground.Name = "testHardBackground";
            this.testHardBackground.Size = new System.Drawing.Size(95, 16);
            this.testHardBackground.TabIndex = 28;
            this.testHardBackground.Text = "考试成绩(难)";
            this.testHardBackground.UseVisualStyleBackColor = true;
            this.testHardBackground.CheckedChanged += new System.EventHandler(this.testHardBackground_CheckedChanged);
            // 
            // coffeeBackground
            // 
            this.coffeeBackground.AutoSize = true;
            this.coffeeBackground.Enabled = false;
            this.coffeeBackground.Location = new System.Drawing.Point(19, 64);
            this.coffeeBackground.Name = "coffeeBackground";
            this.coffeeBackground.Size = new System.Drawing.Size(95, 16);
            this.coffeeBackground.TabIndex = 26;
            this.coffeeBackground.Text = "咖啡猜测(易)";
            this.coffeeBackground.UseVisualStyleBackColor = true;
            this.coffeeBackground.CheckedChanged += new System.EventHandler(this.coffeeBackground_CheckedChanged);
            // 
            // testBackground
            // 
            this.testBackground.AutoSize = true;
            this.testBackground.Enabled = false;
            this.testBackground.Location = new System.Drawing.Point(19, 86);
            this.testBackground.Name = "testBackground";
            this.testBackground.Size = new System.Drawing.Size(95, 16);
            this.testBackground.TabIndex = 25;
            this.testBackground.Text = "考试成绩(中)";
            this.testBackground.UseVisualStyleBackColor = true;
            this.testBackground.CheckedChanged += new System.EventHandler(this.testBackground_CheckedChanged);
            // 
            // metalBackground
            // 
            this.metalBackground.AutoSize = true;
            this.metalBackground.Checked = true;
            this.metalBackground.Enabled = false;
            this.metalBackground.Location = new System.Drawing.Point(19, 20);
            this.metalBackground.Name = "metalBackground";
            this.metalBackground.Size = new System.Drawing.Size(95, 16);
            this.metalBackground.TabIndex = 23;
            this.metalBackground.TabStop = true;
            this.metalBackground.Text = "矿石分析(易)";
            this.metalBackground.UseVisualStyleBackColor = true;
            this.metalBackground.CheckedChanged += new System.EventHandler(this.metalBackground_CheckedChanged);
            // 
            // courseBackground
            // 
            this.courseBackground.AutoSize = true;
            this.courseBackground.Enabled = false;
            this.courseBackground.Location = new System.Drawing.Point(19, 42);
            this.courseBackground.Name = "courseBackground";
            this.courseBackground.Size = new System.Drawing.Size(95, 16);
            this.courseBackground.TabIndex = 24;
            this.courseBackground.Text = "挂科惨案(易)";
            this.courseBackground.UseVisualStyleBackColor = true;
            this.courseBackground.CheckedChanged += new System.EventHandler(this.courseBackground_CheckedChanged);
            // 
            // quizButton
            // 
            this.quizButton.Location = new System.Drawing.Point(777, 563);
            this.quizButton.Name = "quizButton";
            this.quizButton.Size = new System.Drawing.Size(75, 23);
            this.quizButton.TabIndex = 29;
            this.quizButton.Text = "出题";
            this.quizButton.UseVisualStyleBackColor = true;
            this.quizButton.Click += new System.EventHandler(this.quizButton_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // identityBoxD
            // 
            this.identityBoxD.Enabled = false;
            this.identityBoxD.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.identityBoxD.FormattingEnabled = true;
            this.identityBoxD.Items.AddRange(new object[] {
            "牧师",
            "赌棍",
            "骗子"});
            this.identityBoxD.Location = new System.Drawing.Point(382, 616);
            this.identityBoxD.Name = "identityBoxD";
            this.identityBoxD.Size = new System.Drawing.Size(155, 25);
            this.identityBoxD.TabIndex = 30;
            this.identityBoxD.Text = "请选择他的身份";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.amOnlyStyle);
            this.groupBox4.Controls.Add(this.amNotStyle);
            this.groupBox4.Location = new System.Drawing.Point(750, 310);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(135, 67);
            this.groupBox4.TabIndex = 28;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "题目形式(类型1)";
            // 
            // amOnlyStyle
            // 
            this.amOnlyStyle.AutoSize = true;
            this.amOnlyStyle.Checked = true;
            this.amOnlyStyle.Location = new System.Drawing.Point(19, 20);
            this.amOnlyStyle.Name = "amOnlyStyle";
            this.amOnlyStyle.Size = new System.Drawing.Size(95, 16);
            this.amOnlyStyle.TabIndex = 23;
            this.amOnlyStyle.TabStop = true;
            this.amOnlyStyle.Text = "无否定句(易)";
            this.amOnlyStyle.UseVisualStyleBackColor = true;
            this.amOnlyStyle.CheckedChanged += new System.EventHandler(this.amOnlyStyle_CheckedChanged);
            // 
            // amNotStyle
            // 
            this.amNotStyle.AutoSize = true;
            this.amNotStyle.Enabled = false;
            this.amNotStyle.Location = new System.Drawing.Point(19, 42);
            this.amNotStyle.Name = "amNotStyle";
            this.amNotStyle.Size = new System.Drawing.Size(95, 16);
            this.amNotStyle.TabIndex = 24;
            this.amNotStyle.Text = "有否定句(难)";
            this.amNotStyle.UseVisualStyleBackColor = true;
            // 
            // dialogLabelD
            // 
            this.dialogLabelD.BackColor = System.Drawing.Color.Transparent;
            this.dialogLabelD.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dialogLabelD.Location = new System.Drawing.Point(407, 238);
            this.dialogLabelD.Name = "dialogLabelD";
            this.dialogLabelD.Size = new System.Drawing.Size(113, 40);
            this.dialogLabelD.TabIndex = 33;
            this.dialogLabelD.Text = "丁说的话";
            this.dialogLabelD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // identityLabelA
            // 
            this.identityLabelA.BackColor = System.Drawing.Color.Transparent;
            this.identityLabelA.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.identityLabelA.Location = new System.Drawing.Point(99, 745);
            this.identityLabelA.Name = "identityLabelA";
            this.identityLabelA.Size = new System.Drawing.Size(159, 20);
            this.identityLabelA.TabIndex = 18;
            this.identityLabelA.Text = "真实身份";
            this.identityLabelA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // identityLabelD
            // 
            this.identityLabelD.BackColor = System.Drawing.Color.Transparent;
            this.identityLabelD.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.identityLabelD.Location = new System.Drawing.Point(453, 745);
            this.identityLabelD.Name = "identityLabelD";
            this.identityLabelD.Size = new System.Drawing.Size(159, 20);
            this.identityLabelD.TabIndex = 31;
            this.identityLabelD.Text = "a";
            this.identityLabelD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // identityLabelB
            // 
            this.identityLabelB.BackColor = System.Drawing.Color.Transparent;
            this.identityLabelB.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.identityLabelB.Location = new System.Drawing.Point(276, 745);
            this.identityLabelB.Name = "identityLabelB";
            this.identityLabelB.Size = new System.Drawing.Size(159, 20);
            this.identityLabelB.TabIndex = 19;
            this.identityLabelB.Text = "真实身份";
            this.identityLabelB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // identityLabelC
            // 
            this.identityLabelC.BackColor = System.Drawing.Color.Transparent;
            this.identityLabelC.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.identityLabelC.Location = new System.Drawing.Point(564, 694);
            this.identityLabelC.Name = "identityLabelC";
            this.identityLabelC.Size = new System.Drawing.Size(159, 20);
            this.identityLabelC.TabIndex = 20;
            this.identityLabelC.Text = "真实身份";
            this.identityLabelC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dialogBox3
            // 
            this.dialogBox3.BackColor = System.Drawing.Color.Transparent;
            this.dialogBox3.Image = global::ReasoningGame.Resource1.RIGHT;
            this.dialogBox3.Location = new System.Drawing.Point(555, 220);
            this.dialogBox3.Name = "dialogBox3";
            this.dialogBox3.Size = new System.Drawing.Size(180, 100);
            this.dialogBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dialogBox3.TabIndex = 12;
            this.dialogBox3.TabStop = false;
            // 
            // dialogBox4
            // 
            this.dialogBox4.BackColor = System.Drawing.Color.Transparent;
            this.dialogBox4.Image = global::ReasoningGame.Resource1.RIGHT;
            this.dialogBox4.Location = new System.Drawing.Point(370, 220);
            this.dialogBox4.Name = "dialogBox4";
            this.dialogBox4.Size = new System.Drawing.Size(180, 100);
            this.dialogBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dialogBox4.TabIndex = 34;
            this.dialogBox4.TabStop = false;
            // 
            // dialogBox1
            // 
            this.dialogBox1.BackColor = System.Drawing.Color.Transparent;
            this.dialogBox1.Image = ((System.Drawing.Image)(resources.GetObject("dialogBox1.Image")));
            this.dialogBox1.Location = new System.Drawing.Point(0, 220);
            this.dialogBox1.Name = "dialogBox1";
            this.dialogBox1.Size = new System.Drawing.Size(180, 100);
            this.dialogBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dialogBox1.TabIndex = 10;
            this.dialogBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(158, 330);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(469, 264);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // dialogBox2
            // 
            this.dialogBox2.BackColor = System.Drawing.Color.Transparent;
            this.dialogBox2.Image = ((System.Drawing.Image)(resources.GetObject("dialogBox2.Image")));
            this.dialogBox2.Location = new System.Drawing.Point(185, 220);
            this.dialogBox2.Name = "dialogBox2";
            this.dialogBox2.Size = new System.Drawing.Size(180, 100);
            this.dialogBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dialogBox2.TabIndex = 11;
            this.dialogBox2.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::ReasoningGame.Resource1.BGP;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(930, 680);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 32;
            this.pictureBox2.TabStop = false;
            // 
            // LinZikun
            // 
            this.LinZikun.BackColor = System.Drawing.Color.Transparent;
            this.LinZikun.Location = new System.Drawing.Point(765, 641);
            this.LinZikun.Name = "LinZikun";
            this.LinZikun.Size = new System.Drawing.Size(137, 12);
            this.LinZikun.TabIndex = 0;
            this.LinZikun.Text = "自45 林子坤 2014011541";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(914, 662);
            this.Controls.Add(this.LinZikun);
            this.Controls.Add(this.dialogLabelC);
            this.Controls.Add(this.dialogBox3);
            this.Controls.Add(this.dialogLabelD);
            this.Controls.Add(this.dialogBox4);
            this.Controls.Add(this.dialogLabelA);
            this.Controls.Add(this.dialogBox1);
            this.Controls.Add(this.dialogLabelB);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.quizButton);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.identityLabelC);
            this.Controls.Add(this.identityLabelB);
            this.Controls.Add(this.identityLabelA);
            this.Controls.Add(this.identityBoxC);
            this.Controls.Add(this.identityBoxB);
            this.Controls.Add(this.identityBoxA);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dialogBox2);
            this.Controls.Add(this.questionLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.timeBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.identityBoxD);
            this.Controls.Add(this.identityLabelD);
            this.Controls.Add(this.pictureBox2);
            this.MaximumSize = new System.Drawing.Size(930, 700);
            this.MinimumSize = new System.Drawing.Size(930, 700);
            this.Name = "Form1";
            this.Text = "推理游戏";
            ((System.ComponentModel.ISupportInitialize)(this.timeBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dialogBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dialogBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dialogBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dialogBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown timeBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label questionLabel;
        private System.Windows.Forms.Label dialogLabelA;
        private System.Windows.Forms.Label dialogLabelB;
        private System.Windows.Forms.Label dialogLabelC;
        private System.Windows.Forms.PictureBox dialogBox1;
        private System.Windows.Forms.PictureBox dialogBox2;
        private System.Windows.Forms.PictureBox dialogBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox identityBoxA;
        private System.Windows.Forms.ComboBox identityBoxB;
        private System.Windows.Forms.ComboBox identityBoxC;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.RadioButton machineMode;
        private System.Windows.Forms.RadioButton humanMode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton typeA;
        private System.Windows.Forms.RadioButton typeB;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton defaultQuestion;
        private System.Windows.Forms.RadioButton randomQuestion;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton coffeeBackground;
        private System.Windows.Forms.RadioButton testBackground;
        private System.Windows.Forms.RadioButton metalBackground;
        private System.Windows.Forms.RadioButton courseBackground;
        private System.Windows.Forms.Button quizButton;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ComboBox identityBoxD;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton amOnlyStyle;
        private System.Windows.Forms.RadioButton amNotStyle;
        private System.Windows.Forms.RadioButton testHardBackground;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label dialogLabelD;
        private System.Windows.Forms.Label identityLabelA;
        private System.Windows.Forms.Label identityLabelD;
        private System.Windows.Forms.Label identityLabelB;
        private System.Windows.Forms.Label identityLabelC;
        private System.Windows.Forms.PictureBox dialogBox4;
        private System.Windows.Forms.Label LinZikun;

    }
}

