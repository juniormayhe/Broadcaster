namespace Broadcaster
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pnlExpander = new System.Windows.Forms.Panel();
            this.lnkClose = new System.Windows.Forms.LinkLabel();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.pnlMessage = new System.Windows.Forms.Panel();
            this.lnkNext = new System.Windows.Forms.LinkLabel();
            this.lnkBack = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlExpander.SuspendLayout();
            this.pnlMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlExpander
            // 
            this.pnlExpander.BackColor = System.Drawing.Color.SteelBlue;
            this.pnlExpander.BackgroundImage = global::Broadcaster.Properties.Resources.right_arrow;
            this.pnlExpander.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlExpander.Controls.Add(this.lnkClose);
            this.pnlExpander.Controls.Add(this.monthCalendar1);
            this.pnlExpander.Controls.Add(this.txtBuscar);
            this.pnlExpander.Controls.Add(this.btnBuscar);
            this.pnlExpander.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlExpander.Location = new System.Drawing.Point(342, -2);
            this.pnlExpander.Name = "pnlExpander";
            this.pnlExpander.Size = new System.Drawing.Size(264, 259);
            this.pnlExpander.TabIndex = 18;
            this.toolTip1.SetToolTip(this.pnlExpander, "Fechar este painel de busca");
            this.pnlExpander.Click += new System.EventHandler(this.pnlExpander_Click);
            // 
            // lnkClose
            // 
            this.lnkClose.ActiveLinkColor = System.Drawing.Color.Silver;
            this.lnkClose.AutoSize = true;
            this.lnkClose.BackColor = System.Drawing.Color.Transparent;
            this.lnkClose.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkClose.LinkColor = System.Drawing.Color.White;
            this.lnkClose.Location = new System.Drawing.Point(107, 228);
            this.lnkClose.Name = "lnkClose";
            this.lnkClose.Size = new System.Drawing.Size(44, 17);
            this.lnkClose.TabIndex = 30;
            this.lnkClose.TabStop = true;
            this.lnkClose.Text = "fechar";
            this.toolTip1.SetToolTip(this.lnkClose, "Fechar painel de busca");
            this.lnkClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkClose_LinkClicked);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.monthCalendar1.Location = new System.Drawing.Point(11, 15);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.ShowTodayCircle = false;
            this.monthCalendar1.TabIndex = 22;
            this.toolTip1.SetToolTip(this.monthCalendar1, "Mostrar avisos de um determinado dia");
            this.monthCalendar1.TrailingForeColor = System.Drawing.Color.Silver;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtBuscar.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtBuscar.Location = new System.Drawing.Point(11, 189);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(188, 29);
            this.txtBuscar.TabIndex = 0;
            this.txtBuscar.Text = "Procurar...";
            this.toolTip1.SetToolTip(this.txtBuscar, "Buscar avisos contendo um texto");
            this.txtBuscar.Enter += new System.EventHandler(this.txtBuscar_Enter);
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.YellowGreen;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnBuscar.Image = global::Broadcaster.Properties.Resources.tabsearch;
            this.btnBuscar.Location = new System.Drawing.Point(205, 189);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(33, 29);
            this.btnBuscar.TabIndex = 21;
            this.toolTip1.SetToolTip(this.btnBuscar, "Buscar avisos contendo um texto");
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Broadcaster";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // pnlMessage
            // 
            this.pnlMessage.Controls.Add(this.lnkNext);
            this.pnlMessage.Controls.Add(this.lnkBack);
            this.pnlMessage.Controls.Add(this.label2);
            this.pnlMessage.Controls.Add(this.label1);
            this.pnlMessage.Controls.Add(this.lblTitle);
            this.pnlMessage.Controls.Add(this.lblDate);
            this.pnlMessage.Controls.Add(this.lblMessage);
            this.pnlMessage.Location = new System.Drawing.Point(4, 6);
            this.pnlMessage.Name = "pnlMessage";
            this.pnlMessage.Size = new System.Drawing.Size(337, 251);
            this.pnlMessage.TabIndex = 0;
            this.toolTip1.SetToolTip(this.pnlMessage, "tyyy");
            // 
            // lnkNext
            // 
            this.lnkNext.ActiveLinkColor = System.Drawing.Color.YellowGreen;
            this.lnkNext.AutoSize = true;
            this.lnkNext.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkNext.Location = new System.Drawing.Point(253, 223);
            this.lnkNext.Name = "lnkNext";
            this.lnkNext.Size = new System.Drawing.Size(69, 17);
            this.lnkNext.TabIndex = 29;
            this.lnkNext.TabStop = true;
            this.lnkNext.Text = "Próximo >";
            this.toolTip1.SetToolTip(this.lnkNext, "Mostrar próximo aviso");
            this.lnkNext.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkNext_LinkClicked);
            // 
            // lnkBack
            // 
            this.lnkBack.ActiveLinkColor = System.Drawing.Color.YellowGreen;
            this.lnkBack.AutoSize = true;
            this.lnkBack.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkBack.Location = new System.Drawing.Point(13, 223);
            this.lnkBack.Name = "lnkBack";
            this.lnkBack.Size = new System.Drawing.Size(68, 17);
            this.lnkBack.TabIndex = 28;
            this.lnkBack.TabStop = true;
            this.lnkBack.Text = "< Anterior";
            this.toolTip1.SetToolTip(this.lnkBack, "Mostrar aviso anterior");
            this.lnkBack.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkBack_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(8, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 19);
            this.label2.TabIndex = 25;
            this.label2.Text = "Mensagem";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 19);
            this.label1.TabIndex = 24;
            this.label1.Text = "Anúncio";
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(12, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(310, 44);
            this.lblTitle.TabIndex = 21;
            this.lblTitle.Text = "Aguardando mensagem...";
            // 
            // lblDate
            // 
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.DarkGray;
            this.lblDate.Location = new System.Drawing.Point(12, 199);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(310, 19);
            this.lblDate.TabIndex = 23;
            this.lblDate.Text = "data";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblMessage.ForeColor = System.Drawing.Color.Black;
            this.lblMessage.Location = new System.Drawing.Point(12, 107);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(310, 92);
            this.lblMessage.TabIndex = 22;
            this.lblMessage.Text = "Aguardando mensagem...";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(594, 257);
            this.Controls.Add(this.pnlExpander);
            this.Controls.Add(this.pnlMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "Broadcaster";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.pnlExpander.ResumeLayout(false);
            this.pnlExpander.PerformLayout();
            this.pnlMessage.ResumeLayout(false);
            this.pnlMessage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlExpander;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Panel pnlMessage;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.LinkLabel lnkBack;
        private System.Windows.Forms.LinkLabel lnkNext;
        private System.Windows.Forms.LinkLabel lnkClose;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer timer1;
    }
}

