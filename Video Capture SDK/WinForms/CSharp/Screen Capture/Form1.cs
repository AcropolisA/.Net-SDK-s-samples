// ReSharper disable InconsistentNaming

using System.IO;
using VisioForge.Controls.UI.Dialogs.OutputFormats;
using VisioForge.Controls.UI.Dialogs.VideoEffects;
using VisioForge.Tools;

namespace VisioForge_SDK_Screen_Capture_Demo
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    using VisioForge.Controls.UI.WinForms;
    using VisioForge.Types;
    using VisioForge.Types.OutputFormat;
    using VisioForge.Types.Sources;
    using VisioForge.Types.VideoEffects;

    public partial class Form1 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        private MFSettingsDialog mp4v11SettingsDialog;

        private MFSettingsDialog mpegTSSettingsDialog;

        private MFSettingsDialog movSettingsDialog;

        private MP4v10SettingsDialog mp4V10SettingsDialog;

        private AVISettingsDialog aviSettingsDialog;

        private MP3SettingsDialog mp3SettingsDialog;

        private WMVSettingsDialog wmvSettingsDialog;

        private DVSettingsDialog dvSettingsDialog;

        private WebMSettingsDialog webmSettingsDialog;

        private FFMPEGDLLSettingsDialog ffmpegDLLSettingsDialog;

        private FFMPEGEXESettingsDialog ffmpegEXESettingsDialog;

        private GIFSettingsDialog gifSettingsDialog;

        private readonly SaveFileDialog screenshotSaveDialog = new SaveFileDialog()
        {
            FileName = "image.jpg",
            Filter = "JPEG|*.jpg|BMP|*.bmp|PNG|*.png|GIF|*.gif|TIFF|*.tiff",
            InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\VisioForge\\"
        };
        
        private readonly System.Timers.Timer tmRecording = new System.Timers.Timer(1000);
        
        public Form1()
        {
            InitializeComponent();
        }

        private void btScreenCaptureUpdate_Click(object sender, EventArgs e)
        {
            VideoCapture1.Screen_Capture_UpdateParameters(Convert.ToInt32(edScreenLeft.Text), Convert.ToInt32(edScreenTop.Text), cbScreenCapture_GrabMouseCursor.Checked);
        }
        
        private void cbAudioInputDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAudioInputDevice.SelectedIndex != -1)
            {
                VideoCapture1.Audio_CaptureDevice = cbAudioInputDevice.Text;
                cbAudioInputFormat.Items.Clear();

                var deviceItem = VideoCapture1.Audio_CaptureDevicesInfo.First(device => device.Name == cbAudioInputDevice.Text);

                var defaultValue = "PCM, 44100 Hz, 16 Bits, 2 Channels";
                var defaultValueExists = false;
                foreach (string format in deviceItem.Formats)
                {
                    cbAudioInputFormat.Items.Add(format);

                    if (defaultValue == format)
                    {
                        defaultValueExists = true;
                    }
                }

                if (cbAudioInputFormat.Items.Count > 0)
                {
                    cbAudioInputFormat.SelectedIndex = 0;

                    if (defaultValueExists)
                    {
                        cbAudioInputFormat.Text = defaultValue;
                    }
                }

                cbAudioInputFormat_SelectedIndexChanged(null, null);

                cbAudioInputLine.Items.Clear();

                foreach (string line in deviceItem.Lines)
                {
                    cbAudioInputLine.Items.Add(line);
                }

                if (cbAudioInputLine.Items.Count > 0)
                {
                    cbAudioInputLine.SelectedIndex = 0;
                }

                cbAudioInputLine_SelectedIndexChanged(null, null);

                btAudioInputDeviceSettings.Enabled = deviceItem.DialogDefault;
            }
        }

        private void btAudioInputDeviceSettings_Click(object sender, EventArgs e)
        {
            VideoCapture1.Audio_CaptureDevice_SettingsDialog_Show(IntPtr.Zero, cbAudioInputDevice.Text);
        }

        private void cbAudioInputFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            VideoCapture1.Audio_CaptureDevice_Format = cbAudioInputFormat.Text;
        }

        private void cbAudioInputLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            VideoCapture1.Audio_CaptureDevice_Line = cbAudioInputLine.Text;
        }

        private void cbUseBestAudioInputFormat_CheckedChanged(object sender, EventArgs e)
        {
            cbAudioInputFormat.Enabled = !cbUseBestAudioInputFormat.Checked;
        }

        private void SetMP4Output(ref VFMP4v8v10Output mp4Output)
        {
            if (mp4V10SettingsDialog == null)
            {
                mp4V10SettingsDialog = new MP4v10SettingsDialog();
            }

            mp4V10SettingsDialog.FillSettings(ref mp4Output);
        }

        private void SetFFMPEGEXEOutput(ref VFFFMPEGEXEOutput ffmpegOutput)
        {
            if (ffmpegEXESettingsDialog == null)
            {
                ffmpegEXESettingsDialog = new FFMPEGEXESettingsDialog();
            }

            ffmpegEXESettingsDialog.FillSettings(ref ffmpegOutput);
        }

        private void SetWMVOutput(ref VFWMVOutput wmvOutput)
        {
            if (wmvSettingsDialog == null)
            {
                wmvSettingsDialog = new WMVSettingsDialog(VideoCapture1.Core);
            }

            wmvSettingsDialog.WMA = false;
            wmvSettingsDialog.FillSettings(ref wmvOutput);
        }

        private void SetWebMOutput(ref VFWebMOutput webmOutput)
        {
            if (webmSettingsDialog == null)
            {
                webmSettingsDialog = new WebMSettingsDialog();
            }

            webmSettingsDialog.FillSettings(ref webmOutput);
        }

        private void SetFFMPEGDLLOutput(ref VFFFMPEGDLLOutput ffmpegDLLOutput)
        {
            if (ffmpegDLLSettingsDialog == null)
            {
                ffmpegDLLSettingsDialog = new FFMPEGDLLSettingsDialog();
            }

            ffmpegDLLSettingsDialog.FillSettings(ref ffmpegDLLOutput);
        }
               
        private void SetMP4v11Output(ref VFMP4v11Output mp4Output)
        {
            if (mp4v11SettingsDialog == null)
            {
                mp4v11SettingsDialog = new MFSettingsDialog(MFSettingsDialogMode.MP4v11);
            }

            mp4v11SettingsDialog.FillSettings(ref mp4Output);
        }

        private void SetMPEGTSOutput(ref VFMPEGTSOutput mpegTSOutput)
        {
            if (mpegTSSettingsDialog == null)
            {
                mpegTSSettingsDialog = new MFSettingsDialog(MFSettingsDialogMode.MPEGTS);
            }

            mpegTSSettingsDialog.FillSettings(ref mpegTSOutput);
        }

        private void SetMOVOutput(ref VFMOVOutput mkvOutput)
        {
            if (movSettingsDialog == null)
            {
                movSettingsDialog = new MFSettingsDialog(MFSettingsDialogMode.MOV);
            }

            movSettingsDialog.FillSettings(ref mkvOutput);
        }

        private void SetGIFOutput(ref VFAnimatedGIFOutput gifOutput)
        {
            if (gifSettingsDialog == null)
            {
                gifSettingsDialog = new GIFSettingsDialog();
            }

            gifSettingsDialog.FillSettings(ref gifOutput);
        }

        private void SetDVOutput(ref VFDVOutput dvOutput)
        {
            if (dvSettingsDialog == null)
            {
                dvSettingsDialog = new DVSettingsDialog();
            }

            dvSettingsDialog.FillSettings(ref dvOutput);
        }

        private void SetAVIOutput(ref VFAVIOutput aviOutput)
        {
            if (aviSettingsDialog == null)
            {
                aviSettingsDialog = new AVISettingsDialog(VideoCapture1.Video_Codecs.ToArray(),
                    VideoCapture1.Audio_Codecs.ToArray());
            }

            aviSettingsDialog.FillSettings(ref aviOutput);

            if (aviOutput.Audio_UseMP3Encoder)
            {
                var mp3Output = new VFMP3Output();
                SetMP3Output(ref mp3Output);
                aviOutput.MP3 = mp3Output;
            }
        }

        private void SetMP3Output(ref VFMP3Output mp3Output)
        {
            if (mp3SettingsDialog == null)
            {
                mp3SettingsDialog = new MP3SettingsDialog();
            }

            mp3SettingsDialog.FillSettings(ref mp3Output);
        }

        private void SetMKVOutput(ref VFMKVv1Output mkvOutput)
        {
            if (aviSettingsDialog == null)
            {
                aviSettingsDialog = new AVISettingsDialog(VideoCapture1.Video_Codecs.ToArray(),
                    VideoCapture1.Audio_Codecs.ToArray());
            }

            aviSettingsDialog.FillSettings(ref mkvOutput);

            if (mkvOutput.Audio_UseMP3Encoder)
            {
                var mp3Output = new VFMP3Output();
                SetMP3Output(ref mp3Output);
                mkvOutput.MP3 = mp3Output;
            }
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            mmLog.Clear();

            VideoCapture1.Video_Renderer.Zoom_Ratio = 0;
            VideoCapture1.Video_Renderer.Zoom_ShiftX = 0;
            VideoCapture1.Video_Renderer.Zoom_ShiftY = 0;

            VideoCapture1.Debug_Mode = cbDebugMode.Checked;
            VideoCapture1.Debug_Dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\VisioForge\\";

            VideoCapture1.Video_Sample_Grabber_Enabled = true;

            // from screen
            VideoCapture1.Screen_Capture_Source = new ScreenCaptureSourceSettings();
            if (rbScreenCaptureWindow.Checked)
            {
                VideoCapture1.Screen_Capture_Source.Mode = VFScreenCaptureMode.Window;

                VideoCapture1.Screen_Capture_Source.WindowHandle = IntPtr.Zero;

                try
                {
                    VideoCapture1.Screen_Capture_Source.WindowHandle = FindWindow(edScreenCaptureWindowName.Text, null);
                }
                // ReSharper disable once EmptyGeneralCatchClause
                catch
                {
                }

                if (VideoCapture1.Screen_Capture_Source.WindowHandle == IntPtr.Zero)
                {
                    MessageBox.Show("Incorrect window title for screen capture.");
                    return;
                }
            }
            else
            {
                VideoCapture1.Screen_Capture_Source.Mode = VFScreenCaptureMode.Screen;
            }

            VideoCapture1.Screen_Capture_Source.FrameRate = (float)Convert.ToDouble(edScreenFrameRate.Text);
            VideoCapture1.Screen_Capture_Source.FullScreen = rbScreenFullScreen.Checked;
            VideoCapture1.Screen_Capture_Source.Top = Convert.ToInt32(edScreenTop.Text);
            VideoCapture1.Screen_Capture_Source.Bottom = Convert.ToInt32(edScreenBottom.Text);
            VideoCapture1.Screen_Capture_Source.Left = Convert.ToInt32(edScreenLeft.Text);
            VideoCapture1.Screen_Capture_Source.Right = Convert.ToInt32(edScreenRight.Text);
            VideoCapture1.Screen_Capture_Source.GrabMouseCursor = cbScreenCapture_GrabMouseCursor.Checked;
            VideoCapture1.Screen_Capture_Source.DisplayIndex = Convert.ToInt32(cbScreenCaptureDisplayIndex.Text);
            VideoCapture1.Screen_Capture_Source.AllowDesktopDuplicationEngine = cbScreenCapture_DesktopDuplication.Checked;

            if (cbRecordAudio.Checked)
            {
                VideoCapture1.Audio_RecordAudio = true;
                VideoCapture1.Audio_PlayAudio = false;

                VideoCapture1.Audio_CaptureDevice = cbAudioInputDevice.Text;
                VideoCapture1.Audio_CaptureDevice_Format = cbAudioInputFormat.Text;
                VideoCapture1.Audio_CaptureDevice_Line = cbAudioInputLine.Text;
            }
            else
            {
                VideoCapture1.Audio_RecordAudio = false;
                VideoCapture1.Audio_PlayAudio = false;
            }

            // apply capture params
            VideoCapture1.Video_Effects_Enabled = true;
            VideoCapture1.Video_Effects_Clear();
            lbLogos.Items.Clear();
            ConfigureVideoEffects();

            if (rbPreview.Checked)
            {
                VideoCapture1.Mode = VFVideoCaptureMode.ScreenPreview;
            }
            else
            {
                VideoCapture1.Mode = VFVideoCaptureMode.ScreenCapture;
                VideoCapture1.Output_Filename = edOutput.Text;

                switch (cbOutputFormat.SelectedIndex)
                {
                    case 0:
                        {
                            var aviOutput = new VFAVIOutput();
                            SetAVIOutput(ref aviOutput);
                            VideoCapture1.Output_Format = aviOutput;

                            break;
                        }
                    case 1:
                        {
                            var mkvOutput = new VFMKVv1Output();
                            SetMKVOutput(ref mkvOutput);
                            VideoCapture1.Output_Format = mkvOutput;

                            break;
                        }
                    case 2:
                        {
                            var wmvOutput = new VFWMVOutput();
                            SetWMVOutput(ref wmvOutput);
                            VideoCapture1.Output_Format = wmvOutput;

                            break;
                        }
                    case 3:
                        {
                            var dvOutput = new VFDVOutput();
                            SetDVOutput(ref dvOutput);
                            VideoCapture1.Output_Format = dvOutput;

                            break;
                        }
                    case 4:
                        {
                            var webmOutput = new VFWebMOutput();
                            SetWebMOutput(ref webmOutput);
                            VideoCapture1.Output_Format = webmOutput;

                            break;
                        }
                    case 5:
                        {
                            var ffmpegDLLOutput = new VFFFMPEGDLLOutput();
                            SetFFMPEGDLLOutput(ref ffmpegDLLOutput);
                            VideoCapture1.Output_Format = ffmpegDLLOutput;

                            break;
                        }
                    case 6:
                        {
                            var ffmpegOutput = new VFFFMPEGEXEOutput();
                            SetFFMPEGEXEOutput(ref ffmpegOutput);
                            VideoCapture1.Output_Format = ffmpegOutput;

                            break;
                        }
                    case 7:
                        {
                            var mp4Output = new VFMP4v8v10Output();
                            SetMP4Output(ref mp4Output);
                            VideoCapture1.Output_Format = mp4Output;

                            break;
                        }
                    case 8:
                        {
                            var mp4Output = new VFMP4v11Output();
                            SetMP4v11Output(ref mp4Output);
                            VideoCapture1.Output_Format = mp4Output;

                            break;
                        }
                    case 9:
                        {
                            var gifOutput = new VFAnimatedGIFOutput();
                            SetGIFOutput(ref gifOutput);

                            VideoCapture1.Output_Format = gifOutput;

                            break;
                        }
                    case 10:
                        {
                            var encOutput = new VFMP4v8v10Output();
                            SetMP4Output(ref encOutput);
                            encOutput.Encryption = true;
                            encOutput.Encryption_Format = VFEncryptionFormat.MP4_H264_SW_AAC;

                            VideoCapture1.Output_Format = encOutput;

                            break;
                        }
                    case 11:
                        {
                            var tsOutput = new VFMPEGTSOutput();
                            SetMPEGTSOutput(ref tsOutput);
                            VideoCapture1.Output_Format = tsOutput;

                            break;
                        }
                    case 12:
                        {
                            var movOutput = new VFMOVOutput();
                            SetMOVOutput(ref movOutput);
                            VideoCapture1.Output_Format = movOutput;

                            break;
                        }
                }
            }

            VideoCapture1.Start();

            tcMain.SelectedIndex = 3;
            tmRecording.Start();
        }
        
        private void btStop_Click(object sender, EventArgs e)
        {
            tmRecording.Stop();

            VideoCapture1.Stop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text += " (SDK v" + VideoCapture1.SDK_Version + ", " + VideoCapture1.SDK_State + ")";

            tmRecording.Elapsed += (senderx, args) =>
            {
                UpdateRecordingTime();
            };
            
            foreach (var device in VideoCapture1.Audio_CaptureDevicesInfo)
            {
                cbAudioInputDevice.Items.Add(device.Name);
            }

            if (cbAudioInputDevice.Items.Count > 0)
            {
                cbAudioInputDevice.SelectedIndex = 0;
                cbAudioInputDevice_SelectedIndexChanged(null, null);
            }
            
            foreach (var screen in Screen.AllScreens)
            {
                cbScreenCaptureDisplayIndex.Items.Add(screen.DeviceName.Replace(@"\\.\DISPLAY", string.Empty));
            }

            cbScreenCaptureDisplayIndex.SelectedIndex = 0;

            cbOutputFormat.SelectedIndex = 7;

            edOutput.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\VisioForge\\" + "output.mp4";

            if (VideoCapture.Filter_Supported_EVR())
            {
                VideoCapture1.Video_Renderer.Video_Renderer = VFVideoRenderer.EVR;
            }
            else if (VideoCapture.Filter_Supported_VMR9())
            {
                VideoCapture1.Video_Renderer.Video_Renderer = VFVideoRenderer.VMR9;
            }
            else
            {
                VideoCapture1.Video_Renderer.Video_Renderer = VFVideoRenderer.VideoRenderer;
            }
        }

        private void llVideoTutorials_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", @"http://www.visioforge.com/video_tutorials");
            Process.Start(startInfo);
        }

        private void VideoCapture1_OnError(object sender, ErrorsEventArgs e)
        {
            mmLog.Text = mmLog.Text + e.Message + Environment.NewLine;
        }

        private void VideoCapture1_OnLicenseRequired(object sender, LicenseEventArgs e)
        {
            if (cbLicensing.Checked)
            {
                mmLog.Text += "LICENSING:" + Environment.NewLine + e.Message + Environment.NewLine;
            }
        }

        private void btOutputConfigure_Click(object sender, EventArgs e)
        {
            switch (cbOutputFormat.SelectedIndex)
            {
                case 0:
                    {
                        if (aviSettingsDialog == null)
                        {
                            aviSettingsDialog = new AVISettingsDialog(VideoCapture1.Video_Codecs.ToArray(), VideoCapture1.Audio_Codecs.ToArray());
                        }

                        aviSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 1:
                    {
                        if (aviSettingsDialog == null)
                        {
                            aviSettingsDialog = new AVISettingsDialog(VideoCapture1.Video_Codecs.ToArray(), VideoCapture1.Audio_Codecs.ToArray());
                        }

                        aviSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 2:
                    {
                        if (wmvSettingsDialog == null)
                        {
                            wmvSettingsDialog = new WMVSettingsDialog(VideoCapture1.Core);
                        }

                        wmvSettingsDialog.WMA = false;
                        wmvSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 3:
                    {
                        if (dvSettingsDialog == null)
                        {
                            dvSettingsDialog = new DVSettingsDialog();
                        }

                        dvSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 4:
                    {
                        if (webmSettingsDialog == null)
                        {
                            webmSettingsDialog = new WebMSettingsDialog();
                        }

                        webmSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 5:
                    {
                        if (ffmpegDLLSettingsDialog == null)
                        {
                            ffmpegDLLSettingsDialog = new FFMPEGDLLSettingsDialog();
                        }

                        ffmpegDLLSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 6:
                    {
                        if (ffmpegEXESettingsDialog == null)
                        {
                            ffmpegEXESettingsDialog = new FFMPEGEXESettingsDialog();
                        }

                        ffmpegEXESettingsDialog.ShowDialog(this);

                        break;
                    }
                case 7:
                    {
                        if (mp4V10SettingsDialog == null)
                        {
                            mp4V10SettingsDialog = new MP4v10SettingsDialog();
                        }

                        mp4V10SettingsDialog.ShowDialog(this);

                        break;
                    }
                case 8:
                    {
                        if (mp4v11SettingsDialog == null)
                        {
                            mp4v11SettingsDialog = new MFSettingsDialog(MFSettingsDialogMode.MP4v11);
                        }

                        mp4v11SettingsDialog.ShowDialog(this);

                        break;
                    }
                case 9:
                    {
                        if (gifSettingsDialog == null)
                        {
                            gifSettingsDialog = new GIFSettingsDialog();
                        }

                        gifSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 10:
                    {
                        if (mp4V10SettingsDialog == null)
                        {
                            mp4V10SettingsDialog = new MP4v10SettingsDialog();
                        }

                        mp4V10SettingsDialog.ShowDialog(this);

                        break;
                    }
                case 11:
                    {
                        if (mpegTSSettingsDialog == null)
                        {
                            mpegTSSettingsDialog = new MFSettingsDialog(MFSettingsDialogMode.MPEGTS);
                        }

                        mpegTSSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 12:
                    {
                        if (movSettingsDialog == null)
                        {
                            movSettingsDialog = new MFSettingsDialog(MFSettingsDialogMode.MOV);
                        }

                        movSettingsDialog.ShowDialog(this);

                        break;
                    }
            }
        }

        private void cbOutputFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbOutputFormat.SelectedIndex)
            {
                case 0:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi");
                        break;
                    }
                case 1:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mkv");
                        break;
                    }
                case 2:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".wmv");
                        break;
                    }
                case 3:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi");
                        break;
                    }
                case 4:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".webm");
                        break;
                    }
                case 5:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi");
                        break;
                    }
                case 6:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi");
                        break;
                    }
                case 7:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mp4");
                        break;
                    }
                case 8:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mp4");
                        break;
                    }
                case 9:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".gif");
                        break;
                    }
                case 10:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".enc");
                        break;
                    }
                case 11:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".ts");
                        break;
                    }
                case 12:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mov");
                        break;
                    }
            }
        }

        private void UpdateRecordingTime()
        {
            long timestamp = VideoCapture1.Duration_Time();

            if (timestamp < 0)
            {
                return;
            }

            BeginInvoke((Action)(() =>
            {
                TimeSpan ts = TimeSpan.FromMilliseconds(timestamp);
                lbTimestamp.Text = "Recording time: " + ts.ToString(@"hh\:mm\:ss");
            }));
        }

        private void btSaveScreenshot_Click(object sender, EventArgs e)
        {
            if (screenshotSaveDialog.ShowDialog(this) == DialogResult.OK)
            {
                var filename = screenshotSaveDialog.FileName;
                var ext = Path.GetExtension(filename)?.ToLowerInvariant();
                switch (ext)
                {
                    case ".bmp":
                        VideoCapture1.Frame_Save(filename, VFImageFormat.BMP, 0);
                        break;
                    case ".jpg":
                        VideoCapture1.Frame_Save(filename, VFImageFormat.JPEG, 85);
                        break;
                    case ".gif":
                        VideoCapture1.Frame_Save(filename, VFImageFormat.GIF, 0);
                        break;
                    case ".png":
                        VideoCapture1.Frame_Save(filename, VFImageFormat.PNG, 0);
                        break;
                    case ".tiff":
                        VideoCapture1.Frame_Save(filename, VFImageFormat.TIFF, 0);
                        break;
                }
            }
        }

        private void btSelectOutput_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edOutput.Text = saveFileDialog1.FileName;
            }
        }

        private void btPause_Click(object sender, EventArgs e)
        {
            VideoCapture1.Pause();
        }

        private void btResume_Click(object sender, EventArgs e)
        {
            VideoCapture1.Resume();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            btStop_Click(null, null);
        }

        
        private void btTextLogoAdd_Click(object sender, EventArgs e)
        {
            var dlg = new TextLogoSettingsDialog();

            var name = dlg.GenerateNewEffectName(VideoCapture1.Core);
            var effect = new VFVideoEffectTextLogo(true, name);

            VideoCapture1.Video_Effects_Add(effect);
            lbLogos.Items.Add(effect.Name);
            dlg.Fill(effect);

            dlg.ShowDialog(this);
            dlg.Dispose();
        }

        private void btImageLogoAdd_Click(object sender, EventArgs e)
        {
            var dlg = new ImageLogoSettingsDialog();

            var name = dlg.GenerateNewEffectName(VideoCapture1.Core);
            var effect = new VFVideoEffectImageLogo(true, name);

            VideoCapture1.Video_Effects_Add(effect);
            lbLogos.Items.Add(effect.Name);

            dlg.Fill(effect);
            dlg.ShowDialog(this);
            dlg.Dispose();
        }

        private void btLogoRemove_Click(object sender, EventArgs e)
        {
            if (lbLogos.SelectedItem != null)
            {
                VideoCapture1.Video_Effects_Remove((string)lbLogos.SelectedItem);
                lbLogos.Items.Remove(lbLogos.SelectedItem);
            }
        }

        private void btLogoEdit_Click(object sender, EventArgs e)
        {
            if (lbLogos.SelectedItem != null)
            {
                var effect = VideoCapture1.Video_Effects_Get((string)lbLogos.SelectedItem);
                if (effect.GetEffectType() == VFVideoEffectType.TextLogo)
                {
                    var dlg = new TextLogoSettingsDialog();

                    dlg.Attach(effect);

                    dlg.ShowDialog(this);
                    dlg.Dispose();
                }
                else if (effect.GetEffectType() == VFVideoEffectType.ImageLogo)
                {
                    var dlg = new ImageLogoSettingsDialog();

                    dlg.Attach(effect);

                    dlg.ShowDialog(this);
                    dlg.Dispose();
                }
            }
        }

        private void tbLightness_Scroll(object sender, EventArgs e)
        {
            IVFVideoEffectLightness lightness;
            var effect = VideoCapture1.Video_Effects_Get("Lightness");
            if (effect == null)
            {
                lightness = new VFVideoEffectLightness(true, tbLightness.Value);
                VideoCapture1.Video_Effects_Add(lightness);
            }
            else
            {
                lightness = effect as IVFVideoEffectLightness;
                if (lightness != null)
                {
                    lightness.Value = tbLightness.Value;
                }
            }
        }

        private void tbSaturation_Scroll(object sender, EventArgs e)
        {
            IVFVideoEffectSaturation saturation;
            var effect = VideoCapture1.Video_Effects_Get("Saturation");
            if (effect == null)
            {
                saturation = new VFVideoEffectSaturation(tbSaturation.Value);
                VideoCapture1.Video_Effects_Add(saturation);
            }
            else
            {
                saturation = effect as IVFVideoEffectSaturation;
                if (saturation != null)
                {
                    saturation.Value = tbSaturation.Value;
                }
            }
        }

        private void tbContrast_Scroll(object sender, EventArgs e)
        {
            IVFVideoEffectContrast contrast;
            var effect = VideoCapture1.Video_Effects_Get("Contrast");
            if (effect == null)
            {
                contrast = new VFVideoEffectContrast(true, tbContrast.Value);
                VideoCapture1.Video_Effects_Add(contrast);
            }
            else
            {
                contrast = effect as IVFVideoEffectContrast;
                if (contrast != null)
                {
                    contrast.Value = tbContrast.Value;
                }
            }
        }

        private void cbFlipX_CheckedChanged(object sender, EventArgs e)
        {
            IVFVideoEffectFlipDown flip;
            var effect = VideoCapture1.Video_Effects_Get("FlipDown");
            if (effect == null)
            {
                flip = new VFVideoEffectFlipDown(cbFlipX.Checked);
                VideoCapture1.Video_Effects_Add(flip);
            }
            else
            {
                flip = effect as IVFVideoEffectFlipDown;
                if (flip != null)
                {
                    flip.Enabled = cbFlipX.Checked;
                }
            }
        }

        private void cbFlipY_CheckedChanged(object sender, EventArgs e)
        {
            IVFVideoEffectFlipRight flip;
            var effect = VideoCapture1.Video_Effects_Get("FlipRight");
            if (effect == null)
            {
                flip = new VFVideoEffectFlipRight(cbFlipY.Checked);
                VideoCapture1.Video_Effects_Add(flip);
            }
            else
            {
                flip = effect as IVFVideoEffectFlipRight;
                if (flip != null)
                {
                    flip.Enabled = cbFlipY.Checked;
                }
            }
        }

        private void cbGreyscale_CheckedChanged(object sender, EventArgs e)
        {
            IVFVideoEffectGrayscale grayscale;
            var effect = VideoCapture1.Video_Effects_Get("Grayscale");
            if (effect == null)
            {
                grayscale = new VFVideoEffectGrayscale(cbGreyscale.Checked);
                VideoCapture1.Video_Effects_Add(grayscale);
            }
            else
            {
                grayscale = effect as IVFVideoEffectGrayscale;
                if (grayscale != null)
                {
                    grayscale.Enabled = cbGreyscale.Checked;
                }
            }
        }

        private void ConfigureVideoEffects()
        {
            if (tbLightness.Value > 0)
            {
                tbLightness_Scroll(null, null);
            }

            if (tbSaturation.Value < 255)
            {
                tbSaturation_Scroll(null, null);
            }

            if (tbContrast.Value > 0)
            {
                tbContrast_Scroll(null, null);
            }

            if (tbDarkness.Value > 0)
            {
                tbDarkness_Scroll(null, null);
            }

            if (cbGreyscale.Checked)
            {
                cbGreyscale_CheckedChanged(null, null);
            }

            if (cbInvert.Checked)
            {
                cbInvert_CheckedChanged(null, null);
            }

            if (cbFlipX.Checked)
            {
                cbFlipX_CheckedChanged(null, null);
            }

            if (cbFlipY.Checked)
            {
                cbFlipY_CheckedChanged(null, null);
            }
        }

        private void cbInvert_CheckedChanged(object sender, EventArgs e)
        {
            IVFVideoEffectInvert invert;
            var effect = VideoCapture1.Video_Effects_Get("Invert");
            if (effect == null)
            {
                invert = new VFVideoEffectInvert(cbInvert.Checked);
                VideoCapture1.Video_Effects_Add(invert);
            }
            else
            {
                invert = effect as IVFVideoEffectInvert;
                if (invert != null)
                {
                    invert.Enabled = cbInvert.Checked;
                }
            }
        }

        private void tbDarkness_Scroll(object sender, EventArgs e)
        {
            IVFVideoEffectDarkness darkness;
            var effect = VideoCapture1.Video_Effects_Get("Darkness");
            if (effect == null)
            {
                darkness = new VFVideoEffectDarkness(true, tbDarkness.Value);
                VideoCapture1.Video_Effects_Add(darkness);
            }
            else
            {
                darkness = effect as IVFVideoEffectDarkness;
                if (darkness != null)
                {
                    darkness.Value = tbDarkness.Value;
                }
            }
        }
    }
}

// ReSharper restore InconsistentNaming
