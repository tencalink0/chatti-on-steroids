using System;
using System.Windows.Forms;

class MainForm : Form
{
    private TextBox textBox = null!;

    public void RenderTextBox(Size WindowSize) 
    {
        textBox = new TextBox();
        textBox.Size = new Size((int)(WindowSize.Width / 1.5), WindowSize.Height / 10);
        textBox.Multiline = true;
        textBox.Location = new Point(
            (int)(WindowSize.Width / 10),
            (int)(WindowSize.Height - 100)
        );

        textBox.BorderStyle = BorderStyle.FixedSingle;
        
        Controls.Add(textBox);
    }

    public void RenderButtons(Size WindowSize) 
    {
        Button btn = new Button();
        btn.Text = "CLICK";
        btn.Size = new Size(WindowSize.Width / 10, WindowSize.Height / 10);
        btn.Location = new Point
        (
            WindowSize.Width - btn.Width - 10, 
            (int)(WindowSize.Height - (1.5 * btn.Height) - 10)
        );


        btn.Click += (sender, e) => MessageBox.Show($"Message Inputted '{textBox.Text ?? ""}'");
    
        Controls.Add(btn);
    }

    public MainForm(string Title, Size WindowSize)
    {
        Text = Title;
        Width = WindowSize.Width;
        Height = WindowSize.Height;
        StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.FixedSingle;

        RenderButtons(WindowSize);
        RenderTextBox(WindowSize);
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
