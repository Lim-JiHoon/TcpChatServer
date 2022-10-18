namespace TcpChatServer
{
  partial class ServerForm
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
      this.btnConnect = new System.Windows.Forms.Button();
      this.txtChat = new System.Windows.Forms.RichTextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.txtIp = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txtPort = new System.Windows.Forms.TextBox();
      this.txtMessage = new System.Windows.Forms.TextBox();
      this.btnSendMessage = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // btnConnect
      // 
      this.btnConnect.Location = new System.Drawing.Point(228, 6);
      this.btnConnect.Name = "btnConnect";
      this.btnConnect.Size = new System.Drawing.Size(64, 23);
      this.btnConnect.TabIndex = 0;
      this.btnConnect.Text = "서버연결";
      this.btnConnect.UseVisualStyleBackColor = true;
      this.btnConnect.Click += new System.EventHandler(this.button1_Click);
      // 
      // txtChat
      // 
      this.txtChat.Location = new System.Drawing.Point(12, 35);
      this.txtChat.Name = "txtChat";
      this.txtChat.Size = new System.Drawing.Size(420, 371);
      this.txtChat.TabIndex = 1;
      this.txtChat.Text = "";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(50, 15);
      this.label1.TabIndex = 2;
      this.label1.Text = "ServerIP";
      // 
      // txtIp
      // 
      this.txtIp.Location = new System.Drawing.Point(68, 6);
      this.txtIp.Name = "txtIp";
      this.txtIp.Size = new System.Drawing.Size(68, 23);
      this.txtIp.TabIndex = 3;
      this.txtIp.Text = "127.0.0.1";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(142, 9);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(29, 15);
      this.label2.TabIndex = 4;
      this.label2.Text = "Port";
      // 
      // txtPort
      // 
      this.txtPort.Location = new System.Drawing.Point(177, 6);
      this.txtPort.Name = "txtPort";
      this.txtPort.Size = new System.Drawing.Size(45, 23);
      this.txtPort.TabIndex = 5;
      this.txtPort.Text = "8080";
      // 
      // txtMessage
      // 
      this.txtMessage.Location = new System.Drawing.Point(12, 412);
      this.txtMessage.Name = "txtMessage";
      this.txtMessage.Size = new System.Drawing.Size(321, 23);
      this.txtMessage.TabIndex = 15;
      this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyDown);
      // 
      // btnSendMessage
      // 
      this.btnSendMessage.Location = new System.Drawing.Point(339, 412);
      this.btnSendMessage.Name = "btnSendMessage";
      this.btnSendMessage.Size = new System.Drawing.Size(93, 23);
      this.btnSendMessage.TabIndex = 14;
      this.btnSendMessage.Text = "메세지 전송";
      this.btnSendMessage.UseVisualStyleBackColor = true;
      this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
      // 
      // ServerForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(442, 442);
      this.Controls.Add(this.txtMessage);
      this.Controls.Add(this.btnSendMessage);
      this.Controls.Add(this.txtPort);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.txtIp);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.txtChat);
      this.Controls.Add(this.btnConnect);
      this.Name = "ServerForm";
      this.Text = "Form1";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Button btnConnect;
    private RichTextBox txtChat;
    private Label label1;
    private TextBox txtIp;
    private Label label2;
    private TextBox txtPort;
    private TextBox txtMessage;
    private Button btnSendMessage;
  }
}