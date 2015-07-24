using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Mvc.Samples.ViewEngine.Models
{
    public class LandingPageModel
    {
        public IntroHeader Header {get; set;}
        public IList<Content> Contents {get; set;}
        public Banner Banner{get; set;}

        public static LandingPageModel GetSample()
        {
            return new LandingPageModel()
            {
                Header = new IntroHeader()
                {
                    Header1 = "::Landing Page",
                    Header2 = "::A Template by Start Bootstrap"
                },
                Contents = new List<Content>
                {
                    new Content(){
                        Heading = "::Death to the Stock Photo:<br>Special Thanks",
                        Lead = "::A special thanks to Death to the Stock Photo for providing the photographs that you see in this template. Visit their website to become a member."
                    },
                    new Content(){
                        Heading = "::3D Device Mockups<br>by PSDCovers",
                        Lead = "::Turn your 2D designs into high quality, 3D product shots in seconds using free Photoshop actions by PSDCovers! Visit their website to download some of their awesome, free photoshop actions!"
                    },
                      new Content(){
                        Heading = "::Google Web Fonts and<br>Font Awesome Icons",
                        Lead = "::This template features the 'Lato' font, part of the Google Web Font library, as well as icons from Font Awesome"
                    },

                },
                Banner = new Banner()
                {
                    Header = "::Connect to Start Bootstrap:"
                }

            };
        }
    }

    public class IntroHeader
    {
        public string Header1 { get; set; }
        public string Header2 { get; set; }
    }

    public class Content
    {
        public string Heading {get; set;}
        public string Lead {get; set;}
    }

    public class Banner
    {
        public string Header {get; set;}
    }
}
