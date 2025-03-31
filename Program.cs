using System;
using System.Windows.Forms;

class MainForm : Form
{
    private TextBox textBox = null!;
    private Label stateLabel = null!;
    private Size WindowSize;

    public void RenderMessage(String message) 
    {
        Label label = new Label();
        label.Text = message; 
        label.Font = new Font("Arial", 16);
        label.Location = new Point(50, 50);
        label.AutoSize = true; 

        label.BackColor = Color.LightBlue; 
        label.ForeColor = Color.Black;

        Controls.Add(label);
    }

    public void RenderState() 
    {
        stateLabel = new();
        stateLabel.Text = "Loading";
        stateLabel.Font = new Font("Arial", 24);
        stateLabel.Location = new Point(WindowSize.Width / 2, WindowSize.Height / 2);

        Controls.Add(stateLabel);
    }

    public void RenderBase() 
    {
        Button btn = new Button();
        btn.Text = "Send";
        btn.Size = new Size(WindowSize.Width / 10, WindowSize.Height / 10);
        btn.Location = new Point
        (
            WindowSize.Width - btn.Width - 10, 
            (int)(WindowSize.Height - (1.5 * btn.Height) - 10)
        );


        btn.Click += (sender, e) => MessageBox.Show($"Message Inputted '{textBox.Text ?? ""}'");
    
        textBox = new TextBox();
        textBox.Size = new Size((int)(WindowSize.Width / 1.5), WindowSize.Height / 10);
        textBox.Multiline = true;
        textBox.Location = new Point(
            (int)(WindowSize.Width / 10),
            (int)(WindowSize.Height - 100)
        );

        textBox.BorderStyle = BorderStyle.FixedSingle;

        Controls.Add(btn);
        Controls.Add(textBox);
    }

    public MainForm(string Title, Size WindowSize)
    {
        Text = Title;
        this.WindowSize = WindowSize;
        Width = WindowSize.Width;
        Height = WindowSize.Height;
        StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.FixedSingle;

        RenderBase();
        RenderMessage("Test message");
        RenderState();
    }
}

class Program
{
    const string PROG_NAME = "Chatti On Steroids";
    static readonly Size WINDOW_SIZE = new Size(800, 600);

    [STAThread] 
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new MainForm(PROG_NAME, WINDOW_SIZE));
    }
}
