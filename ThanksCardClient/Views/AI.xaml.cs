using System.Windows.Controls;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIMLbot;
using System.Windows.Forms;

namespace ThanksCardClient.Views
{
    /// <summary>
    /// Interaction logic for AI
    /// </summary>
    public partial class AI 
     // : UserControl
    {
        public AI()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Bot AI = new Bot();
            AI.loadSettings(); //It will load default settings from its configuration folder.
            AI.loadAIMLFromFiles(); //With this cod will load AIML files.
            AI.isAcceptingUserInput = false;
            User myuser = new User("Username Here", AI);
            AI.isAcceptingUserInput = true;
            Request r = new Request(textBox1.Text,myuser, AI);
            Result res = new Result(myuser, AI, r);
            textBox2.Text = "Tutorial Bot: " + res.Output;

            
        }
    }
}
