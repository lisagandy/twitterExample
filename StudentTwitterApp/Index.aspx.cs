using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Twitterizer;
//using DotNet.Highcharts;

namespace Tweet3
{
    public partial class WebForm2 : System.Web.UI.Page
    {

        String resource_url = "https://api.twitter.com/1.1/statuses/user_timeline.json";
        // oauth application keys
        String oauth_token = "212250358-WFFsHAIIpxg2eX4IWLjehcSVO8bfIkmKeZMlM7fE";
        String oauth_token_secret = "HVNrsCITWyzf9rhQ0cwqS9Et9bqDJ9urPumZ58vvcbfgR";
        String oauth_consumer_key = "nUnNM0FxrpZ7cNtHIgOzjrJmB";
        String oauth_consumer_secret = "0sIMR7SiysqR9uvPWgoRqyy5wSyz05oUQiokNPXHNfPu9duU3O";

        // oauth implementation details
        String oauth_version = "1.0";
        String oauth_signature_method = "HMAC-SHA1";

        OAuthTokens tokens = new OAuthTokens();
        string globalscreenname = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            List<TwitterApiArgs> args = new List<TwitterApiArgs>();
            args.Add(TwitterApiArgs.NewArg("screen_name", "krishhip"));
            //getFromTwitterApi(args);

            tokens.ConsumerKey = "nUnNM0FxrpZ7cNtHIgOzjrJmB"; //<-- replace with yours
            tokens.ConsumerSecret = "0sIMR7SiysqR9uvPWgoRqyy5wSyz05oUQiokNPXHNfPu9duU3O";//<-- replace with yours
            tokens.AccessToken = "212250358-WFFsHAIIpxg2eX4IWLjehcSVO8bfIkmKeZMlM7fE";//<-- replace with yours
            tokens.AccessTokenSecret = "HVNrsCITWyzf9rhQ0cwqS9Et9bqDJ9urPumZ58vvcbfgR";//<-- replace with yours

        }

        //public void getFromTwitterApi(List<TwitterApiArgs> args)
        //{
        //    // unique request details
        //    String oauth_nonce = Convert.ToBase64String(new ASCIIEncoding().GetBytes(DateTime.Now.Ticks.ToString()));
        //    TimeSpan timeSpan = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        //    String oauth_timestamp = Convert.ToInt64(timeSpan.TotalSeconds).ToString();


        //    // create oauth signature
        //    String baseFormat = "oauth_consumer_key={0}&oauth_nonce={1}&oauth_signature_method={2}" +
        //                    "&oauth_timestamp={3}&oauth_token={4}&oauth_version={5}";

        //    object[] paramslist = new object[6 + args.Count];
        //    paramslist[0] = oauth_consumer_key;
        //    paramslist[1] = oauth_nonce;
        //    paramslist[2] = oauth_signature_method;
        //    paramslist[3] = oauth_timestamp;
        //    paramslist[4] = oauth_token;
        //    paramslist[5] = oauth_version;

        //    String postBody = string.Empty;

        //    int currarg = 6;
        //    foreach (TwitterApiArgs arg in args)
        //    {
        //        baseFormat += "&" + arg.parameter + "={" + currarg.ToString() + "}";
        //        paramslist[currarg] = arg.value;
        //        postBody += arg.parameter + "=" + Uri.EscapeDataString(arg.value) + "&";
        //        currarg++;
        //    }

        //    postBody = postBody.Substring(0, postBody.Length - 1);

        //    String baseString = string.Format(baseFormat, paramslist);

        //    baseString = string.Concat("GET&", Uri.EscapeDataString(resource_url), "&", Uri.EscapeDataString(baseString));

        //    String compositeKey = string.Concat(Uri.EscapeDataString(oauth_consumer_secret),
        //                            "&", Uri.EscapeDataString(oauth_token_secret));

        //    string oauth_signature;
        //    using (HMACSHA1 hasher = new HMACSHA1(ASCIIEncoding.ASCII.GetBytes(compositeKey)))
        //    {
        //        oauth_signature = Convert.ToBase64String(
        //            hasher.ComputeHash(ASCIIEncoding.ASCII.GetBytes(baseString)));
        //    }

        //    // create the request header
        //    String headerFormat = "OAuth oauth_nonce=\"{0}\", oauth_signature_method=\"{1}\", " +
        //                       "oauth_timestamp=\"{2}\", oauth_consumer_key=\"{3}\", " +
        //                       "oauth_token=\"{4}\", oauth_signature=\"{5}\", " +
        //                       "oauth_version=\"{6}\"";

        //    String authHeader = string.Format(headerFormat,
        //                            Uri.EscapeDataString(oauth_nonce),
        //                            Uri.EscapeDataString(oauth_signature_method),
        //                            Uri.EscapeDataString(oauth_timestamp),
        //                            Uri.EscapeDataString(oauth_consumer_key),
        //                            Uri.EscapeDataString(oauth_token),
        //                            Uri.EscapeDataString(oauth_signature),
        //                            Uri.EscapeDataString(oauth_version)
        //                    );



        //    ServicePointManager.Expect100Continue = false;

        //    // make the request
        //    resource_url += "?" + postBody;
        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(resource_url);
        //    request.Headers.Add("Authorization", authHeader);
        //    request.Method = "GET";
        //    request.ContentType = "application/x-www-form-urlencoded";
        //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //    StreamReader reader = new StreamReader(response.GetResponseStream());
        //    String objText = reader.ReadToEnd();
        //   // TextBox2.Text = objText;
        //   // mydiv.InnerHtml = objText;

        //}

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            txtConsole.Text += Menu1.SelectedValue.ToString() + "()\n";


        }

        protected void btnRun_Click(object sender, EventArgs e)
        {

            TextBox2.Text = "";
            string[] Str = txtConsole.Text.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            //Str = Str.Where(o => o != Str.Length).ToArray();

            //foreach (string s in Str)
            for (int x = 0; x < Str.Length - 1; x++)
            {
                //switch (Str[x].Substring((0, Str[x].Length - (Str[x].IndexOf("(") + 2)))
                if (Str[x] != string.Empty)
                {
                    switch (Str[x].Substring(0, Str[x].IndexOf('(')))
                    {
                        case "LoadUser":
                            int y = Str[x].Length - 1 - (Str[x].IndexOf('(') + 1);
                            globalscreenname = Str[x].Substring(Str[x].IndexOf('(') + 1, y);
                            getFromTwitterApi(globalscreenname);
                            break;
                        case "GetFollowers":
                            int a = Str[x].Length - 1 - (Str[x].IndexOf('(') + 1);
                            string getFollowervalue = Str[x].Substring(Str[x].IndexOf('(') + 1, a);
                            if (getFollowervalue != "")
                                Getfollowers(getFollowervalue);
                            else if (globalscreenname != "")
                                Getfollowers(globalscreenname);
                            else
                                TextBox2.Text = "Please enter a valid screen name";
                            break;
                        case "ShowTrends": ShowTrends();
                            break;
                        case "GetUserLocation":
                            int d = Str[x].Length - 1 - (Str[x].IndexOf('(') + 1);
                            string Locationvalue = Str[x].Substring(Str[x].IndexOf('(') + 1, d);
                            if (Locationvalue != "")
                                GetUserLocation(Locationvalue);
                            else if (globalscreenname != "")
                                GetUserLocation(globalscreenname);
                            else
                                TextBox2.Text = "Please enter a valid screen name";
                            break;
                        case "PostTweet":
                            //int c = Str[x].Length - 1 - (Str[x].IndexOf('(') + 1);
                            //string[] postTweetvalue = (Str[x].Substring(Str[x].IndexOf('(') + 1, c)).Split(',');
                            //if (Str[x].Contains(','))
                            //{
                            //    PostTweets(postTweetvalue[0], postTweetvalue[1], postTweetvalue[2], postTweetvalue[3], postTweetvalue[4], postTweetvalue[5]);
                            //}

                            //else
                            //{
                            //    TextBox2.Text += "enter Status,Screen Name and token values";
                            //}
                            int c = Str[x].Length - 1 - (Str[x].IndexOf('(') + 1);
                            string[] postTweetvalue = (Str[x].Substring(Str[x].IndexOf('(') + 1, c)).Split(',');
                            if (Str[x].Contains(','))
                            {
                                PostTweetsfirst(postTweetvalue[0], postTweetvalue[1]);
                            }

                            else
                            {
                                TextBox2.Text += "enter Status,Screen Name and token values";
                            }
                            break;
                        case "DisplayTweets":
                            int b = Str[x].Length - 1 - (Str[x].IndexOf('(') + 1);
                            string getDisplayTweetvalue = Str[x].Substring(Str[x].IndexOf('(') + 1, b);
                            if (getDisplayTweetvalue != "")
                                DisplayTweets(getDisplayTweetvalue);
                            else if (globalscreenname != "")
                                DisplayTweets(globalscreenname);
                            else
                                TextBox2.Text = "Please enter a valid screen name";
                            break;
                        case "GetProfileImage":
                            int f = Str[x].Length - 1 - (Str[x].IndexOf('(') + 1);
                            string profileUrl = Str[x].Substring(Str[x].IndexOf('(') + 1, f);
                            if (profileUrl != "")
                                GetProfileImage(profileUrl);
                            else if (globalscreenname != "")
                                GetProfileImage(globalscreenname);
                            else
                                TextBox2.Text = "Please enter a valid screen name";
                            break;
                        case "GetFromUrl":
                            int h = Str[x].Length - 1 - (Str[x].IndexOf('(') + 1);
                            string url = Str[x].Substring(Str[x].IndexOf('(') + 1, h);
                            GetFromUrl(url);
                            break;
                        case "TweetTimechart":
                            int g = Str[x].Length - 1 - (Str[x].IndexOf('(') + 1);
                            string tweettimevalue = Str[x].Substring(Str[x].IndexOf('(') + 1, g);
                            if (tweettimevalue != "")
                                TweetTimechart(tweettimevalue);
                            else if (globalscreenname != "")
                                TweetTimechart(globalscreenname);
                            else
                                TextBox2.Text = "Please enter a valid screen name";
                            break;

                    }
                }
            }

        }

        public void GetFromUrl(String url)
        {
            var oauth_token = "212250358-WFFsHAIIpxg2eX4IWLjehcSVO8bfIkmKeZMlM7fE";
            var oauth_token_secret = "HVNrsCITWyzf9rhQ0cwqS9Et9bqDJ9urPumZ58vvcbfgR";
            var oauth_consumer_key = "nUnNM0FxrpZ7cNtHIgOzjrJmB";
            var oauth_consumer_secret = "0sIMR7SiysqR9uvPWgoRqyy5wSyz05oUQiokNPXHNfPu9duU3O";

            // oauth implementation details
            var oauth_version = "1.0";
            var oauth_signature_method = "HMAC-SHA1";

            // unique request details
            var oauth_nonce = Convert.ToBase64String(new ASCIIEncoding().GetBytes(DateTime.Now.Ticks.ToString()));
            var timeSpan = DateTime.UtcNow
                - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            var oauth_timestamp = Convert.ToInt64(timeSpan.TotalSeconds).ToString();


            // create oauth signature
            var baseFormat = "oauth_consumer_key={0}&oauth_nonce={1}&oauth_signature_method={2}" +
                            "&oauth_timestamp={3}&oauth_token={4}&oauth_version={5}";

            var baseString = string.Format(baseFormat,
                                        oauth_consumer_key,
                                        oauth_nonce,
                                        oauth_signature_method,
                                        oauth_timestamp,
                                        oauth_token,
                                        oauth_version);

            baseString = string.Concat("GET&", Uri.EscapeDataString(resource_url), "&", Uri.EscapeDataString(baseString));

            var compositeKey = string.Concat(Uri.EscapeDataString(oauth_consumer_secret),
                                    "&", Uri.EscapeDataString(oauth_token_secret));

            string oauth_signature;
            using (HMACSHA1 hasher = new HMACSHA1(ASCIIEncoding.ASCII.GetBytes(compositeKey)))
            {
                oauth_signature = Convert.ToBase64String(
                    hasher.ComputeHash(ASCIIEncoding.ASCII.GetBytes(baseString)));
            }

            // create the request header
            var headerFormat = "OAuth oauth_nonce=\"{0}\", oauth_signature_method=\"{1}\", " +
                               "oauth_timestamp=\"{2}\", oauth_consumer_key=\"{3}\", " +
                               "oauth_token=\"{4}\", oauth_signature=\"{5}\", " +
                               "oauth_version=\"{6}\"";

            var authHeader = string.Format(headerFormat,
                                    Uri.EscapeDataString(oauth_nonce),
                                    Uri.EscapeDataString(oauth_signature_method),
                                    Uri.EscapeDataString(oauth_timestamp),
                                    Uri.EscapeDataString(oauth_consumer_key),
                                    Uri.EscapeDataString(oauth_token),
                                    Uri.EscapeDataString(oauth_signature),
                                    Uri.EscapeDataString(oauth_version)
                            );



            ServicePointManager.Expect100Continue = false;

            // make the request
            // var postBody = "id=" + Uri.EscapeDataString(id);//
            // resource_url += "?" + postBody;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(resource_url);
            request.Headers.Add("Authorization", authHeader);
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            var response = (HttpWebResponse)request.GetResponse();
            var reader = new StreamReader(response.GetResponseStream());
            var objText = reader.ReadToEnd();
            //Console.WriteLine(objText);

            TextBox2.Text += objText + Environment.NewLine;
            TextBox2.Text += "-----------------------------------------------------------------------" + Environment.NewLine;

        }

        public void getFromTwitterApi(string value)
        {
            if (value != "")
            {
                TwitterResponse<TwitterUser> followers = TwitterUser.Show(tokens, value);

                if (followers.Result == RequestResult.Success)
                {
                    TextBox2.Text += "Name: " + followers.ResponseObject.Name + Environment.NewLine;
                    TextBox2.Text += "Screen Name:" + followers.ResponseObject.ScreenName + Environment.NewLine;
                    TextBox2.Text += "Date Created:" + followers.ResponseObject.CreatedDate + Environment.NewLine;
                    TextBox2.Text += "Location:" + followers.ResponseObject.Location + Environment.NewLine;
                    TextBox2.Text += "Number of Friends:" + followers.ResponseObject.NumberOfFriends + Environment.NewLine;
                    TextBox2.Text += "Number of Status Messages:" + followers.ResponseObject.NumberOfStatuses + Environment.NewLine;
                }
                TextBox2.Text += "-----------------------------------------------------------------------" + Environment.NewLine;
            }
            else
            {
                TextBox2.Text += "Invalid screen name";
            }
        }

        public void Getfollowers(string value)
        {
            if (value != "")
            {
                TwitterResponse<TwitterUser> followers = TwitterUser.Show(tokens, value);

                if (followers.Result == RequestResult.Success)
                {
                    TextBox2.Text += "Number of followers for " + followers.ResponseObject.ScreenName + " is " + followers.ResponseObject.NumberOfFollowers + Environment.NewLine;
                }

                TextBox2.Text += "-----------------------------------------------------------------------" + Environment.NewLine;
            }
            else
            {
                TextBox2.Text += "Invalid Screen Name";
            }
        }

        public void ShowTrends()
        {
            var oauth_token = "212250358-WFFsHAIIpxg2eX4IWLjehcSVO8bfIkmKeZMlM7fE";
            var oauth_token_secret = "HVNrsCITWyzf9rhQ0cwqS9Et9bqDJ9urPumZ58vvcbfgR";
            var oauth_consumer_key = "nUnNM0FxrpZ7cNtHIgOzjrJmB";
            var oauth_consumer_secret = "0sIMR7SiysqR9uvPWgoRqyy5wSyz05oUQiokNPXHNfPu9duU3O";


            // oauth implementation details
            var oauth_version = "1.0";
            var oauth_signature_method = "HMAC-SHA1";

            // unique request details
            var oauth_nonce = Convert.ToBase64String(new ASCIIEncoding().GetBytes(DateTime.Now.Ticks.ToString()));
            var timeSpan = DateTime.UtcNow
                - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            var oauth_timestamp = Convert.ToInt64(timeSpan.TotalSeconds).ToString();
            string q = "1";

            //  String resource_url1 = "https://api.twitter.com/1.1/trends/available.json";

            String resource_url1 = "https://api.twitter.com/1.1/account/settings.json";

            // create oauth signature
            var baseFormat = "oauth_consumer_key={0}&oauth_nonce={1}&oauth_signature_method={2}" +
                            "&oauth_timestamp={3}&oauth_token={4}&oauth_version={5}&q={6}";

            var baseString = string.Format(baseFormat,
                                        oauth_consumer_key,
                                        oauth_nonce,
                                        oauth_signature_method,
                                        oauth_timestamp,
                                        oauth_token,
                                        oauth_version,
                                        Uri.EscapeDataString(q)
                                        );

            baseString = string.Concat("GET&", Uri.EscapeDataString(resource_url1), "&", Uri.EscapeDataString(baseString));

            var compositeKey = string.Concat(Uri.EscapeDataString(oauth_consumer_secret),
                                    "&", Uri.EscapeDataString(oauth_token_secret));

            string oauth_signature;
            using (HMACSHA1 hasher = new HMACSHA1(ASCIIEncoding.ASCII.GetBytes(compositeKey)))
            {
                oauth_signature = Convert.ToBase64String(
                    hasher.ComputeHash(ASCIIEncoding.ASCII.GetBytes(baseString)));
            }

            // create the request header
            var headerFormat = "OAuth oauth_nonce=\"{0}\", oauth_signature_method=\"{1}\", " +
                               "oauth_timestamp=\"{2}\", oauth_consumer_key=\"{3}\", " +
                               "oauth_token=\"{4}\", oauth_signature=\"{5}\", " +
                               "oauth_version=\"{6}\"";

            var authHeader = string.Format(headerFormat,
                                    Uri.EscapeDataString(oauth_nonce),
                                    Uri.EscapeDataString(oauth_signature_method),
                                    Uri.EscapeDataString(oauth_timestamp),
                                    Uri.EscapeDataString(oauth_consumer_key),
                                    Uri.EscapeDataString(oauth_token),
                                    Uri.EscapeDataString(oauth_signature),
                                    Uri.EscapeDataString(oauth_version)
                            );



            ServicePointManager.Expect100Continue = false;

            // make the request
            var postBody = "id=" + Uri.EscapeDataString(q);//
            resource_url1 += "?" + postBody;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(resource_url1);
            request.Headers.Add("Authorization", authHeader);
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            var response = (HttpWebResponse)request.GetResponse();
            var reader = new StreamReader(response.GetResponseStream());
            var objText = reader.ReadToEnd();
            WebHeaderCollection header = response.Headers;
            var encoding = ASCIIEncoding.ASCII;
            using (var reader1 = new System.IO.StreamReader(response.GetResponseStream(), encoding))
            {
                string responseText = reader1.ReadToEnd();
            }

            //Console.WriteLine(objText);
            TextBox2.Text += objText;

        }

        public void GetUserLocation(string value)
        {
            if (value != "")
            {
                TwitterResponse<TwitterUser> followers = TwitterUser.Show(tokens, value);

                if (followers.Result == RequestResult.Success)
                {
                    TextBox2.Text += "UserLocation: " + followers.ResponseObject.Location + Environment.NewLine;
                }
                TextBox2.Text += "-----------------------------------------------------------------------" + Environment.NewLine;
            }
            else
            {
                TextBox2.Text += "Invalid Screen Name";
            }
        }

        public void PostTweetsfirst(string status, string screenname)
        {
            if (screenname != "" && status != "")
            {
                pnlReqKeys.Visible = true;
                txtConsole.Visible = false;
                Label6.Text = status;
                Label7.Text = screenname;
                TextBox2.Text += "Please enter the required details in the side panel" + Environment.NewLine;
                TextBox2.Text += "-----------------------------------------------------------------------" + Environment.NewLine;

            }
            else
            {
                TextBox2.Text += "Enter both status and valid Screen Name";
            }
        }

        protected void btnRegKeySubmit_Click(object sender, EventArgs e)
        {
            string status = Label6.Text;
            string screenname = Label7.Text;
            string oauth_token = TextBox4.Text;
            var oauth_token_secret = TextBox5.Text;
            var oauth_consumer_key = TextBox6.Text;
            var oauth_consumer_secret = TextBox7.Text;

            PostTweets(status, screenname, oauth_token, oauth_token_secret, oauth_consumer_key, oauth_consumer_secret);
        }

        protected void btnRegKeyCancel_Click(object sender, EventArgs e)
        {
            pnlReqKeys.Visible = false;
            txtConsole.Visible = true;
        }


        public void PostTweets(string status, string screenname, string token, string tokensecret, string consumerkey, string consumersecret)
        {
            if (screenname != "" && status != "" && token != "" && tokensecret != "" && consumerkey != "" && consumersecret != "")
            {
                pnlReqKeys.Visible = false;
                txtConsole.Visible = true;
                var oauth_token = token;
                var oauth_token_secret = tokensecret;
                var oauth_consumer_key = consumerkey;
                var oauth_consumer_secret = consumersecret;

                var oauth_version = "1.0";
                var oauth_signature_method = "HMAC-SHA1";
                var oauth_nonce = Convert.ToBase64String(new ASCIIEncoding().GetBytes(DateTime.Now.Ticks.ToString()));
                var timeSpan = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0,
                                                       DateTimeKind.Utc);
                var oauth_timestamp = Convert.ToInt64(timeSpan.TotalSeconds).ToString();
                var resource_url = "https://api.twitter.com/1.1/statuses/update.json";
                //var status = "Updating status via REST API if this works";


                var baseFormat = "oauth_consumer_key={0}&oauth_nonce={1}&oauth_signature_method={2}" +
                    "&oauth_timestamp={3}&oauth_token={4}&oauth_version={5}&status={6}";

                var baseString = string.Format(baseFormat,
                                            oauth_consumer_key,
                                            oauth_nonce,
                                            oauth_signature_method,
                                            oauth_timestamp,
                                            oauth_token,
                                            oauth_version,
                                            Uri.EscapeDataString(status)
                                            );

                baseString = string.Concat("POST&", Uri.EscapeDataString(resource_url),
                             "&", Uri.EscapeDataString(baseString));

                var compositeKey = string.Concat(Uri.EscapeDataString(oauth_consumer_secret),
                            "&", Uri.EscapeDataString(oauth_token_secret));

                string oauth_signature;
                using (HMACSHA1 hasher = new HMACSHA1(ASCIIEncoding.ASCII.GetBytes(compositeKey)))
                {
                    oauth_signature = Convert.ToBase64String(
                        hasher.ComputeHash(ASCIIEncoding.ASCII.GetBytes(baseString)));
                }

                var headerFormat = "OAuth oauth_nonce=\"{0}\", oauth_signature_method=\"{1}\", " +
                       "oauth_timestamp=\"{2}\", oauth_consumer_key=\"{3}\", " +
                       "oauth_token=\"{4}\", oauth_signature=\"{5}\", " +
                       "oauth_version=\"{6}\"";

                var authHeader = string.Format(headerFormat,
                                        Uri.EscapeDataString(oauth_nonce),
                                        Uri.EscapeDataString(oauth_signature_method),
                                        Uri.EscapeDataString(oauth_timestamp),
                                        Uri.EscapeDataString(oauth_consumer_key),
                                        Uri.EscapeDataString(oauth_token),
                                        Uri.EscapeDataString(oauth_signature),
                                        Uri.EscapeDataString(oauth_version)
                                );

                var postBody = "status=" + Uri.EscapeDataString(status);

                ServicePointManager.Expect100Continue = false;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(resource_url);
                request.Headers.Add("Authorization", authHeader);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                using (Stream stream = request.GetRequestStream())
                {
                    byte[] content = ASCIIEncoding.ASCII.GetBytes(postBody);
                    stream.Write(content, 0, content.Length);
                }
                WebResponse response = request.GetResponse();
                DisplayTweets(screenname);
            }
            else
            {
                TextBox2.Text += "Enter both status and valid Screen Name";
            }
            //Panel1.Visible = true;
        }

        public void DisplayTweets(string value)
        {
            if (value != "")
            {
                UserTimelineOptions userOptions = new UserTimelineOptions();
                userOptions.APIBaseAddress = "https://api.twitter.com/1.1/"; // <-- needed for API 1.1
                userOptions.Count = 20;
                userOptions.UseSSL = true; // <-- needed for API 1.1
                userOptions.ScreenName = value;//<-- replace with yours
                TwitterResponse<TwitterStatusCollection> timeline = TwitterTimeline.UserTimeline(tokens, userOptions); // collects first 20 tweets from our account
                int i = 1;

                foreach (TwitterStatus status in timeline.ResponseObject)
                {

                    TextBox2.Text += i + ")" + status.Text + Environment.NewLine;
                    i++;
                }

                TextBox2.Text += "-----------------------------------------------------------------------" + Environment.NewLine;
            }
            else
            {
                TextBox2.Text += "Invalid Screen Name";
            }
        }

        public void GetProfileImage(string value)
        {

            if (value != "")
            {
                Image1.Visible = true;
                TwitterResponse<TwitterUser> followers = TwitterUser.Show(tokens, value);

                Image1.ImageUrl = followers.ResponseObject.ProfileImageLocation;
            }
            else
            {
                TextBox2.Text += "Enter valid Screen Name";
            }
        }

        public void TweetTimechart(string value)
        {
            if (value != "")
            {
                Chart1.Visible = true;
                UserTimelineOptions userOptions = new UserTimelineOptions();
                userOptions.APIBaseAddress = "https://api.twitter.com/1.1/"; // <-- needed for API 1.1
                userOptions.Count = 20;
                userOptions.UseSSL = true; // <-- needed for API 1.1
                userOptions.ScreenName = value;//<-- replace with yours
                TwitterResponse<TwitterStatusCollection> timeline = TwitterTimeline.UserTimeline(tokens, userOptions); // collects first 20 tweets from our account
                int i = 1, Mrng = 0, Afternoon = 0, evening = 0, night = 0;
                int timeinhrs;

                foreach (TwitterStatus status in timeline.ResponseObject)
                {

                    //TextBox2.Text += i + ")" + status.CreatedDate + Environment.NewLine;
                    timeinhrs = status.CreatedDate.Hour;
                    if (timeinhrs > 0 && timeinhrs <= 5)
                        night++;
                    else if (timeinhrs > 5 && timeinhrs <= 12)
                        Mrng++;
                    else if (timeinhrs > 12 && timeinhrs <= 18)
                        Afternoon++;
                    else if (timeinhrs > 18 && timeinhrs <= 22)
                        evening++;
                    else if (timeinhrs > 22 && timeinhrs <= 24)
                        night++;

                    //i++;
                }

                Chart1.Series["Time"].Points.AddXY("Morning", Mrng);
                Chart1.Series["Time"].Points.AddXY("Afternoon", Afternoon);
                Chart1.Series["Time"].Points.AddXY("Evening", evening);
                Chart1.Series["Time"].Points.AddXY("Night", night);


            }
            else
            {
                TextBox2.Text += "Invalid Screen Name";
            }

        }





    }

    public class TwitterApiArgs
    {
        private string _parameter = string.Empty;
        public string parameter
        {
            get
            {
                return _parameter;
            }
            set
            {
                _parameter = value;
            }
        }

        private string _value = string.Empty;
        public string value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        public static TwitterApiArgs NewArg(string parameter, string value)
        {
            TwitterApiArgs obj = new TwitterApiArgs();
            obj.parameter = parameter;
            obj.value = value;
            return obj;
        }
    }
}