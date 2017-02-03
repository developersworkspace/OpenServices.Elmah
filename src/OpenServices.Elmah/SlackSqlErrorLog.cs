using Elmah;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenServices.Elmah
{
    public class SlackSqlErrorLog : SqlErrorLog
    {
        protected string _slackWebhookUrl { get; set; }
        protected string _messageFormat { get; set; }

        public SlackSqlErrorLog(IDictionary config) : base(config)
        {
            _slackWebhookUrl = config["slackUrl"] as string;
            _messageFormat = config["messageFormat"] as string;
        }

        public override string Name
        {
            get { return "Open Services Slack/Sql Error Log"; }
        }

        public override string Log(Error error)
        {

  

            try
            {
                Dictionary<string, string> vars = new Dictionary<string, string>();
                vars.Add("ApplicationName", error.ApplicationName);
                vars.Add("Detail", error.Detail);
                vars.Add("Exception", error.Exception.ToString());
                vars.Add("HostName", error.HostName);
                vars.Add("Message", error.Message);
                vars.Add("StatusCode", error.StatusCode.ToString());
                vars.Add("Time", error.Time.ToString());

                string message = _messageFormat;
                foreach (var key in vars)
                {
                    message = message.Replace(string.Format("[{0}]", key.Key), key.Value);
                }

                var client = new RestClient(_slackWebhookUrl);

                var request = new RestRequest(Method.POST);
                request.RequestFormat = DataFormat.Json;

                request.AddJsonBody(new
                {
                    text = message
                });

                client.ExecuteAsync(request, null);
            }catch(Exception ex)
            {

            }

            return base.Log(error);
        }
    }
}
