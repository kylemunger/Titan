using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Net.Http;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Titan.Agents;
using Titan.Core.OpenAi;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Titan.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ChatPage : Page
    {
        private string _displayContent = string.Empty;
        private IOpenAiWrapper _openAiWrapper;
        private IAgent _agent;

        public ChatPage()
        {
            this.InitializeComponent();
            _displayContent = string.Empty;
            _openAiWrapper = new OpenAiWrapper(new HttpClient(), "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");
            _agent = new SystemControllerAgent(_openAiWrapper, OpenAiModel.GPT4);
        }

        private async void SendButton_Click(object sender, RoutedEventArgs e)
        {
            await SendMessage();
        }

        private async void UserInput_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                await SendMessage();
                e.Handled = true;
            }
        }

        private void AddMessageToDisplay(string message)
        {
            BotResponse.Text += string.Format("{0}\n\n", message);
        }

        private async Task SendMessage()
        {
            IAgentTask task = new AgentTask(UserInput.Text);
            IAgentTaskResult result = await _agent.InvokeAgentTaskAsync(task);
            if (result.RequestedTask != null && result.Result != null)
            {
                AddMessageToDisplay(result.Result);
            }
        }
    }
}
