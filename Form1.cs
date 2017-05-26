using Broadcaster.Properties;
using BroadcastRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.AccountManagement;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Broadcaster
{
    public partial class Form1 : Form
    {
        static string title, description, tooltip;
        public int i = 0;
        bool showNext = true;
        bool expanded = false;
        public MessageRepository mr;
        public ReadMessageRepository rm;
        static BroadcastRepository.Message m;
        static ReadMessage readMessage;
        bool keepAnnoying = true;
        public IQueryable<BroadcastRepository.Message> messages;
        int total;
        
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            search();
            m = messages.ToList().ElementAt(i);
            loadMessage();
        }

        private void search()
        {
            Form2 f2 = new Form2(this);
            f2.ShowDialog(this);
        }

        //public int I { get; set; }
        public string TextToFind { get { return txtBuscar.Text; } }
        public MonthCalendar MonthCalendar1 { get { return monthCalendar1; }}

        

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Activate();
            this.Show();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Activate();
            this.Show();
        }


        public Form1()
        {
            InitializeComponent();
            pnlExpander.Size = new Size(22, 259);
            this.Size = new Size(380, 296);
            pnlExpander.Tag = new Bitmap(pnlExpander.BackgroundImage);
            monthCalendar1.Visible = false;
            txtBuscar.Visible = false;
            lnkClose.Visible = false;
            pnlExpander.Cursor = Cursors.Hand;

            try
            {

                
                //MessageBox.Show(Environment.UserName);

                //string tempo = "Bom dia";
                //if (DateTime.Now.Hour > 12 && DateTime.Now.Hour < 19)
                //    tempo = "Boa tarde";
                //else if (DateTime.Now.Hour > 19 && DateTime.Now.Hour < 5)
                //    tempo = "Boa noite";
                //string nome = System.DirectoryServices.AccountManagement.UserPrincipal.Current.DisplayName.Split(' ')[0];
                //toolTip1.SetToolTip(this.pnlMessage, string.Format("{0}, {1}", tempo, nome));


                //UserPrincipal current = UserPrincipal.Current;

                //var groups = UserPrincipal.Current.GetGroups();

            }
            catch (PrincipalServerDownException pex)
            {
                MessageBox.Show($"Não foi possível determinar seu usuário na rede. Efetue o seu logon na rede Windows.\n\n{pex.Message}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Environment.Exit(0);
                //return;
            }
            catch (Exception ex) {
                MessageBox.Show($"Não foi possível determinar seu usuário na rede. Efetue o seu logon na rede Windows:\n\n{ex.GetType().ToString()} {ex.StackTrace.ToString()} {ex.Message}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Environment.Exit(0);
                //return;
            }

            mr = new MessageRepository();
            rm = new ReadMessageRepository();

            

            timer1.Start();
            backgroundWorker1.RunWorkerAsync();
            
            
        }

        private void loadMessages()
        {
            try
            {

                m = mr.GetLatestMessage(Environment.UserName);


                messages = mr.FilterByDate(DateTime.Now);
                if (messages != null && messages.Count() > 0)
                {
                    total = messages.Count();
                    i = total - 1;
                    m = messages.ToList().ElementAt(i);
                }
                else
                    total = 1;

                var r = rm.Find(m.MessageID, Environment.UserName);
                if (r == null)
                {
                    //if message was not read by user, pop it up
                    showBalloon();
                    rm.Add(new ReadMessage { MessageID = m.MessageID, Username = Environment.UserName });
                }

                if (m.Created.ToString("g") == monthCalendar1.SelectionRange.Start.ToString("g"))
                    loadMessage();
                this.Invoke(new Action(() =>
                {
                    monthCalendar1.SetDate(m.Created);
                }));
                keepAnnoying = true;
            }
            catch (Exception ex) {
                if (keepAnnoying) { 
                    MessageBox.Show("Ocorreu um problema ao tentar ler os avisos. Tente mais tarde.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    keepAnnoying = false;
                }
                this.Invoke(new Action(() =>
                {
                    this.pnlMessage.Enabled = false;
                    this.pnlExpander.Enabled = false;
                }));
            }

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            try
            {
                DateTime selectedDate = monthCalendar1.SelectionRange.Start;
                messages = mr.FilterByDate(monthCalendar1.SelectionRange.Start);
                total = messages.Count();
                if (showNext)
                    i = 0;
                else
                    i = total - 1;
                if (messages == null || messages.Count() == 0)
                {
                    lblDate.Text = string.Format("Nenhum anúncio em {0}", selectedDate.ToString("dd/MM/yyyy"));
                    lblTitle.Text = "Não há avisos";
                    lblMessage.Text = "Não há avisos para este dia";
                    return;
                }
                m = messages.ToList().ElementAt(i);
                loadMessage();
            }
            catch (Exception ex) {
                MessageBox.Show("Ocorreu um problema ao selecionar a data desejada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        

        private void pnlExpander_Click(object sender, EventArgs e)
        {
            if (!expanded)
            {
                pnlExpander.Size = new Size(264, 259);
                this.Size = new Size(613, 296);
                pnlExpander.BackgroundImage = null;
                monthCalendar1.Visible = true;
                txtBuscar.Visible = true;
                lnkClose.Visible = true;
                expanded = true;
                pnlExpander.Cursor = Cursors.Default;
            }
            else
            {
                colapse();
            }
        }

        private void colapse()
        {
            txtBuscar.Text = "";
            pnlExpander.Size = new Size(22, 259);
            this.Size = new Size(380, 296);
            pnlExpander.BackgroundImage = new Bitmap((Image)pnlExpander.Tag);
            monthCalendar1.Visible = false;
            txtBuscar.Visible = false;
            lnkClose.Visible = false;
            expanded = false;
            pnlExpander.Cursor = Cursors.Hand;
            
        }

        private void lnkBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                previous();
            }
            catch (Exception ex) {
                loadMessages();
            }

        }

        private void previous()
        {
            showNext = false;
            if (i > 0)
            {

                m = messages.ToList().ElementAt(--i);
                loadMessage();
            }
            else
            {

                //i = total-1;
                monthCalendar1.SetDate(monthCalendar1.SelectionRange.Start.AddDays(-1));
            }
        }

        private void lnkNext_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                next();
            }
            catch (Exception ex) {
                loadMessages();
            }
        }

        private void next()
        {
            showNext = true;
            if (i + 1 < total)
            {
                m = messages.ToList().ElementAt(++i);
                loadMessage();
            }
            else
            {
                i = 0;
                monthCalendar1.SetDate(monthCalendar1.SelectionRange.Start.AddDays(1));
            }
        }

        private void lnkClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            colapse();
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Trim() == "Procurar...")
                txtBuscar.Text = "";
            
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                search();
            }
        }

        
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            if (keyData == Keys.Left)
                previous();
            else if (keyData == Keys.Right)
                next();
            else if (keyData == Keys.Escape)
                this.WindowState = FormWindowState.Minimized;
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            loadMessages();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                //notifyIcon1.Visible = true;
                //notifyIcon1.ShowBalloonTip(500);
                this.Hide();
            }

            else
            {
                
                this.WindowState = FormWindowState.Normal;
                this.Activate();
                this.Show();
            }
        }

        private void loadMessage()
        {
            this.Invoke(new Action(() =>
            {
                lblDate.Text = string.Format("{0} anúncio{1} em {2}", total, total > 1 ? "s" : "", m.Created.ToString("g"));
                lblTitle.Text = m.MessageTitle;
                lblMessage.Text = $"{m.MessageBody}\n\nenviado por {m.Username}";
            }));

            
        }

        private void showBalloon()
        {
            title = m.MessageTitle;
            description = m.MessageBody;
            notifyIcon1.Visible = true;
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.BalloonTipTitle = title;
            notifyIcon1.BalloonTipText = description;
            notifyIcon1.Text = tooltip;

            //notifyIcon1.BalloonTipText = Regex.Replace(notifyIcon1.BalloonTipText, @"\s*\r\n\s*", "\r\n");
            //notifyIcon1.BalloonTipText = Regex.Replace(notifyIcon1.BalloonTipText, @"\s*\r\r\s*", "\r");
            
            notifyIcon1.ShowBalloonTip(20 * 1000);
            System.Media.SoundPlayer sound = new System.Media.SoundPlayer(Broadcaster.Properties.Resources.sino);
            sound.PlaySync();

        }


    }
}
