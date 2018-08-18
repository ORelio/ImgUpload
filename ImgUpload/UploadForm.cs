using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Imaging;
using System.IO;

namespace ImgUpload
{
    public partial class UploadForm : Form
    {
        private string file = "";
        private bool advanced_mode = false;
        private bool singleusage = false;
        private Thread t;

        /// <summary>
        /// Create a new Upload window
        /// </summary>

        public UploadForm()
        {
            Init();
        }

        /// <summary>
        /// Upload a file in simple mode and auto-exit
        /// </summary>
        /// <param name="filearg">File to send</param>

        public UploadForm(string filearg)
        {
            Init();
            singleusage = true;
            processFile(filearg, false);
        }

        /// <summary>
        /// Form initialization
        /// </summary>

        private void Init()
        {
            InitializeComponent();

            this.Text = Program.name;
            this.Text = Program.name + " v" + Program.version + " - by ORelio";

            button_select.Text = Translations.Get("button_select");
            button_close.Text = Translations.Get("button_close");
            button_simple_cancelclose.Text = Translations.Get("button_close");
            button_simple_send.Text = Translations.Get("button_select");
            button_choosefile.Text = Translations.Get("button_browse");
            btn_copy.Text = Translations.Get("text_copy");
            groupBox1.Text = Translations.Get("text_resizepic");
            groupBox2.Text = Translations.Get("text_result");
            groupBox3.Text = Translations.Get("text_output_format");
            groupBox4.Text = Translations.Get("text_choose_picture");
            option_image_with_fullsize_link.Text = Translations.Get("text_size_forum_fullsize");
            option_forumcode.Text = Translations.Get("text_size_forum");
            option_directlink.Text = Translations.Get("text_size_directlink");
            text_advanced_mode.Text = Translations.Get("text_advanced_mode");
            providerGoWebsite.Text = Translations.Get("text_about_this_provider");

            providerChange.Maximum = Settings.UploadProviders.Length - 1;
            providerChange.Value = Settings.ImgUpload_Provider;
            providerChange_Scroll(new object(), new ScrollEventArgs(ScrollEventType.EndScroll, Settings.ImgUpload_Provider));
            settingResize.Items.Clear();

            //Load resize settings
            foreach (KeyValuePair<string, string> kvp in Settings.descriptions)
            {
                settingResize.Items.Add(kvp.Value);
            }

            //Set default resize setting
            if (Settings.ImgUpload_resizetag != "" && Settings.descriptions.ContainsKey(Settings.ImgUpload_resizetag))
            {
                settingResize.Text = Settings.descriptions[Settings.ImgUpload_resizetag];
            }
            else settingResize.Text = Settings.descriptions["resample"];

            //Set output format setting
            switch (Settings.ImgUpload_setting)
            {
                case '1': option_directlink.Checked = true; break;
                case '2': option_forumcode.Checked = true; break;
                case '3': option_image_with_fullsize_link.Checked = true; break;
                default: option_directlink.Checked = true; break;
            }

            //Set simple mode as default mode
            advanced_mode = true;
            button_advanced_mode_Click(new object(), EventArgs.Empty);

            //Allow drag and drop
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Drag_Enter);
            this.DragDrop += new DragEventHandler(Drag_Drop);
        }

        /// <summary>
        /// Change host by clicking on arrow buttons
        /// </summary>

        private void providerChange_Scroll(object sender, ScrollEventArgs e)
        {
            Settings.ImgUpload_Provider = e.NewValue;
            BackgroundImage = Settings.UploadProviders[Settings.ImgUpload_Provider].Logo;
        }

        /// <summary>
        /// Visally show to the user that he can drop the file he currently holds with his mouse cursor
        /// </summary>

        private void Drag_Enter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        /// <summary>
        /// Receive a file from drag-and-drop event
        /// </summary>

        private void Drag_Drop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                processFile(files[0], false);
            }
        }

        /// <summary>
        /// Start uploading by clicking the Send button (advanced mode)
        /// </summary>

        private void button_select_Click(object sender, EventArgs e)
        {
            //Save settings
            foreach (KeyValuePair<string, string> kvp in Settings.descriptions)
            if (kvp.Value == settingResize.Text) { Settings.ImgUpload_resizetag = kvp.Key; }
            if (option_directlink.Checked) { Settings.ImgUpload_setting = '1'; }
            if (option_forumcode.Checked) { Settings.ImgUpload_setting = '2'; }
            if (option_image_with_fullsize_link.Checked) { Settings.ImgUpload_setting = '3'; }
            Settings.SavePrefs();

            //Check that the file is valid
            if (textBox_file.Text != "")
            {
                processFile(textBox_file.Text, true);
            }
            else MessageBox.Show(Translations.Get("error_no_image"), Translations.Get("error"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Show the browsing windows, and process the choosen file with processFile()
        /// </summary>

        private void button_choosefile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (Program.minecraft_mode) { dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.minecraft\\screenshots"; }
            dlg.Filter = Translations.Get("text_image_files") + "|*.jpg;*.jpeg;*.bmp;*.gif;*.png;*.tif;*.tiff";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                processFile(dlg.FileName, false);
            }
        }

        /// <summary>
        /// Verify that a file is valid, and then launch upload on a separate thread
        /// </summary>
        /// <param name="filepath">File to upload</param>

        private void processFile(string filepath, bool modeavance_uploadnow)
        {
            if (System.IO.File.Exists(filepath))
            {
                string ext = Path.GetExtension(filepath).ToLower();
                if (ext == ".jpg" || ext == ".jpeg" || ext == ".bmp" || ext == ".gif" || ext == ".png" || ext == ".tif" || ext == ".tiff")
                {
                    if (advanced_mode && !modeavance_uploadnow)
                    {
                        textBox_file.Text = filepath;
                        box_result.Text = "";
                    }
                    else
                    {
                        file = filepath;
                        t = new Thread(new ThreadStart(t_upload));
                        t.Start();
                    }
                }
                else MessageBox.Show(Translations.Get("error_invalid_filetype"), Translations.Get("error"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else MessageBox.Show(Translations.Get("error_file_not_found") + " \"" + filepath + "\"", Translations.Get("error"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        /// <summary>
        /// Upload procedure, called on a separate thread by processFile()
        /// </summary>

        private void t_upload()
        {
            LockButtons(true);
            UploadProvider provider = Settings.UploadProviders[Settings.ImgUpload_Provider];
            string ImgURL = UploadFile(provider, file, advanced_mode ? Settings.ImgUpload_resizetag : "resample");
            if (ImgURL != "")
            {
                //Show the result in the corresponding textbox OR launch the file URL in the user's web browser
                if (advanced_mode)
                {
                    string ImgFullSizeURL = "";

                    //Do we need the full size direct link? Then we need to upload the picture one more time.
                    if (Settings.ImgUpload_setting == '3' && Settings.ImgUpload_resizetag.Contains('x'))
                    {
                        ImgFullSizeURL = UploadFile(provider, file, "resample");
                    }
                    else ImgFullSizeURL = ImgURL;

                    switch (Settings.ImgUpload_setting)
                    {
                        default:
                        case '1':
                            GiveResult(ImgURL);
                            break;
                        case '2':
                            GiveResult("[img]" + ImgURL + "[/img]");
                            break;
                        case '3':
                            GiveResult("[url=" + ImgFullSizeURL + "][img]" + ImgURL + "[/img][/url]");
                            break;
                    }
                }
                else
                {
                    try
                    {
                        if (ImgURL != null && ImgURL.ToLower().StartsWith("http"))
                        {
                            System.Diagnostics.Process.Start(ImgURL);
                        }
                        else throw new Win32Exception();
                    }
                    catch (Win32Exception) { MessageBox.Show(Translations.Get("error_url"), Translations.Get("error"), MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    if (singleusage) { Environment.Exit(0); }
                }

                //Ding j'ai fini !
                if (advanced_mode) { try { new System.Media.SoundPlayer("C:\\WINDOWS\\Media\\chimes.wav").Play(); } catch { } }
            }
            else if (singleusage) { Environment.Exit(0); }
            LockButtons(false);
        }

        /// <summary>
        /// Sufunction of the upload procedure. Allow to (un)lock the form buttons on upload start and upload end from another thread
        /// </summary>
        /// <param name="locked">TRUE to lock buttons, FALSE to unlock buttons</param>

        private void LockButtons(bool locked)
        {
            if (this.InvokeRequired) { this.Invoke(new Action<bool>(LockButtons), new object[1] { locked }); }
            else
            {
                button_select.Enabled = !locked;
                button_simple_send.Enabled = !locked;
                button_advanced_mode.Enabled = !locked;
                providerChange.Enabled = !locked;
                button_select.Text = locked ? Translations.Get("text_upload_in_progress") : Translations.Get("button_select");
                button_simple_send.Text = locked ? Translations.Get("text_upload_in_progress") : Translations.Get("button_select");
                button_simple_cancelclose.Text = locked ? Translations.Get("button_cancel") : Translations.Get("button_close");
                button_close.Text = locked ? Translations.Get("button_cancel") : Translations.Get("button_close");
            }
        }

        /// <summary>
        /// Sufunction of the upload procedure. Set result box text from another thread
        /// </summary>
        /// <param name="resultat">Result to pass to the user</param>

        private void GiveResult(string resultat)
        {
            if (this.InvokeRequired) { this.Invoke(new Action<string>(GiveResult), new object[1] { resultat }); }
            else
            {
                box_result.Text = resultat;
            }
        }

        /// <summary>
        /// Buton for copying text in the clipboard
        /// </summary>

        private void btn_copier_Click(object sender, EventArgs e)
        {
            System.Windows.Clipboard.SetData(DataFormats.Text, box_result.Text);
        }

        /// <summary>
        /// Cancel upload / exit the program if the user clicks the [X] window button or the Cancel button
        /// </summary>

        private void button_close_Click(object sender, EventArgs e)
        {
            Settings.SavePrefs();
            if (t != null && t.IsAlive)
            {
                t.Abort();
                LockButtons(false);
                if (singleusage) { Environment.Exit(0); }
            }
            else Close();
        }

        /// <summary>
        /// Toggle advanced mode
        /// </summary>

        private void button_advanced_mode_Click(object sender, EventArgs e)
        {
            advanced_mode = !advanced_mode;
            
            text_advanced_mode.Visible = advanced_mode;
            button_simple_send.Visible = !advanced_mode;
            button_simple_cancelclose.Visible = !advanced_mode;

            textBox_file.Visible = advanced_mode;
            button_choosefile.Visible = advanced_mode;
            settingResize.Visible = advanced_mode;
            option_directlink.Visible = advanced_mode;
            option_forumcode.Visible = advanced_mode;
            option_image_with_fullsize_link.Visible = advanced_mode;
            box_result.Visible = advanced_mode;
            btn_copy.Visible = advanced_mode;
            button_select.Visible = advanced_mode;
            button_close.Visible = advanced_mode;

            button_advanced_mode.Text = advanced_mode ? "˄" : "˅";
            this.Height = advanced_mode ? 410 : 140;
        }

        /// <summary>
        /// Show about window with info about the software and the current host
        /// </summary>

        private void providerGoWebsite_Click(object sender, EventArgs e)
        {
            if (providerChange.Enabled)
            {
                if (MessageBox.Show("- " + Translations.Get("about_about") + ' ' + Program.name + " -\n"
                    + Translations.Get("about_created_by") + " ORelio\n"
                    + Translations.Get("about_website") + " : " + (Program.minecraft_mode ? "https://hellominecraft.fr/" : "https://microzoom.fr/") + "\n"
                    + "\n- " + Translations.Get("about_about") +' ' + Settings.UploadProviders[Settings.ImgUpload_Provider].Name + " --\n"
                    + Translations.Get("about_service_offered_by") + ' ' + Settings.UploadProviders[Settings.ImgUpload_Provider].Company + '\n'
                    + Translations.Get("about_website") + " : " + Settings.UploadProviders[Settings.ImgUpload_Provider].WebSite + '\n'
                    + '\n' + Translations.Get("about_confirm_visit"), Translations.Get("about_title"),
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    System.Diagnostics.Process.Start(Settings.UploadProviders[Settings.ImgUpload_Provider].WebSite);
                }
            }
        }

        /// <summary>
        /// Send a picture using a specific host and a specific resize mode
        /// </summary>
        /// <param name="provider">Host to use</param>
        /// <param name="file">File to upload</param>
        /// <param name="resizesetting">Resize mode</param>
        /// <returns>Returns direct link to the picture</returns>

        private static string UploadFile(UploadProvider provider, string file, string resizesetting)
        {
            bool is_temp_file = false;

            if (resizesetting.Length > 0)
            {
                string[] test = resizesetting.Split('x');
                if (test.Length == 2)
                {
                    try
                    {
                        int desired_width = Int32.Parse(test[0]);
                        int desired_height = Int32.Parse(test[1]);

                        Image image = Image.FromFile(file);

                        if (image.Width > desired_width || image.Height > desired_height)
                        {
                            Image newImage = ScaleImage(image, desired_width, desired_height);

                            ImageFormat save_format;
                            string save_ext;
                            switch (Path.GetExtension(file).ToLower())
                            {
                                case "jpg":
                                case "jpeg":
                                    save_ext = "jpg";
                                    save_format = ImageFormat.Jpeg;
                                    break;
                                case "gif":
                                    save_ext = "gif";
                                    save_format = ImageFormat.Gif;
                                    break;
                                case "bmp":
                                    save_ext = "bmp";
                                    save_format = ImageFormat.Bmp;
                                    break;
                                case "tif":
                                case "tiff":
                                    save_ext = "tif";
                                    save_format = ImageFormat.Tiff;
                                    break;
                                default:
                                    save_ext = "png";
                                    save_format = ImageFormat.Png;
                                    break;
                            }

                            string temp_file = Path.GetTempPath() + '\\' + Path.GetFileNameWithoutExtension(file) + '.' + save_ext;
                            newImage.Save(temp_file, ImageFormat.Png);
                            is_temp_file = true;
                            file = temp_file;
                        }
                    }
                    catch { }
                }
            }

            string ImgURL = "";

            if (!provider.UploadAndGetURL(file, ref ImgURL))
                MessageBox.Show(Translations.Get("error_upload"), Translations.Get("error"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            if (is_temp_file)
                File.Delete(file);

            return ImgURL;
        }

        /// <summary>
        /// Resize a picture to a specific width / height while keeping aspect ratio
        /// </summary>
        /// <param name="image">Source image</param>
        /// <param name="maxWidth">Desired maximum width</param>
        /// <param name="maxHeight">Desired maximum height</param>
        /// <returns>Returns a resized picture</returns>

        private static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
            return newImage;
        }
    }
}
