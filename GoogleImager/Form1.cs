using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;

namespace GoogleImager
{
    
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string  GetURL(string URL)
        {

            // prepare the web page we will be asking for
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(URL);

            // execute the request
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            
            StreamReader sr = new StreamReader(response.GetResponseStream());
            string ret=sr.ReadToEnd();
            sr.Close();
            response.Close();

            return ret;

        }


    
            public static  string cleanString(string instr)
    {
        string outstr = instr.Replace("\\x3cb\\x3e", "");
            outstr = outstr.Replace("\\x3c/b\\x3e","");
            outstr = outstr.Replace("\\x26#39;", "'");
            outstr = outstr.Replace("\\x26quot;", "\"");
            outstr = outstr.Replace("\\x26amp;", "&");

string newname = "";
                string name = outstr;
            for(int i=0;i<name.Length;i++)
            {
                if((name[i]=='&')&&(name.Length>=i+6))
                {   if(name[i+1]=='#')
                        if((Char.IsNumber(name[i+2]))&&(Char.IsNumber(name[i+3]))&&(Char.IsNumber(name[i+4]))&&(Char.IsNumber(name[i+5])))
                        {
                            int num = Convert.ToInt32(name.Substring(i + 2, 4));
                            Char c = Convert.ToChar(num);
                            newname += c;
                            i = i + 6;
                        }
                }
                else
                        {
                            newname += name[i];
                            
                        }
                
                
            }   
                outstr = newname;
         
            return outstr;
    }
        public static int pages = 1;
        public static void getMaxPage(string page)
        {

            int startpos = page.IndexOf("<div id=navcnt>");
            int endpos = page.IndexOf("</div>", startpos);
            int cur = startpos;
            bool stop = false;

            while ((cur >= 0) && (!stop))
            {
                int startchunk = page.IndexOf("<td", cur);
                int endchunk = page.IndexOf("<td", startchunk + 1);
                if (endchunk < 0) { endchunk = endpos; stop = true; }
                
                try
                {
                    string chunk = page.Substring(startchunk, endchunk - startchunk);
                    int pagenum_start = chunk.IndexOf("<br>") + 4;
                    int pagenum_end = chunk.IndexOf("</a>", pagenum_start);
                    int pagenum = Convert.ToInt32(chunk.Substring(pagenum_start, pagenum_end - pagenum_start));
                    if (pagenum > pages) pages = pagenum;
                    
                }
                catch { 
                }
                cur = endchunk;
            }

            
        }
        public static ArrayList images = new ArrayList();
        public static ArrayList images_attr = new ArrayList();

        public static bool getImagesFromPage(string temp)
        {


            //string temp = textBox3.Text;
            int start = temp.IndexOf("[\"/imgres?imgurl");
            if (start < 0) return false;
            int end = temp.IndexOf("]);</script></div>", start);
            bool stop = false;

            string images_data = temp.Substring(start, end - start);

            
            int cur = 0;
            while ((cur >= 0) && (!stop))
            {
                int startchunk = cur;
                int endchunk = images_data.IndexOf(",[\"/imgres", cur);
                if (endchunk < 0) { endchunk = images_data.Length - 1; stop = true; }

                string chunk = images_data.Substring(startchunk, endchunk - startchunk);
               
                string[] split = Regex.Split(chunk, "\",\"");
                /*string img_id = ;
                string img_url = ;
                string img_thumb_width = ;
                string img_thumb_height = ;
                string img_name = ;
                string img_ori_size = ;
                string img_format = ;
                string img_host = ;
                string img_thumb_server = ;
                */
                images_attr.Clear();
                images_attr.Add(split[2]);
                images_attr.Add(split[3]);
                images_attr.Add(split[4]);
                images_attr.Add(split[5]);
                images_attr.Add(split[6]);
                images_attr.Add(split[9]);
                images_attr.Add(split[10]);
                images_attr.Add(split[11]);
                images_attr.Add(split[14]);
                images.Add(images_attr.Clone() as ArrayList);

                cur = endchunk + 1;

            }
            return true;
        }

        public static ImageList tmpimagelist = new ImageList();
        public static Image GetImage(string URL)
        {
            try
            {
                WebRequest request = WebRequest.Create(URL);

                MemoryStream memoryStream = new MemoryStream(0x1000);

                using (Stream responseStream = request.GetResponse().GetResponseStream())
                {
                    byte[] buffer = new byte[0x1000];
                    int bytes;
                    while ((bytes = responseStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        memoryStream.Write(buffer, 0, bytes);
                    }
                }

                // If you cannot manipulate the MemoryStream directly, you can obtain a byte array
                //Image newImage = Image.FromStream(memoryStream);


                return Image.FromStream(memoryStream);//newImage;//.Clone() as Image;
            }
            catch { }
            return null;

        }
        public static object lockObj = new object();

        public static  void AddThumbnailImage(object obj)
        {
            int index = (int)obj;
            ArrayList templist = new ArrayList(images[index] as ArrayList);
            string thumb_url = templist[8].ToString() + "?q=tbn:" + templist[0].ToString() + templist[1].ToString();
            
            //tmpimagelist.Images.Add(tmp_img);
            Image tmp_img = GetImage(thumb_url);
            lock (lockObj)
            {
                
                Form1.imagesarray[index] = tmp_img.Clone() as Image;
                tmp_img.Dispose();
                //Form1.imagesthumbs.Insert(index,tmp_img.Clone() as Image);

                lock (lockObj)
                {
                    imagesdownloaded++;
                }
                statustext = "Downloading thumbnails: " + imagesdownloaded + "/" + images.Count; ;
                
                if (index == images.Count - 1)
                {
                    bool running = true;
                    while (running)
                    {
                        running = false;
                        for (int i = 0; i < Form1.threadpool.Length - 1; i++)
                            if (threadpool[i].ThreadState == ThreadState.Running) running = true;
                    }
                    statustext = "Populating list...";
                    
                    triggerResizeList = true;

                }
                
            }
        }
        public static string statustext = "Enter text to search...";
        public static Thread[] threadpool=null;
        //public static ArrayList imagesthumbs= new ArrayList();
        public static Image[] imagesarray;
        public static bool triggerPreparePopulateList = false;
        public  void populateList()
        {


            listView1.BeginUpdate();

            tmpimagelist.ColorDepth = ColorDepth.Depth16Bit;
            
            int size = 128;
            switch (cbTileSize.Text)
            {
                case "128x128":
                    size = 128;
                    break;
                case "64x64":
                    size = 64;
                    break;
                case "256x256":
                    size = 256;
                    break;
                default:
                    size = 128;
                    break;
            }

            
                tmpimagelist.ImageSize = new Size(size,size);

            threadpool = new Thread[images.Count];
            imagesarray = new Image[images.Count];

            for (int i = 0; i < images.Count; i++)
            {
                threadpool[i] = new Thread(AddThumbnailImage);
                threadpool[i].Start(i);
                ArrayList templist = new ArrayList(images[i] as ArrayList);
                //threaded
                //templistview.Items.Add(cleanString(templist[4].ToString() + "\r\n(" + templist[5].ToString() + ")"), i);
                //templistview.Items[i].ToolTipText = "URL: " + templist[1].ToString() + "\r\nReferrer: " + templist[7].ToString() + "\r\nFormat: " + templist[6].ToString();
                listView1.Items.Add(cleanString(templist[4].ToString() + "\r\n(" + templist[5].ToString() + ")"), i);
                listView1.Items[i].ToolTipText = "URL: " + templist[1].ToString() + "\r\nReferrer: " + templist[7].ToString() + "\r\nFormat: " + templist[6].ToString();
                //Size: " + templist[5].ToString() + "\r\n
                
                

            }
            listView1.EndUpdate();
            
            

        }
        ListView templistview = new ListView();
        
        public static int imagesdownloaded = 0;
        public static void GetPages()
        {
            

            int cur_page = 0;
            while (cur_page < pages)
            {
                string page = "";
                //if( cur_page==0) page = GetURL("http://www.google.com/images?q=" + textBox1.Text.ToString());
                //else 
                page = GetURL("http://www.google.com/images?start=" + 21 * cur_page + query);
                if (getImagesFromPage(page))
                {
                    getMaxPage(page);
                }
                cur_page++;
                statustext = "Parsing result pages: " + cur_page + "/" + pages; ;
            }
            triggerPreparePopulateList = true;
            

        }
        public static string query = "";
        public void GetQuery()
        {
            query = "&ie=UTF-8&imgtbs=z";

            if (rSizeSmall.Checked)
                query += "&imgsz=i";
            if (rSizeMedium.Checked)
                query += "&imgsz=m";
            if (rSizeLarge.Checked)
                query += "&imgsz=l";

            if (rSizeLarger.Checked)
            {
                switch (cbSizeLarger.Text)
                {
                    
case "400 x 300":
                        query += "&imgsz=qsvga";
                        break;
case "640 x 480":
                        query += "&imgsz=vga";
                        break;
case "800 x 600":
                        query += "&imgsz=svga";
                        break;
case "1024 x 768":
                        query += "&imgsz=xga";
                        break;
case "1600 x 1200":
                        query += "&imgsz=2mp";
                        break;
case "2272 x 1704":
                        query += "&imgsz=4mp";
                        break;
case "2816 x 2112":
                        query += "&imgsz=6mp";
                        break;
case "3264 x 2448":
                        query += "&imgsz=8mp";
                        break;
case "3648 x 2736":
                        query += "&imgsz=10mp";
                        break;
case "4096 x 3072":
                        query += "&imgsz=12mp";
                        break;
case "4480 x 3360":
                        query += "&imgsz=15mp";
                        break;
case "5120 x 3840":
                        query += "&imgsz=20mp";
                        break;
case "7216 x 5412":
                        query += "&imgsz=40mp";
                        break;
case "9600 x 7200":
                        query += "&imgsz=70mp";
                        break;


                    default:
                        break;

                }
            }

            if(rTypeFace.Checked)
                query+="&imgtype=face";
            if (rTypePhoto.Checked)
                query += "&imgtype=photo";
            if (rTypeClipArt.Checked)
                query += "&imgtype=clipart";
            if (rTypeBarcode.Checked)
                query += "&imgtype=lineart";

            if(rColorColor.Checked)
                query += "&imgc=color";
            if (rColorBW.Checked)
                query += "&imgc=gray";
            if ((rColorExact.Checked)&&(cbColor.Text!=""))
                query += "&imgc=specific&imgcolor=" + cbColor.Text;



            if (rSizeExact.Checked == true)
            {
                if ((eWidth.Text != "") && (eHeight.Text != ""))
                {
                    try
                    {
                        int width = Convert.ToInt32(eWidth.Text);
                        int height = Convert.ToInt32(eHeight.Text);
                        query+="&imgw=" + width + "&imgh=" + height;
                    }
                    catch { }
                }
            }



            query += "&q=" + textBox1.Text.ToString();
            
        }

        public void startSearch()
        {
            if (textBox1.Text != "")
            {
                Cursor = Cursors.WaitCursor;
                statustext = "Searching...";
                lFound.Text = "";
                ClearMem();

                GetQuery();
                Thread threaded_GetPages = new Thread(new ThreadStart(GetPages));
                threaded_GetPages.Start();
            }

        }
        
        private void button1_Click(object sender, EventArgs e)
        {

            startSearch();
        }
        public static void ResizedImage(int width, int height, int i)
        {
        //org_Image = new Bitmap(imagesarray[i]);
        Bitmap final_bitmap = new Bitmap(width, height);
        Graphics gr = Graphics.FromImage(final_bitmap);
        double scale;
        //scale = (double)org_Image.Height / (double)org_Image.Width;
        scale = (double)imagesarray[i].Height / (double)imagesarray[i].Width;
        int drawwidth = final_bitmap.Width;
        int drawheight = (int)((double)final_bitmap.Width * scale);
        int startx = 0;
        int starty = (final_bitmap.Height - drawheight) / 2;

        if (drawheight > height)
        {
            //scale = (double)org_Image.Width / (double)org_Image.Height;
            scale = (double)imagesarray[i].Width / (double)imagesarray[i].Height;
            drawheight = final_bitmap.Height;
            drawwidth = (int)((double)final_bitmap.Height * scale);
            startx = (final_bitmap.Width - drawwidth) / 2;
            starty = 0;
   
        }
            //gr.DrawImage(org_Image,startx,starty,drawwidth,drawheight);
        gr.DrawImage(imagesarray[i], startx, starty, drawwidth, drawheight);
        
            gr.Save();

            //MemoryStream ms= new MemoryStream();
            //final_bitmap.Save(ms,System.Drawing.Imaging.ImageFormat.Gif);
            
            tmpimagelist.Images.Add(final_bitmap.Clone() as Image);
            //tmpimagelist.Images.Add(b2i2(final_bitmap));
            
           // org_Image.Dispose();
            final_bitmap.Dispose();
            gr.Dispose();
            GC.Collect();



        }
        public static Image b2i2(Bitmap b)
        {
            MemoryStream ms = new MemoryStream();
          
                b.Save(ms, ImageFormat.Gif);

            
            b.Dispose();
            return Image.FromStream(ms);

        }

        public static Image b2i(Bitmap b)
        {
         
	      System.Drawing.Imaging.EncoderParameters encoderParams = new System.Drawing.Imaging.EncoderParameters(); 
	      long[] quality = new long[1]; 
	       

            

	      quality[0] = 1; //0 to 100 - 100 highest quality 
	      EncoderParameter encoderParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality); 
	      encoderParams.Param[0] = encoderParam; 
	
	      ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders(); 
	      ImageCodecInfo jpegICI = null; 
	      for (int x = 0; x < arrayICI.Length; x++) 
	      { 
	        if (arrayICI[x].FormatDescription.Equals("JPEG")) 
	        { 
	          jpegICI = arrayICI[x]; 
	          break; 
	        } 
	      } 
	MemoryStream ms  = new MemoryStream();
	      if (jpegICI != null) 
	      { 
            
              b.Save(ms, jpegICI, encoderParams); 

	      }
            b.Dispose();
            return Image.FromStream(ms);

        }


        public void ClearMem()
        {
            if (imagesarray != null)
            {
                imagesdownloaded = 0;
                pages = 1;
                listView1.BeginUpdate();
                listView1.Clear();
                //for (int i = 0; i < imagesarray.Length; i++)
                //{
                //    imagesarray[i].Dispose();
                //    tmpimagelist.Images[i].Dispose();
                //}
                images.Clear();
                imagesarray = null;
                tmpimagelist.Images.Clear();
                tmpimagelist = new ImageList();
                templistview.Clear();
                listView1.LargeImageList.Images.Clear();
                listView1.LargeImageList = null; 
                listView1.EndUpdate();
                listView1.Refresh();
                GC.Collect();
            }
        }

        public static bool triggerStartPopulatingList = false;
        public static bool triggerResizeList=false;

        public static void resizeList()
        {
            for (int i = 0; i < imagesarray.Length; i++)
            {
                ResizedImage(tmpimagelist.ImageSize.Width, tmpimagelist.ImageSize.Height, i);
                //tmpimagelist.Images.Add(imagesarray[i].Clone() as Image);
                    

            }
            for (int i = 0; i < imagesarray.Length; i++)
            {
                imagesarray[i].Dispose();


            }
            triggerStartPopulatingList = true;

            
        }

        public static ListViewItem[] items;
        public  void startPopulateList()
        {


            statustext = "Updating list..."; 
            listView1.BeginUpdate();
            listView1.LargeImageList = tmpimagelist;
            //listView1.Items.AddRange(items);
            listView1.EndUpdate();
            listView1.Refresh();
            lFound.Text = "Found: " + images.Count + " images";
            statustext = "Enter text to search...";
            Cursor = Cursors.Arrow; 
            GC.Collect();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (lStatus.Text != statustext) lStatus.Text = statustext;
            if (triggerPreparePopulateList)
            {
                populateList();
                triggerPreparePopulateList = false;
            }

            if (triggerResizeList)
            {


                resizeList();
                triggerResizeList = false;
            }
            if (triggerStartPopulatingList)
            {


                startPopulateList();
                triggerStartPopulatingList = false;
            }
            if (triggerSaveFileFinished)
            {


                triggerSaveFileFinished = false; 
                MessageBox.Show("Saving Files Finished");
                statustext = "Enter text to search...";
                
            }

            
        }

        public static void saveImage(object obj)
        {
            int index = (int)obj;
            ArrayList templist = Downloads[index] as ArrayList;

            string image_url = templist[0].ToString();
            string filePath = templist[1].ToString();
            string fileName = templist[2].ToString();
            string fileformat = templist[3].ToString();
            
            int counter = 0;

            Image img_to_download = GetImage(image_url);

            while (File.Exists(filePath + "\\["+ (index+1)+"] " + fileName+"."+fileformat))
            {
                fileName = "["+ (index+1)+"] "+MakeValidFileName(fileName) + "_Duplicate(" + counter + ")";

                counter++;
            }

            if (img_to_download != null)
            {
                img_to_download.Save(filePath + "\\["+ (index+1)+"] " + fileName + "." + fileformat);
                img_to_download.Dispose();

            }
            saveFileCurrent++;
            statustext = "Saving image: " + saveFileCurrent + "/" + saveFiles +"...";
            if (index == saveFiles - 1)
            {
                bool running = true;
                while (running)
                {
                    running = false;
                    for (int i = 0; i < saveFiles - 2; i++)
                        if (savearray[i].ThreadState == ThreadState.Running) running = true;

                }
                triggerSaveFileFinished = true;
            }
        
        }
        public static bool triggerSaveFileFinished = false;
        public static ArrayList Downloads;
        public static ArrayList DownloadsProp;
        public static Thread[] savearray;
        public static int saveFiles=0;
        public static int saveFileCurrent = 0;
        public void saveImages()
        {
           
            string filePath = "";
            while (filePath == "")
            {
                FolderBrowserDialog dir = new FolderBrowserDialog();
                dir.ShowDialog();
                filePath = dir.SelectedPath;
            }
            Downloads = new ArrayList();
            DownloadsProp = new ArrayList();
            saveFileCurrent = 0;
            saveFiles = listView1.SelectedItems.Count;
            savearray = new Thread[saveFiles];
            for (int i = 0; i < listView1.SelectedItems.Count; i++)
            {
                int index = listView1.SelectedItems[i].Index;
                ArrayList templist = images[index] as ArrayList;

                string image_url = templist[1].ToString();
                string fileName = MakeValidFileName(templist[4].ToString());
                string fileformat = templist[6].ToString();

                DownloadsProp.Clear();
                DownloadsProp.Add(image_url);
                DownloadsProp.Add(filePath);
                DownloadsProp.Add(fileName);
                DownloadsProp.Add(fileformat);
                Downloads.Add(DownloadsProp.Clone());

                savearray[i] = new Thread(saveImage);
                savearray[i].Start(i);
                

            }
            
        }


        private void saveSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {

            saveImages();
            


           
        }
        private static string MakeValidFileName(string name)
        {
            name = cleanString(name);
            

            string invalidChars = Regex.Escape(new string(Path.GetInvalidFileNameChars()));
            string invalidReStr = string.Format(@"[{0}]", invalidChars);
            return Regex.Replace(name, invalidReStr, "_");
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void eWidth_TextChanged(object sender, EventArgs e)
        {
            rSizeExact.Checked = true;
        }

        private void cbSizeLarger_SelectedIndexChanged(object sender, EventArgs e)
        {
            rSizeLarger.Checked = true;

        }

        private void cbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            rColorExact.Checked = true;
        }

        private void eHeight_TextChanged(object sender, EventArgs e)
        {
            rSizeExact.Checked = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) startSearch();


        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                Cursor = Cursors.WaitCursor;
                int index = listView1.SelectedItems[0].Index;
                ArrayList templist = images[index] as ArrayList;

                string image_url = templist[1].ToString();
                string fileName = MakeValidFileName(templist[4].ToString());
                string fileformat = templist[6].ToString();



                string filePath = Path.GetTempPath();

                int counter = 0;

                Image img_to_download = GetImage(image_url);
                string fullfile = filePath + fileName + "." + fileformat;
                while (File.Exists(fullfile))
                {

                    fileName = MakeValidFileName(fileName) + "_Duplicate(" + counter + ")";
                    fullfile = filePath + fileName + "." + fileformat;
                    counter++;
                }

                if (img_to_download != null)
                {
                    img_to_download.Save(fullfile);
                    img_to_download.Dispose();

                
                string explorerstring = Environment.GetEnvironmentVariable("windir") + "\\explorer.exe";
                try
                {
                    System.Diagnostics.Process.Start(explorerstring, fullfile);
                }
                catch
                {

                }
                }
                Cursor = Cursors.Arrow;

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && e.Control)
            {
                listView1.MultiSelect = true;
                foreach (ListViewItem item in listView1.Items)
                {
                    item.Selected = true;
                }
            }
        }

    }
}
