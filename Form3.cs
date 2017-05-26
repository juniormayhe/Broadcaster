using BroadcastRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.AccountManagement;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Broadcaster
{
    public partial class Form3 : Form
    {
        private static int totalRecords = 10;
        private static int pageSize = 5;

        public IQueryable<BroadcastRepository.Message> messages;
        public MessageRepository mr;
        public BroadcastRepository.Message currentMessage;
        public ReadMessageRepository rm;
        bool keepAnnoying, keepAnnoyingAboutRead = true;

        public Form3()
        {
            InitializeComponent();

            try
            {
                string nome = System.DirectoryServices.AccountManagement.UserPrincipal.Current.DisplayName.Split(' ')[0];
            }
            catch (PrincipalServerDownException pex)
            {
                MessageBox.Show($"Não foi possível determinar seu usuário na rede.\n\nEfetue o seu logon na rede Windows e execute este programa a partir do seu disco local.\n\n{pex.Message}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Environment.Exit(0);
                //return;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Não foi possível determinar seu usuário na rede.\n\nEfetue o seu logon na rede Windows e execute este programa a partir do seu disco local:\n\n{ex.GetType().ToString()} {ex.StackTrace.ToString()} {ex.Message}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Environment.Exit(0);
                //return;
            }
            this.WindowState = FormWindowState.Minimized;
            mr = new MessageRepository();
            rm = new ReadMessageRepository();

            
            timer1.Start();
            backgroundWorker1.RunWorkerAsync();
        }

        //loadRecentMessages();

        
        private void loadRecentMessages()
        {
            try
            {
                toolStripButton2.Visible = false;
                toolStripButton2.Visible = false;

                messages = mr.RecentList;
                totalRecords = messages.Count();
                messageBindingNavigator.BindingSource = messageBindingSource;
                messageBindingSource.CurrentChanged += MessageBindingSource_CurrentChanged;
                this.Invoke(new Action(() =>
                {
                    messageBindingSource.DataSource = new PageOffsetList();
                }));
                
                keepAnnoying = true;
            }
            catch (Exception ex) {
                if (keepAnnoying)
                {
                    MessageBox.Show("Ocorreu um problema ao tentar ler os avisos. Tente mais tarde.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    keepAnnoying = false;
                }
            }

            try
            {
                currentMessage = messages.FirstOrDefault();

                var r = rm.Find(currentMessage.MessageID, Environment.UserName);
                if (r == null)
                {
                    //if message was not read by user, pop it up
                    showBalloon();
                    
                    rm.Add(new ReadMessage { MessageID = currentMessage.MessageID, Username = Environment.UserName });
                }
                keepAnnoyingAboutRead = true;
            }
            catch (Exception ex) {
                
                if (keepAnnoyingAboutRead)
                {
                    MessageBox.Show("Ocorreu um problema ao tentar marcar o aviso como lido. Tente mais tarde.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    keepAnnoyingAboutRead = false;
                }
            }

        }

        private void MessageBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (messageBindingSource.Current == null) {
                
                return;
            }
            // The desired page has changed, so fetch the page of records using the "Current" offset 
            int offset = (int)messageBindingSource.Current;
            var records = new List<BroadcastRepository.Message>();
            for (int i = offset; i < offset + pageSize && i < totalRecords; i++)
                records.Add(messages.ToList().ElementAt(i));
            messageDataGridView.DataSource = records;
        }

        class PageOffsetList : System.ComponentModel.IListSource
        {
            public bool ContainsListCollection { get; protected set; }

            public System.Collections.IList GetList()
            {
                // Return a list of page offsets based on "totalRecords" and "pageSize"
                var pageOffsets = new List<int>();
                for (int offset = 0; offset < totalRecords; offset += pageSize)
                    pageOffsets.Add(offset);
                return pageOffsets;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            search();
        }

        private void search()
        {
            string texto = toolStripTextBox1.Text.Trim();
            if (texto == string.Empty)
            {
                MessageBox.Show("Por favor informe um termo para busca", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                toolStripTextBox1.Focus();
                return;
            }
            var filteredMessages = mr.FilterByText(texto);
            if (filteredMessages.Count() == 0)
            {
                MessageBox.Show($"Nenhum aviso foi encontrado com a palavra \"{toolStripTextBox1.Text}\"", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                totalRecords = filteredMessages.Count();
                messages = filteredMessages;
                messageBindingNavigator.BindingSource = messageBindingSource;
                messageBindingSource.CurrentChanged += MessageBindingSource_CurrentChanged;
                messageBindingSource.DataSource = new PageOffsetList();
                toolStripButton2.Visible = true;
                toolStripButton2.Visible = true;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            loadRecentMessages();
            
        }

        private void toolStripTextBox1_Enter(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text.Trim() == "Digite a palavra desejada...")
            {
                toolStripTextBox1.Text = "";
                toolStripTextBox1.ForeColor = SystemColors.ControlText;
            }
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text.Trim() == "Digite a palavra desejada...")
            {
                toolStripTextBox1.Text = "";
                toolStripTextBox1.ForeColor = SystemColors.ControlDark;
            }
            else
                toolStripTextBox1.ForeColor = SystemColors.ControlText;
        }

        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                search();
            }
        }

        private void Form3_Resize(object sender, EventArgs e)
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

        private void showBalloon()
        {
            
            notifyIcon1.Visible = true;
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.BalloonTipTitle = currentMessage.MessageTitle;
            notifyIcon1.BalloonTipText = currentMessage.MessageBody;
            notifyIcon1.Text = "Broadcaster";

            //notifyIcon1.BalloonTipText = Regex.Replace(notifyIcon1.BalloonTipText, @"\s*\r\n\s*", "\r\n");
            //notifyIcon1.BalloonTipText = Regex.Replace(notifyIcon1.BalloonTipText, @"\s*\r\r\s*", "\r");

            notifyIcon1.ShowBalloonTip(20 * 1000);
            System.Media.SoundPlayer sound = new System.Media.SoundPlayer(Broadcaster.Properties.Resources.sino);
            sound.PlaySync();

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //test if toolstripbutton exists because it can be unavailable s
                //reset filter
                toolStripButton2.Visible = false;
                toolStripButton2.Visible = false;

            
            //then load messages
            loadRecentMessages();
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            showForm();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            showForm();
        }

        private void showForm()
        {
            this.WindowState = FormWindowState.Normal;
            this.Activate();
            this.Show();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {

            //capture keys on form
            if (keyData == Keys.Left)

                bindingNavigatorMovePreviousItem.PerformClick();
            else if (keyData == Keys.Right)
                bindingNavigatorMoveNextItem.PerformClick();
            else if (keyData == Keys.Home)
                bindingNavigatorMoveFirstItem.PerformClick();
            else if (keyData == Keys.End)
                bindingNavigatorMoveLastItem.PerformClick();
            else if (keyData == Keys.Escape)
                Hide();

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
