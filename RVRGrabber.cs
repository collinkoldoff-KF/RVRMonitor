﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RVRMonitor
{
    class RVRGrabber
    {
        public static string[] getAirports() {
            string urlAddress = "https://rvr.data.faa.gov/cgi-bin/rvr-status.pl";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            string data = "";

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (string.IsNullOrWhiteSpace(response.CharacterSet))
                    readStream = new StreamReader(receiveStream);
                else
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));

                data = readStream.ReadToEnd();

                response.Close();
                readStream.Close();
            }
            else
            {
                return new string[] { };
            }

            if (data == "") return new string[] { };
            try
            {
                data = data.Split(new[] { "RVR Airports</th></tr>\n" }, StringSplitOptions.None)[1];

                data = data.Split(new[] { "<b>KEY:</b>" }, StringSplitOptions.None)[0];

                data = data.Substring(0, data.LastIndexOf("</table>"));
            }
            catch
            {
                return new string[] { };
            }

            string[] rvrList = data.Split(new[] { "<td" }, StringSplitOptions.None);

            string[] aptList = new string[] { };

            foreach (string apt in rvrList)
            {
                try
                {
                    string aptName = apt;
                    aptName = aptName.Split(new[] { "&rrate=medium&layout=2x2&gifsize=large&fontsize=large&fs=lg\"><b>" }, StringSplitOptions.None)[1];
                    aptName = aptName.Split('<')[0];
                    Array.Resize(ref aptList, aptList.Length + 1);
                    aptList[aptList.Length - 1] = aptName;
                }
                catch
                {
                    continue;
                }
            }

            return aptList;
        }
        public static Panel getRVRData(string apt)
        {
            if (apt == "Select An Airport") return new Panel(); ;
            string urlAddress = "https://rvr.data.faa.gov/cgi-bin/rvr-details.pl?content=table&airport=" + apt + "&rrate=medium&layout=2x2&gifsize=large&fontsize=large&fs=lg&cache_this=ct1602390244";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            string data = null;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (string.IsNullOrWhiteSpace(response.CharacterSet))
                    readStream = new StreamReader(receiveStream);
                else
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));

                data = readStream.ReadToEnd();

                response.Close();
                readStream.Close();
            }
            else
            {
                return new Panel();
            }

            if (data == null) return new Panel();
            data = data.Split(new[] { "<b>RVR DETAILS</b></font>" }, StringSplitOptions.None)[1];

            string airportInfo = data.Split(new[] { "<strong>" }, StringSplitOptions.None)[1].Split(new[] { "</strong>" }, StringSplitOptions.None)[0].Replace("&nbsp", "");
            string dateTime = data.Split(new[] { "<strong><table><tr><th>" }, StringSplitOptions.None)[1].Split(new[] { "</th></tr></table></strong>" }, StringSplitOptions.None)[0].Replace("</th><th>", " ");

            data = data.Split(new[] { "<TH>&nbsp;E&nbsp</TH><TH>&nbsp;C&nbsp</TH></TR>" }, StringSplitOptions.None)[1].Split(new[] { "</table></font>" }, StringSplitOptions.None)[0];

            string[] runways = data.Split(new[] { "<tr>" }, StringSplitOptions.None);

            Panel output = new Panel();
            output.Location = new System.Drawing.Point(13, 115);
            output.Name = "panel2";
            output.Size = new System.Drawing.Size(433, 383);
            output.TabIndex = 3;

            Label label;

            int x = 0;
            int y = 0;
            int i = 0;

            label = new Label();
            label.ForeColor = Color.White;
            label.Tag = i.ToString();
            label.Text = airportInfo;
            label.AutoSize = true;
            label.Location = new Point(x, y);
            output.Controls.Add(label);
            i++;
            y += 20;

            label = new Label();
            label.ForeColor = Color.White;
            label.Tag = i.ToString();
            label.Text = dateTime;
            label.AutoSize = true;
            label.Location = new Point(x, y);
            output.Controls.Add(label);
            i++;
            y += 20;

            label = new Label();
            label.ForeColor = Color.White;
            label.Tag = i.ToString();
            label.Text = "RWY";
            label.AutoSize = true;
            label.Location = new Point(x, y);
            output.Controls.Add(label);
            i++;

            label = new Label();
            label.ForeColor = Color.White;
            label.Tag = i.ToString();
            label.Text = "TD";
            label.AutoSize = true;
            label.Location = new Point(x + 50, y);
            output.Controls.Add(label);
            i++;

            label = new Label();
            label.ForeColor = Color.White;
            label.Tag = i.ToString();
            label.Text = "MP";
            label.AutoSize = true;
            label.Location = new Point(x + 100, y);
            output.Controls.Add(label);
            i++;

            label = new Label();
            label.ForeColor = Color.White;
            label.Tag = i.ToString();
            label.Text = "RO";
            label.AutoSize = true;
            label.Location = new Point(x + 150, y);
            output.Controls.Add(label);
            i++;

            y += 17;

            foreach (string rwy in runways)
            {
                if (rwy == runways[0]) continue;
                string[] rvrList = rwy.Split(new[] { "<td align=\"center\">" }, StringSplitOptions.None);
                string runway = rvrList[0].Replace("<th>", "").Replace("</th>", "").Trim();
                string td = rvrList[1].Replace("</td>", "").Replace("&nbsp;", "").Replace("&#9650;", "▲").Replace("&#9660;", "▼").Trim();
                string mp = rvrList[2].Replace("</td>", "").Replace("&nbsp;", "").Replace("&#9650;", "▲").Replace("&#9660;", "▼").Trim();
                string ro = rvrList[3].Replace("</td>", "").Replace("&nbsp;", "").Replace("&#9650;", "▲").Replace("&#9660;", "▼").Trim();

                label = new Label();
                label.ForeColor = Color.White;
                label.Tag = i.ToString();
                label.Text = runway;
                label.AutoSize = true;
                label.Location = new Point(x, y);
                output.Controls.Add(label);
                i++;

                label = new Label();
                label.ForeColor = Color.White;
                label.Tag = i.ToString();
                label.Text = td;
                label.AutoSize = true;
                label.Location = new Point(x + 50, y);
                output.Controls.Add(label);
                i++;

                label = new Label();
                label.ForeColor = Color.White;
                label.Tag = i.ToString();
                label.Text = mp;
                label.AutoSize = true;
                label.Location = new Point(x + 100, y);
                output.Controls.Add(label);
                i++;

                label = new Label();
                label.ForeColor = Color.White;
                label.Tag = i.ToString();
                label.Text = ro;
                label.AutoSize = true;
                label.Location = new Point(x + 150, y);
                output.Controls.Add(label);
                i++;

                y += 17;

                //Console.WriteLine($"Runway: {runway} Touchdown: {td} Midpoint: {mp} Rollout: {ro}");
            }

            //Console.WriteLine(data);
            //Console.WriteLine(airportInfo);
            //Console.WriteLine(dateTime);

            return output;
        }
    }
}
