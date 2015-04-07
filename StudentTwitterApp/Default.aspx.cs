using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Twitterizer;



namespace Tweet3
{
    public partial class _Default : System.Web.UI.Page
    {
        OAuthTokens tokens = new OAuthTokens();
        public void Page_Load(object sender, EventArgs e)
        {
            
            tokens.ConsumerKey = "nUnNM0FxrpZ7cNtHIgOzjrJmB"; //<-- replace with yours
            tokens.ConsumerSecret = "0sIMR7SiysqR9uvPWgoRqyy5wSyz05oUQiokNPXHNfPu9duU3O";//<-- replace with yours
            tokens.AccessToken = "212250358-WFFsHAIIpxg2eX4IWLjehcSVO8bfIkmKeZMlM7fE";//<-- replace with yours
            tokens.AccessTokenSecret = "HVNrsCITWyzf9rhQ0cwqS9Et9bqDJ9urPumZ58vvcbfgR";//<-- replace with yours

            //USER TIMELINE (ALL TWEETS)
            
            

        }

        public void Button1_Click(object sender, EventArgs e)
        {
            string Input = TextBox1.Text;
            string method = Input.Split('(')[0];
            int x = Input.Length -1-(Input.IndexOf('(')+1);
            string value = Input.Substring(Input.IndexOf('(')+1, x);

            UserTimelineOptions userOptions = new UserTimelineOptions();
            userOptions.APIBaseAddress = "https://api.twitter.com/1.1/"; // <-- needed for API 1.1
            userOptions.Count = 5;
            userOptions.UseSSL = true; // <-- needed for API 1.1
            userOptions.ScreenName = value;//<-- replace with yours
            TwitterResponse<TwitterStatusCollection> timeline = TwitterTimeline.UserTimeline(tokens, userOptions); // collects first 20 tweets from our account
            int i = 1;
            //TwitterResponse<TwitterTrendCollection> timelineres = TwitterTrend.Trends(tokens,1); 

            TwitterResponse<TwitterUser> followers = TwitterUser.Show(tokens, value);

            if (followers.Result == RequestResult.Success)
            {
                TextBox2.Text = "Number of followers for " + followers.ResponseObject.ScreenName + " is " + followers.ResponseObject.NumberOfFollowers + Environment.NewLine;
            }

            //if (showUserResponse.Result == RequestResult.Success)
            //    {
            //    string screenName = showUserResponse.ResponseObject.ScreenName;
            //    Response.Write(screenName);
            //    Response.Write("<br>");
            //    Response.Write(showUserResponse.ResponseObject.NumberOfFollowers);
            //    } 
            //FollowersOptions options = new FollowersOptions();
            //options.ScreenName = value;
            //options.UserId = 212250358;
            //options.UseSSL = true;
            //TwitterResponse<TwitterUserCollection> Followernames = TwitterFriendship.Followers(tokens, options);
            //TwitterResponse<TwitterUserCollection> followers = TwitterFriendship.Followers(options);
            //foreach (var follower in followers.ResponseObject.)
            //{
            //    TextBox2.Text += i + ")" + follower + Environment.NewLine;
            //    i++;
            //}
            foreach(TwitterStatus status in timeline.ResponseObject)
            {
                
                TextBox2.Text += i +")" +status.Text + Environment.NewLine ;
                i++;
            }

            //Getting trends from a location
            LocalTrendsOptions trendoptions = new LocalTrendsOptions();
            trendoptions.UseSSL =true;
            
    
          //  TwitterResponse<TwitterTrendCollection> tr = TwitterTrend.Trends(1);
            //foreach (TwitterTrend tnds in tr.ResponseObject)
            //{
            //    TextBox2.Text += tnds.ToString() + Environment.NewLine;
            //}
         
        }
    }
}
