using System;
using System.Collections;
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
        public void getAirports()
        {
            string urlAddress = "https://collinkoldoff.dev/rvrmonitor/rvrdata.json";

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
                return;
            }

            if (data == "") return;

            data = data.Replace("[[", "");
            data = data.Replace("]]]", "");

            string[] jsonArray = data.Split(new[] { "],[" }, StringSplitOptions.RemoveEmptyEntries);

            Airport[] airportsList = new Airport[] { };

            foreach (string airport in jsonArray)
            {
                string icao = airport.Split(',')[0].Replace("\"", "");
                List<string> runways = new List<string>(airport.Replace("\"", "").Replace("[", "").Replace("]", "").Split(','));
                runways.RemoveAt(0);

                Airport airportObj = new Airport(icao, runways.ToArray());

                Array.Resize(ref airportsList, airportsList.Length + 1);
                airportsList[airportsList.Length - 1] = airportObj;
            }

            Debug.WriteLine("Airport List Cached");
            Form1.airportList = airportsList;
            Form1.airportListCached = true;
        }
        public void getAirportsOld()
        {
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
                return;
            }

            if (data == "") return;
            try
            {
                data = data.Split(new[] { "RVR Airports</th></tr>\n" }, StringSplitOptions.None)[1];

                data = data.Split(new[] { "<b>KEY:</b>" }, StringSplitOptions.None)[0];

                data = data.Substring(0, data.LastIndexOf("</table>"));
            }
            catch
            {
                return;
            }

            string[] rvrList = data.Split(new[] { "<td" }, StringSplitOptions.None);

            string[] aptList = new string[] { };

            Airport[] airportsList = new Airport[] { };

            Task[] tasks = new Task[] { };

            foreach (string apt in rvrList)
            {
                Task task = new Task(delegate
                {
                    try
                    {
                        string aptName = apt;
                        aptName = aptName.Split(new[] { "&rrate=medium&layout=2x2&gifsize=large&fontsize=large&fs=lg\"><b>" }, StringSplitOptions.None)[1];
                        aptName = aptName.Split('<')[0];

                        Airport airport = new Airport(aptName, getRunwaysListOld(aptName));

                        Array.Resize(ref airportsList, airportsList.Length + 1);
                        airportsList[airportsList.Length - 1] = airport;
                    }
                    catch
                    {

                    }
                });
                Array.Resize(ref tasks, tasks.Length + 1);
                tasks[tasks.Length - 1] = task;
                task.Start();
            }
            Task.WaitAll(tasks);

            // Sort the airportList array
            Array.Sort(airportsList, new AirportComparer());

            Debug.WriteLine("Airport List Cached");
            Form1.airportList = airportsList;
            Form1.airportListCached = true;
        }
        public string[] getRunwaysListOld(string apt)
        {
            if (apt == "Select An Airport") return new string[0];
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
                return new string[0];
            }

            if (data == null) return new string[0];

            data = data.Split(new[] { "<TH>&nbsp;E&nbsp</TH><TH>&nbsp;C&nbsp</TH></TR>" }, StringSplitOptions.None)[1].Split(new[] { "</table></font>" }, StringSplitOptions.None)[0];

            string[] runways = data.Split(new[] { "<tr>" }, StringSplitOptions.None);
            string[] runwayList = new string[] { };

            foreach (string rwy in runways)
            {
                if (rwy == runways[0]) continue;
                string[] rvrList = rwy.Split(new[] { "<td align=\"center\">" }, StringSplitOptions.None);
                string runway = rvrList[0].Replace("<th>", "").Replace("</th>", "").Trim();

                Array.Resize(ref runwayList, runwayList.Length + 1);
                runwayList[runwayList.Length - 1] = runway;
            }

            return runwayList;
        }
        public static Panel getRVRData(string aptRwy)
        {
            string airport, runway;
            try
            {
                airport = aptRwy.Split('.')[0];
                runway = aptRwy.Split('.')[1];
            }
            catch
            {
                return new Panel();
            }
            if (airport == "Select An Airport") return new Panel();
            string urlAddress = "https://rvr.data.faa.gov/cgi-bin/rvr-details.pl?content=table&airport=" + airport + "&rrate=medium&layout=2x2&gifsize=large&fontsize=large&fs=lg&cache_this=ct1602390244";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            string data = null;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream;
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
            data = data.Split(new[] { "<b>RVR DETAILS</b></font>" }, StringSplitOptions.None)[1]
                .Split(new[] { "<TH>&nbsp;E&nbsp</TH><TH>&nbsp;C&nbsp</TH></TR>" }, StringSplitOptions.None)[1]
                .Split(new[] { "</table></font>" }, StringSplitOptions.None)[0];

            string[] runways = data.Split(new[] { "<tr>" }, StringSplitOptions.None);

            Panel output = new Panel();
            output.AutoScroll = true;
            output.Location = new Point(0, ((Form1.rvrIndex) * 40));
            output.Name = "panel2";
            output.Size = new Size(340, 40);
            output.TabIndex = 3;
            output.Tag = Form1.rvrIndex.ToString();

            Label labelApt, labelRwy, labelTd, labelMp, labelRo;

            labelApt = new Label();
            labelApt.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelApt.ForeColor = Color.White;
            labelApt.Text = airport;
            labelApt.AutoSize = true;
            labelApt.Location = new Point(5, 0);
            output.Controls.Add(labelApt);


            labelRwy = new Label();
            labelRwy.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelRwy.ForeColor = Color.White;
            labelRwy.Text = runway;
            labelRwy.AutoSize = true;
            labelRwy.Location = new Point(40, 0);
            output.Controls.Add(labelRwy);

            foreach (string rwyInfo in runways)
            {
                if (rwyInfo == runways[0]) continue;
                string[] rvrList = rwyInfo.Split(new[] { "<td align=\"center\">" }, StringSplitOptions.None);
                string rwy = rvrList[0].Replace("<th>", "").Replace("</th>", "").Trim();
                if (rwy == runway)
                {
                    string td = rvrList[1].Replace("</td>", "").Replace("&nbsp;", "").Replace("&#9650;", "▲").Replace("&#9660;", "▼").Trim();
                    string mp = rvrList[2].Replace("</td>", "").Replace("&nbsp;", "").Replace("&#9650;", "▲").Replace("&#9660;", "▼").Trim();
                    string ro = rvrList[3].Replace("</td>", "").Replace("&nbsp;", "").Replace("&#9650;", "▲").Replace("&#9660;", "▼").Trim();

                    labelTd = new Label();
                    labelTd.Text = td;
                    labelTd.Location = new Point(75, 0);
                    labelTd = createLabel(labelTd);
                    output.Controls.Add(labelTd);


                    labelMp = new Label();
                    labelMp.Text = mp;
                    labelMp.Location = new Point(150, 0);
                    labelMp = createLabel(labelMp);
                    output.Controls.Add(labelMp);

                    labelRo = new Label();
                    labelRo.Text = ro;
                    labelRo.Location = new Point(225, 0);
                    labelRo = createLabel(labelRo);
                    output.Controls.Add(labelRo);

                    break;
                }
            }

            return output;
        }
        private static Label createLabel(Label label)
        {
            string text = label.Text.Replace("▲", "").Replace("▼", "").Replace(">", "");
            label.ForeColor = Color.Black;
            label.Size = new Size(75, 30);
            label.TextAlign = ContentAlignment.TopCenter;
            label.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label.TextAlign = ContentAlignment.TopCenter;

            if (label.Text == "" || label.Text == "FFF")
            {
                label.ForeColor = Color.White;
            }
            else if (int.Parse(text) == 6000 && label.Text.Contains(">"))
            {
                label.BackColor = Color.FromArgb(0, 255, 0);
            }
            else if (int.Parse(text) >= 2500)
            {
                label.BackColor = Color.FromArgb(255, 255, 0);
            }
            else if (int.Parse(text) >= 1300)
            {
                label.BackColor = Color.FromArgb(255, 189, 0);
            }
            else if (int.Parse(text) >= 800)
            {
                label.BackColor = Color.FromArgb(255, 123, 0);
            }
            else if (int.Parse(text) >= 0)
            {
                label.BackColor = Color.FromArgb(255, 0, 0);
                label.ForeColor = Color.White;
            }
            return label;
        }
        private static void removeIndex(int index)
        {
            string[] oldArray = Form1.rvrList;
            string[] newArray = new string[oldArray.Length - 1];

            int i = 0;
            int j = 0;
            while (i < oldArray.Length)
            {
                if (i != index)
                {
                    newArray[j] = oldArray[i];
                    j++;
                }
                i++;
            }
            Form1.rvrList = newArray;
        }
    }
    class AirportComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            return (new CaseInsensitiveComparer()).Compare(((Airport)x).code, ((Airport)y).code);
        }
    }
}
